using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class ChannelSamples
{
    public static readonly Guid EMMAIL_CHANNEL_SAMPLE_GUID = new Guid("FC847362-E4B0-40AE-8235-F20098DAF09F");
    public static readonly Guid WEBSITE_CHANNEL_SAMPLE_GUID = new Guid("5322A379-5B5F-4220-9383-8E3115E66CD3");

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
}
