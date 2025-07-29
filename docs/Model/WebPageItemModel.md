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
  "webPageItemGUID": "6e995319-77e7-475e-9ebb-607bdbf5af9a",
  "webPageItemName": "CreationOfUmtModelUs",
  "webPageItemTreePath": "/creation-of-umt-model",
  "webPageItemWebsiteChannelGuid": "a6ba6fcb-9d05-4abe-afb4-74b153c90db7",
  "webPageItemContentItemGuid": "df81215e-1414-4d87-befd-ae123f4e5653",
  "webPageItemOrder": 1
}
```

### ContentItem Sample
This sample describes how to create class inside XbyK to hold WebPage Item data with relations
```json
{
  "$type": "WebPageItem",
  "webPageItemGUID": "14784bf0-69d0-40cf-8be6-e5a0d897774b",
  "webPageItemName": "ContentItemWithRelations",
  "webPageItemTreePath": "/content-item-with-relations",
  "webPageItemWebsiteChannelGuid": "a6ba6fcb-9d05-4abe-afb4-74b153c90db7",
  "webPageItemContentItemGuid": "e09121ad-dd97-472f-b8f6-85fe5428ed6a",
  "webPageItemOrder": 1
}
```
