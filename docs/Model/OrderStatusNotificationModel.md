<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## OrderStatusNotificationModel
Model represents XbyK OrderStatusNotificationInfo.

Model [discriminator](../UmtModel.md#discriminator): `OrderStatusNotification`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|OrderStatusNotificationOrderStatusGUID\*||System.Guid?|Reference to [OrderStatusInfo](../References.md#OrderStatusInfo) on property OrderStatusNotificationOrderStatusID **required**|
|OrderStatusNotificationUserGUID\*||System.Guid?|Reference to [UserInfo](../References.md#UserInfo) on property OrderStatusNotificationUserID **required**|
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>

### Sample of order status notification

```json
{
  "$type": "OrderStatusNotification",
  "orderStatusNotificationOrderStatusGUID": "e5f6a7b8-c9d0-4012-d345-6789abcdef01",
  "orderStatusNotificationUserGUID": "b8c9d0e1-f2a3-4124-a567-89abcdef0123"
}
```