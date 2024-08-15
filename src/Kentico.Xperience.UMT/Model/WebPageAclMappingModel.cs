using System.ComponentModel.DataAnnotations;

using CMS.Websites.Internal;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK WebPageAclMappingInfo
/// </summary>
/// <sample>webpageitem.sample.article.aclmapping</sample>
/// <sample>webpageitem.sample.article.wr.aclmapping</sample>
[UmtModel(DISCRIMINATOR)]
public class WebPageAclMappingModel: UmtModel
{
    /// <summary>
    /// Discriminator used in serialized structures to identify model 
    /// </summary>
    public const string DISCRIMINATOR = "WebPageAclMapping";
    
    [Required]
    [UniqueKeyPart("WebPageAclMappingWebPageItemID", referencedInfoType: typeof(WebPageItemInfo))]
    [ReferenceProperty(typeof(WebPageItemInfo), "WebPageAclMappingWebPageItemID", IsRequired = true)]
    public Guid? WebPageItemGuid { get; set; }
    
    [Required]
    [UniqueKeyPart("WebPageAclMappingWebPageAclID", referencedInfoType: typeof(WebPageAclInfo))]
    [ReferenceProperty(typeof(WebPageAclInfo), "WebPageAclMappingWebPageAclID", IsRequired = true)]
    public Guid? WebPageAclGuid { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (null, $"WebPageItemGuid={WebPageItemGuid}|WebPageAclMappingGuid:{WebPageAclGuid}", null);
}
