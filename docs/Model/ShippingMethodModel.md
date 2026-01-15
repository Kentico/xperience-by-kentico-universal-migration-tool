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


### Sample of shipping method

```json
{
  "$type": "ShippingMethod",
  "shippingMethodGUID": "a7b8c9d0-e1f2-4234-f567-89abcdef0123",
  "shippingMethodName": "StandardShipping",
  "shippingMethodDisplayName": "Standard Shipping",
  "shippingMethodDescription": "Standard shipping with 5-7 business days delivery",
  "shippingMethodEnabled": true,
  "shippingMethodPrice": 15.00
}
```