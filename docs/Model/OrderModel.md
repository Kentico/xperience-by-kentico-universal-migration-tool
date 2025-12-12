<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## OrderModel
Model represents XbyK .

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

