using CMS.Websites;

using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class WebSiteChannelSamples
{
    public static readonly Guid WebsiteChannelGuid = new("A6BA6FCB-9D05-4ABE-AFB4-74B153C90DB7");

    [Sample("websitechannels.sample", "This sample describes how to create class inside XbyK to hold WebSiteChannel language data", "WebSiteChannel Sample")]
    public static WebsiteChannelModel SampleWebSiteChannel => new()
    {
        WebsiteChannelGUID = WebsiteChannelGuid,
        WebsiteChannelDefaultCookieLevel = CookieLevelConstants.ALL,
        WebsiteChannelDomain = "websitesamplewebsitedomain.com",
        WebsiteChannelChannelGuid = ChannelSamples.WEBSITE_CHANNEL_SAMPLE_GUID,
        WebsiteChannelHomePage = "home",
        WebsiteChannelPrimaryContentLanguageGuid = ContentLanguageSamples.CONTENT_LANGUAGE_ENUS_SAMPLE_GUID,
        WebsiteChannelStoreFormerUrls = false
    };
}
