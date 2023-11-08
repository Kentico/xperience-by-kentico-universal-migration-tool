using System.ComponentModel.DataAnnotations;
using CMS.ContentEngine;
using CMS.DataEngine;
using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

[UmtModel(DISCRIMINATOR)]
public class ContentItemModel : UmtModel
{
    public const string DISCRIMINATOR = "ContentItem";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? ContentItemGUID { get; set; }

    [Map]
    [Required]
    public string? ContentItemName { get; set; }

    [Map]
    [Required]
    public bool? ContentItemIsSecured { get; set; }

    [ReferenceProperty(typeof(DataClassInfo), "ContentItemContentTypeID", IsRequired = false)]
    public Guid? ContentItemDataClassGuid { get; set; }

    [Required]
    [ReferenceProperty(typeof(ChannelInfo), "ContentItemChannelID", IsRequired = false)]
    public Guid? ContentItemChannelGuid { get; set; }
}
