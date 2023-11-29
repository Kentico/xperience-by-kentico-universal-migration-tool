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

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (WebPageUrlPathGUID, WebPageUrlPath, NOT_AVAILABLE);
}
