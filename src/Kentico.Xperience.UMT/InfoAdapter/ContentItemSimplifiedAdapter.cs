﻿using System.Text.Json;

using CMS.ContentEngine;
using CMS.ContentEngine.Internal;
using CMS.Core;
using CMS.Core.Internal;
using CMS.DataEngine;
using CMS.FormEngine;
using CMS.Helpers;
using CMS.Membership;
using CMS.Websites;
using CMS.Websites.Internal;

using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Services;
using Kentico.Xperience.UMT.Utils;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class ContentItemSimplifiedAdapter : IInfoAdapter<ContentItemInfo, IUmtModel>
{
    private readonly IProviderProxyFactory providerProxyFactory;
    private readonly IDateTimeNowService dateTimeNowService;
    private readonly AdapterFactory adapterFactory;
    private readonly ILogger<ContentItemSimplifiedAdapter> logger;
    private readonly WorkspaceService workspaceService;

    public IProviderProxy ProviderProxy { get; }

    internal ContentItemSimplifiedAdapter(IProviderProxy providerProxy,
        IProviderProxyFactory providerProxyFactory,
        IDateTimeNowService dateTimeNowService,
        AdapterFactory adapterFactory,
        ILogger<ContentItemSimplifiedAdapter> logger,
        IInfoProvider<ContentFolderInfo> contentFolderInfoProvider,
        WorkspaceService workspaceService)
    {
        this.providerProxyFactory = providerProxyFactory;
        this.dateTimeNowService = dateTimeNowService;
        this.adapterFactory = adapterFactory;
        this.logger = logger;
        this.workspaceService = workspaceService;
        rootContentFolderGUID = contentFolderInfoProvider.Get().Where(x => x.WhereEquals(nameof(ContentFolderInfo.ContentFolderTreePath), "/")).FirstOrDefault()?.ContentFolderGUID;
        ProviderProxy = providerProxy;
    }

    BaseInfo IInfoAdapter<IUmtModel>.Adapt(IUmtModel input) => Adapt(input);

    Guid? IInfoAdapter<ContentItemInfo, IUmtModel>.GetUniqueIdOrNull(IUmtModel input) => throw new NotImplementedException();

    private readonly Guid? rootContentFolderGUID;

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
            ContentItemChannelGuid = channel?.ChannelGUID,
            ContentItemContentFolderGUID = cim.ContentItemContentFolderGUID ?? rootContentFolderGUID,
            ContentItemWorkspaceGUID = cim.ContentItemWorkspaceGUID ?? workspaceService.FallbackWorkspace.Value.WorkspaceGUID,
        };

        var contentItemAdapter = adapterFactory.CreateAdapter(contentItemModel, new ProviderProxyContext());
        ArgumentNullException.ThrowIfNull(contentItemAdapter);

        var contentItemInfo = (ContentItemInfo)contentItemAdapter.Adapt(contentItemModel);
        contentItemInfo = (ContentItemInfo)contentItemAdapter.ProviderProxy.Save(contentItemInfo, contentItemModel);

        var contentLanguageProxy = providerProxyFactory.CreateProviderProxy<ContentLanguageInfo>(new ProviderProxyContext());
        var userInfoProxy = providerProxyFactory.CreateProviderProxy<UserInfo>(new ProviderProxyContext());

        foreach (var languageData in cim.LanguageData)
        {
            var customData = languageData.ContentItemData?.ToDictionary() ?? [];

            var fi = new FormInfo(dataClassInfo.ClassFormDefinition);

            ArgumentException.ThrowIfNullOrWhiteSpace(languageData.LanguageName);

            var contentLanguageInfo = contentLanguageProxy.GetBaseInfoByCodeName(languageData.LanguageName, null!) as ContentLanguageInfo;
            ArgumentNullException.ThrowIfNull(contentLanguageInfo);

            if (languageData.UserGuid is { } userGuid && userInfoProxy.GetBaseInfoByGuid(userGuid, null!) is null)
            {
                throw new InvalidOperationException($"User with GUID '{userGuid}' not found");
            }

            var dataProvider = Service.Resolve<IContentItemDataInfoProviderAccessor>()
                        .Get(dataClassInfo.ClassName);

            #region Move reusable schema properties to common data
            var commonFields = SchemaHelper.UnpackReusableFieldSchemas(fi.GetFields<FormSchemaInfo>());
            var commonDataCustomProperties = new Dictionary<string, object?>();
            foreach (var formFieldInfo in commonFields)
            {
                if (customData.TryGetValue(formFieldInfo.Name, out object? value))
                {
                    logger.LogTrace("Reusable schema field '{FieldName}' from schema '{SchemaGuid}' populated", formFieldInfo.Name, formFieldInfo.Properties[ReusableFieldSchemaConstants.SCHEMA_IDENTIFIER_KEY]);
                    commonDataCustomProperties[formFieldInfo.Name] = value;
                    customData.Remove(formFieldInfo.Name);
                }
                else
                {
                    logger.LogTrace("Reusable schema field '{FieldName}' from schema '{SchemaGuid}' missing", formFieldInfo.Name, formFieldInfo.Properties[ReusableFieldSchemaConstants.SCHEMA_IDENTIFIER_KEY]);
                }
            }
            #endregion

            var existingCommonDataInfo = existingContentItem is not null ? Provider<ContentItemCommonDataInfo>.Instance.Get()
                    .WhereEquals(nameof(ContentItemCommonDataInfo.ContentItemCommonDataContentItemID), existingContentItem.ContentItemID)
                    .WhereEquals(nameof(ContentItemCommonDataInfo.ContentItemCommonDataContentLanguageID), contentLanguageInfo.ContentLanguageID)
                    .WhereEquals(nameof(ContentItemCommonDataInfo.ContentItemCommonDataVersionStatus), languageData.VersionStatus)
                    .FirstOrDefault() : null;
            var existingItemDataInfo = existingCommonDataInfo is not null ? dataProvider.Get().WhereEquals(nameof(ContentItemDataInfo.ContentItemDataCommonDataID), existingCommonDataInfo.ContentItemCommonDataID).FirstOrDefault() : null;

            var commonDataModel = new ContentItemCommonDataModel
            {
                ContentItemCommonDataGUID = existingCommonDataInfo?.ContentItemCommonDataGUID ?? Guid.NewGuid(),
                ContentItemCommonDataContentItemGuid = contentItemInfo.ContentItemGUID,
                ContentItemCommonDataContentLanguageGuid = contentLanguageInfo.ContentLanguageGUID,
                CustomProperties = commonDataCustomProperties,
                ContentItemCommonDataVisualBuilderWidgets = languageData.VisualBuilderWidgets is not null ? JsonSerializer.Serialize(languageData.VisualBuilderWidgets, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }) : null,
                ContentItemCommonDataVisualBuilderTemplateConfiguration = languageData.VisualBuilderTemplateConfiguration is not null ? JsonSerializer.Serialize(languageData.VisualBuilderTemplateConfiguration, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }) : null,
                ContentItemCommonDataVersionStatus = languageData.VersionStatus,
                ContentItemCommonDataIsLatest = languageData.IsLatest,
            };
            var commonItemCommonDataAdapter = adapterFactory.CreateAdapter(commonDataModel, new ProviderProxyContext());
            ArgumentNullException.ThrowIfNull(commonItemCommonDataAdapter);
            var commonDataInfo = (ContentItemCommonDataInfo)commonItemCommonDataAdapter.Adapt(commonDataModel);
            commonItemCommonDataAdapter.ProviderProxy.Save(commonDataInfo, commonDataModel);
            commonItemCommonDataAdapter.Postprocess(commonDataModel, commonDataInfo);

            var itemDataModel = new ContentItemDataModel
            {
                ContentItemDataGUID = existingItemDataInfo?.ContentItemDataGUID ?? Guid.NewGuid(),
                ContentItemDataCommonDataGuid = commonDataInfo.ContentItemCommonDataGUID,
                CustomProperties = customData,
                ContentItemContentTypeName = cim.ContentTypeName
            };
            var itemDataAdapter = adapterFactory.CreateAdapter(itemDataModel, new ProviderProxyContext());
            ArgumentNullException.ThrowIfNull(itemDataAdapter);
            var itemDataInfo = (ContentItemDataInfo)itemDataAdapter.Adapt(itemDataModel);
            itemDataAdapter.ProviderProxy.Save(itemDataInfo, itemDataModel);
            itemDataAdapter.Postprocess(itemDataModel, itemDataInfo);

            var existingLanguageMetadataInfo = Provider<ContentItemLanguageMetadataInfo>.Instance.Get()
                    .WhereEquals(nameof(ContentItemLanguageMetadataInfo.ContentItemLanguageMetadataContentItemID), contentItemInfo.ContentItemID)
                    .WhereEquals(nameof(ContentItemLanguageMetadataInfo.ContentItemLanguageMetadataContentLanguageID), contentLanguageInfo.ContentLanguageID)
                    .FirstOrDefault();
            var languageMetadataModel = new ContentItemLanguageMetadataModel
            {
                ContentItemLanguageMetadataGUID = existingLanguageMetadataInfo?.ContentItemLanguageMetadataGUID ?? Guid.NewGuid(),
                ContentItemLanguageMetadataContentItemGuid = contentItemInfo.ContentItemGUID,
                ContentItemLanguageMetadataLatestVersionStatus = languageData.VersionStatus,
                ContentItemLanguageMetadataDisplayName = languageData.DisplayName,
                ContentItemLanguageMetadataCreatedWhen = createdWhen,
                ContentItemLanguageMetadataCreatedByUserGuid = languageData.UserGuid,
                ContentItemLanguageMetadataModifiedWhen = null,
                ContentItemLanguageMetadataModifiedByUserGuid = languageData.UserGuid,
                ContentItemLanguageMetadataHasImageAsset = languageData.ContentItemData?.Values.Any(IsImageAsset) ?? false,
                ContentItemLanguageMetadataContentLanguageGuid = contentLanguageInfo.ContentLanguageGUID,
                ContentItemLanguageMetadataScheduledPublishWhen = languageData.ScheduledPublishWhen,
                ContentItemLanguageMetadataScheduledUnpublishWhen = languageData.ScheduledUnpublishWhen,
            };
            var languageMetadataAdapter = adapterFactory.CreateAdapter(languageMetadataModel, new ProviderProxyContext());
            ArgumentNullException.ThrowIfNull(languageMetadataAdapter);
            var languageMetadataInfo = (ContentItemLanguageMetadataInfo)languageMetadataAdapter.Adapt(languageMetadataModel);
            languageMetadataAdapter.ProviderProxy.Save(languageMetadataInfo, languageMetadataModel);
        }

        if (dataClassInfo.ClassContentTypeType == ClassContentTypeType.WEBSITE)
        {
            if (cim.PageData is { } pageData)
            {
                var webSiteChannel = Provider<WebsiteChannelInfo>.Instance.Get()
                    .WhereEquals(nameof(WebsiteChannelInfo.WebsiteChannelChannelID), channel?.ChannelID)
                    ?.FirstOrDefault();

                ArgumentNullException.ThrowIfNull(webSiteChannel);

                var webPageItemGuid = pageData.PageGuid;
                if (existingContentItem != null && webPageItemGuid == null)
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

                var webPageItemAdapter = adapterFactory.CreateAdapter(webPageItemModel, new ProviderProxyContext());
                ArgumentNullException.ThrowIfNull(webPageItemAdapter);
                var webPageItemInfo = (WebPageItemInfo)webPageItemAdapter.Adapt(webPageItemModel);
                webPageItemInfo = (WebPageItemInfo)webPageItemAdapter.ProviderProxy.Save(webPageItemInfo, webPageItemModel);

                var urls = pageData.PageUrls ?? [];

                foreach (var urlsByLang in urls.GroupBy(url => url.LanguageName))
                {
                    ArgumentException.ThrowIfNullOrWhiteSpace(urlsByLang.Key);

                    var contentLanguageInfo = contentLanguageProxy.GetBaseInfoByCodeName(urlsByLang.Key, null!) as ContentLanguageInfo;
                    ArgumentNullException.ThrowIfNull(contentLanguageInfo);

                    foreach (var pageUrlModel in urlsByLang)
                    {
                        ArgumentException.ThrowIfNullOrWhiteSpace(pageUrlModel.LanguageName);

                        var existingPathInfo = Provider<WebPageUrlPathInfo>.Instance.Get()
                                    .WhereEquals(nameof(WebPageUrlPathInfo.WebPageUrlPathWebPageItemID), webPageItemInfo.WebPageItemID)
                                    .WhereEquals(nameof(WebPageUrlPathInfo.WebPageUrlPathContentLanguageID), contentLanguageInfo.ContentLanguageID)
                                    .WhereEquals(nameof(WebPageUrlPathInfo.WebPageUrlPathIsDraft), pageUrlModel.PathIsDraft)
                                    .WhereEquals(nameof(WebPageUrlPathInfo.WebPageUrlPathWebsiteChannelID), webSiteChannel.WebsiteChannelID)
                                    .FirstOrDefault();

                        if (pageUrlModel.PathIsDraft == true && 1 != cim.LanguageData.Count(x => x.LanguageName == contentLanguageInfo.ContentLanguageName && x.VersionStatus == VersionStatus.Draft))
                        {
                            throw new InvalidOperationException($"{nameof(PageUrlModel)} {pageUrlModel.UrlPath} of {nameof(ContentItemSimplifiedModel)}[{nameof(cim.ContentItemGUID)}={cim.ContentItemGUID}]" +
                                $"has ${nameof(PageUrlModel.PathIsDraft)} = true, but no corresponding {nameof(VersionStatus.Draft)} version (unique per language) found in {nameof(ContentItemSimplifiedModel)}.{nameof(cim.LanguageData)}");
                        }

                        var pathModel = new WebPageUrlPathModel
                        {
                            WebPageUrlPathGUID = existingPathInfo?.WebPageUrlPathGUID ?? Guid.NewGuid(),
                            WebPageUrlPathIsLatest = pageUrlModel.PathIsLatest,
                            WebPageUrlPathIsDraft = pageUrlModel.PathIsDraft,
                            WebPageUrlPath = pageUrlModel.UrlPath,
                            WebPageUrlPathWebPageItemGuid = webPageItemModel.WebPageItemGUID,
                            WebPageUrlPathWebsiteChannelGuid = webSiteChannel.WebsiteChannelGUID,
                            WebPageUrlPathContentLanguageGuid = contentLanguageInfo.ContentLanguageGUID,
                            // WebPageUrlPathHash = null,
                        };
                        var pathAdapter = adapterFactory.CreateAdapter(pathModel, new ProviderProxyContext());
                        ArgumentNullException.ThrowIfNull(pathAdapter);
                        var pathInfo = (WebPageUrlPathInfo)pathAdapter.Adapt(pathModel);
                        pathAdapter.ProviderProxy.Save(pathInfo, pathModel);
                    }
                }

                var formerUrls = pageData.PageFormerUrls ?? [];

                foreach (var urlsByLang in formerUrls.GroupBy(url => url.LanguageName))
                {
                    ArgumentException.ThrowIfNullOrWhiteSpace(urlsByLang.Key);

                    var contentLanguageInfo = contentLanguageProxy.GetBaseInfoByCodeName(urlsByLang.Key, null!) as ContentLanguageInfo;
                    ArgumentNullException.ThrowIfNull(contentLanguageInfo);

                    foreach (var pageFormerUrlModel in urlsByLang)
                    {
                        ArgumentException.ThrowIfNullOrWhiteSpace(pageFormerUrlModel.LanguageName);

                        var existingPathInfo = Provider<WebPageFormerUrlPathInfo>.Instance.Get()
                                    .WhereEquals(nameof(WebPageFormerUrlPathInfo.WebPageFormerUrlPath), pageFormerUrlModel.FormerUrlPath)
                                    .WhereEquals(nameof(WebPageFormerUrlPathInfo.WebPageFormerUrlPathWebPageItemID), webPageItemInfo.WebPageItemID)
                                    .WhereEquals(nameof(WebPageFormerUrlPathInfo.WebPageFormerUrlPathContentLanguageID), contentLanguageInfo.ContentLanguageID)
                                    .WhereEquals(nameof(WebPageFormerUrlPathInfo.WebPageFormerUrlPathWebsiteChannelID), webSiteChannel.WebsiteChannelID)
                                    .FirstOrDefault();

                        if (existingPathInfo == null)
                        {
                            var formerPathModel = new WebPageFormerUrlPathModel
                            {
                                WebPageFormerUrlPathGUID = Guid.NewGuid(),
                                WebPageFormerUrlPathWebPageItemGuid = webPageItemModel.WebPageItemGUID,
                                WebPageFormerUrlPath = pageFormerUrlModel.FormerUrlPath,
                                WebPageFormerUrlPathWebsiteChannelGuid = webSiteChannel.WebsiteChannelGUID,
                                WebPageFormerUrlPathContentLanguageGuid = contentLanguageInfo.ContentLanguageGUID,
                                WebPageFormerUrlPathIsRedirectScheduled = false,
                                WebPageFormerUrlPathIsRedirect = false
                            };

                            var formerPathAdapter = adapterFactory.CreateAdapter(formerPathModel, new ProviderProxyContext());
                            ArgumentNullException.ThrowIfNull(formerPathAdapter);
                            var formerPathInfo = (WebPageFormerUrlPathInfo)formerPathAdapter.Adapt(formerPathModel);
                            formerPathAdapter.ProviderProxy.Save(formerPathInfo, formerPathModel);
                        }
                    }
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

    Guid? IInfoAdapter<IUmtModel>.GetUniqueIdOrNull(IUmtModel input) => input is ContentItemSimplifiedModel sm ? sm.ContentItemGUID : null;

    private static bool IsImageAsset(object? value)
    {
        switch (value)
        {
            case AssetSource assetSource:
            {
                return ImageHelper.IsImage(assetSource.InferExtension());
            }
            case JsonElement { ValueKind: JsonValueKind.Object } jsonElement when jsonElement.GetProperty(AssetSource.DISCRIMINATOR_PROPERTY).GetString() is { }:
            {
                var asset = jsonElement.Deserialize<AssetSource>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? throw new InvalidOperationException($"JSON object with property {AssetSource.DISCRIMINATOR_PROPERTY} cannot be deserialized");
                return ImageHelper.IsImage(asset.InferExtension());
            }
            default:
            {
                return false;
            }
        }
    }

    public void Postprocess(IUmtModel input, BaseInfo baseInfo) { }
}
