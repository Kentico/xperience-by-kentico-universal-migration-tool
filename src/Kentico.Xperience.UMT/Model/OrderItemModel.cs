using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

using CMS.Commerce;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

[UmtModel(DISCRIMINATOR)]
[Experimental("UMTExperimentalModelOrderItem")]
public class OrderItemModel : UmtModel
{
    public const string DISCRIMINATOR = "OrderItem";

    [UniqueIdProperty]
    [Required]
    public Guid? OrderItemGUID { get; set; }

    [ReferenceProperty(typeof(OrderInfo), "OrderItemOrderID", IsRequired = true)]
    [Required]
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
