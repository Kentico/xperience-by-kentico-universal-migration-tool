<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## OrderItemModel
Model represents XbyK OrderItemInfo.

Model [discriminator](../UmtModel.md#discriminator): `OrderItem`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|OrderItemGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|OrderItemOrderGUID\*||System.Guid?|Reference to [OrderInfo](../References.md#OrderInfo) on property OrderItemOrderID **required**|
|OrderItemSKU||string?||
|OrderItemName||string?||
|OrderItemQuantity||decimal?||
|OrderItemUnitPrice||decimal?||
|OrderItemTotalPrice||decimal?||
|OrderItemTotalTax||decimal?||
|OrderItemTaxRate||decimal?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Instance of OrderItemInfo - Sample order item
Sample demonstrates how to create an order item
```json
{
  "$type": "OrderItem",
  "orderItemGUID": "b4c5d6e7-f8a9-4012-b345-6789abcdef01",
  "orderItemOrderGUID": "e1f2a3b4-c5d6-4789-e012-3456789abcde",
  "orderItemSKU": "PROD-001",
  "orderItemName": "Sample Product",
  "orderItemQuantity": 2,
  "orderItemUnitPrice": 49.99,
  "orderItemTotalPrice": 99.98,
  "orderItemTotalTax": 7.99,
  "orderItemTaxRate": 0.08
}
```
