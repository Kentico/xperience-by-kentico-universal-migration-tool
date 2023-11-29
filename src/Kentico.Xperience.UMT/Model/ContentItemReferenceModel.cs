using System.ComponentModel.DataAnnotations;
using CMS.ContentEngine.Internal;
using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

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

    //TODO check if target item is ContentItem
    [Required]
    [ReferenceProperty(typeof(ContentItemInfo), "ContentItemReferenceTargetItemID", IsRequired = true)]
    public Guid? ContentItemReferenceTargetItemGuid { get; set; }

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? ContentItemReferenceGroupGUID { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (ContentItemReferenceGUID, NOT_AVAILABLE, NOT_AVAILABLE);
}
