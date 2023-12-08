using System.ComponentModel.DataAnnotations;
using CMS.ContentEngine;
using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK WebSiteChannelInfo
/// </summary>
/// <sample>websitechannels.sample</sample>
[UmtModel(DISCRIMINATOR)]
public class WebsiteChannelModel : UmtModel
{
    public const string DISCRIMINATOR = "WebSiteChannel";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? WebsiteChannelGUID { get; set; }

    // example of extended settings [ReferenceProperty(typeof(ChannelInfo), "WebsiteChannelChannelID", IsRequired = true, SearchedField = "WebsiteChannelChannelGUID", ValueField = "WebsiteChannelChannelID")]
    [Required]
    [ReferenceProperty(typeof(ChannelInfo), "WebsiteChannelChannelID", IsRequired = true)]
    public Guid? WebsiteChannelChannelGuid { get; set; }

    [Map]
    [Required]
    public string? WebsiteChannelDomain { get; set; }

    [Map]
    public string? WebsiteChannelHomePage { get; set; }

    [Required]
    [ReferenceProperty(typeof(ContentLanguageInfo), "WebsiteChannelPrimaryContentLanguageID", IsRequired = true)]
    public Guid? WebsiteChannelPrimaryContentLanguageGuid { get; set; }

    [Map]
    [Required]
    public int? WebsiteChannelDefaultCookieLevel { get; set; }

    [Map]
    [Required]
    public bool? WebsiteChannelStoreFormerUrls { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (WebsiteChannelGUID, NOT_AVAILABLE, NOT_AVAILABLE);
}
