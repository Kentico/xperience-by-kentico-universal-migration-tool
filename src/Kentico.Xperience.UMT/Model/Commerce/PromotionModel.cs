using System.ComponentModel.DataAnnotations;

using CMS.Commerce;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model.Commerce;

/// <summary>
/// Model represents XbyK PromotionInfo. 
/// </summary>
/// <seealso cref="PromotionInfo"/>
[UmtModel(DISCRIMINATOR)]
public class PromotionModel : UmtModel
{
    public const string DISCRIMINATOR = "Promotion";

    [Map]
    [Required]
    public string? PromotionDisplayName { get; set; }

    [Map]
    [Required]
    public string? PromotionName { get; set; }

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? PromotionGUID { get; set; }

    [Map]
    public string? PromotionDescription { get; set; }

    [Map]
    [Required]
    public DateTime? PromotionCreatedWhen { get; set; }

    [Map]
    public int? PromotionCreatedByUserID { get; set; }

    [Map]
    [Required]
    public DateTime? PromotionModifiedWhen { get; set; }

    [Map]
    public int? PromotionModifiedByUserID { get; set; }

    [Map]
    public DateTime? PromotionActiveFromWhen { get; set; }

    [Map]
    public DateTime? PromotionActiveToWhen { get; set; }

    [Map]
    [Required]
    public PromotionType? PromotionType { get; set; }

    [Map]
    [Required]
    public string? PromotionRuleIdentifier { get; set; }

    [Map]
    [Required]
    public string? PromotionRuleConfiguration { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (PromotionGUID, PromotionName, PromotionDisplayName);
}
