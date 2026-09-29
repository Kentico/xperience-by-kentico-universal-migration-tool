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


### Instance of OrderInfo - Sample order
Sample demonstrates how to create an order
```json
{
  "$type": "Order",
  "orderGUID": "e1f2a3b4-c5d6-4789-e012-3456789abcde",
  "orderNumber": "ORD-2024-001",
  "orderCreatedWhen": "2024-03-15T09:30:00Z",
  "orderModifiedWhen": "2024-03-16T09:30:00Z",
  "orderOrderStatusGUID": "d4e5f6a7-b8c9-4012-d345-6789abcdef01",
  "orderTotalPrice": 129.97,
  "orderTotalShipping": 5.99,
  "orderTotalTax": 8.00,
  "orderGrandTotal": 149.95,
  "orderCustomerGUID": "a1b2c3d4-e5f6-4789-a012-3456789abcde",
  "orderPaymentMethodDisplayName": "Credit Card",
  "orderShippingMethodDisplayName": "Standard Shipping",
  "orderShippingMethodPrice": 5.99
}
```
