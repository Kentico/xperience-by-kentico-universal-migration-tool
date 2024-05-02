using System.ComponentModel.DataAnnotations;
using CMS.ContentEngine;
using CMS.DataEngine;
using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// 
/// </summary>
/// <sample>ContentItemModel.Sample.Article</sample>
/// <sample>ContentItemModel.Sample.Faq</sample>
/// <sample>ContentItemModel.Sample.Article.WithRelations</sample>
[UmtModel(DISCRIMINATOR)]
public class ContentItemModel : UmtModel
{
    public const string DISCRIMINATOR = "ContentItem";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? ContentItemGUID { get; set; }

    /// <summary>
    /// reference to content folder
    /// </summary>
    [ReferenceProperty(typeof(ContentFolderInfo), "ContentItemContentFolderID", IsRequired = false)]
    public Guid? ContentItemContentFolderGUID { get; set; }
    
    [Map]
    [Required]
    public string? ContentItemName { get; set; }

    [Map]
    [Required]
    public bool? ContentItemIsReusable { get; set; }

    [Map]
    public bool? ContentItemIsSecured { get; set; } = false;

    [ReferenceProperty(typeof(DataClassInfo), "ContentItemContentTypeID", IsRequired = false)]
    public Guid? ContentItemDataClassGuid { get; set; }

    [ReferenceProperty(typeof(ChannelInfo), "ContentItemChannelID", IsRequired = false)]
    public Guid? ContentItemChannelGuid { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (ContentItemGUID, ContentItemName, NOT_AVAILABLE);
}
