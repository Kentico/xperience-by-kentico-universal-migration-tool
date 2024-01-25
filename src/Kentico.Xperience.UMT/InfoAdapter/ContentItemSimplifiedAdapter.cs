using Azure.Identity;
using CMS.ContentEngine;
using CMS.ContentEngine.Internal;
using CMS.Core;
using CMS.Core.Internal;
using CMS.DataEngine;
using CMS.DataEngine.Internal;
using CMS.Membership;
using CMS.Websites;
using CMS.Websites.Internal;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;
using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class ContentItemSimplifiedAdapter : IInfoAdapter<ContentItemInfo, IUmtModel>
{
    private readonly ILogger<ContentItemSimplifiedAdapter> logger;
    private readonly IProviderProxyFactory providerProxyFactory;
    private readonly IDateTimeNowService dateTimeNowService;
    private readonly AdapterFactory adapterFactory;
    public IProviderProxy ProviderProxy { get; }

    internal ContentItemSimplifiedAdapter(
        ILogger<ContentItemSimplifiedAdapter> logger,
        IProviderProxy providerProxy,
        IProviderProxyFactory providerProxyFactory,
        IDateTimeNowService dateTimeNowService,
        AdapterFactory adapterFactory
    )
    {
        this.logger = logger;
        this.providerProxyFactory = providerProxyFactory;
        this.dateTimeNowService = dateTimeNowService;
        this.adapterFactory = adapterFactory;
        ProviderProxy = providerProxy;
    }

    BaseInfo IInfoAdapter<IUmtModel>.Adapt(IUmtModel input) => Adapt(input);

    Guid? IInfoAdapter<ContentItemInfo, IUmtModel>.GetUniqueIdOrNull(IUmtModel input) => throw new NotImplementedException();

    public ContentItemInfo Adapt(IUmtModel input)
    {
        if (input is not ContentItemSimplifiedModel cim)
        {
            throw new InvalidOperationException($"Invalid model supplied");
        }

        using var scope = new CMSTransactionScope();

        ArgumentNullException.ThrowIfNull(cim.ContentItemGUID);
        var existingContentItem = ProviderProxy.GetBaseInfoByGuid(cim.ContentItemGUID.Value, cim) as ContentItemInfo;

        var createdWhen = dateTimeNowService.GetDateTimeNow();

        var contentTypeProxy = providerProxyFactory.CreateProviderProxy<DataClassInfo>(new ProviderProxyContext());
        ArgumentException.ThrowIfNullOrWhiteSpace(cim.ContentTypeName);
        var dataClassInfo = contentTypeProxy.GetBaseInfoByCodeName(cim.ContentTypeName, null!) as DataClassInfo;
        ArgumentNullException.ThrowIfNull(dataClassInfo);
        
        var channelProxy = providerProxyFactory.CreateProviderProxy<ChannelInfo>(new ProviderProxyContext());
        ChannelInfo? channel = null;
        if (dataClassInfo.ClassContentTypeType == ClassContentTypeType.WEBSITE)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(cim.ChannelName);
            channel = channelProxy.GetBaseInfoByCodeName(cim.ChannelName, null!) as ChannelInfo;
            ArgumentNullException.ThrowIfNull(channel);
        }

        var contentItemModel = new ContentItemModel
        {
            ContentItemGUID = cim.ContentItemGUID,
            ContentItemName = cim.Name,
            ContentItemIsReusable = cim.IsReusable,
            ContentItemIsSecured = cim.IsSecured ?? false,
            ContentItemDataClassGuid = dataClassInfo.ClassGUID,
            ContentItemChannelGuid = channel?.ChannelGUID
        };
        
        var adapter = adapterFactory.CreateAdapter(contentItemModel, new ProviderProxyContext());
        ArgumentNullException.ThrowIfNull(adapter);
        var contentItemInfo = (ContentItemInfo)adapter.Adapt(contentItemModel);
        contentItemInfo = (ContentItemInfo)adapter.ProviderProxy.Save(contentItemInfo, contentItemModel);
        
        var contentLanguageProxy = providerProxyFactory.CreateProviderProxy<ContentLanguageInfo>(new ProviderProxyContext());
        var userInfoProxy = providerProxyFactory.CreateProviderProxy<UserInfo>(new ProviderProxyContext());
        
        foreach (var languageData in cim.LanguageData)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(languageData.LanguageName);
            var contentLanguageInfo = contentLanguageProxy.GetBaseInfoByCodeName(languageData.LanguageName, null!) as ContentLanguageInfo;
            ArgumentNullException.ThrowIfNull(contentLanguageInfo);
            
            ArgumentNullException.ThrowIfNull(languageData.UserGuid);
            var userInfo = userInfoProxy.GetBaseInfoByGuid(languageData.UserGuid.Value, null!) as UserInfo;
            ArgumentNullException.ThrowIfNull(userInfo);

            Guid? contentItemCommonDataInfoGuid = null;
            Guid? contentItemLanguageMetadataGuid = null;
            if (existingContentItem != null)
            {
                contentItemCommonDataInfoGuid = Provider<ContentItemCommonDataInfo>.Instance.Get()
                    .WhereEquals(nameof(ContentItemCommonDataInfo.ContentItemCommonDataContentItemID), contentItemInfo.ContentItemID)
                    .WhereEquals(nameof(ContentItemCommonDataInfo.ContentItemCommonDataContentLanguageID), contentLanguageInfo.ContentLanguageID)
                    .FirstOrDefault()
                    ?.ContentItemCommonDataGUID;
                
                contentItemLanguageMetadataGuid = Provider<ContentItemLanguageMetadataInfo>.Instance.Get()
                    .WhereEquals(nameof(ContentItemLanguageMetadataInfo.ContentItemLanguageMetadataContentItemID), contentItemInfo.ContentItemID)
                    .WhereEquals(nameof(ContentItemLanguageMetadataInfo.ContentItemLanguageMetadataContentLanguageID), contentLanguageInfo.ContentLanguageID)
                    .FirstOrDefault()
                    ?.ContentItemLanguageMetadataGUID;
            }

            if (languageData.VersionStatus == VersionStatus.Draft)
            {
                // initial version status cannot be Draft! 
                throw new InvalidOperationException("Content item cannot be created with initial version status \"Draft\"");
            }

            var contentItemCommonDataModel = new ContentItemCommonDataModel
            {
                ContentItemCommonDataGUID = contentItemCommonDataInfoGuid ?? Guid.NewGuid(),
                ContentItemCommonDataContentItemGuid = contentItemInfo.ContentItemGUID,
                ContentItemCommonDataContentLanguageGuid = contentLanguageInfo.ContentLanguageGUID,
                ContentItemCommonDataVersionStatus = languageData.VersionStatus,
                ContentItemCommonDataIsLatest = true,
                ContentItemCommonDataPageBuilderWidgets = null,
                ContentItemCommonDataPageTemplateConfiguration = null
            };

            adapter = adapterFactory.CreateAdapter(contentItemCommonDataModel, new ProviderProxyContext());
            ArgumentNullException.ThrowIfNull(adapter);
            var commonDataInfo = (ContentItemCommonDataInfo)adapter.Adapt(contentItemCommonDataModel);
            adapter.ProviderProxy.Save(commonDataInfo, contentItemCommonDataModel);

            var contentItemLanguageMetadataModel = new ContentItemLanguageMetadataModel
            {
                ContentItemLanguageMetadataGUID = contentItemLanguageMetadataGuid ?? Guid.NewGuid(),
                ContentItemLanguageMetadataContentItemGuid = contentItemInfo.ContentItemGUID,
                ContentItemLanguageMetadataDisplayName = languageData.DisplayName,
                ContentItemLanguageMetadataLatestVersionStatus = languageData.VersionStatus,
                ContentItemLanguageMetadataCreatedWhen = createdWhen,
                ContentItemLanguageMetadataCreatedByUserGuid = languageData.UserGuid,
                ContentItemLanguageMetadataModifiedWhen = null,
                ContentItemLanguageMetadataModifiedByUserGuid = languageData.UserGuid,
                // ContentItemLanguageMetadataHasImageAsset = null,
                ContentItemLanguageMetadataContentLanguageGuid = contentLanguageInfo.ContentLanguageGUID
            };

            adapter = adapterFactory.CreateAdapter(contentItemLanguageMetadataModel, new ProviderProxyContext());
            ArgumentNullException.ThrowIfNull(adapter);
            var contentItemLanguageMetadataInfo = (ContentItemLanguageMetadataInfo)adapter.Adapt(contentItemLanguageMetadataModel);
            adapter.ProviderProxy.Save(contentItemLanguageMetadataInfo, contentItemLanguageMetadataModel);

            Guid? contentItemDataGuid = null;
            if (existingContentItem != null)
            {
                var dataProvider = Service.Resolve<IContentItemDataInfoProviderAccessor>()
                    .Get(dataClassInfo.ClassName);
                
                contentItemDataGuid = dataProvider.Get()
                    .WhereEquals(nameof(ContentItemDataInfo.ContentItemDataCommonDataID), commonDataInfo.ContentItemCommonDataID)
                    .FirstOrDefault()
                    ?.ContentItemDataGUID;
            }
            
            var contentItemDataModel = new ContentItemDataModel
            {
                CustomProperties = languageData.ContentItemData ?? [],
                ContentItemDataGUID = contentItemDataGuid ?? Guid.NewGuid(),
                ContentItemDataCommonDataGuid = commonDataInfo.ContentItemCommonDataGUID,
                ContentItemContentTypeName = cim.ContentTypeName
            };
            adapter = adapterFactory.CreateAdapter(contentItemDataModel, new ProviderProxyContext());
            ArgumentNullException.ThrowIfNull(adapter);
            var contentItemDataInfo = (ContentItemDataInfo)adapter.Adapt(contentItemDataModel);
            adapter.ProviderProxy.Save(contentItemDataInfo, contentItemDataModel);
        }

        if (dataClassInfo.ClassContentTypeType == ClassContentTypeType.WEBSITE)
        {
            if (cim.PageData is { } pageData)
            {
                var webSiteChannel = Provider<WebsiteChannelInfo>.Instance.Get()
                    .WhereEquals(nameof(WebsiteChannelInfo.WebsiteChannelChannelID), channel?.ChannelID)
                    ?.FirstOrDefault();
                
                ArgumentNullException.ThrowIfNull(webSiteChannel);
                
                Guid? webPageItemGuid = null;
                if (existingContentItem != null)
                {
                    webPageItemGuid = Provider<WebPageItemInfo>.Instance.Get()
                        .WhereEquals(nameof(WebPageItemInfo.WebPageItemContentItemID), contentItemInfo.ContentItemID)
                        .WhereEquals(nameof(WebPageItemInfo.WebPageItemWebsiteChannelID), webSiteChannel.WebsiteChannelID)
                        .FirstOrDefault()
                        ?.WebPageItemGUID;
                }
                
                var webPageItemModel = new WebPageItemModel
                {
                    WebPageItemGUID = webPageItemGuid ?? Guid.NewGuid(),
                    WebPageItemParentGuid = pageData.ParentGuid,
                    WebPageItemName = contentItemInfo.ContentItemName,
                    WebPageItemTreePath = pageData.TreePath,
                    WebPageItemWebsiteChannelGuid = webSiteChannel.WebsiteChannelGUID,
                    WebPageItemContentItemGuid = contentItemModel.ContentItemGUID,
                    WebPageItemOrder = pageData.ItemOrder
                };
                
                adapter = adapterFactory.CreateAdapter(webPageItemModel, new ProviderProxyContext());
                ArgumentNullException.ThrowIfNull(adapter);
                var webPageItemInfo = (WebPageItemInfo)adapter.Adapt(webPageItemModel);
                adapter.ProviderProxy.Save(webPageItemInfo, webPageItemModel);

                foreach (var pu in pageData.PageUrls ?? throw new ArgumentNullException(nameof(pageData.PageUrls)))
                {
                    ArgumentException.ThrowIfNullOrWhiteSpace(pu.LanguageName);
                    var contentLanguageInfo = contentLanguageProxy.GetBaseInfoByCodeName(pu.LanguageName, null!) as ContentLanguageInfo;
                    ArgumentNullException.ThrowIfNull(contentLanguageInfo);

                    Guid? webPageUrlPathGuid = null;
                    if (existingContentItem != null)
                    {
                        // this will miss if url path is changed, it is up to user cleaning old urls (or we supply parameter to configure if old urls should be cleared)
                        webPageUrlPathGuid = Provider<WebPageUrlPathInfo>.Instance.Get()
                            .WhereEquals(nameof(WebPageUrlPathInfo.WebPageUrlPathWebPageItemID), webPageItemInfo.WebPageItemID)
                            .WhereEquals(nameof(WebPageUrlPathInfo.WebPageUrlPathContentLanguageID), contentLanguageInfo.ContentLanguageID)
                            .WhereEquals(nameof(WebPageUrlPathInfo.WebPageUrlPathWebsiteChannelID), webSiteChannel.WebsiteChannelID)
                            .WhereEquals(nameof(WebPageUrlPathInfo.WebPageUrlPath), pu.UrlPath)
                            .FirstOrDefault()
                            ?.WebPageUrlPathGUID;
                    }

                    var webPageUrlPathModel = new WebPageUrlPathModel
                    {
                        WebPageUrlPathGUID = webPageUrlPathGuid ?? Guid.NewGuid(),
                        WebPageUrlPath = pu.UrlPath,
                        // WebPageUrlPathHash = null,
                        WebPageUrlPathWebPageItemGuid = webPageItemModel.WebPageItemGUID,
                        WebPageUrlPathWebsiteChannelGuid = webSiteChannel.WebsiteChannelGUID,
                        WebPageUrlPathContentLanguageGuid = contentLanguageInfo.ContentLanguageGUID,
                        WebPageUrlPathIsLatest = true,
                        WebPageUrlPathIsDraft = pu.PathIsDraft ?? true
                    };
                    
                    adapter = adapterFactory.CreateAdapter(webPageUrlPathModel, new ProviderProxyContext());
                    ArgumentNullException.ThrowIfNull(adapter);
                    var webPageUrlPathInfo = (WebPageUrlPathInfo)adapter.Adapt(webPageUrlPathModel);
                    adapter.ProviderProxy.Save(webPageUrlPathInfo, webPageUrlPathModel);
                }
            }
            else
            {
                ArgumentNullException.ThrowIfNull(cim.PageData);    
            }
        }
        
        scope.Commit();

        return contentItemInfo;
    }


    Guid? IInfoAdapter<IUmtModel>.GetUniqueIdOrNull(IUmtModel input) => throw new NotImplementedException();
}
