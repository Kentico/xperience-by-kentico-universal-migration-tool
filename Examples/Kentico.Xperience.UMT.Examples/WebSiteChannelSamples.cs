using CMS.Base;
using CMS.Helpers;
using CMS.Websites;
using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class WebSiteChannelSamples
{
    [Sample("websitechannels.sample", "Sample", "Sample")]
    public static WebsiteChannelModel SampleWebSiteChannel => new()
    {
        WebsiteChannelGUID = Guid.NewGuid(),
        WebsiteChannelDefaultCookieLevel = CookieLevelConstants.ALL,
        WebsiteChannelDomain = "examplewebsitedomain.sk",
        WebsiteChannelChannelGuid = new Guid("08E00761-2CD3-40F8-9A21-C97060DA30FF"),
        WebsiteChannelHomePage = "home",
        WebsiteChannelPrimaryContentLanguageGuid = new Guid("FD0A0727-FC68-4936-B868-119DF0F0AD7A"),
        WebsiteChannelStoreFormerUrls = false
    };
}
