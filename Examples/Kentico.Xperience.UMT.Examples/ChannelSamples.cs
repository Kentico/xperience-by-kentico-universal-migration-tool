using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class ChannelSamples
{
    [Sample("emailchannelchannel.sample", "Channel for EmailChannel", "Sample")]
    public static ChannelModel SampleChannelForEmailChannel => new()
    {
        ChannelGUID = Guid.NewGuid(),
        ChannelDisplayName = "absoluteluz11Newemailchannelllllll",
        ChannelName = "abs11Newexampleemailchannellllll",
        ChannelType = CMS.ContentEngine.ChannelType.Email
    };

    [Sample("websitechannelchannel.sample", "Channel for WebSiteChannel", "Sample")]
    public static ChannelModel SampleChannelForWebSiteChannel => new()
    {
        ChannelGUID = Guid.NewGuid(),
        ChannelDisplayName = "Newwebsitechannelll",
        ChannelName = "Newexamplewebsitechannelll",
        ChannelType = CMS.ContentEngine.ChannelType.Website
    };
}
