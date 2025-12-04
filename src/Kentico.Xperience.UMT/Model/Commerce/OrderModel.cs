using System.ComponentModel.DataAnnotations;

using CMS.Commerce;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK <see cref="OrderInfo"/>.
/// </summary>
[UmtModel(DISCRIMINATOR)]
public class OrderModel : UmtModel
{
    public const string DISCRIMINATOR = "Order";

    [Required]
    [UniqueIdProperty]
    public Guid? OrderGUID { get; set; }

    [Map]
    [Required]
    public string? OrderNumber { get; set; }

    [Map]
    [Required]
    public DateTime? OrderCreatedWhen { get; set; }

    [Map]
    [Required]
    public DateTime? OrderModifiedWhen { get; set; }

    [Required]
    [ReferenceProperty(typeof(OrderStatusInfo), "OrderOrderStatusID", IsRequired = true)]
    public Guid? OrderOrderStatusGUID { get; set; }

    [Map]
    public decimal? OrderTotalPrice { get; set; }

    [Map]
    public decimal? OrderTotalShipping { get; set; }

    [Map]
    public decimal? OrderTotalTax { get; set; }

    [Map]
    public decimal? OrderGrandTotal { get; set; }

    [Required]
    [ReferenceProperty(typeof(CustomerInfo), "OrderCustomerID", IsRequired = true)]
    public Guid? OrderCustomerGUID { get; set; }

    [ReferenceProperty(typeof(PaymentMethodInfo), "OrderPaymentMethodID")]
    public Guid? OrderPaymentMethodGUID { get; set; }

    [Map]
    public string? OrderPaymentMethodDisplayName { get; set; }

    [ReferenceProperty(typeof(ShippingMethodInfo), "OrderShippingMethodID")]
    public Guid? OrderShippingMethodGUID { get; set; }

    [Map]
    public string? OrderShippingMethodDisplayName { get; set; }

    [Map]
    public decimal? OrderShippingMethodPrice { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (OrderGUID, OrderNumber, NOT_AVAILABLE);
}
