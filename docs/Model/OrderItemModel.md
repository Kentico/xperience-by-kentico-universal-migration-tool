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



### Sample of order item

```json
{
  "$type": "OrderItem",
  "orderItemGUID": "e5f6a7b8-c9d0-4903-f456-789abcdef012",
  "orderItemOrderGUID": "c3d4e5f6-a7b8-4901-c234-56789abcdef0",
  "orderItemSKU": "PROD-001",
  "orderItemName": "Premium Widget",
  "orderItemQuantity": 2.0,
  "orderItemUnitPrice": 149.99,
  "orderItemTotalPrice": 299.98,
  "orderItemTotalTax": 24.00,
  "orderItemTaxRate": 0.08
}
```