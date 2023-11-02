using CMS.Websites;
using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class WebSiteChannelSamples
{
    [Sample("websitechannels.sample", "This sample describes how to create class inside XbyK to hold WebSiteChannel language data", "WebSiteChannel Sample")]
    public static WebsiteChannelModel SampleWebSiteChannel => new()
    {
        WebsiteChannelGUID = Guid.NewGuid(),
        WebsiteChannelDefaultCookieLevel = CookieLevelConstants.ALL,
        WebsiteChannelDomain = "samplewebsitedomain.com",
        WebsiteChannelChannelGuid = ChannelSamples.WEBSITE_CHANNEL_SAMPLE_GUID,
        WebsiteChannelHomePage = "home",
        WebsiteChannelPrimaryContentLanguageGuid = new Guid("FD0A0727-FC68-4936-B868-119DF0F0AD7A"),
        WebsiteChannelStoreFormerUrls = false
    };
}
