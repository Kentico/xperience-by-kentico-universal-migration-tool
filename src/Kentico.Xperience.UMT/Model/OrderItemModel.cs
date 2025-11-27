using System.ComponentModel.DataAnnotations;

using CMS.Commerce;

using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK OrderItemInfo
/// </summary>
[UmtModel(DISCRIMINATOR)]
public class OrderItemModel : UmtModel
{
    public const string DISCRIMINATOR = "OrderItem";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? OrderItemGUID { get; set; }

    /// <summary>
    /// reference to order
    /// </summary>
    [ReferenceProperty(typeof(OrderInfo), "OrderItemOrderID", IsRequired = true)]
    public Guid? OrderItemOrderGUID { get; set; }

    [Map]
    [Required]
    public string? OrderItemSKU { get; set; }

    [Map]
    [Required]
    public string? OrderItemName { get; set; }

    [Map]
    [Required]
    public decimal? OrderItemQuantity { get; set; }

    [Map]
    [Required]
    public decimal? OrderItemUnitPrice { get; set; }

    [Map]
    [Required]
    public decimal? OrderItemTotalPrice { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (OrderItemGUID, OrderItemSKU, OrderItemName);
}

