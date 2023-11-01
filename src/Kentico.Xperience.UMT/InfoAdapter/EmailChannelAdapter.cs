using CMS.ContentEngine;
using CMS.DataEngine.Internal;
using CMS.EmailLibrary;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Services.Model;
using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class EmailChannelAdapter : GenericInfoAdapter<EmailChannelInfo>
{
    internal EmailChannelAdapter(ILogger<EmailChannelAdapter> logger, UmtModelService modelService, IProviderProxy providerProxy, IProviderProxyFactory providerProxyFactory) : base(logger, modelService, providerProxy, providerProxyFactory)
    { 
    }

    public override EmailChannelInfo Adapt(IUmtModel input)
    {
        if (input is EmailChannelModel)
        {
            var provider = Provider<ChannelInfo>.Instance;
            var adapted = base.Adapt(input);
            var channelModel = (ChannelModel)input;

            var existing = provider.Get().WithGuid(channelModel.ChannelGUID).FirstOrDefault();

            if (existing != null)
            {
                if (existing is ChannelInfo)
                {
                    logger.LogTrace("ChannelInfo {Guid} exists", channelModel.ChannelGUID);
                }
                else
                {
                    logger.LogError("Returned object of type '{ReturnedType}' is not assignable to wanted type '{WantedType}'", existing.GetType().FullName, typeof(ChannelInfo).FullName);
                    throw new InvalidOperationException($"Returned object of type '{existing.GetType().FullName}' is not assignable to wanted type '{typeof(ChannelInfo).FullName}'");
                }
            }
            else
            {
                var channelInfo = new ChannelInfo
                {
                    ChannelDisplayName = channelModel.ChannelDisplayName,
                    ChannelName = channelModel.ChannelName,
                    ChannelType = ChannelType.Email,
                    ChannelGUID = channelModel.ChannelGUID
                };

                
                provider.Set(channelInfo);

                existing = provider.Get().WithGuid(channelModel.ChannelGUID).FirstOrDefault();
            }

            adapted.EmailChannelChannelID = ((ChannelInfo)existing).ChannelID;
            return adapted;
        }
        else
        {
            throw new InvalidOperationException($"Invalid adapter for model");
        }
    }
}
