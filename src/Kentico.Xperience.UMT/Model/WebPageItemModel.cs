using System.ComponentModel.DataAnnotations;
using CMS.ContentEngine.Internal;
using CMS.Websites;
using CMS.Websites.Internal;
using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// 
/// </summary>
/// <sample>webpageitem.sample.article</sample>
/// <sample>webpageitem.sample.article.WithRelations</sample>
[UmtModel(DISCRIMINATOR)]
public class WebPageItemModel : UmtModel
{
    public const string DISCRIMINATOR = "WebPageItem";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? WebPageItemGUID { get; set; }

    [ReferenceProperty(typeof(WebPageItemInfo), "WebPageItemParentID", IsRequired = false)]
    public Guid? WebPageItemParentGuid { get; set; }

    [Map]
    [Required]
    public string? WebPageItemName { get; set; }

    [Map]
    [Required]
    public string? WebPageItemTreePath { get; set; }

    [Required]
    [ReferenceProperty(typeof(WebsiteChannelInfo), "WebPageItemWebsiteChannelID", IsRequired = true)]
    public Guid? WebPageItemWebsiteChannelGuid { get; set; }

    [Required]
    [ReferenceProperty(typeof(ContentItemInfo), "WebPageItemContentItemID", IsRequired = true)]
    public Guid? WebPageItemContentItemGuid { get; set; }

    [Map]
    [Required]
    public int? WebPageItemOrder { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (WebPageItemGUID, WebPageItemName, NOT_AVAILABLE);
}
