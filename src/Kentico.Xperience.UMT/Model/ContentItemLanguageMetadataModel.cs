using System.ComponentModel.DataAnnotations;
using CMS.ContentEngine;
using CMS.ContentEngine.Internal;
using CMS.Membership;
using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// 
/// </summary>
/// <sample>contentitemlanguagemetadata.sample.article.enus</sample>
/// <sample>contentitemlanguagemetadata.sample.article.engb</sample>
/// <sample>contentitemlanguagemetadata.sample.faq.enus</sample>
/// <sample>contentitemlanguagemetadata.sample.faq.engb</sample>
/// <sample>contentitemlanguagemetadata.sample.article.enus.WithRelations</sample>
/// <sample>contentitemlanguagemetadata.sample.article.engb.WithRelations</sample>
[UmtModel(DISCRIMINATOR)]
public class ContentItemLanguageMetadataModel : UmtModel
{
    public const string DISCRIMINATOR = "ContentItemLanguageMetadata";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? ContentItemLanguageMetadataGUID { get; set; }

    [Required]
    [ReferenceProperty(typeof(ContentItemInfo), "ContentItemLanguageMetaDataContentItemID", IsRequired = true)]
    public Guid? ContentItemLanguageMetadataContentItemGuid { get; set; }

    [Map]
    [Required]
    public string? ContentItemLanguageMetadataDisplayName { get; set; }

    [Map]
    [Required]
    public VersionStatus? ContentItemLanguageMetadataLatestVersionStatus { get; set; }

    [Map]
    [Required]
    public DateTime? ContentItemLanguageMetadataCreatedWhen { get; set; }

    [ReferenceProperty(typeof(UserInfo), "ContentItemLanguageMetadataCreatedByUserID", IsRequired = false)]
    public Guid? ContentItemLanguageMetadataCreatedByUserGuid { get; set; }

    [Map]
    // [Required]
    public DateTime? ContentItemLanguageMetadataModifiedWhen { get; set; }

    [ReferenceProperty(typeof(UserInfo), "ContentItemLanguageMetadataModifiedByUserID", IsRequired = false)]
    public Guid? ContentItemLanguageMetadataModifiedByUserGuid { get; set; }

    [Map]
    [Required]
    public bool? ContentItemLanguageMetadataHasImageAsset { get; set; }

    [Required]
    [ReferenceProperty(typeof(ContentLanguageInfo), "ContentItemLanguageMetadataContentLanguageID", IsRequired = true)]
    public Guid? ContentItemLanguageMetadataContentLanguageGuid { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (ContentItemLanguageMetadataGUID, NOT_AVAILABLE, ContentItemLanguageMetadataDisplayName);
}
