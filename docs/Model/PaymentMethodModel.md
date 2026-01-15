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


### Sample of payment method

```json
{
  "$type": "PaymentMethod",
  "paymentMethodGUID": "f6a7b8c9-d0e1-4123-e456-789abcdef012",
  "paymentMethodName": "CreditCard",
  "paymentMethodDisplayName": "Credit Card",
  "paymentMethodDescription": "Pay securely with your credit or debit card",
  "paymentMethodEnabled": true
}
```