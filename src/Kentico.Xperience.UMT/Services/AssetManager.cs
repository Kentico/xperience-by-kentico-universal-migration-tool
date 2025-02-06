using CMS.Base;
using CMS.ContentEngine;
using CMS.ContentEngine.Internal;
using CMS.Core;
using CMS.Core.Internal;
using CMS.DataEngine;
using CMS.FormEngine;
using CMS.Helpers;

using Kentico.Xperience.UMT.Model;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.Services;

internal class AssetManager(
    ILogger<AssetManager> logger
)
{
    private readonly IDateTimeNowService dateTimeNowService = Service.Resolve<IDateTimeNowService>();
    private readonly IContentItemAssetFieldsProvider contentItemAssetFieldsProvider = Service.Resolve<IContentItemAssetFieldsProvider>();
    private readonly IContentItemAssetFileService contentItemAssetFileService = Service.Resolve<IContentItemAssetFileService>();
    private readonly IImageInfoRetrieverService imageInfoRetrieverService = Service.Resolve<IImageInfoRetrieverService>();
    private readonly IImageOptimizationPipeline imageOptimizationPipeline = Service.Resolve<IImageOptimizationPipeline>();
    private readonly IContentItemAssetPathProvider contentItemAssetPathProvider = Service.Resolve<IContentItemAssetPathProvider>();

    private readonly HttpClient httpClient = new();

    public async Task<object?> SetAsset(string className, AssetSource assetSource, string columnName, Guid contentItemGuid, CancellationToken cancellationToken)
    {
        logger.LogTrace("SetAsset {Args}", new { className, assetSource, columnName, contentItemGuid });
        if (contentItemAssetFieldsProvider
                .GetAssetFields(className)
                .FirstOrDefault(info => info.Name.Equals(columnName, StringComparison.InvariantCultureIgnoreCase)) is { } assetField)
        {
            // assumption & copnsideration: setting new assets doesn't mean removal of old ones
            ContentItemAssetMetadataWithSource source;
            ContentItemAssetMetadata assetMetadata;

            (int? imageWidth, int? imageHeight) dimensions = (assetSource.ImageWidth, assetSource.ImageHeight);

            switch (assetSource)
            {
                case AssetDataSource byteSource:
                {
                    ArgumentNullException.ThrowIfNull(byteSource.Data);
                    ArgumentNullException.ThrowIfNull(byteSource.Identifier);

                    if ((dimensions.imageWidth is null || dimensions.imageHeight is null) && !imageInfoRetrieverService.TryGetImageDimensions(byteSource.Data, out dimensions))
                    {
                        logger.LogError("Unable to get image dimensions");
                        throw new InvalidOperationException("Unable to create asset");
                    }

                    assetMetadata = new ContentItemAssetMetadata
                    {
                        Extension = assetSource.InferExtension(),
                        Identifier = byteSource.Identifier.Value,
                        LastModified = byteSource.LastModified ?? dateTimeNowService.GetDateTimeNow(),
                        Name = byteSource.Name,
                        Size = byteSource.Size ?? byteSource.Data.LongLength,
                        Width = dimensions.imageWidth,
                        Height = dimensions.imageHeight,
                    };
                    source = new ContentItemAssetMetadataWithSource(
                        new ContentItemAssetStreamSource(_ => Task.FromResult<Stream>(new MemoryStream(byteSource.Data))),
                        assetMetadata
                    );
                    break;
                }

                case AssetFileSource fileSource:
                {
                    ArgumentException.ThrowIfNullOrWhiteSpace(fileSource.FilePath);
                    ArgumentNullException.ThrowIfNull(fileSource.Identifier);

                    var file = CMS.IO.FileInfo.New(fileSource.FilePath);
                    if ((dimensions.imageWidth is null || dimensions.imageHeight is null) && !imageInfoRetrieverService.TryGetImageDimensions(fileSource.FilePath, out dimensions))
                    {
                        logger.LogError("Unable to get image dimensions");
                        throw new InvalidOperationException("Unable to create asset");
                    }

                    assetMetadata = new ContentItemAssetMetadata
                    {
                        Extension = assetSource.InferExtension(),
                        Identifier = fileSource.Identifier.Value,
                        LastModified = fileSource.LastModified ?? dateTimeNowService.GetDateTimeNow(),
                        Name = fileSource.Name ?? file.Name,
                        Size = fileSource.Size ?? file.Length
                    };
                    source = new ContentItemAssetMetadataWithSource(
                        new ContentItemAssetFileSource(file.FullName, false),
                        assetMetadata
                    );
                    break;
                }
                case AssetUrlSource urlSource:
                {
                    ArgumentException.ThrowIfNullOrWhiteSpace(urlSource.Url);
                    ArgumentNullException.ThrowIfNull(urlSource.Identifier);

                    // Download the file
                    var response = await httpClient.GetAsync(urlSource.Url);

                    await response.Content.LoadIntoBufferAsync();
                    byte[] data = await response.Content.ReadAsByteArrayAsync();

                    if ((dimensions.imageWidth is null || dimensions.imageHeight is null) && !imageInfoRetrieverService.TryGetImageDimensions(data, out dimensions))
                    {
                        logger.LogError("Unable to get image dimensions");
                        throw new InvalidOperationException("Unable to create asset");
                    }

                    assetMetadata = new ContentItemAssetMetadata
                    {
                        Extension = assetSource.InferExtension(),
                        Identifier = urlSource.Identifier.Value,
                        LastModified = urlSource.LastModified ?? dateTimeNowService.GetDateTimeNow(),
                        Name = urlSource.Name,
                        Size = data.Length,
                        Width = dimensions.imageWidth,
                        Height = dimensions.imageHeight,
                    };
                    source = new ContentItemAssetMetadataWithSource(
                        new ContentItemAssetStreamSource(_ => Task.FromResult<Stream>(new MemoryStream(data))),
                        assetMetadata
                    );
                    break;
                }

                default:
                    throw new ArgumentOutOfRangeException(nameof(assetSource));
            }

            await contentItemAssetFileService.Delete(source, contentItemGuid, assetField.Guid, false, cancellationToken);
            await contentItemAssetFileService.Save(source, contentItemGuid, assetField.Guid, false, cancellationToken);

            var optimizedMetadata = await Optimize(assetField, source, assetMetadata, contentItemGuid);
            if (optimizedMetadata is not null)
            {
                return optimizedMetadata;
            }
            else
            {
                return source;
            }
        }
        else
        {
            logger.LogError("Field is not asset {ClassName}.{ColumnName}", className, columnName);
        }

        throw new InvalidOperationException("Unable to create asset");
    }

    private async Task<object?> Optimize(FormFieldInfo assetField, ContentItemAssetMetadataWithSource source, ContentItemAssetMetadata assetMetadata, Guid contentItemGuid)
    {
        if (ImageHelper.IsImage(source.Extension))
        {
            string? assetFilePath = GetAssetFilePath(assetMetadata, contentItemGuid, assetField) ?? throw new InvalidOperationException("Unable to get asset file path");

            bool metadataChanged = false;
            if (!source.Width.HasValue || source.Width == 0 || !source.Height.HasValue || source.Height == 0)
            {
                metadataChanged = TrySetImageDimensions(source, assetFilePath);
            }

            if (source.Original == null)
            {
                var contentItemAssetMetadataWithSource = await OptimizeContentItemAsset(source, assetField, assetFilePath, contentItemGuid, CancellationToken.None);
                if (contentItemAssetMetadataWithSource != null)
                {
                    source = contentItemAssetMetadataWithSource;
                    metadataChanged = true;
                }
            }

            if (metadataChanged)
            {
                var dataType = DataTypeManager.GetDataType(typeof(ContentItemAssetMetadata));
                return dataType.ConvertToDbType(source, SystemContext.SystemCulture, dataType.ObjectDefaultValue);
            }
        }
        return null;
    }

    /// <summary>
    /// Adopted from ContentItemAssetBinaryManager
    /// </summary>
    private string? GetAssetFilePath(ContentItemAssetMetadata assetMetadata, Guid contentItemGuid, FormFieldInfo assetField)
    {
        string fileLocation = contentItemAssetPathProvider.GetFileLocation(assetMetadata, contentItemGuid, assetField.Guid);
        if (File.Exists(fileLocation))
        {
            return fileLocation;
        }

        return null;
    }

    /// <summary>
    /// Adopted from ContentItemAssetBinaryManager
    /// </summary>
    private static bool ShouldOptimizeImage(ContentItemAssetMetadataWithSource assetMetadataWithSource, AutomaticImageFormatConversionParameters formatConversionParameters)
    {
        if (formatConversionParameters != null && formatConversionParameters.IsFormatConversionEnabled && ImageHelper.IsOptimizableImage(assetMetadataWithSource.Extension) && formatConversionParameters.InputImageExtensions != null)
        {
            return formatConversionParameters.InputImageExtensions.Contains(assetMetadataWithSource.Extension.TrimStart('.'), StringComparer.OrdinalIgnoreCase);
        }

        return false;
    }

    /// <summary>
    /// Adopted from ContentItemAssetBinaryManager
    /// </summary>
    private async Task<ContentItemAssetMetadataWithSource?> OptimizeContentItemAsset(ContentItemAssetMetadataWithSource assetMetadataWithSource, FormFieldInfo assetField, string imagePath, Guid contentItemGuid, CancellationToken cancellationToken)
    {
        var automaticImageFormatConversionParameters = AutomaticImageFormatConversionParameters.FromField(assetField);
        if (!ShouldOptimizeImage(assetMetadataWithSource, automaticImageFormatConversionParameters))
        {
            return null;
        }

        var parameters = new ImageOptimizationParameters
        {
            OutputExtension = automaticImageFormatConversionParameters.OutputImageExtension,
            Quality = ValidationHelper.GetInteger(automaticImageFormatConversionParameters.OutputQuality, 100)
        };
        var optimizedMetadata = await imageOptimizationPipeline.OptimizeContentItemAsset(assetMetadataWithSource, assetMetadataWithSource.Source, parameters, imagePath);
        if (optimizedMetadata != null)
        {
            await SaveOptimizedAsset(optimizedMetadata, contentItemGuid, assetField, cancellationToken);
            return optimizedMetadata;
        }

        return null;
    }

    /// <summary>
    /// Adopted from ContentItemAssetBinaryManager
    /// </summary>
    private bool TrySetImageDimensions(ContentItemAssetMetadata assetMetadata, string imagePath)
    {
        if (!imageInfoRetrieverService.TryGetImageDimensions(imagePath, out (int?, int?) dimensions))
        {
            return false;
        }

        (assetMetadata.Width, assetMetadata.Height) = dimensions;
        if (assetMetadata.Original != null)
        {
            assetMetadata.Original.Height = dimensions.Item2;
            assetMetadata.Original.Width = dimensions.Item1;
        }

        return true;
    }

    /// <summary>
    /// Adopted from ContentItemAssetBinaryManager
    /// </summary>
    private async Task SaveOptimizedAsset(ContentItemAssetMetadataWithSource optimizedMetadata, Guid contentItemGuid, FormFieldInfo assetField, CancellationToken cancellationToken)
    {
        var metadata = new ContentItemAssetMetadata
        {
            Name = optimizedMetadata.Name,
            Identifier = optimizedMetadata.Identifier,
            Extension = optimizedMetadata.Extension,
            Size = optimizedMetadata.Size,
            LastModified = optimizedMetadata.LastModified,
            Height = optimizedMetadata.Height,
            Width = optimizedMetadata.Width
        };
        var assetMetadataWithSource = new ContentItemAssetMetadataWithSource(optimizedMetadata.Source, metadata);
        await contentItemAssetFileService.Save(assetMetadataWithSource, contentItemGuid, assetField.Guid, logWebFarmTask: true, cancellationToken);
    }
}
