<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## PaymentMethodModel
Model represents XbyK PaymentMethodInfo.

Model [discriminator](../UmtModel.md#discriminator): `PaymentMethod`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|PaymentMethodGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|PaymentMethodName\*||string?||
|PaymentMethodDisplayName\*||string?||
|PaymentMethodDescription||string?||
|PaymentMethodEnabled||bool?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Instance of PaymentMethodInfo - Sample credit card payment method
Sample demonstrates how to create a credit card payment method
```json
{
  "$type": "PaymentMethod",
  "paymentMethodGUID": "a7b8c9d0-e1f2-4345-a678-9abcdef01234",
  "paymentMethodName": "CreditCard",
  "paymentMethodDisplayName": "Credit Card",
  "paymentMethodDescription": "Pay with credit or debit card",
  "paymentMethodEnabled": true
}
```
