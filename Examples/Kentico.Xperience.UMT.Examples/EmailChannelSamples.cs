using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class EmailChannelSamples
{
    [Sample("emailchannels.sample", "This sample describes how to create class inside XbyK to hold EmailChannel data", "EmailChannel Sample")]
    public static EmailChannelModel SampleEmailChannel => new()
    {
        EmailChannelGUID = Guid.NewGuid(),
        EmailChannelSendingDomain = "emailChannelSendingDomainSample.com",
        EmailChannelServiceDomain = "www.emailChannelSendingDomainSample",
        EmailChannelPrimaryContentLanguageGUID = new Guid("FD0A0727-FC68-4936-B868-119DF0F0AD7A"),
        EmailChannelChannelGuid = ChannelSamples.EMMAIL_CHANNEL_SAMPLE_GUID,
    };

}
