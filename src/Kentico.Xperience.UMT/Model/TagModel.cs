using System.ComponentModel.DataAnnotations;

using CMS.ContentEngine;

using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <sample>taginfo.canephorasample</sample>
/// <sample>taginfo.ngandasample</sample>
/// <sample>taginfo.robustasample</sample>
/// <sample>taginfo.arabicasample</sample>
[UmtModel(DISCRIMINATOR)]
public class TagModel: UmtModel
{
    public const string DISCRIMINATOR = "Tag";
    
    [Map]
    [Required]
    public string? TagName { get; set; }
    
    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? TagGUID { get; set; }
    
    /// <summary>
    /// Guid of taxonomy where tag belongs
    /// </summary>
    [ReferenceProperty(typeof(TaxonomyInfo), "TagTaxonomyID", IsRequired = false)]
    public Guid? TagTaxonomyGUID { get; set; }
    
    [ReferenceProperty(typeof(TagInfo), "TagParentID", IsRequired = false)]
    public Guid? TagParentGUID { get; set; }
    
    [Map]
    public int? TagOrder { get; set; }
    
    [Map]
    [Required]
    public string? TagTitle { get; set; }
    
    [Map]
    public string? TagDescription { get; set; }
    
    /// <summary>
    /// Key of the dictionary is the <see cref="P:CMS.ContentEngine.ContentLanguageInfo.ContentLanguageGUID" />.
    /// </summary>
    public Dictionary<Guid, TagTranslationModel>? TagTranslations { get; set; }
    
    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (TagGUID, TagName, TagTitle);
}

public record TagTranslationModel(string Title, string Description);
