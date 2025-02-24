using System.ComponentModel.DataAnnotations;

using CMS.Websites;
using CMS.Websites.Internal;

using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK WebPageScopeInfo
/// </summary>
[UmtModel(DISCRIMINATOR)]
public class WebPageScopeModel : UmtModel
{
    public const string DISCRIMINATOR = "WebPageScope";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? WebPageScopeGUID { get; set; }

    [Required]
    [ReferenceProperty(typeof(WebsiteChannelInfo), "WebPageScopeWebsiteChannelID", IsRequired = true)]
    public Guid? WebPageScopeWebsiteChannelGuid { get; set; }

    [ReferenceProperty(typeof(WebPageItemInfo), "WebPageScopeWebPageItemID", IsRequired = false)]
    public Guid? WebPageScopeWebPageItemGuid { get; set; }

    [Map]
    [Required]
    public bool? WebPageScopeIncludeChildren { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (WebPageScopeGUID, NOT_AVAILABLE, NOT_AVAILABLE);
}
