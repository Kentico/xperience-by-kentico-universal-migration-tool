using CMS.ContentEngine;
using CMS.DataEngine;
using CMS.EmailLibrary;
// using CMS.DocumentEngine; => obsolete
using CMS.Membership;
using CMS.Websites;
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
            ChannelModel => new GenericInfoAdapter<ChannelInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ChannelInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<ChannelInfo>(providerProxyContext), providerProxyFactory),
            WebsiteChannelModel => new GenericInfoAdapter<WebsiteChannelInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<WebsiteChannelInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<WebsiteChannelInfo>(providerProxyContext), providerProxyFactory),
            EmailChannelModel => new GenericInfoAdapter<EmailChannelInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<EmailChannelInfo>>(), modelService, providerProxyFactory.CreateProviderProxy<EmailChannelInfo>(providerProxyContext), providerProxyFactory),
            DataClassModel => new DataClassAdapter(loggerFactory.CreateLogger<DataClassAdapter>(), modelService, providerProxyFactory.CreateProviderProxy<DataClassInfo>(providerProxyContext), providerProxyFactory),
            _ => null,
        };
}
