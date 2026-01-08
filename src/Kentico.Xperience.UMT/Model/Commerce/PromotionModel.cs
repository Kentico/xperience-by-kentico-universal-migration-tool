using System.ComponentModel.DataAnnotations;

using CMS.Commerce;
using CMS.Membership;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

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

    [ReferenceProperty(typeof(UserInfo), nameof(PromotionInfo.PromotionCreatedByUserID), IsRequired = false)]
    public Guid? PromotionCreatedByUserGUID { get; set; }

    [Map]
    [Required]
    public DateTime? PromotionModifiedWhen { get; set; }

    [ReferenceProperty(typeof(UserInfo), nameof(PromotionInfo.PromotionModifiedByUserID), IsRequired = false)]
    public Guid? PromotionModifiedByUserGUID { get; set; }

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
