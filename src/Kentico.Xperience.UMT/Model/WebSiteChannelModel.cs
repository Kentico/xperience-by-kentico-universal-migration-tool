using System.ComponentModel.DataAnnotations;
using CMS.ContentEngine;
using CMS.DataEngine;
using CMS.Websites;
using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents EmailChannel
/// </summary>
/// <sample>websitechannels.sample</sample>
[UmtModel(DISCRIMINATOR)]
public class WebsiteChannelModel : ChannelModel
{
    public const string DISCRIMINATOR = "WebSiteChannel";

    [Required]
    [UniqueIdProperty]
    //[ReferenceProperty(typeof(DataClassInfo), "NodeClassID", IsRequired = true)]
    public Guid? WebsiteChannelGuid { get; set; }
    
    // example of extended settings [ReferenceProperty(typeof(ChannelInfo), "WebsiteChannelChannelID", IsRequired = true, SearchedField = "WebsiteChannelChannelGUID", ValueField = "WebsiteChannelChannelID")]
    [ReferenceProperty(typeof(ChannelInfo), "WebsiteChannelChannelID", IsRequired = true)]
    public Guid? WebsiteChannelChannelGuid { get; set; }

    [Map]
    [Required]
    public string? WebsiteChannelDomain { get; set; }

    [Map]
    public string? WebsiteChannelHomePage { get; set; }

    [Map]
    [Required]
    [ReferenceProperty(typeof(ContentLanguageInfo), "WebsiteChannelPrimaryContentLanguageID", IsRequired = true)]
    public Guid? WebsiteChannelPrimaryContentLanguageGuid { get; set; }

    // TODO tomas.krch: 2023-11-02 CookieLevelConstants.ALL
    [Map]
    [Required]
    public int? WebsiteChannelDefaultCookieLevel { get; set; }

    [Map]
    public bool? WebsiteChannelStoreFormerUrls { get; set; }
}
