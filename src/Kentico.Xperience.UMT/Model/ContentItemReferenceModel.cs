using System.ComponentModel.DataAnnotations;
using CMS.ContentEngine.Internal;
using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global // used implicitly

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// 
/// </summary>
/// <sample>ContentItemReferenceModel.Sample.Article.enUS.WithRelations</sample>
/// <sample>ContentItemReferenceModel.Sample.Article.enGB.WithRelations</sample>
[UmtModel(DISCRIMINATOR)]
public class ContentItemReferenceModel : UmtModel
{
    public const string DISCRIMINATOR = "ContentItemReference";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? ContentItemReferenceGUID { get; set; }

    [Required]
    [ReferenceProperty(typeof(ContentItemCommonDataInfo), "ContentItemReferenceSourceCommonDataID", IsRequired = true)]
    public Guid? ContentItemReferenceSourceCommonDataGuid { get; set; }

    [Required]
    [ReferenceProperty(typeof(ContentItemInfo), "ContentItemReferenceTargetItemID", IsRequired = true)]
    public Guid? ContentItemReferenceTargetItemGuid { get; set; }

    [Map]
    [Required]
    public Guid? ContentItemReferenceGroupGUID { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (ContentItemReferenceGUID, NOT_AVAILABLE, NOT_AVAILABLE);
}
