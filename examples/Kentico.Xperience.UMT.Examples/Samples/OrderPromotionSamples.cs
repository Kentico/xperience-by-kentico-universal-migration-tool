using CMS.Commerce;

using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class OrderPromotionSamples
{
    [Sample("orderpromotion.sample.order", "Sample demonstrates how to create an order promotion applied to an entire order", "Instance of OrderPromotionInfo - Sample order level promotion")]
    public static OrderPromotionModel SampleOrderPromotionOrderLevel => new()
    {
        OrderPromotionPromotionGUID = PromotionSamples.SAMPLE_PROMOTION_ORDER_10_PERCENT_OFF_GUID,
        OrderPromotionOrderGUID = OrderSamples.SAMPLE_ORDER_GUID,
        OrderPromotionOrderItemGUID = OrderItemSamples.SAMPLE_ORDER_ITEM_2_GUID,
        OrderPromotionPromotionDisplayName = "10% Off Your Order",
        OrderPromotionDiscountAmount = 12.99m,
        OrderPromotionPromotionType = PromotionType.Order
    };


    [Sample("orderpromotion.sample.catalog", "Sample demonstrates how to create a catalog promotion applied to a specific order item", "Instance of OrderPromotionInfo - Sample catalog promotion on order item")]
    public static OrderPromotionModel SampleOrderPromotionCatalogItem => new()
    {
        OrderPromotionPromotionGUID = PromotionSamples.SAMPLE_PROMOTION_CATALOG_BUY_ONE_GET_ONE_GUID,
        OrderPromotionOrderGUID = OrderSamples.SAMPLE_ORDER_GUID,
        OrderPromotionOrderItemGUID = OrderItemSamples.SAMPLE_ORDER_ITEM_2_GUID,
        OrderPromotionPromotionDisplayName = "Buy One Get One Free",
        OrderPromotionDiscountAmount = 49.99m,
        OrderPromotionPromotionType = PromotionType.Catalog
    };
}
