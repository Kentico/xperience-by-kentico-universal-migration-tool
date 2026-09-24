using CMS.ContentEngine;
using CMS.ContentEngine.Internal;
using CMS.Core;
using CMS.Core.Internal;
using CMS.DataEngine;
using CMS.Websites;
using CMS.Websites.Internal;

using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

/// <summary>
/// Adapter for creating WebPageFolder items.
/// Folders are special items with ContentItemDataClassID = 0 (no content type).
/// </summary>
internal class WebPageFolderAdapter : IInfoAdapter<ContentItemInfo, IUmtModel>
{
    private readonly ILogger<WebPageFolderAdapter> logger;
    private readonly IProviderProxyFactory providerProxyFactory;
    private readonly IDateTimeNowService dateTimeNowService;
    private readonly AdapterFactory adapterFactory;

    public IProviderProxy ProviderProxy { get; }

    internal WebPageFolderAdapter(
        IProviderProxy providerProxy,
        IProviderProxyFactory providerProxyFactory,
        ILogger<WebPageFolderAdapter> logger,
        AdapterFactory adapterFactory)
    {
        this.logger = logger;
        this.providerProxyFactory = providerProxyFactory;
        this.dateTimeNowService = Service.Resolve<IDateTimeNowService>();
        this.adapterFactory = adapterFactory;
        ProviderProxy = providerProxy;
    }

