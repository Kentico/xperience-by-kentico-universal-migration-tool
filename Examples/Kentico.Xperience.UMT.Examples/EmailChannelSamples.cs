using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class EmailChannelSamples
{
    [Sample("emailchannels.sample", "This sample describes how to create class inside XbyK to hold EmailChannel data", "EmailChannel Sample")]
    public static EmailChannelModel SampleEmailChannel => new()
    {
        EmailChannelGUID = new Guid("2C7309EC-1E24-4715-AE6C-8C7EFC98A4C5"),
        EmailChannelSendingDomain = "emailChannelsample.com",
        EmailChannelServiceDomain = "www.emailChannelSendingDomainSample",
        EmailChannelPrimaryContentLanguageGUID = ContentLanguageSamples.CONTENT_LANGUAGE_ENUS_SAMPLE_GUID,
        EmailChannelChannelGuid = ChannelSamples.EMMAIL_CHANNEL_SAMPLE_GUID,
    };

}
