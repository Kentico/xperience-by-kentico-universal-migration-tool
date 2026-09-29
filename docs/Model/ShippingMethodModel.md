<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## ShippingMethodModel
Model represents XbyK ShippingMethodInfo.

Model [discriminator](../UmtModel.md#discriminator): `ShippingMethod`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|ShippingMethodGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|ShippingMethodName\*||string?||
|ShippingMethodDisplayName\*||string?||
|ShippingMethodDescription||string?||
|ShippingMethodEnabled||bool?||
|ShippingMethodPrice||decimal?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Instance of ShippingMethodInfo - Sample standard shipping method
Sample demonstrates how to create a standard shipping method
```json
{
  "$type": "ShippingMethod",
  "shippingMethodGUID": "a1b2c3d4-e5f6-4789-abcd-1234567890ab",
  "shippingMethodName": "StandardShipping",
  "shippingMethodDisplayName": "Standard Shipping",
  "shippingMethodDescription": "Standard shipping method with 5-7 business days delivery",
  "shippingMethodEnabled": true,
  "shippingMethodPrice": 9.99
}
```
