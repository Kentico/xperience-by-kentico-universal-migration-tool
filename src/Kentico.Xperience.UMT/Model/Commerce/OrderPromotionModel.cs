using System.ComponentModel.DataAnnotations;

using CMS.Commerce;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model.Commerce;

/// <summary>
/// Model represents XbyK OrderPromotionInfo.
/// </summary>
/// <seealso cref="OrderPromotionInfo"/>
[UmtModel(DISCRIMINATOR)]
public class OrderPromotionModel : UmtModel
{
    public const string DISCRIMINATOR = "OrderPromotion";

    [ReferenceProperty(typeof(PromotionInfo), nameof(OrderPromotionInfo.OrderPromotionPromotionID), IsRequired = false)]
    public Guid OrderPromotionPromotionGuid { get; set; }

    [ReferenceProperty(typeof(OrderInfo), nameof(OrderPromotionInfo.OrderPromotionOrderID), IsRequired = true)]
    public Guid OrderPromotionOrderGuid { get; set; }

    [ReferenceProperty(typeof(OrderItemInfo), nameof(OrderPromotionInfo.OrderPromotionOrderItemID), IsRequired = false)]
    public Guid OrderPromotionOrderItemGuid { get; set; }

    [Map]
    [Required]
    public string? OrderPromotionPromotionDisplayName { get; set; }

    [Map]
    [Required]
    public decimal? OrderPromotionDiscountAmount { get; set; }

    [Map]
    [Required]
    public PromotionType? OrderPromotionPromotionType { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (null, null, OrderPromotionPromotionDisplayName);
}
