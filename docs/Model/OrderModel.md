<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## OrderModel
Model represents XbyK OrderInfo.

Model [discriminator](../UmtModel.md#discriminator): `Order`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|OrderGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|OrderNumber\*||string?||
|OrderCreatedWhen\*||System.DateTime?||
|OrderModifiedWhen\*||System.DateTime?||
|OrderOrderStatusGUID\*||System.Guid?|Reference to [OrderStatusInfo](../References.md#OrderStatusInfo) on property OrderOrderStatusID **required**|
|OrderTotalPrice||decimal?||
|OrderTotalShipping||decimal?||
|OrderTotalTax||decimal?||
|OrderGrandTotal||decimal?||
|OrderCustomerGUID\*||System.Guid?|Reference to [CustomerInfo](../References.md#CustomerInfo) on property OrderCustomerID **required**|
|OrderPaymentMethodGUID||System.Guid?|Reference to [PaymentMethodInfo](../References.md#PaymentMethodInfo) on property OrderPaymentMethodID|
|OrderPaymentMethodDisplayName||string?||
|OrderShippingMethodGUID||System.Guid?|Reference to [ShippingMethodInfo](../References.md#ShippingMethodInfo) on property OrderShippingMethodID|
|OrderShippingMethodDisplayName||string?||
|OrderShippingMethodPrice||decimal?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Sample of order

```json
{
  "$type": "Order",
  "orderGUID": "c3d4e5f6-a7b8-4901-c234-56789abcdef0",
  "orderNumber": "ORD-2024-001234",
  "orderCreatedWhen": "2024-02-15T14:30:00Z",
  "orderModifiedWhen": "2024-02-15T14:35:00Z",
  "orderOrderStatusGUID": "e5f6a7b8-c9d0-4012-d345-6789abcdef01",
  "orderTotalPrice": 299.99,
  "orderTotalShipping": 15.0,
  "orderTotalTax": 24.0,
  "orderGrandTotal": 338.99,
  "orderCustomerGUID": "a1b2c3d4-e5f6-4789-a012-3456789abcde",
  "orderPaymentMethodGUID": "f6a7b8c9-d0e1-4123-e456-789abcdef012",
  "orderPaymentMethodDisplayName": "Credit Card",
  "orderShippingMethodGUID": "a7b8c9d0-e1f2-4234-f567-89abcdef0123",
  "orderShippingMethodDisplayName": "Standard Shipping",
  "orderShippingMethodPrice": 15.0
}
```
