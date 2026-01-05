using CMS.Commerce;

using UmtPromotionModel = Kentico.Xperience.UMT.Model.Commerce.PromotionModel;

namespace Kentico.Xperience.UMT.Examples;

public static class PromotionSamples
{
    public static readonly Guid SAMPLE_PROMOTION_ORDER_10_PERCENT_OFF_GUID = new("D1E2F3A4-B5C6-4789-D012-3456789ABCDE");
    public static readonly Guid SAMPLE_PROMOTION_CATALOG_BUY_ONE_GET_ONE_GUID = new("E2F3A4B5-C6D7-4890-E123-456789ABCDEF");
    public static readonly Guid SAMPLE_PROMOTION_ORDER_FREE_SHIPPING_GUID = new("F3A4B5C6-D7E8-4901-F234-56789ABCDEF0");

    [Sample("promotion.sample.order", "Sample demonstrates how to create an order promotion with 10% discount", "Instance of PromotionInfo - Sample order promotion")]
    public static UmtPromotionModel SamplePromotionOrder10PercentOff => new()
    {
        PromotionGUID = SAMPLE_PROMOTION_ORDER_10_PERCENT_OFF_GUID,
        PromotionName = "Order10PercentOff",
        PromotionDisplayName = "10% Off Your Order",
        PromotionDescription = "Get 10% off your entire order",
        PromotionCreatedWhen = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
        PromotionModifiedWhen = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
        PromotionActiveFromWhen = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
        PromotionActiveToWhen = new DateTime(2024, 12, 31, 23, 59, 59, DateTimeKind.Utc),
        PromotionType = PromotionType.Order,
        PromotionRuleIdentifier = "OrderPercentageDiscount",
        PromotionRuleConfiguration = "{\"DiscountPercentage\":10}"
    };


    [Sample("promotion.sample.catalog", "Sample demonstrates how to create a catalog promotion with buy one get one free", "Instance of PromotionInfo - Sample catalog promotion")]
    public static UmtPromotionModel SamplePromotionCatalogBuyOneGetOne => new()
    {
        PromotionGUID = SAMPLE_PROMOTION_CATALOG_BUY_ONE_GET_ONE_GUID,
        PromotionName = "CatalogBuyOneGetOne",
        PromotionDisplayName = "Buy One Get One Free",
        PromotionDescription = "Buy one product and get another one free",
        PromotionCreatedWhen = new DateTime(2024, 02, 01, 0, 0, 0, DateTimeKind.Utc),
        PromotionModifiedWhen = new DateTime(2024, 02, 01, 0, 0, 0, DateTimeKind.Utc),
        PromotionActiveFromWhen = new DateTime(2024, 02, 01, 0, 0, 0, DateTimeKind.Utc),
        PromotionActiveToWhen = new DateTime(2024, 03, 31, 23, 59, 59, DateTimeKind.Utc),
        PromotionType = PromotionType.Catalog,
        PromotionRuleIdentifier = "CatalogBuyXGetY",
        PromotionRuleConfiguration = "{\"BuyQuantity\":1,\"GetQuantity\":1,\"DiscountPercentage\":100}"
    };


    [Sample("promotion.sample.freeshipping", "Sample demonstrates how to create an order promotion with free shipping", "Instance of PromotionInfo - Sample free shipping promotion")]
    public static UmtPromotionModel SamplePromotionOrderFreeShipping => new()
    {
        PromotionGUID = SAMPLE_PROMOTION_ORDER_FREE_SHIPPING_GUID,
        PromotionName = "OrderFreeShipping",
        PromotionDisplayName = "Free Shipping",
        PromotionDescription = "Free shipping on orders over $50",
        PromotionCreatedWhen = new DateTime(2024, 03, 01, 0, 0, 0, DateTimeKind.Utc),
        PromotionModifiedWhen = new DateTime(2024, 03, 01, 0, 0, 0, DateTimeKind.Utc),
        PromotionActiveFromWhen = new DateTime(2024, 03, 01, 0, 0, 0, DateTimeKind.Utc),
        PromotionActiveToWhen = new DateTime(2024, 12, 31, 23, 59, 59, DateTimeKind.Utc),
        PromotionType = PromotionType.Order,
        PromotionRuleIdentifier = "OrderFreeShipping",
        PromotionRuleConfiguration = "{\"MinimumOrderAmount\":50}"
    };
}
