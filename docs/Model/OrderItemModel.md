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
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>

