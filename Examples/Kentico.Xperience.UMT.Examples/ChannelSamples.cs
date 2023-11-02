using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class ChannelSamples
{
    public static readonly Guid EMMAIL_CHANNEL_SAMPLE_GUID = Guid.NewGuid();
    public static readonly Guid WEBSITE_CHANNEL_SAMPLE_GUID = Guid.NewGuid();

    [Sample("emailchannelchannel.sample", "This sample describes how to create class inside XbyK to hold Channel data to be used with EmailChannel data", "Channel Sample for Email Channel Sample")]
    public static ChannelModel SampleChannelForEmailChannel => new()
    {
        ChannelGUID = EMMAIL_CHANNEL_SAMPLE_GUID,
        ChannelDisplayName = "ChannelForEmailChannelExample",
        ChannelName = "ChannelForEmailChannelExampleNotDisplayed",
        ChannelType = CMS.ContentEngine.ChannelType.Email
    };

    [Sample("websitechannelchannel.sample", "This sample describes how to create class inside XbyK to hold Channel data to be used with WebSiteChannel data", "Channel Sample for WebSite Channel Sample")]
    public static ChannelModel SampleChannelForWebSiteChannel => new()
    {
        ChannelGUID = WEBSITE_CHANNEL_SAMPLE_GUID,
        ChannelDisplayName = "ChannelForWebSiteChannelExample",
        ChannelName = "ChannelForWebSiteChannelExampleNotDisplayed",
        ChannelType = CMS.ContentEngine.ChannelType.Website
    };
}
