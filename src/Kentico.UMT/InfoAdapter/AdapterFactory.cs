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

    public AdapterFactory(ILoggerFactory loggerFactory, UmtModelService modelService)
    {
        this.loggerFactory = loggerFactory;
        this.modelService = modelService;
    }

    internal IInfoAdapter<IUmtModel>? CreateAdapter(IUmtModel umtModel, ProviderProxyContext providerProxyContext) =>
        umtModel switch
        {
            UserInfoModel => new GenericInfoAdapter<UserInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<UserInfo>>(), modelService, ProviderProxyFactory.CreateProviderProxy<UserInfo>(providerProxyContext)),
            TreeNodeModel => new GenericInfoAdapter<TreeNode>(loggerFactory.CreateLogger<GenericInfoAdapter<TreeNode>>(), modelService, ProviderProxyFactory.CreateProviderProxy<TreeNode>(providerProxyContext)),
            DataClassModel => new DataClassAdapter(loggerFactory.CreateLogger<DataClassAdapter>(), modelService, ProviderProxyFactory.CreateProviderProxy<DataClassInfo>(providerProxyContext)),
            _ => null
        };
}
