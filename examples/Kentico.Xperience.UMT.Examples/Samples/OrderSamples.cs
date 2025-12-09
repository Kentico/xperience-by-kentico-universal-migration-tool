using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class OrderSamples
{
    public static readonly Guid SAMPLE_ORDER_GUID = new("E1F2A3B4-C5D6-4789-E012-3456789ABCDE");
    public static readonly Guid SAMPLE_ORDER_WITH_METHODS_GUID = new("F2A3B4C5-D6E7-4890-F123-456789ABCDEF");

    [Sample("order.sample.basic", "Sample demonstrates how to create an order", "Instance of OrderInfo - Sample order")]
    public static OrderModel SampleOrder => new()
    {
        OrderGUID = SAMPLE_ORDER_GUID,
        OrderNumber = "ORD-2024-001",
        OrderCreatedWhen = new DateTime(2024, 03, 15, 9, 30, 0, DateTimeKind.Utc),
        OrderModifiedWhen = new DateTime(2024, 03, 16, 9, 30, 0, DateTimeKind.Utc),
        OrderCustomerGUID = CustomerSamples.SAMPLE_CUSTOMER_GUID,
        OrderOrderStatusGUID = OrderStatusSamples.SAMPLE_ORDER_STATUS_NEW_GUID,
        OrderTotalPrice = 99.99m,
        OrderTotalShipping = 5.99m,
        OrderTotalTax = 8.00m,
        OrderGrandTotal = 113.98m,
        OrderPaymentMethodDisplayName = "Credit Card",
        OrderShippingMethodDisplayName = "Standard Shipping",
        OrderShippingMethodPrice = 5.99m
    };


    [Sample("order.sample.withmethods", "Sample demonstrates how to create an order with payment and shipping method references", "Instance of OrderInfo - Sample order with payment and shipping method references")]
    public static OrderModel SampleOrderWithMethods => new()
    {
        OrderGUID = SAMPLE_ORDER_WITH_METHODS_GUID,
        OrderNumber = "ORD-2024-002",
        OrderCreatedWhen = new DateTime(2024, 03, 20, 14, 15, 0, DateTimeKind.Utc),
        OrderModifiedWhen = new DateTime(2024, 03, 20, 14, 15, 0, DateTimeKind.Utc),
        OrderCustomerGUID = CustomerSamples.SAMPLE_CUSTOMER_GUID,
        OrderOrderStatusGUID = OrderStatusSamples.SAMPLE_ORDER_STATUS_NEW_GUID,
        OrderTotalPrice = 19.98m,
        OrderTotalShipping = 24.99m,
        OrderTotalTax = 1.98m,
        OrderGrandTotal = 46.94m,
        OrderPaymentMethodGUID = PaymentMethodSamples.SAMPLE_PAYMENT_METHOD_CREDIT_CARD_GUID,
        OrderShippingMethodGUID = ShippingMethodSamples.SAMPLE_SHIPPING_METHOD_EXPRESS_GUID,
        OrderShippingMethodPrice = 24.99m
    };
}
