using System.ComponentModel.DataAnnotations;

using CMS.Commerce;

using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK OrderInfo
/// </summary>
[UmtModel(DISCRIMINATOR)]
public class OrderModel : UmtModel
{
    public const string DISCRIMINATOR = "Order";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? OrderGUID { get; set; }

    [Map]
    [Required]
    public string? OrderNumber { get; set; }

    [Map]
    public DateTime? OrderCreatedWhen { get; set; }

    /// <summary>
    /// reference to customer
    /// </summary>
    [ReferenceProperty(typeof(CustomerInfo), "OrderCustomerID", IsRequired = true)]
    public Guid? OrderCustomerGUID { get; set; }

    /// <summary>
    /// reference to order status
    /// </summary>
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

    /// <summary>
    /// reference to payment method
    /// </summary>
    [ReferenceProperty(typeof(PaymentMethodInfo), "OrderPaymentMethodID", IsRequired = false)]
    public Guid? OrderPaymentMethodGUID { get; set; }

    [Map]
    public string? OrderPaymentMethodDisplayName { get; set; }

    /// <summary>
    /// reference to shipping method
    /// </summary>
    [ReferenceProperty(typeof(ShippingMethodInfo), "OrderShippingMethodID", IsRequired = false)]
    public Guid? OrderShippingMethodGUID { get; set; }

    [Map]
    public string? OrderShippingMethodDisplayName { get; set; }

    [Map]
    public decimal? OrderShippingMethodPrice { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (OrderGUID, OrderNumber, NOT_AVAILABLE);
}

