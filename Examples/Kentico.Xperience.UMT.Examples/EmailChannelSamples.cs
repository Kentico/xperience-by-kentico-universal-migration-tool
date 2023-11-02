using CMS.EmailLibrary;
using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class EmailChannelSamples
{
    [Sample("emailchannels.sample", "Sample", "Sample")]
    public static EmailChannelModel SampleEmailChannel => new()
    {
        EmailChannelGUID = Guid.NewGuid(),
        EmailChannelSendingDomain = "aaaaaaaaaaaabsolutelynew11111111111emaildomainfortryingfinalversionofsample.com",
        EmailChannelServiceDomain = "aaaaaaaaaaaaaaaaaaaabsse111111111111ndingdomainfortryingthesamethingbutdiffetrentdomain.com",
        EmailChannelPrimaryContentLanguageGUID = new Guid("FD0A0727-FC68-4936-B868-119DF0F0AD7A"),
        EmailChannelChannelGuid = new Guid("81F8E302-40A3-4286-B772-FB7405F68A08"),
    };

}
