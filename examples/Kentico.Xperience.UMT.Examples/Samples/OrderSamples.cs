using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class OrderSamples
{
    public static readonly Guid SAMPLE_ORDER_GUID = new("E1F2A3B4-C5D6-4789-E012-3456789ABCDE");

    [Sample("order.sample.basic", "Sample demonstrates how to create an order", "Instance of dataclass OrderInfo - Sample order")]
    public static OrderModel SampleOrder => new()
    {
        OrderGUID = SAMPLE_ORDER_GUID,
        OrderNumber = "ORD-2024-001",
        OrderCreatedWhen = new DateTime(2024, 03, 15, 9, 30, 0, DateTimeKind.Utc),
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
}

