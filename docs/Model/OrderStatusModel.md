<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## OrderStatusModel
Model represents XbyK OrderStatusInfo.

Model [discriminator](../UmtModel.md#discriminator): `OrderStatus`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|OrderStatusGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|OrderStatusName\*||string?||
|OrderStatusDisplayName\*||string?||
|OrderStatusOrder\*||int?||
|OrderStatusInternalNotificationEnabled\*||bool?||
|OrderStatusCustomerNotificationEnabled\*||bool?||
|OrderStatusCustomerNotificationEmailConfigurationGUID||System.Guid?|Reference to [EmailConfigurationInfo](../References.md#EmailConfigurationInfo) on property OrderStatusCustomerNotificationEmailConfigurationID|
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Instance of OrderStatusInfo - Sample new order status
Sample demonstrates how to create a new order status
```json
{
  "$type": "OrderStatus",
  "orderStatusGUID": "d4e5f6a7-b8c9-4012-d345-6789abcdef01",
  "orderStatusName": "New",
  "orderStatusDisplayName": "New Order",
  "orderStatusOrder": 1,
  "orderStatusInternalNotificationEnabled": true,
  "orderStatusCustomerNotificationEnabled": true
}
```
