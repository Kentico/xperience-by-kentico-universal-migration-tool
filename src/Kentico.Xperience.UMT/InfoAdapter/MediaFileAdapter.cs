using CMS.Base;
using CMS.MediaLibrary;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Services.Model;
using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class MediaFileAdapter : GenericInfoAdapter<MediaFileInfo>
{
    private static readonly Lazy<HttpClient> httpClient = new(() => new HttpClient());
    
    public MediaFileAdapter(ILogger<MediaFileAdapter> logger, UmtModelService modelService, IProviderProxy providerProxy, IProviderProxyFactory providerProxyFactory) : base(logger, modelService, providerProxy, providerProxyFactory)
    {
    }

    protected override MediaFileInfo ObjectFactory(UmtModelInfo umtModelInfo, IUmtModel umtModel)
    {
        MediaFileInfo mediaFileInfo;

        var model = (MediaFileModel)umtModel;
        
        if (!File.Exists(model.DataSourcePath) && model.DataSourceUrl == null)
        {
#pragma warning disable S125 // temporarily unsupported, support for media file import without binary information will be unlocked if there is demand 
            // mediaFileInfo = new MediaFileInfo();
            // mediaFileInfo.SaveFileToDisk(false);
            // return mediaFileInfo;
#pragma warning restore S125
            throw new InvalidOperationException($"File '{model.DataSourcePath}' not found");
        }

        string? fileNameWext = Path.GetFileNameWithoutExtension(model.FileName);
        string? fileExt = model.FileExtension ?? Path.GetExtension(model.FileName);
        
        IUploadedFile? uploadedFile = null;
        if (!string.IsNullOrWhiteSpace(model.DataSourcePath))
        {
            var memoryStream = new MemoryStream();
            var fileStream = new FileStream(model.DataSourcePath!, FileMode.Open, FileAccess.Read);
            fileStream.CopyTo(memoryStream);
            fileStream.Dispose();

            memoryStream.Position = 0;

            uploadedFile = UploadedFile.FromStream(memoryStream, memoryStream.Length, $"{fileNameWext}.{fileExt?.Trim('.')}");    
        }

        if (!string.IsNullOrWhiteSpace(model.DataSourceUrl))
        {
            var memoryStream = new MemoryStream();
            var stream = Task.Run(() => httpClient.Value.GetStreamAsync(model.DataSourceUrl)).GetAwaiter().GetResult();
            stream.CopyTo(memoryStream);
            stream.Dispose();

            memoryStream.Position = 0;
            uploadedFile = UploadedFile.FromStream(memoryStream, memoryStream.Length, $"{fileNameWext}.{fileExt?.Trim('.')}");    
        }

        if (uploadedFile == null)
        {
            throw new InvalidOperationException("File download failed");
        }

        var mediaLibrary = MediaLibraryInfoProvider.ProviderObject.Get(model.FileLibraryGuid!.Value);
        MediaLibraryInfoProvider.CreateMediaLibraryFolder(mediaLibrary.LibraryID, Path.GetDirectoryName(model.FilePath));
        
        mediaFileInfo = new MediaFileInfo(uploadedFile, 0);
        mediaFileInfo.SaveFileToDisk(true);
        return mediaFileInfo;
    }

    protected override MediaFileInfo MapProperties(IUmtModel umtModel, MediaFileInfo current)
    {
        var mediaModel = (MediaFileModel)umtModel;
        
        var model = new MediaFileModel()
        {
            FileGUID = mediaModel.FileGUID,
            FileLibraryGuid = mediaModel.FileLibraryGuid,
            FileCreatedByUserGuid = mediaModel.FileCreatedByUserGuid,
            FileModifiedByUserGuid = mediaModel.FileModifiedByUserGuid,
            FileName = mediaModel.FileName,
            FileTitle = mediaModel.FileTitle ?? current.FileTitle,
            FileDescription = mediaModel.FileDescription ?? current.FileDescription,
            FileExtension = mediaModel.FileExtension ?? current.FileExtension,
            FileMimeType = mediaModel.FileMimeType ?? current.FileMimeType,
            FilePath = mediaModel.FilePath ?? current.FilePath,
            FileImageHeight = mediaModel.FileImageHeight ?? current.FileImageHeight,
            FileImageWidth = mediaModel.FileImageWidth ?? current.FileImageWidth,
            FileCreatedWhen = mediaModel.FileCreatedWhen ?? current.FileCreatedWhen,
            FileModifiedWhen = mediaModel.FileModifiedWhen ?? current.FileModifiedWhen,
        };

        current = base.MapProperties(model, current);

        return current;
    }
}