    public ContentItemInfo Adapt(IUmtModel input)
    {
        if (input is not WebPageFolderModel model)
        {
            throw new InvalidOperationException($"Invalid model type. Expected {nameof(WebPageFolderModel)}.");
        }

        ArgumentNullException.ThrowIfNull(model.WebPageFolderGUID);
        ArgumentException.ThrowIfNullOrWhiteSpace(model.WebPageFolderName);
        ArgumentException.ThrowIfNullOrWhiteSpace(model.WebPageFolderDisplayName);
        ArgumentException.ThrowIfNullOrWhiteSpace(model.WebPageFolderTreePath);
        ArgumentException.ThrowIfNullOrWhiteSpace(model.WebsiteChannelName);
        ArgumentException.ThrowIfNullOrWhiteSpace(model.LanguageName);

        using var scope = new CMSTransactionScope();

        var now = dateTimeNowService.GetDateTimeNow();

        // Resolve channel using proxy
        var channelProxy = providerProxyFactory.CreateProviderProxy<ChannelInfo>(new ProviderProxyContext());
        var channel = channelProxy.GetBaseInfoByCodeName(model.WebsiteChannelName, null!) as ChannelInfo;
        ArgumentNullException.ThrowIfNull(channel, $"Channel '{model.WebsiteChannelName}' not found");

        // Resolve website channel using proxy
        var websiteChannelProxy = providerProxyFactory.CreateProviderProxy<WebsiteChannelInfo>(new ProviderProxyContext());
        var websiteChannel = websiteChannelProxy.GetBaseInfoBy(channel.ChannelGUID, nameof(WebsiteChannelInfo.WebsiteChannelChannelID), null!) as WebsiteChannelInfo;
        if (websiteChannel == null)
        {
            // Fallback: query by channel ID since the reference is by ID not GUID
            var websiteChannels = websiteChannelProxy.GetInfoByKeys(null!, [(nameof(WebsiteChannelInfo.WebsiteChannelChannelID), channel.ChannelID)]);
            websiteChannel = websiteChannels.FirstOrDefault() as WebsiteChannelInfo;
        }
        ArgumentNullException.ThrowIfNull(websiteChannel, $"WebsiteChannel for channel '{model.WebsiteChannelName}' not found");

        // Resolve language using proxy
        var languageProxy = providerProxyFactory.CreateProviderProxy<ContentLanguageInfo>(new ProviderProxyContext());
        var language = languageProxy.GetBaseInfoByCodeName(model.LanguageName, null!) as ContentLanguageInfo;
        ArgumentNullException.ThrowIfNull(language, $"Language '{model.LanguageName}' not found");

        // Create ContentItem model (folders have ContentItemContentTypeID = 0, so we don't set ContentItemDataClassGuid)
        var contentItemModel = new ContentItemModel
        {
            ContentItemGUID = model.WebPageFolderGUID,
            ContentItemName = model.WebPageFolderName,
            ContentItemIsReusable = false,
            ContentItemIsSecured = false,
            ContentItemChannelGuid = channel.ChannelGUID
        };

        var contentItemAdapter = adapterFactory.CreateAdapter(contentItemModel, new ProviderProxyContext());
        ArgumentNullException.ThrowIfNull(contentItemAdapter);

        var contentItemInfo = (ContentItemInfo)contentItemAdapter.Adapt(contentItemModel);
        // Folders have ContentItemContentTypeID = 0 (no content type)
        contentItemInfo.ContentItemContentTypeID = 0;
        contentItemInfo = (ContentItemInfo)contentItemAdapter.ProviderProxy.Save(contentItemInfo, contentItemModel);

        logger.LogTrace("ContentItem created/updated with GUID {Guid} for folder {Name}",
            contentItemInfo.ContentItemGUID, model.WebPageFolderName);

        // Resolve parent WebPageItem if specified using proxy
        Guid? parentWebPageItemGuid = null;
        if (model.WebPageFolderParentGUID.HasValue)
        {
            var webPageItemProxy = providerProxyFactory.CreateProviderProxy<WebPageItemInfo>(new ProviderProxyContext());
            var parentWebPageItem = webPageItemProxy.GetBaseInfoByGuid(model.WebPageFolderParentGUID.Value, null!) as WebPageItemInfo;

            if (parentWebPageItem != null)
            {
                parentWebPageItemGuid = parentWebPageItem.WebPageItemGUID;
            }
            else
            {
                logger.LogWarning("Parent WebPageItem with GUID {ParentGuid} not found for folder {Name}",
                    model.WebPageFolderParentGUID, model.WebPageFolderName);
            }
        }

        // Check for existing WebPageItem using proxy
        var webPageItemProxyForExisting = providerProxyFactory.CreateProviderProxy<WebPageItemInfo>(new ProviderProxyContext());
        var existingWebPageItems = webPageItemProxyForExisting.GetInfoByKeys(null!, [
            (nameof(WebPageItemInfo.WebPageItemContentItemID), contentItemInfo.ContentItemID),
            (nameof(WebPageItemInfo.WebPageItemWebsiteChannelID), websiteChannel.WebsiteChannelID)
        ]);
        var existingWebPageItem = existingWebPageItems.FirstOrDefault() as WebPageItemInfo;

        // Create WebPageItem model
        var webPageItemModel = new WebPageItemModel
        {
            WebPageItemGUID = existingWebPageItem?.WebPageItemGUID ?? model.WebPageFolderGUID,
            WebPageItemName = model.WebPageFolderName,
            WebPageItemTreePath = model.WebPageFolderTreePath,
            WebPageItemWebsiteChannelGuid = websiteChannel.WebsiteChannelGUID,
            WebPageItemContentItemGuid = contentItemInfo.ContentItemGUID,
            WebPageItemParentGuid = parentWebPageItemGuid,
            WebPageItemOrder = model.WebPageFolderOrder ?? 0
        };

        var webPageItemAdapter = adapterFactory.CreateAdapter(webPageItemModel, new ProviderProxyContext());
        ArgumentNullException.ThrowIfNull(webPageItemAdapter);

        var webPageItemInfo = (WebPageItemInfo)webPageItemAdapter.Adapt(webPageItemModel);
        webPageItemInfo = (WebPageItemInfo)webPageItemAdapter.ProviderProxy.Save(webPageItemInfo, webPageItemModel);
        // Note: ACL mapping is automatically handled by ProviderProxy<WebPageItemInfo>.Save()

        logger.LogTrace("WebPageItem created/updated with GUID {Guid} for folder {Name}",
            webPageItemInfo.WebPageItemGUID, model.WebPageFolderName);

        // Check for existing LanguageMetadata using proxy
        var languageMetadataProxy = providerProxyFactory.CreateProviderProxy<ContentItemLanguageMetadataInfo>(new ProviderProxyContext());
        var existingLanguageMetadataList = languageMetadataProxy.GetInfoByKeys(null!, [
            (nameof(ContentItemLanguageMetadataInfo.ContentItemLanguageMetadataContentItemID), contentItemInfo.ContentItemID),
            (nameof(ContentItemLanguageMetadataInfo.ContentItemLanguageMetadataContentLanguageID), language.ContentLanguageID)
        ]);
        var existingLanguageMetadata = existingLanguageMetadataList.FirstOrDefault() as ContentItemLanguageMetadataInfo;

        // Create ContentItemLanguageMetadata model
        var languageMetadataModel = new ContentItemLanguageMetadataModel
        {
            ContentItemLanguageMetadataGUID = existingLanguageMetadata?.ContentItemLanguageMetadataGUID ?? Guid.NewGuid(),
            ContentItemLanguageMetadataContentItemGuid = contentItemInfo.ContentItemGUID,
            ContentItemLanguageMetadataContentLanguageGuid = language.ContentLanguageGUID,
            ContentItemLanguageMetadataDisplayName = model.WebPageFolderDisplayName,
            ContentItemLanguageMetadataLatestVersionStatus = VersionStatus.Published,
            ContentItemLanguageMetadataCreatedWhen = existingLanguageMetadata?.ContentItemLanguageMetadataCreatedWhen ?? now,
            ContentItemLanguageMetadataModifiedWhen = now,
            ContentItemLanguageMetadataHasImageAsset = false
        };

        var languageMetadataAdapter = adapterFactory.CreateAdapter(languageMetadataModel, new ProviderProxyContext());
        ArgumentNullException.ThrowIfNull(languageMetadataAdapter);

        var languageMetadataInfo = (ContentItemLanguageMetadataInfo)languageMetadataAdapter.Adapt(languageMetadataModel);
        languageMetadataAdapter.ProviderProxy.Save(languageMetadataInfo, languageMetadataModel);

        logger.LogTrace("ContentItemLanguageMetadata created/updated for folder {Name} in language {Language}",
            model.WebPageFolderName, model.LanguageName);

        scope.Commit();

        return contentItemInfo;
    }

    BaseInfo IInfoAdapter<IUmtModel>.Adapt(IUmtModel input) => Adapt(input);

    public Guid? GetUniqueIdOrNull(IUmtModel input) =>
        input is WebPageFolderModel model ? model.WebPageFolderGUID : null;

    public void Postprocess(IUmtModel input, BaseInfo baseInfo)
    {
        // No post-processing needed for folders
    }
}
