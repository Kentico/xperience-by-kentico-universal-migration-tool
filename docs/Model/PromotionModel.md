<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## PromotionModel
Model represents XbyK PromotionInfo.

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


> **Note**: Promotions do not work out of the box. Once promotions are migrated, it is necessary to implement and register [promotion rules](https://docs.kentico.com/x/commerce_promotions_xp).

### Sample of promotion

```json
{
  "$type": "Promotion",
  "promotionGUID": "d1e2f3a4-b5c6-4789-d012-3456789abcde",
  "promotionName": "Order10PercentOff",
  "promotionDisplayName": "10% Off Your Order",
  "promotionDescription": "Get 10% off your entire order",
  "promotionCreatedWhen": "2024-01-01T00:00:00Z",
  "promotionCreatedByUserGUID": null,
  "promotionModifiedWhen": "2024-01-01T00:00:00Z",
  "promotionModifiedByUserGUID": null,
  "promotionActiveFromWhen": "2024-01-01T00:00:00Z",
  "promotionActiveToWhen": "2024-12-31T23:59:59Z",
  "promotionType": 0,
  "promotionRuleIdentifier": "OrderPercentageDiscount",
  "promotionRuleConfiguration": "{\"DiscountValueType\":\"Percentage\",\"DiscountValue\":0,\"MinimumRequirementValueType\":\"None\",\"MinimumRequirementValue\":0}"
}
```