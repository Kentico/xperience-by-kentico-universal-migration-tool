using System.ComponentModel.DataAnnotations;
using CMS.ContentEngine;
using CMS.ContentEngine.Internal;
using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

[UmtModel(DISCRIMINATOR)]
public class ContentItemCommonDataModel: UmtModel
{
    public const string DISCRIMINATOR = "ContentItemCommonData";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? ContentItemCommonDataGUID { get; set; }

    [Required]
    [ReferenceProperty(typeof(ContentItemInfo), "ContentItemCommonDataContentItemID", IsRequired = true)]
    public Guid? ContentItemCommonDataContentItemGuid { get; set; }

    [Required]
    [ReferenceProperty(typeof(ContentLanguageInfo), "ContentItemCommonDataContentLanguageID", IsRequired = true)]
    public Guid? ContentItemCommonDataContentLanguageGuid { get; set; }

    [Map]
    [Required]
    public VersionStatus? ContentItemCommonDataVersionStatus { get; set; }

    [Map]
    [Required]
    public bool? ContentItemCommonDataIsLatest { get; set; }

    [Map]
    public string? ContentItemCommonDataPageBuilderWidgets { get; set; }

    [Map]
    public string? ContentItemCommonDataPageTemplateConfiguration { get; set; }
}
