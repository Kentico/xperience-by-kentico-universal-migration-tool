<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## ContentItemModel
Model [discriminator](../UmtModel.md#discriminator): `ContentItem`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|ContentItemGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|ContentItemContentFolderGUID|reference to content folder|System.Guid?|Reference to [ContentFolderInfo](../References.md#ContentFolderInfo) on property ContentItemContentFolderID|
|ContentItemName\*||string?||
|ContentItemIsReusable\*||bool?||
|ContentItemIsSecured||bool?||
|ContentItemDataClassGuid||System.Guid?|Reference to [DataClassInfo](../References.md#DataClassInfo) on property ContentItemContentTypeID|
|ContentItemChannelGuid||System.Guid?|Reference to [ChannelInfo](../References.md#ChannelInfo) on property ContentItemChannelID|
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### ContentItem basic Sample
This sample describes how to create content item data inside XbyK
```json
{
  "$type": "ContentItem",
  "ContentItemGUID": "df81215e-1414-4d87-befd-ae123f4e5653",
  "ContentItemName": "CreationOfUmtModel",
  "ContentItemIsReusable": false,
  "ContentItemIsSecured": false,
  "ContentItemDataClassGuid": "06540294-3b56-4cf7-8773-088bb766ac23",
  "ContentItemChannelGuid": "5322a379-5b5f-4220-9383-8e3115e66cd3"
}
```

### Reusable ContentItem Faq
This sample describes how to create reusable content item data inside XbyK
```json
{
  "$type": "ContentItem",
  "ContentItemGUID": "b64b3e3e-f5a9-4d02-8cdb-6d81805c0fee",
  "ContentItemName": "SampleReusableFaq",
  "ContentItemIsReusable": true,
  "ContentItemIsSecured": true,
  "ContentItemDataClassGuid": "7ed6604e-613b-4ce0-8c21-acfb372c416a"
}
```

### ContentItem with relations sample
This sample describes how to create content item with relations to other content items
```json
{
  "$type": "ContentItem",
  "ContentItemGUID": "e09121ad-dd97-472f-b8f6-85fe5428ed6a",
  "ContentItemName": "Content-item-with-relations",
  "ContentItemIsReusable": false,
  "ContentItemIsSecured": true,
  "ContentItemDataClassGuid": "06540294-3b56-4cf7-8773-088bb766ac23",
  "ContentItemChannelGuid": "5322a379-5b5f-4220-9383-8e3115e66cd3"
}
```
