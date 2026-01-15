using System.ComponentModel.DataAnnotations;

using CMS.Commerce;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK OrderPromotionInfo.
/// </summary>
/// <seealso cref="OrderPromotionInfo"/>
[UmtModel(DISCRIMINATOR)]
public class OrderPromotionModel : UmtModel
{
    public const string DISCRIMINATOR = "OrderPromotion";

    [ReferenceProperty(typeof(PromotionInfo), nameof(OrderPromotionInfo.OrderPromotionPromotionID), IsRequired = false)]
    [UniqueKeyPart(nameof(OrderPromotionInfo.OrderPromotionPromotionID), typeof(PromotionInfo))]
    public Guid? OrderPromotionPromotionGUID { get; set; }

    [Required]
    [ReferenceProperty(typeof(OrderInfo), nameof(OrderPromotionInfo.OrderPromotionOrderID), IsRequired = true)]
    [UniqueKeyPart(nameof(OrderPromotionInfo.OrderPromotionOrderID), typeof(OrderInfo))]
    public Guid? OrderPromotionOrderGUID { get; set; }

    [ReferenceProperty(typeof(OrderItemInfo), nameof(OrderPromotionInfo.OrderPromotionOrderItemID), IsRequired = false)]
    [UniqueKeyPart(nameof(OrderPromotionInfo.OrderPromotionOrderItemID), typeof(OrderItemInfo))]
    public Guid? OrderPromotionOrderItemGUID { get; set; }

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
