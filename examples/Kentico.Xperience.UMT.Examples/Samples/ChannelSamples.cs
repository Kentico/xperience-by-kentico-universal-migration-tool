using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class ChannelSamples
{
    public static readonly Guid EMMAIL_CHANNEL_SAMPLE_GUID = new("FC847362-E4B0-40AE-8235-F20098DAF09F");
    public static readonly Guid WEBSITE_CHANNEL_SAMPLE_GUID = new("5322A379-5B5F-4220-9383-8E3115E66CD3");

    [Sample("emailchannelchannel.sample", "This sample describes how to create class inside XbyK to hold Channel data to be used with EmailChannel data", "Channel Sample for Email Channel Sample")]
    public static ChannelModel SampleChannelForEmailChannel => new()
    {
        ChannelGUID = EMMAIL_CHANNEL_SAMPLE_GUID,
        ChannelDisplayName = "email Channel Example",
        ChannelName = "emailChannelExampleBasic",
        ChannelType = CMS.ContentEngine.ChannelType.Email
    };

    [Sample("websitechannelchannel.sample", "This sample describes how to create class inside XbyK to hold Channel data to be used with WebSiteChannel data", "Channel Sample for WebSite Channel Sample")]
    public static ChannelModel SampleChannelForWebSiteChannel => new()
    {
        ChannelGUID = WEBSITE_CHANNEL_SAMPLE_GUID,
        ChannelDisplayName = "website Channel Example",
        ChannelName = "websitechannelExample",
        ChannelType = CMS.ContentEngine.ChannelType.Website
    };

    public static readonly Guid LANGUAGE_DOMAINS_CHANNEL_SAMPLE_GUID = new("0B41BF6E-9D8F-45F0-A9B3-8218CA733FE1");

    [Sample("websitechannelchannel.lsd.sample", "This sample describes how to create class inside XbyK to hold Channel data to be used with a WebSiteChannel routed by language-specific domains", "Channel Sample for WebSite Channel with language-specific domains")]
    public static ChannelModel SampleChannelForLanguageDomainsWebSiteChannel => new()
    {
        ChannelGUID = LANGUAGE_DOMAINS_CHANNEL_SAMPLE_GUID,
        ChannelDisplayName = "website Channel with language domains Example",
        ChannelName = "websitechannelLanguageDomainsExample",
        ChannelType = CMS.ContentEngine.ChannelType.Website
    };
}
