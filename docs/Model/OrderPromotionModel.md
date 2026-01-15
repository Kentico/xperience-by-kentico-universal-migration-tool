<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## OrderPromotionModel
Model represents XbyK OrderPromotionInfo.

Model [discriminator](../UmtModel.md#discriminator): `OrderPromotion`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|OrderPromotionPromotionGUID||System.Guid?|Reference to [PromotionInfo](../References.md#PromotionInfo) on property OrderPromotionPromotionID|
|OrderPromotionOrderGUID\*||System.Guid?|Reference to [OrderInfo](../References.md#OrderInfo) on property OrderPromotionOrderID **required**|
|OrderPromotionOrderItemGUID||System.Guid?|Reference to [OrderItemInfo](../References.md#OrderItemInfo) on property OrderPromotionOrderItemID|
|OrderPromotionPromotionDisplayName\*||string?||
|OrderPromotionDiscountAmount\*||decimal?||
|OrderPromotionPromotionType\*||CMS.Commerce.PromotionType?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


> **Note**: Promotions do not work out of the box. Once promotions are migrated, it is necessary to implement and register [promotion rules](https://docs.kentico.com/x/commerce_promotions_xp).

### Sample of order promotion

```json
{
  "$type": "OrderPromotion",
  "orderPromotionPromotionGUID": "d1e2f3a4-b5c6-4789-d012-3456789abcde",
  "orderPromotionOrderGUID": "e1f2a3b4-c5d6-4789-e012-3456789abcde",
  "orderPromotionOrderItemGUID": "c5d6e7f8-a9b0-4123-c456-789abcdef012",
  "orderPromotionPromotionDisplayName": "10% Off Your Order",
  "orderPromotionDiscountAmount": 12.99,
  "orderPromotionPromotionType": 0
}
```