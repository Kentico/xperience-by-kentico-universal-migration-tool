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


### Instance of OrderStatusNotificationInfo - Sample notification for new order status
Sample demonstrates how to create an order status notification for new orders
```json
{
  "$type": "OrderStatusNotification",
  "orderStatusNotificationOrderStatusGUID": "d4e5f6a7-b8c9-4012-d345-6789abcdef01",
  "orderStatusNotificationUserGUID": "dbfcc244-2cb9-4934-857f-9d75404c1553"
}
```
