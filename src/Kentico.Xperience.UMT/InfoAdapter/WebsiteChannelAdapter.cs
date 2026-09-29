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

    protected override void SetValue(WebsiteChannelInfo current, string propertyName, object? value)
    {
        // null means "not specified" - reflection would coerce it to default (PathPrefix) and reset an existing channel's routing mode on reimport
        if (propertyName == nameof(WebsiteChannelInfo.WebsiteChannelLanguageRoutingMode) && value is null)
        {
            return;
        }

        base.SetValue(current, propertyName, value);
    }

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
