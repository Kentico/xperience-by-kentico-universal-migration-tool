using System.ComponentModel.DataAnnotations;

using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <sample>taxonomyinfo.coffeesample</sample>
[UmtModel(DISCRIMINATOR)]
public class TaxonomyModel: UmtModel
{
    public const string DISCRIMINATOR = "Taxonomy";
    
    [Map]
    [Required]
    public string? TaxonomyName { get; set; }
    
    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? TaxonomyGUID { get; set; }
    
    [Map]
    [Required]
    public string? TaxonomyTitle { get; set; }
    
    [Map]
    public string? TaxonomyDescription { get; set; }
    
    /// <summary>
    /// Key of the dictionary is the <see cref="P:CMS.ContentEngine.ContentLanguageInfo.ContentLanguageGUID" />.
    /// </summary>
    public Dictionary<Guid, TaxonomyTranslationModel>? TaxonomyTranslations { get; set; }
    
    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (TaxonomyGUID, TaxonomyName, TaxonomyTitle);
}

public record TaxonomyTranslationModel(string Title);
