using CMS.DataEngine;
// using CMS.DocumentEngine; => obsolete

namespace Kentico.Xperience.UMT.ProviderProxy;

internal interface IProviderProxyFactory
{
    IProviderProxy CreateProviderProxy<TInfo>(ProviderProxyContext context) where TInfo : BaseInfo;
    IProviderProxy CreateProviderProxy(Type? infoType, ProviderProxyContext context);
}

internal class ProviderProxyFactory : IProviderProxyFactory
{
    public IProviderProxy CreateProviderProxy<TInfo>(ProviderProxyContext context) where TInfo : BaseInfo => CreateProviderProxy(typeof(TInfo), context);

    public IProviderProxy CreateProviderProxy(Type? infoType, ProviderProxyContext context)
    {
        ArgumentNullException.ThrowIfNull(infoType, nameof(infoType));
        
        // TODO tomas.krch: 2023-09-05 migration v27: obsolete
        // if (infoType.IsAssignableTo(typeof(TreeNode)))
        // {
        //     return new TreeProviderProxy(context);
        // }

        return (IProviderProxy)(Activator.CreateInstance(typeof(ProviderProxy<>).MakeGenericType(infoType), context) ?? 
                                throw new InvalidOperationException($"Cannot create proxy for type '{infoType.FullName}'"));
    }
}
