using System.ComponentModel.DataAnnotations;

using CMS.Commerce;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK OrderItemInfo.
/// </summary>
/// <seealso cref="OrderItemInfo"/>
[UmtModel(DISCRIMINATOR)]
public class OrderItemModel : UmtModel
{
    public const string DISCRIMINATOR = "OrderItem";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? OrderItemGUID { get; set; }

    [Required]
    [ReferenceProperty(typeof(OrderInfo), "OrderItemOrderID", IsRequired = true)]
    public Guid? OrderItemOrderGUID { get; set; }

    [Map]
    public string? OrderItemSKU { get; set; }

    [Map]
    public string? OrderItemName { get; set; }

    [Map]
    public decimal? OrderItemQuantity { get; set; }

    [Map]
    public decimal? OrderItemUnitPrice { get; set; }

    [Map]
    public decimal? OrderItemTotalPrice { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (OrderItemGUID, OrderItemName, NOT_AVAILABLE);
}
