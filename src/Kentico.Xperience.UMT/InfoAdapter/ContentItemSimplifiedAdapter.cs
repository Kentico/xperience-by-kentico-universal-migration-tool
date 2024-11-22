using System.Text.Json;

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
using CMS.Websites.Routing.Internal;

using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Utils;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

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
        ILogger<ContentItemSimplifiedAdapter> logger)
    {
        this.providerProxyFactory = providerProxyFactory;
        this.dateTimeNowService = dateTimeNowService;
        this.adapterFactory = adapterFactory;
        this.logger = logger;
        ProviderProxy = providerProxy;
    }

    BaseInfo IInfoAdapter<IUmtModel>.Adapt(IUmtModel input) => Adapt(input);

    Guid? IInfoAdapter<ContentItemInfo, IUmtModel>.GetUniqueIdOrNull(IUmtModel input) => throw new NotImplementedException();

    private enum CreateStrategy { Unspecified, CreateOrUpdate, CreateDraftFromPublished, PublishFromDraft, PublishFromInitialDraft }

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
            ContentItemContentFolderGUID = cim.ContentItemContentFolderGUID
        };

        var contentItemAdapter = adapterFactory.CreateAdapter(contentItemModel, new ProviderProxyContext());
        ArgumentNullException.ThrowIfNull(contentItemAdapter);

        var contentItemInfo = (ContentItemInfo)contentItemAdapter.Adapt(contentItemModel);
        contentItemInfo = (ContentItemInfo)contentItemAdapter.ProviderProxy.Save(contentItemInfo, contentItemModel);

        var contentLanguageProxy = providerProxyFactory.CreateProviderProxy<ContentLanguageInfo>(new ProviderProxyContext());
        var userInfoProxy = providerProxyFactory.CreateProviderProxy<UserInfo>(new ProviderProxyContext());

        var commonDataModelsByLang = new Dictionary<string, List<ContentItemCommonDataModel>>();
        CreateStrategy createStrategy = CreateStrategy.Unspecified;

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

            ContentItemCommonDataInfo? latestContentItemCommonDataInfo = null;
            Guid? contentItemLanguageMetadataGuid = null;

            var dataProvider = Service.Resolve<IContentItemDataInfoProviderAccessor>()
                        .Get(dataClassInfo.ClassName);

            if (existingContentItem != null)
            {
                latestContentItemCommonDataInfo = Provider<ContentItemCommonDataInfo>.Instance.Get()
                    .WhereEquals(nameof(ContentItemCommonDataInfo.ContentItemCommonDataContentItemID), contentItemInfo.ContentItemID)
                    .WhereEquals(nameof(ContentItemCommonDataInfo.ContentItemCommonDataContentLanguageID), contentLanguageInfo.ContentLanguageID)
                    .WhereEquals(nameof(ContentItemCommonDataInfo.ContentItemCommonDataIsLatest), true)
                    .FirstOrDefault();
                
                contentItemLanguageMetadataGuid = Provider<ContentItemLanguageMetadataInfo>.Instance.Get()
                    .WhereEquals(nameof(ContentItemLanguageMetadataInfo.ContentItemLanguageMetadataContentItemID), contentItemInfo.ContentItemID)
                    .WhereEquals(nameof(ContentItemLanguageMetadataInfo.ContentItemLanguageMetadataContentLanguageID), contentLanguageInfo.ContentLanguageID)
                    .FirstOrDefault()
                    ?.ContentItemLanguageMetadataGUID;
            }

            #region ContentItemCommonData and ContentItemData
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

            // Prepare base models to be set as one or multiple instances with variable 'assigned later' fields
            var contentItemCommonDataModelBase = () => new ContentItemCommonDataModel
            {
                // ContentItemCommonDataGUID will be assigned later
                // ContentItemCommonDataVersionStatus will be assigned later
                // ContentItemCommonDataIsLatest will be assigned later
                ContentItemCommonDataContentItemGuid = contentItemInfo.ContentItemGUID,
                ContentItemCommonDataContentLanguageGuid = contentLanguageInfo.ContentLanguageGUID,
                ContentItemCommonDataPageBuilderWidgets = null,
                ContentItemCommonDataPageTemplateConfiguration = null,
                CustomProperties = customProperties
            };
            var contentItemDataModelBase = () => new ContentItemDataModel
            {
                //ContentItemDataGUID will be assigned later
                //ContentItemDataCommonDataGuid will be assigned later,
                CustomProperties = customData,
                ContentItemContentTypeName = cim.ContentTypeName
            };

            var itemDataAdapter = adapterFactory.CreateAdapter(contentItemDataModelBase(), new ProviderProxyContext());
            ArgumentNullException.ThrowIfNull(itemDataAdapter);
            var commonItemDataAdapter = adapterFactory.CreateAdapter(contentItemCommonDataModelBase(), new ProviderProxyContext());
            ArgumentNullException.ThrowIfNull(commonItemDataAdapter);

            // Create ContentItemCommonDataModel instances to be set. For each one a ContentItemDataModel will be automatically instantiated
            commonDataModelsByLang[languageData.LanguageName] = [];

            createStrategy = GetCreateStrategy(latestContentItemCommonDataInfo?.ContentItemCommonDataVersionStatus, languageData.VersionStatus);
            if (createStrategy == CreateStrategy.CreateOrUpdate)
            {
                // Create a new or update an existing entry
                commonDataModelsByLang[languageData.LanguageName].Add(contentItemCommonDataModelBase().Apply(x =>
                {
                    x.ContentItemCommonDataGUID = latestContentItemCommonDataInfo?.ContentItemCommonDataGUID ?? Guid.NewGuid();
                    x.ContentItemCommonDataIsLatest = true;
                    x.ContentItemCommonDataVersionStatus = languageData.VersionStatus;
                }));
            }
            else if (createStrategy == CreateStrategy.CreateDraftFromPublished)
            {
                // Update published version -> not latest
                latestContentItemCommonDataInfo!.ContentItemCommonDataIsLatest = false;
                commonItemDataAdapter.ProviderProxy.Save(latestContentItemCommonDataInfo, contentItemCommonDataModelBase());

                // Insert new draft version
                commonDataModelsByLang[languageData.LanguageName].Add(contentItemCommonDataModelBase().Apply(x =>
                {
                    x.ContentItemCommonDataGUID = Guid.NewGuid();
                    x.ContentItemCommonDataIsLatest = true;
                    x.ContentItemCommonDataVersionStatus = VersionStatus.Draft;
                }));
            }
            else if (createStrategy == CreateStrategy.PublishFromDraft)
            {
                throw new NotImplementedException("Importing published content item while a draft item exists is not supported yet");
            }
            else if (createStrategy == CreateStrategy.PublishFromInitialDraft)
            {
                throw new NotImplementedException("Importing published content item while an initial draft item exists is not supported yet");
            }
            else
            {
                throw new NotImplementedException($"Create strategy {createStrategy} not implemented");
            }

            foreach (var commonDataModel in commonDataModelsByLang[languageData.LanguageName])
            {
                var commonDataInfo = (ContentItemCommonDataInfo)commonItemDataAdapter.Adapt(commonDataModel);
                commonItemDataAdapter!.ProviderProxy.Save(commonDataInfo, commonDataModel);

                var dataModel = contentItemDataModelBase().Apply(x =>
                {
                    var existingItemDataInfo = dataProvider.Get().WhereEquals(nameof(ContentItemDataInfo.ContentItemDataCommonDataID), commonDataInfo.ContentItemCommonDataID).FirstOrDefault();
                    x.ContentItemDataGUID = (existingItemDataInfo != null) ? existingItemDataInfo!.ContentItemDataGUID : Guid.NewGuid();
                    x.ContentItemDataCommonDataGuid = commonDataModel.ContentItemCommonDataGUID;
                });
                
                var dataInfo = (ContentItemDataInfo)itemDataAdapter.Adapt(dataModel);
                itemDataAdapter!.ProviderProxy.Save(dataInfo, dataModel);
            }

            #endregion

            #region ContentItemLanguageMetadata
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
                ContentItemLanguageMetadataHasImageAsset = languageData.ContentItemData?.Values.Any(IsImageAsset) ?? false,
                ContentItemLanguageMetadataContentLanguageGuid = contentLanguageInfo.ContentLanguageGUID,
                ContentItemLanguageMetadataScheduledPublishWhen = languageData.ScheduledPublishWhen,
                ContentItemLanguageMetadataScheduledUnpublishWhen = languageData.ScheduledUnpublishWhen
            };

            var languageMetadataAdapter = adapterFactory.CreateAdapter(contentItemLanguageMetadataModel, new ProviderProxyContext());
            ArgumentNullException.ThrowIfNull(languageMetadataAdapter);
            var contentItemLanguageMetadataInfo = (ContentItemLanguageMetadataInfo)languageMetadataAdapter.Adapt(contentItemLanguageMetadataModel);
            languageMetadataAdapter.ProviderProxy.Save(contentItemLanguageMetadataInfo, contentItemLanguageMetadataModel);
            #endregion

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

                        var webPageUrlPathModelBase = () => new WebPageUrlPathModel
                        {
                            // WebPageUrlPathGUID to be assigned later
                            // WebPageUrlPathIsLatest to be assigned later
                            // WebPageUrlPathIsDraft to be assigned later
                            // WebPageUrlPathHash = null,
                            WebPageUrlPath = pageUrlModel.UrlPath,
                            WebPageUrlPathWebPageItemGuid = webPageItemModel.WebPageItemGUID,
                            WebPageUrlPathWebsiteChannelGuid = webSiteChannel.WebsiteChannelGUID,
                            WebPageUrlPathContentLanguageGuid = contentLanguageInfo.ContentLanguageGUID,
                        };

                        var pagePathAdapter = adapterFactory.CreateAdapter(webPageUrlPathModelBase(), new ProviderProxyContext());
                        ArgumentNullException.ThrowIfNull(pagePathAdapter);

                        var modelsToSet = new List<WebPageUrlPathModel>();
                        if (createStrategy == CreateStrategy.CreateOrUpdate)
                        {
                            WebPageUrlPathInfo? webPageUrlPath = null;
                            if (existingContentItem != null)
                            {
                                webPageUrlPath = Provider<WebPageUrlPathInfo>.Instance.Get()
                                    .WhereEquals(nameof(WebPageUrlPathInfo.WebPageUrlPathWebPageItemID), webPageItemInfo.WebPageItemID)
                                    .WhereEquals(nameof(WebPageUrlPathInfo.WebPageUrlPathContentLanguageID), contentLanguageInfo.ContentLanguageID)
                                    .WhereEquals(nameof(WebPageUrlPathInfo.WebPageUrlPathWebsiteChannelID), webSiteChannel.WebsiteChannelID)
                                    .FirstOrDefault();
                            }

                            var commonDataModel = commonDataModelsByLang.GetValueOrDefault(pageUrlModel.LanguageName)?[0];
                            var webPageUrlPathModel = webPageUrlPathModelBase().Apply(x =>
                            {
                                x.WebPageUrlPathGUID = webPageUrlPath?.WebPageUrlPathGUID ?? Guid.NewGuid();
                                x.WebPageUrlPathIsLatest = commonDataModel?.ContentItemCommonDataIsLatest ?? true;
                                x.WebPageUrlPathIsDraft = commonDataModel is not null && (commonDataModel.ContentItemCommonDataVersionStatus == VersionStatus.Draft);
                            });
                            modelsToSet.Add(webPageUrlPathModel);
                        }
                        else if (createStrategy == CreateStrategy.CreateDraftFromPublished)
                        {
                            var latestWebPageUrlPath = Provider<WebPageUrlPathInfo>.Instance.Get()
                                .WhereEquals(nameof(WebPageUrlPathInfo.WebPageUrlPathWebPageItemID), webPageItemInfo.WebPageItemID)
                                .WhereEquals(nameof(WebPageUrlPathInfo.WebPageUrlPathContentLanguageID), contentLanguageInfo.ContentLanguageID)
                                .WhereEquals(nameof(WebPageUrlPathInfo.WebPageUrlPathWebsiteChannelID), webSiteChannel.WebsiteChannelID)
                                .First();
                            latestWebPageUrlPath.WebPageUrlPathIsLatest = false;
                            pagePathAdapter.ProviderProxy.Save(latestWebPageUrlPath, webPageUrlPathModelBase());

                            modelsToSet.Add(webPageUrlPathModelBase().Apply(x =>
                            {
                                x.WebPageUrlPathGUID = Guid.NewGuid();
                                x.WebPageUrlPathIsLatest = true;
                                x.WebPageUrlPathIsDraft = true;
                            }));
                        }
                        else
                        {
                            throw new NotImplementedException($"Create strategy {createStrategy} not supported");
                        }

                        foreach (var model in modelsToSet)
                        {
                            var webPageUrlPathInfo = (WebPageUrlPathInfo)pagePathAdapter.Adapt(model);
                            pagePathAdapter.ProviderProxy.Save(webPageUrlPathInfo, model);
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

    private static CreateStrategy GetCreateStrategy(VersionStatus? currentVersion, VersionStatus importedVersion)
    {
        if (importedVersion == VersionStatus.Draft)
        {
            if (currentVersion.HasValue)
            {
                return currentVersion.Value switch
                {
                    VersionStatus.Draft => CreateStrategy.CreateOrUpdate,   // latest version will be updated
                    VersionStatus.Published => CreateStrategy.CreateDraftFromPublished,  // draft will be updated
                    _ => throw new InvalidOperationException($"Draft cannot be created from {currentVersion.Value}. Only creating from {nameof(VersionStatus.Published)} or updating existing draft is supported")
                };
            }
            else
            {
                throw new InvalidOperationException($"Draft cannot be created when the item doesn't exist. Create {nameof(VersionStatus.Published)} version first.");
            }
        }
        else if (importedVersion == VersionStatus.Published)
        {
            if (currentVersion.HasValue)
            {
                return currentVersion.Value switch
                {
                    VersionStatus.InitialDraft => CreateStrategy.PublishFromInitialDraft,
                    VersionStatus.Draft => CreateStrategy.PublishFromDraft,
                    VersionStatus.Published => CreateStrategy.CreateOrUpdate,
                    _ => throw new InvalidOperationException($"Content item imported version status \"{currentVersion}\" is not supported while the item already exists")
                };
            }
            else
            {
                return CreateStrategy.CreateOrUpdate;
            }
        }
        else
        {
            if (!currentVersion.HasValue || currentVersion == importedVersion)
            {
                return CreateStrategy.CreateOrUpdate;
            }
        }

        return CreateStrategy.Unspecified;
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
