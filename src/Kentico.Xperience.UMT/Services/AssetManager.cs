using CMS.ContentEngine;
using CMS.ContentEngine.Internal;
using CMS.Core;
using CMS.Core.Internal;

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
    private readonly HttpClient httpClient = new();

    public async Task<ContentItemAssetMetadata> SetAsset(string className, AssetSource assetSource, string columnName, Guid contentItemGuid, CancellationToken cancellationToken)
    {
        logger.LogTrace("SetAsset {Args}", new { className, assetSource, columnName, contentItemGuid });
        if (contentItemAssetFieldsProvider
                .GetAssetFields(className)
                .FirstOrDefault(info => info.Name.Equals(columnName, StringComparison.InvariantCultureIgnoreCase)) is { } assetField)
        {
            // assumption & copnsideration: setting new assets doesn't mean removal of old ones
            
            ContentItemAssetMetadataWithSource source;
            switch (assetSource)
            {
                case AssetByteSource byteSource:
                {
                    ArgumentNullException.ThrowIfNull(byteSource.Data);
                    ArgumentNullException.ThrowIfNull(byteSource.Identifier);

                    var assetMetadata = new ContentItemAssetMetadata
                    {
                        Extension = byteSource.Extension,
                        Identifier = byteSource.Identifier.Value,
                        LastModified = byteSource.LastModified ?? dateTimeNowService.GetDateTimeNow(),
                        Name = byteSource.Name,
                        Size = byteSource.Size ?? byteSource.Data.LongLength
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
                    var assetMetadata = new ContentItemAssetMetadata
                    {
                        Extension = fileSource.Extension ?? file.Extension,
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

                    var assetMetadata = new ContentItemAssetMetadata
                    {
                        Extension = urlSource.Extension,
                        Identifier = urlSource.Identifier.Value,
                        LastModified = urlSource.LastModified ?? dateTimeNowService.GetDateTimeNow(),
                        Name = urlSource.Name,
                        Size = urlSource.Size ?? 0L
                    };
                    source = new ContentItemAssetMetadataWithSource(
                        new ContentItemAssetStreamSource(async token =>
                        {
                            var response = await httpClient.GetAsync(urlSource.Url, token);

                            await response.Content.LoadIntoBufferAsync();
                            long? contentLength = response.Content.Headers.ContentLength;
                            if (assetMetadata.Size == 0)
                            {
                                assetMetadata.Size = contentLength ?? 0;
                            }

                            return await response.Content.ReadAsStreamAsync(token);
                        }),
                        assetMetadata
                    );
                    break;
                }

                default:
                    throw new ArgumentOutOfRangeException(nameof(assetSource));
            }

            await contentItemAssetFileService.Save(source, contentItemGuid, assetField.Guid, false, cancellationToken);

            return source;
        }
        else
        {
            logger.LogError("Field is not asset {ClassName}.{ColumnName}", className, columnName);
        }

        throw new InvalidOperationException("Unable to create asset");
    }
}
