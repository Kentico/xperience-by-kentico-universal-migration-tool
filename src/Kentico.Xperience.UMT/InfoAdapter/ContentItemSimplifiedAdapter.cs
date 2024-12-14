using System.Text.Json;

using AngleSharp.Dom;

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
using CMS.Workspaces;

using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class ContentItemSimplifiedAdapter : IInfoAdapter<ContentItemInfo, IUmtModel>
{
    private readonly IProviderProxyFactory providerProxyFactory;
    private readonly IDateTimeNowService dateTimeNowService;
    private readonly AdapterFactory adapterFactory;
    private readonly ILogger<ContentItemSimplifiedAdapter> logger;

    public IProviderProxy ProviderProxy { get; }

    internal ContentItemSimplifiedAdapter(IProviderProxy providerProxy,
        IProviderProxyFactory providerProxyFactory,
        IDateTimeNowService dateTimeNowService,
        AdapterFactory adapterFactory,
        ILogger<ContentItemSimplifiedAdapter> logger,
        IInfoProvider<ContentFolderInfo> contentFolderInfoProvider,
        IInfoProvider<WorkspaceInfo> workspaceInfoProvider)
    {
        this.providerProxyFactory = providerProxyFactory;
        this.dateTimeNowService = dateTimeNowService;
        this.adapterFactory = adapterFactory;
        this.logger = logger;
        rootContentFolderGUID = contentFolderInfoProvider.Get().Where(x => x.WhereEquals(nameof(ContentFolderInfo.ContentFolderTreePath), "/")).FirstOrDefault()?.ContentFolderGUID;
        defaultWorkspaceGUID = workspaceInfoProvider.Get().Where(x => x.WhereEquals(nameof(WorkspaceInfo.WorkspaceName), "KenticoDefault")).FirstOrDefault()?.WorkspaceGUID;
        ProviderProxy = providerProxy;
    }

    BaseInfo IInfoAdapter<IUmtModel>.Adapt(IUmtModel input) => Adapt(input);

    Guid? IInfoAdapter<ContentItemInfo, IUmtModel>.GetUniqueIdOrNull(IUmtModel input) => throw new NotImplementedException();

    private readonly Guid? rootContentFolderGUID;
    private readonly Guid? defaultWorkspaceGUID;

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
            ContentItemWorkspaceGUID = cim.ContentItemWorkspaceGUID ?? defaultWorkspaceGUID,
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

            ArgumentException.ThrowIfNullOrWhiteSpace(languageData.LanguageName);

            var contentLanguageInfo = contentLanguageProxy.GetBaseInfoByCodeName(languageData.LanguageName, null!) as ContentLanguageInfo;
            ArgumentNullException.ThrowIfNull(contentLanguageInfo);

            if (languageData.UserGuid is { } userGuid && userInfoProxy.GetBaseInfoByGuid(userGuid, null!) is null)
            {
                throw new InvalidOperationException($"User with GUID '{userGuid}' not found");
            }

            var dataProvider = Service.Resolve<IContentItemDataInfoProviderAccessor>()
                        .Get(dataClassInfo.ClassName);

            var fi = new FormInfo(dataClassInfo.ClassFormDefinition);
            var commonFields = UnpackReusableFieldSchemas(fi.GetFields<FormSchemaInfo>());
            var customProperties = new Dictionary<string, object?>();
            foreach (var formFieldInfo in commonFields)
            {
                if (customData.TryGetValue(formFieldInfo.Name, out object? value))
                {
                    logger.LogTrace("Reusable schema field '{FieldName}' from schema '{SchemaGuid}' populated", formFieldInfo.Name, formFieldInfo.Properties[ReusableFieldSchemaConstants.SCHEMA_IDENTIFIER_KEY]);
                    customProperties[formFieldInfo.Name] = value;
                    customData.Remove(formFieldInfo.Name);
                }
                else
                {
                    logger.LogTrace("Reusable schema field '{FieldName}' from schema '{SchemaGuid}' missing", formFieldInfo.Name, formFieldInfo.Properties[ReusableFieldSchemaConstants.SCHEMA_IDENTIFIER_KEY]);
                }
            }

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
                CustomProperties = customProperties,
                ContentItemCommonDataVisualBuilderWidgets = null,
                ContentItemCommonDataVisualBuilderTemplateConfiguration = null,
                ContentItemCommonDataVersionStatus = languageData.VersionStatus,
                ContentItemCommonDataIsLatest = languageData.IsLatest,
            };
            var commonItemDataAdapter = adapterFactory.CreateAdapter(commonDataModel, new ProviderProxyContext());
            ArgumentNullException.ThrowIfNull(commonItemDataAdapter);
            var commonDataInfo = (ContentItemCommonDataInfo)commonItemDataAdapter.Adapt(commonDataModel);
            commonItemDataAdapter.ProviderProxy.Save(commonDataInfo, commonDataModel);


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
            }
            else
            {
                ArgumentNullException.ThrowIfNull(cim.PageData);
            }
        }

        scope.Commit();

        return contentItemInfo;
    }

    private static IEnumerable<FormFieldInfo> UnpackReusableFieldSchemas(IEnumerable<FormSchemaInfo> schemaInfos)
    {
        using var siEnum = schemaInfos.GetEnumerator();

        if (siEnum.MoveNext() && FormHelper.GetFormInfo(ContentItemCommonDataInfo.TYPEINFO.ObjectClassName, true) is { } cfi)
        {
            do
            {
                var fsi = siEnum.Current;
                var formFieldInfos = cfi
                    .GetFields(true, true, true)
                    .Where(f => string.Equals(f.Properties[ReusableFieldSchemaConstants.SCHEMA_IDENTIFIER_KEY] as string, fsi.Guid.ToString(),
                        StringComparison.InvariantCultureIgnoreCase));

                foreach (var formFieldInfo in formFieldInfos)
                {
                    yield return formFieldInfo;
                }
            } while (siEnum.MoveNext());
        }
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
                var asset = jsonElement.Deserialize<AssetSource>() ?? throw new InvalidOperationException($"JSON object with property {AssetSource.DISCRIMINATOR_PROPERTY} cannot be deserialized");
                return ImageHelper.IsImage(asset.InferExtension());
            }
            default:
            {
                return false;
            }
        }
    }
}
