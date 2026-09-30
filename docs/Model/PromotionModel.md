<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## PromotionModel
Model represents XbyK PromotionInfo.<br/>    **Note**: Promotions do not work out of the box. Once promotions are migrated, it is necessary to implement and register [promotion rules](https://docs.kentico.com/x/commerce_promotions_xp).

Model [discriminator](../UmtModel.md#discriminator): `Promotion`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|PromotionDisplayName\*||string?||
|PromotionName\*||string?||
|PromotionGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|PromotionDescription||string?||
|PromotionCreatedWhen\*||System.DateTime?||
|PromotionCreatedByUserGUID||System.Guid?|Reference to [UserInfo](../References.md#UserInfo) on property PromotionCreatedByUserID|
|PromotionModifiedWhen\*||System.DateTime?||
|PromotionModifiedByUserGUID||System.Guid?|Reference to [UserInfo](../References.md#UserInfo) on property PromotionModifiedByUserID|
|PromotionActiveFromWhen||System.DateTime?||
|PromotionActiveToWhen||System.DateTime?||
|PromotionType\*||CMS.Commerce.PromotionType?||
|PromotionRuleIdentifier\*||string?||
|PromotionRuleConfiguration\*||string?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Instance of PromotionInfo - Sample order promotion
Sample demonstrates how to create an order promotion with 10% discount
```json
{
  "$type": "Promotion",
  "promotionDisplayName": "10% Off Your Order",
  "promotionName": "Order10PercentOff",
  "promotionGUID": "d1e2f3a4-b5c6-4789-d012-3456789abcde",
  "promotionDescription": "Get 10% off your entire order",
  "promotionCreatedWhen": "2024-01-01T00:00:00Z",
  "promotionModifiedWhen": "2024-01-01T00:00:00Z",
  "promotionActiveFromWhen": "2024-01-01T00:00:00Z",
  "promotionActiveToWhen": "2024-12-31T23:59:59Z",
  "promotionType": 0,
  "promotionRuleIdentifier": "OrderPercentageDiscount",
  "promotionRuleConfiguration": "{\u0022DiscountValueType\u0022:\u0022Percentage\u0022,\u0022DiscountValue\u0022:10,\u0022MinimumRequirementValueType\u0022:\u0022None\u0022,\u0022MinimumRequirementValue\u0022:0}"
}
```
