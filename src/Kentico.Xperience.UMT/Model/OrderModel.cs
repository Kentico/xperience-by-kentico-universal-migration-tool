using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

using CMS.Commerce;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

[UmtModel(DISCRIMINATOR)]
[Experimental("UMTExperimentalModelOrder")]
public class OrderModel : UmtModel
{
    public const string DISCRIMINATOR = "Order";

    [UniqueIdProperty]
    [Required]
    public Guid? OrderGUID { get; set; }

    [Map]
    [Required]
    public string? OrderNumber { get; set; }

    [Map]
    public DateTime? OrderCreatedWhen { get; set; }

    [Map]
    public DateTime? OrderModifiedWhen { get; set; }

    [ReferenceProperty(typeof(CustomerInfo), "OrderCustomerID", IsRequired = true)]
    [Required]
    public Guid? OrderCustomerGUID { get; set; }

    [ReferenceProperty(typeof(OrderStatusInfo), "OrderOrderStatusID", IsRequired = true)]
    [Required]
    public Guid? OrderOrderStatusGUID { get; set; }

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

    [Map]
    public decimal? OrderTotalPrice { get; set; }

    [Map]
    public decimal? OrderTotalShipping { get; set; }

    [Map]
    public decimal? OrderTotalTax { get; set; }

    [Map]
    public decimal? OrderGrandTotal { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (OrderGUID, OrderNumber, NOT_AVAILABLE);
}
