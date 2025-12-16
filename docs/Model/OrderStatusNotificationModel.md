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

