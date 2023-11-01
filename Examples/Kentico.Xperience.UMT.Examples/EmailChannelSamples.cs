using CMS.EmailLibrary;
using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class EmailChannelSamples
{
    [Sample("emailchannels.sample", "Sample", "Sample")]
    public static EmailChannelModel SampleEmailChannel => new()
    {
        EmailChannelGuid = Guid.NewGuid(),
        EmailChannelPrimaryContentLanguageID = 1,
        EmailChannelSendingDomain = "secondexmailexample.com",
        EmailChannelServiceDomain = "wwww.secondemailexample.com",
        ChannelDisplayName = "secondemailexampledisplay",
        ChannelGUID = Guid.NewGuid(),
        ChannelName = "secondemailexamplename"
    };

}
