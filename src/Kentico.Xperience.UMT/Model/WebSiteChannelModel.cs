using System.ComponentModel.DataAnnotations;
using CMS.DataEngine;
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

    [Map]
    [Required]
    public string? WebsiteChannelDomain { get; set; }

    [Map]
    public string? WebsiteChannelHomePage { get; set; }

    [Map]
    [Required]
    public int WebsiteChannelPrimaryContentLanguageID { get; set; }

    [Map]
    [Required]
    public int WebsiteChannelDefaultCookieLevel { get; set; }

    [Map]
    public bool WebsiteChannelStoreFormerUrls { get; set; }
}
