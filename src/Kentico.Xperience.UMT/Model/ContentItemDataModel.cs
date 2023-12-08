using System.ComponentModel.DataAnnotations;
using CMS.ContentEngine.Internal;
using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK ContentItemDataInfo
/// </summary>
/// <sample>ContentItemDataModel.Sample.Article.enUS</sample>
/// <sample>ContentItemDataModel.Sample.Article.enGB</sample>
/// <sample>ContentItemCommonDataModel.Sample.Faq.enUS</sample>
/// <sample>ContentItemCommonDataModel.Sample.Faq.enGB</sample>
/// <sample>ContentItemDataModel.Sample.Article.enUS.WithRelations</sample>
/// <sample>ContentItemDataModel.Sample.Article.enGB.WithRelations</sample>
[UmtModel(DISCRIMINATOR)]
public class ContentItemDataModel: UmtModel
{
    public const string DISCRIMINATOR = "ContentItemData";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? ContentItemDataGUID { get; set; }

    [Required]
    [ReferenceProperty(typeof(ContentItemCommonDataInfo), "ContentItemDataCommonDataID", IsRequired = true)]
    public Guid? ContentItemDataCommonDataGuid { get; set; }

    [Required]
    public string? ContentItemContentTypeName { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (ContentItemDataGUID, NOT_AVAILABLE, NOT_AVAILABLE);
}
