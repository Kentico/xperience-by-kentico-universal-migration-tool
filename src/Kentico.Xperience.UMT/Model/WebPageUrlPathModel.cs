using System.ComponentModel.DataAnnotations;

using CMS.ContentEngine;
using CMS.Websites;
using CMS.Websites.Internal;

using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

[UmtModel(DISCRIMINATOR)]
public class WebPageUrlPathModel : UmtModel
{
    public const string DISCRIMINATOR = "WebPageUrlPath";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? WebPageUrlPathGUID { get; set; }

    [Map]
    public string? WebPageUrlPath { get; set; }

    [Map]
    public string? WebPageUrlPathHash { get; set; }

    [Required]
    [ReferenceProperty(typeof(WebPageItemInfo), "WebPageUrlPathWebPageItemID", IsRequired = true)]
    public Guid? WebPageUrlPathWebPageItemGuid { get; set; }

    [Required]
    [ReferenceProperty(typeof(WebsiteChannelInfo), "WebPageUrlPathWebsiteChannelID", IsRequired = true)]
    public Guid? WebPageUrlPathWebsiteChannelGuid { get; set; }

    [Required]
    [ReferenceProperty(typeof(ContentLanguageInfo), "WebPageUrlPathContentLanguageID", IsRequired = true)]
    public Guid? WebPageUrlPathContentLanguageGuid { get; set; }

    [Map]
    public bool? WebPageUrlPathIsLatest { get; set; }

    [Map]
    public bool? WebPageUrlPathIsDraft { get; set; }

    [Map]
    public int? WebPageUrlPathType { get; set; }

    [Map]
    public bool? WebPageUrlPathIsCanonical { get; set; }

    [ReferenceProperty(typeof(WebPageUrlPathInfo), "WebPageUrlPathRedirectWebPageFormerUrlPathID", IsRequired = false)]
    public Guid? WebPageUrlPathRedirectWebPageFormerUrlPathGUID { get; set; }

    [ReferenceProperty(typeof(WebPageUrlPathInfo), "WebPageUrlPathPublishedWebPageUrlPathID", IsRequired = false)]
    public Guid? WebPageUrlPathPublishedWebPageUrlPathGUID { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (WebPageUrlPathGUID, WebPageUrlPath, NOT_AVAILABLE);
}
