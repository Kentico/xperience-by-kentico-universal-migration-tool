using System.ComponentModel.DataAnnotations;

using CMS.Websites;
using CMS.Websites.Internal;

using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK WebPageAclInfo
/// </summary>
/// <sample>webpageitem.sample.article.acl</sample>
/// <sample>webpageitem.sample.article.wr.aclmapping</sample>
[UmtModel(DISCRIMINATOR)]
public class WebPageAclModel: UmtModel
{
    /// <summary>
    /// Discriminator used in serialized structures to identify model 
    /// </summary>
    public const string DISCRIMINATOR = "WebPageAcl";
    
    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? WebPageAclGUID { get; set; }
    
    [Required]
    [ReferenceProperty(typeof(WebsiteChannelInfo), "WebPageAclWebsiteChannelID", IsRequired = true)]
    public Guid? WebPageAclWebsiteChannelGUID { get; set; }
    
    [Required]
    [ReferenceProperty(typeof(WebPageItemInfo), "WebPageAclWebPageItemID", IsRequired = true)]
    public Guid? WebPageAclWebPageItemGUID { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (WebPageAclGUID, null, null);
}
