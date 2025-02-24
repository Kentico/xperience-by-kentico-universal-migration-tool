using CMS.DataEngine;
using CMS.Websites;
using CMS.Websites.Internal;

using Kentico.Xperience.UMT.Model;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class WebsiteChannelAdapter : GenericInfoAdapter<WebsiteChannelInfo>
{
    private readonly IInfoProvider<WebPageScopeInfo> webPageScopeInfoProvider;

    internal WebsiteChannelAdapter(IInfoProvider<WebPageScopeInfo> webPageScopeInfoProvider, ILogger<WebsiteChannelAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext) => this.webPageScopeInfoProvider = webPageScopeInfoProvider;

    public override void Postprocess(IUmtModel model, BaseInfo baseInfo)
    {
        base.Postprocess(model, baseInfo);

        var autoScopeInfo = webPageScopeInfoProvider.Get().WhereEquals(nameof(WebPageScopeInfo.WebPageScopeWebsiteChannelID), (baseInfo as WebsiteChannelInfo)!.WebsiteChannelID).FirstOrDefault();
        if (autoScopeInfo is not null)
        {
            webPageScopeInfoProvider.Delete(autoScopeInfo);
        }
    }
}
