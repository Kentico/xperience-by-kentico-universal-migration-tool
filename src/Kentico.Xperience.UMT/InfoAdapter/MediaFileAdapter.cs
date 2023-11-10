using CMS.MediaLibrary;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Services.Model;
using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class MediaFileAdapter : GenericInfoAdapter<MediaFileInfo>
{
    public MediaFileAdapter(ILogger<MediaFileAdapter> logger, UmtModelService modelService, IProviderProxy providerProxy, IProviderProxyFactory providerProxyFactory) : base(logger, modelService, providerProxy, providerProxyFactory)
    {
    }

    protected override MediaFileInfo ObjectFactory(UmtModelInfo umtModelInfo, IUmtModel umtModel)
    {
        MediaFileInfo mediaFileInfo;

        var model = (MediaFileModel)umtModel;
        if (!File.Exists(model.DataSourcePath))
        {
            mediaFileInfo = new MediaFileInfo();
            mediaFileInfo.SaveFileToDisk(false);
            return mediaFileInfo;
        }

        var memoryStream = new MemoryStream();
        var fileStream = new FileStream(model.DataSourcePath!, FileMode.Open, FileAccess.Read);
        fileStream.CopyTo(memoryStream);
        fileStream.Dispose();

        memoryStream.Position = 0;

        var uploadedFile = UploadedFile.FromStream(memoryStream, memoryStream.Length, model.DataSourcePath!);
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
            FileCustomData = mediaModel.FileDescription ?? ""
        };

        current = base.MapProperties(model, current);

        return current;
    }
}
