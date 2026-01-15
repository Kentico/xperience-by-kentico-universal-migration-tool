using CMS.Base;
using CMS.ContentEngine;
using CMS.ContentEngine.Internal;
using CMS.Core;
using CMS.Core.Internal;
using CMS.DataEngine;
using CMS.Membership;
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

    public IProviderProxy ProviderProxy { get; }

    internal WebPageFolderAdapter(
        ILogger<WebPageFolderAdapter> logger,
        IProviderProxyFactory providerProxyFactory,
        IProviderProxyContext providerProxyContext)
    {
        this.logger = logger;
        this.providerProxyFactory = providerProxyFactory;
        this.dateTimeNowService = Service.Resolve<IDateTimeNowService>();
        ProviderProxy = providerProxyFactory.CreateProviderProxy<ContentItemInfo>(providerProxyContext);
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

        // Resolve website channel
        var channelProxy = providerProxyFactory.CreateProviderProxy<ChannelInfo>(new ProviderProxyContext());
        var channel = channelProxy.GetBaseInfoByCodeName(model.WebsiteChannelName, null!) as ChannelInfo;
        ArgumentNullException.ThrowIfNull(channel, $"Channel '{model.WebsiteChannelName}' not found");

        var websiteChannel = Provider<WebsiteChannelInfo>.Instance.Get()
            .WhereEquals(nameof(WebsiteChannelInfo.WebsiteChannelChannelID), channel.ChannelID)
            .FirstOrDefault();
        ArgumentNullException.ThrowIfNull(websiteChannel, $"WebsiteChannel for channel '{model.WebsiteChannelName}' not found");

        // Resolve language
        var languageProxy = providerProxyFactory.CreateProviderProxy<ContentLanguageInfo>(new ProviderProxyContext());
        var language = languageProxy.GetBaseInfoByCodeName(model.LanguageName, null!) as ContentLanguageInfo;
        ArgumentNullException.ThrowIfNull(language, $"Language '{model.LanguageName}' not found");

        // Check for existing ContentItem
        var existingContentItem = Provider<ContentItemInfo>.Instance.Get()
            .WhereEquals(nameof(ContentItemInfo.ContentItemGUID), model.WebPageFolderGUID)
            .FirstOrDefault();

        // Create or update ContentItem (folders have ContentItemContentTypeID = 0)
        var contentItem = existingContentItem ?? new ContentItemInfo();
        contentItem.ContentItemGUID = model.WebPageFolderGUID.Value;
        contentItem.ContentItemName = model.WebPageFolderName;
        contentItem.ContentItemContentTypeID = 0;  // Folders have no content type
        contentItem.ContentItemChannelID = channel.ChannelID;
        contentItem.ContentItemIsReusable = false;
        contentItem.ContentItemIsSecured = false;

        var context = new CMSActionContext(UserInfoProvider.AdministratorUser)
        {
            User = UserInfoProvider.AdministratorUser,
            UseGlobalAdminContext = true
        };

        using (context)
        {
            Provider<ContentItemInfo>.Instance.Set(contentItem);
        }

        logger.LogTrace("ContentItem created/updated with GUID {Guid} for folder {Name}",
            contentItem.ContentItemGUID, model.WebPageFolderName);

        // Resolve parent WebPageItem if specified
        int parentWebPageItemId = 0;
        if (model.WebPageFolderParentGUID.HasValue)
        {
            var parentWebPageItem = Provider<WebPageItemInfo>.Instance.Get()
                .WhereEquals(nameof(WebPageItemInfo.WebPageItemGUID), model.WebPageFolderParentGUID.Value)
                .FirstOrDefault();

            if (parentWebPageItem != null)
            {
                parentWebPageItemId = parentWebPageItem.WebPageItemID;
            }
            else
            {
                logger.LogWarning("Parent WebPageItem with GUID {ParentGuid} not found for folder {Name}",
                    model.WebPageFolderParentGUID, model.WebPageFolderName);
            }
        }

        // Check for existing WebPageItem
        var existingWebPageItem = Provider<WebPageItemInfo>.Instance.Get()
            .WhereEquals(nameof(WebPageItemInfo.WebPageItemContentItemID), contentItem.ContentItemID)
            .WhereEquals(nameof(WebPageItemInfo.WebPageItemWebsiteChannelID), websiteChannel.WebsiteChannelID)
            .FirstOrDefault();

        // Create or update WebPageItem
        var webPageItem = existingWebPageItem ?? new WebPageItemInfo();
        webPageItem.WebPageItemGUID = model.WebPageFolderGUID.Value;  // Use same GUID for consistency
        webPageItem.WebPageItemName = model.WebPageFolderName;
        webPageItem.WebPageItemTreePath = model.WebPageFolderTreePath;
        webPageItem.WebPageItemContentItemID = contentItem.ContentItemID;
        webPageItem.WebPageItemWebsiteChannelID = websiteChannel.WebsiteChannelID;
        webPageItem.WebPageItemParentID = parentWebPageItemId;
        webPageItem.WebPageItemOrder = model.WebPageFolderOrder ?? 0;

        using (context)
        {
            Provider<WebPageItemInfo>.Instance.Set(webPageItem);
        }

        // Handle ACL mapping (same as ProviderProxy does for WebPageItemInfo)
        var webPageAclMappingManager = Service.Resolve<IWebPageAclMappingManager>();
        webPageAclMappingManager.CreateMapping(
            webPageItem.WebPageItemID,
            webPageItem.WebPageItemParentID,
            webPageItem.WebPageItemWebsiteChannelID,
            CancellationToken.None).GetAwaiter().GetResult();

        var webPageAclManagerFactory = Service.Resolve<IWebPageAclManagerFactory>();
        webPageAclManagerFactory
            .Create(webPageItem.WebPageItemWebsiteChannelID)
            .RestoreInheritance(webPageItem.WebPageItemID)
            .GetAwaiter().GetResult();

        logger.LogTrace("WebPageItem created/updated with GUID {Guid} for folder {Name}",
            webPageItem.WebPageItemGUID, model.WebPageFolderName);

        // Check for existing LanguageMetadata
        var existingLanguageMetadata = Provider<ContentItemLanguageMetadataInfo>.Instance.Get()
            .WhereEquals(nameof(ContentItemLanguageMetadataInfo.ContentItemLanguageMetadataContentItemID), contentItem.ContentItemID)
            .WhereEquals(nameof(ContentItemLanguageMetadataInfo.ContentItemLanguageMetadataContentLanguageID), language.ContentLanguageID)
            .FirstOrDefault();

        // Create or update ContentItemLanguageMetadata for the display name
        var languageMetadata = existingLanguageMetadata ?? new ContentItemLanguageMetadataInfo();
        if (existingLanguageMetadata == null)
        {
            languageMetadata.ContentItemLanguageMetadataGUID = Guid.NewGuid();
        }
        languageMetadata.ContentItemLanguageMetadataContentItemID = contentItem.ContentItemID;
        languageMetadata.ContentItemLanguageMetadataContentLanguageID = language.ContentLanguageID;
        languageMetadata.ContentItemLanguageMetadataDisplayName = model.WebPageFolderDisplayName;
        languageMetadata.ContentItemLanguageMetadataLatestVersionStatus = VersionStatus.Published;
        languageMetadata.ContentItemLanguageMetadataCreatedWhen = existingLanguageMetadata?.ContentItemLanguageMetadataCreatedWhen ?? now;
        languageMetadata.ContentItemLanguageMetadataModifiedWhen = now;
        languageMetadata.ContentItemLanguageMetadataHasImageAsset = false;

        using (context)
        {
            Provider<ContentItemLanguageMetadataInfo>.Instance.Set(languageMetadata);
        }

        logger.LogTrace("ContentItemLanguageMetadata created/updated for folder {Name} in language {Language}",
            model.WebPageFolderName, model.LanguageName);

        scope.Commit();

        return contentItem;
    }

    BaseInfo IInfoAdapter<IUmtModel>.Adapt(IUmtModel input) => Adapt(input);

    public Guid? GetUniqueIdOrNull(IUmtModel input) =>
        input is WebPageFolderModel model ? model.WebPageFolderGUID : null;

    public void Postprocess(IUmtModel input, BaseInfo baseInfo)
    {
        // No post-processing needed for folders
    }
}
