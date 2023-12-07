using CMS.ContentEngine.Internal;
using CMS.DataEngine;

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

        if (typeof(ContentItemDataInfo) == infoType)
        {
            return new ContentItemDataProxy(context);
        }
        
        return (IProviderProxy)(Activator.CreateInstance(typeof(ProviderProxy<>).MakeGenericType(infoType), context) ?? 
                                throw new InvalidOperationException($"Cannot create proxy for type '{infoType.FullName}'"));
    }
}
