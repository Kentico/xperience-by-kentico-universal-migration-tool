using CMS.ContentEngine;
using CMS.ContentEngine.Internal;
using CMS.DataEngine;
using CMS.EmailLibrary;
using CMS.MediaLibrary;
// using CMS.DocumentEngine; => obsolete
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

    internal IInfoAdapter<IUmtModel>? CreateAdapter(IUmtModel umtModel, ProviderProxyContext providerProxyContext) =>
        umtModel switch
        {
            UserInfoModel => new GenericInfoAdapter<UserInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<UserInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<UserInfo>(providerProxyContext), providerProxyFactory),
            // TODO tomas.krch: 2023-09-05 migration v27: obsolete
            // TreeNodeModel => new TreeNodeAdapter(loggerFactory.CreateLogger<TreeNodeAdapter>(), modelService, providerProxyFactory.CreateProviderProxy<TreeNode>(providerProxyContext), providerProxyFactory),
            MediaFileModel => new MediaFileAdapter(loggerFactory.CreateLogger<MediaFileAdapter>(), modelService, providerProxyFactory.CreateProviderProxy<MediaFileInfo>(providerProxyContext), providerProxyFactory),
            MediaLibraryModel => new GenericInfoAdapter<MediaLibraryInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<MediaLibraryInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<MediaLibraryInfo>(providerProxyContext), providerProxyFactory),
            ContentItemLanguageMetadataModel => new GenericInfoAdapter<ContentItemLanguageMetadataInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContentItemLanguageMetadataInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<ContentItemLanguageMetadataInfo>(providerProxyContext), providerProxyFactory),
            //ContentItemLanguageMetadataModel => new ContentItemLanguageMetadataAdapter(loggerFactory.CreateLogger<ContentItemLanguageMetadataAdapter>(), modelService, providerProxyFactory.CreateProviderProxy<ContentItemLanguageMetadataInfo>(providerProxyContext), providerProxyFactory),
            ContentItemCommonDataModel => new ContentItemCommonDataAdapter(loggerFactory.CreateLogger<ContentItemCommonDataAdapter>(), modelService, providerProxyFactory.CreateProviderProxy<ContentItemCommonDataInfo>(providerProxyContext), providerProxyFactory),
            WebsiteChannelModel => new GenericInfoAdapter<WebsiteChannelInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<WebsiteChannelInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<WebsiteChannelInfo>(providerProxyContext), providerProxyFactory),
            EmailChannelModel => new GenericInfoAdapter<EmailChannelInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<EmailChannelInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<EmailChannelInfo>(providerProxyContext), providerProxyFactory),
            // ChannelModel => new GenericInfoAdapter<ChannelInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ChannelInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<ChannelInfo>(providerProxyContext), providerProxyFactory),
            ChannelModel => new ChannelAdapter(loggerFactory.CreateLogger<ChannelAdapter>(), modelService, providerProxyFactory.CreateProviderProxy<ChannelInfo>(providerProxyContext), providerProxyFactory),
            ContentLanguageModel => new GenericInfoAdapter<ContentLanguageInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContentLanguageInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<ContentLanguageInfo>(providerProxyContext), providerProxyFactory),
            ContentItemModel => new GenericInfoAdapter<ContentItemInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContentItemInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<ContentItemInfo>(providerProxyContext), providerProxyFactory),
            WebPageItemModel => new GenericInfoAdapter<WebPageItemInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<WebPageItemInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<WebPageItemInfo>(providerProxyContext), providerProxyFactory),
            WebPageUrlPathModel => new GenericInfoAdapter<WebPageUrlPathInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<WebPageUrlPathInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<WebPageUrlPathInfo>(providerProxyContext), providerProxyFactory),
            DataClassModel => new DataClassAdapter(loggerFactory.CreateLogger<DataClassAdapter>(), modelService, providerProxyFactory.CreateProviderProxy<DataClassInfo>(providerProxyContext), providerProxyFactory),
            _ => null,
        };
}
