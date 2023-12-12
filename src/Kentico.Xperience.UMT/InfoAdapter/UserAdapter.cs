using CMS.Membership;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Services.Model;
using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class UserAdapter: GenericInfoAdapter<UserInfo>
{
    internal UserAdapter(ILogger<UserAdapter> logger, UmtModelService modelService, IProviderProxy providerProxy, IProviderProxyFactory providerProxyFactory) : base(logger, modelService, providerProxy, providerProxyFactory)
    {
    }

    protected override void SetValue(UserInfo current, string propertyName, object? value)
    {
        if (propertyName == "UserPassword")
        {
            current.SetValue("UserPassword", value);
        }
        else
        {
            base.SetValue(current, propertyName, value);    
        }
    }
}
