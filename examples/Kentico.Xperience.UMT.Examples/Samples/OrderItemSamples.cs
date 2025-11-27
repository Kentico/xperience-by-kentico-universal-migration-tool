using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class OrderItemSamples
{
    public static readonly Guid SAMPLE_ORDER_ITEM_1_GUID = new("B4C5D6E7-F8A9-4012-B345-6789ABCDEF01");
    public static readonly Guid SAMPLE_ORDER_ITEM_2_GUID = new("C5D6E7F8-A9B0-4123-C456-789ABCDEF012");

    [Sample("orderitem.sample.basic", "Sample demonstrates how to create an order item", "Instance of dataclass OrderItemInfo - Sample order item")]
    public static OrderItemModel SampleOrderItem => new()
    {
        OrderItemGUID = SAMPLE_ORDER_ITEM_1_GUID,
        OrderItemOrderGUID = OrderSamples.SAMPLE_ORDER_GUID,
        OrderItemSKU = "PROD-001",
        OrderItemName = "Sample Product",
        OrderItemQuantity = 2,
        OrderItemUnitPrice = 49.99m,
        OrderItemTotalPrice = 99.98m
    };


    [Sample("orderitem.sample.second", "Sample demonstrates how to create a second order item", "Instance of dataclass OrderItemInfo - Sample second order item")]
    public static OrderItemModel SampleOrderItemSecond => new()
    {
        OrderItemGUID = SAMPLE_ORDER_ITEM_2_GUID,
        OrderItemOrderGUID = OrderSamples.SAMPLE_ORDER_GUID,
        OrderItemSKU = "PROD-002",
        OrderItemName = "Another Sample Product",
        OrderItemQuantity = 1,
        OrderItemUnitPrice = 29.99m,
        OrderItemTotalPrice = 29.99m
    };
}

