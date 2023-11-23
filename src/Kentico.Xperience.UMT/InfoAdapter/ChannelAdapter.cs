using CMS.ContentEngine;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Services.Model;
using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class ChannelAdapter: GenericInfoAdapter<ChannelInfo>
{
    internal ChannelAdapter(ILogger<ChannelAdapter> logger, UmtModelService modelService, IProviderProxy providerProxy, IProviderProxyFactory providerProxyFactory) : base(logger, modelService, providerProxy, providerProxyFactory)
    {
    }

    protected override void SetValue(ChannelInfo current, string propertyName, object? value)
    {
        if (propertyName == nameof(ChannelInfo.ChannelType))
        {
            base.SetValue(current, propertyName, value?.ToString());            
        }
        else
        {
            base.SetValue(current, propertyName, value);    
        }
    }
}
