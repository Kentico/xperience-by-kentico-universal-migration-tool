using System.ComponentModel.DataAnnotations;
using CMS.ContentEngine;
using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK ContentLanguageInfo
/// </summary>
/// <sample>contentlanguage.sample.en-us</sample>
/// <sample>contentlanguage.sample.en-gb</sample>
[UmtModel(DISCRIMINATOR)]
public class ContentLanguageModel : UmtModel
{
    public const string DISCRIMINATOR = "ContentLanguage";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? ContentLanguageGUID { get; set; }

    [Map]
    [Required]
    public string? ContentLanguageDisplayName { get; set; }

    [Map]
    [Required]
    public string? ContentLanguageName { get; set; }

    [Map]
    [Required]
    public bool? ContentLanguageIsDefault { get; set; }

    [ReferenceProperty(typeof(ContentLanguageInfo), "ContentLanguageFallbackContentLanguageID", IsRequired = false)]
    public Guid? ContentLanguageFallbackContentLanguageGuid { get; set; }

    [Map]
    [Required]
    public string? ContentLanguageCultureFormat { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (ContentLanguageGUID, ContentLanguageName, ContentLanguageDisplayName);
}
