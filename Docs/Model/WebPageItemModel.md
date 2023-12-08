<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## WebPageItemModel
Model [discriminator](../UmtModel.md#discriminator): `WebPageItem`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|WebPageItemGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|WebPageItemParentGuid||System.Guid?|Reference to [WebPageItemInfo](../References.md#WebPageItemInfo) on property WebPageItemParentID|
|WebPageItemName\*||string?||
|WebPageItemTreePath\*||string?||
|WebPageItemWebsiteChannelGuid\*||System.Guid?|Reference to [WebsiteChannelInfo](../References.md#WebsiteChannelInfo) on property WebPageItemWebsiteChannelID **required**|
|WebPageItemContentItemGuid\*||System.Guid?|Reference to [ContentItemInfo](../References.md#ContentItemInfo) on property WebPageItemContentItemID **required**|
|WebPageItemOrder\*||int?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### ContentItem Sample
This sample describes how to create class inside XbyK to hold WebPage Item data
```json
{
  "$type": "WebPageItem",
  "WebPageItemGUID": "6e995319-77e7-475e-9ebb-607bdbf5af9a",
  "WebPageItemName": "CreationOfUmtModelUs",
  "WebPageItemTreePath": "/creation-of-umt-model",
  "WebPageItemWebsiteChannelGuid": "a6ba6fcb-9d05-4abe-afb4-74b153c90db7",
  "WebPageItemContentItemGuid": "df81215e-1414-4d87-befd-ae123f4e5653",
  "WebPageItemOrder": 1
}
```
