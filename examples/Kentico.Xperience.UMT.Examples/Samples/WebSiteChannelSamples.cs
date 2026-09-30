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
        WebsiteChannelStoreFormerUrls = false,
        WebsiteChannelLanguageRoutingMode = WebsiteChannelLanguageRoutingMode.PathPrefix
    };

    public static readonly Guid LanguageDomainsWebsiteChannelGuid = new("3A6C4E10-16C1-45D7-88E5-EF6B9C1D24AB");

    [Sample("websitechannels.lsd.sample", "This sample describes how to create a WebSiteChannel that serves each language on its own domain (language-specific domains). Such channel has no database domain and no primary language - the per-language domains are configured in the application's WebsiteChannelDomainOptions", "WebSiteChannel Sample with language-specific domains")]
    public static WebsiteChannelModel SampleLanguageDomainsWebSiteChannel => new()
    {
        WebsiteChannelGUID = LanguageDomainsWebsiteChannelGuid,
        WebsiteChannelDefaultCookieLevel = CookieLevelConstants.ALL,
        WebsiteChannelChannelGuid = ChannelSamples.LANGUAGE_DOMAINS_CHANNEL_SAMPLE_GUID,
        WebsiteChannelHomePage = "home",
        WebsiteChannelStoreFormerUrls = false,
        WebsiteChannelLanguageRoutingMode = WebsiteChannelLanguageRoutingMode.LanguageDomains
    };
}
