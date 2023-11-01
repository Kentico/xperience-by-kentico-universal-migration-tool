using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class WebSiteChannelSamples
{
    [Sample("websitechannels.sample", "Sample", "Sample")]
    public static WebsiteChannelModel SampleWebSiteChannel => new()
    {
        WebsiteChannelGuid = Guid.NewGuid(),
        WebsiteChannelDefaultCookieLevel = 0,
        WebsiteChannelPrimaryContentLanguageID = 1,
        WebsiteChannelDomain = "ssssssssss44444444444w33e11bsi23techanneldomain.com",
        ChannelName = "4sssssss44444444444webs33i11tec3h2annelname",
        ChannelDisplayName = "4sssssssss444444444webs333i2tec11hanneldisplayedname",
        ChannelGUID = Guid.NewGuid()
    };
}
