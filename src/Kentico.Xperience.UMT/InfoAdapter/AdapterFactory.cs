using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.Membership;
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
            TreeNodeModel => new TreeNodeAdapter(loggerFactory.CreateLogger<TreeNodeAdapter>(), modelService, providerProxyFactory.CreateProviderProxy<TreeNode>(providerProxyContext), providerProxyFactory),
            DataClassModel => new DataClassAdapter(loggerFactory.CreateLogger<DataClassAdapter>(), modelService, providerProxyFactory.CreateProviderProxy<DataClassInfo>(providerProxyContext), providerProxyFactory),
            _ => null
        };
}
