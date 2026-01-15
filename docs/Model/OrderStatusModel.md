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


### Sample of order status

```json
{
  "$type": "OrderStatus",
  "orderStatusGUID": "e5f6a7b8-c9d0-4012-d345-6789abcdef01",
  "orderStatusName": "Processing",
  "orderStatusDisplayName": "Processing",
  "orderStatusOrder": 1,
  "orderStatusInternalNotificationEnabled": true,
  "orderStatusCustomerNotificationEnabled": true,
  "orderStatusCustomerNotificationEmailConfigurationGUID": null
}
```