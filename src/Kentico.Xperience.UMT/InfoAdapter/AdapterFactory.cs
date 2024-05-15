using CMS.ContentEngine;
using CMS.ContentEngine.Internal;
using CMS.Core;
using CMS.Core.Internal;
using CMS.DataEngine;
using CMS.EmailLibrary;
using CMS.MediaLibrary;
using CMS.Membership;
using CMS.Websites;
using CMS.Websites.Internal;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Services.Model;
using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class AdapterFactory
{
    private readonly ILoggerFactory loggerFactory;
    private readonly UmtModelService modelService;
    private readonly IProviderProxyFactory providerProxyFactory;

    public AdapterFactory(ILoggerFactory loggerFactory, UmtModelService modelService, IProviderProxyFactory providerProxyFactory)
    {
        this.loggerFactory = loggerFactory;
        this.modelService = modelService;
        this.providerProxyFactory = providerProxyFactory;
    }

    internal IInfoAdapter<IUmtModel>? CreateAdapter(IUmtModel umtModel, IProviderProxyContext providerProxyContext) =>
        umtModel switch
        {
            UserInfoModel => new UserAdapter(loggerFactory.CreateLogger<UserAdapter>(), modelService, providerProxyFactory.CreateProviderProxy<UserInfo>(providerProxyContext), providerProxyFactory),
            MediaFileModel => new MediaFileAdapter(loggerFactory.CreateLogger<MediaFileAdapter>(), modelService, providerProxyFactory.CreateProviderProxy<MediaFileInfo>(providerProxyContext), providerProxyFactory),
            MediaLibraryModel => new GenericInfoAdapter<MediaLibraryInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<MediaLibraryInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<MediaLibraryInfo>(providerProxyContext), providerProxyFactory),
            ContentItemLanguageMetadataModel => new GenericInfoAdapter<ContentItemLanguageMetadataInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContentItemLanguageMetadataInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<ContentItemLanguageMetadataInfo>(providerProxyContext), providerProxyFactory),
            ContentItemCommonDataModel => new GenericInfoAdapter<ContentItemCommonDataInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContentItemCommonDataInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<ContentItemCommonDataInfo>(providerProxyContext), providerProxyFactory),
            ContentItemDataModel => new ContentItemDataAdapter(loggerFactory.CreateLogger<ContentItemDataAdapter>(), modelService, providerProxyFactory.CreateProviderProxy<ContentItemDataInfo>(providerProxyContext), providerProxyFactory),
            WebsiteChannelModel => new GenericInfoAdapter<WebsiteChannelInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<WebsiteChannelInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<WebsiteChannelInfo>(providerProxyContext), providerProxyFactory),
            EmailChannelModel => new GenericInfoAdapter<EmailChannelInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<EmailChannelInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<EmailChannelInfo>(providerProxyContext), providerProxyFactory),
            ChannelModel => new GenericInfoAdapter<ChannelInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ChannelInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<ChannelInfo>(providerProxyContext), providerProxyFactory),
            ContentLanguageModel => new GenericInfoAdapter<ContentLanguageInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContentLanguageInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<ContentLanguageInfo>(providerProxyContext), providerProxyFactory),
            ContentItemModel => new GenericInfoAdapter<ContentItemInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContentItemInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<ContentItemInfo>(providerProxyContext), providerProxyFactory),
            WebPageItemModel => new GenericInfoAdapter<WebPageItemInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<WebPageItemInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<WebPageItemInfo>(providerProxyContext), providerProxyFactory),
            WebPageUrlPathModel => new WebPageUrlPathAdapter(loggerFactory.CreateLogger<WebPageUrlPathAdapter>(), modelService, providerProxyFactory.CreateProviderProxy<WebPageUrlPathInfo>(providerProxyContext), providerProxyFactory),
            DataClassModel => new DataClassAdapter(loggerFactory.CreateLogger<DataClassAdapter>(), modelService, providerProxyFactory.CreateProviderProxy<DataClassInfo>(providerProxyContext), providerProxyFactory),
            ContentTypeChannelModel => new GenericInfoAdapter<ContentTypeChannelInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContentTypeChannelInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<ContentTypeChannelInfo>(providerProxyContext), providerProxyFactory),
            ContentItemReferenceModel => new GenericInfoAdapter<ContentItemReferenceInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContentItemReferenceInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<ContentItemReferenceInfo>(providerProxyContext), providerProxyFactory),
            ContentFolderModel => new ContentFolderAdapter(loggerFactory.CreateLogger<ContentFolderAdapter>(), modelService, providerProxyFactory.CreateProviderProxy<ContentFolderInfo>(providerProxyContext), providerProxyFactory),
            TaxonomyModel => new TaxonomyAdapter(loggerFactory.CreateLogger<TaxonomyAdapter>(), modelService, providerProxyFactory.CreateProviderProxy<TaxonomyInfo>(providerProxyContext), providerProxyFactory),
            TagModel => new TagAdapter(loggerFactory.CreateLogger<TagAdapter>(), modelService, providerProxyFactory.CreateProviderProxy<TagInfo>(providerProxyContext), providerProxyFactory),
            
            // macro models
            ContentItemSimplifiedModel => new ContentItemSimplifiedAdapter(providerProxyFactory.CreateProviderProxy<ContentItemInfo>(providerProxyContext), providerProxyFactory, Service.Resolve<IDateTimeNowService>(), this, loggerFactory.CreateLogger<ContentItemSimplifiedAdapter>()),
            _ => null,
        };
}

