<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## ContentItemModel
Model [discriminator](../UmtModel.md#discriminator): `ContentItem`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|ContentItemGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|ContentItemContentFolderGUID|reference to content folder|System.Guid?|Reference to [ContentFolderInfo](../References.md#ContentFolderInfo) on property ContentItemContentFolderID|
|ContentItemWorkspaceGUID|reference to workspace|System.Guid?|Reference to [WorkspaceInfo](../References.md#WorkspaceInfo) on property ContentItemWorkspaceID|
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
  "contentItemGUID": "df81215e-1414-4d87-befd-ae123f4e5653",
  "contentItemName": "CreationOfUmtModel",
  "contentItemIsReusable": false,
  "contentItemIsSecured": false,
  "contentItemDataClassGuid": "06540294-3b56-4cf7-8773-088bb766ac23",
  "contentItemChannelGuid": "5322a379-5b5f-4220-9383-8e3115e66cd3"
}
```

### Reusable ContentItem Faq
This sample describes how to create reusable content item data inside XbyK
```json
{
  "$type": "ContentItem",
  "contentItemGUID": "b64b3e3e-f5a9-4d02-8cdb-6d81805c0fee",
  "contentItemName": "SampleReusableFaq",
  "contentItemIsReusable": true,
  "contentItemIsSecured": true,
  "contentItemDataClassGuid": "7ed6604e-613b-4ce0-8c21-acfb372c416a"
}
```

### ContentItem with relations sample
This sample describes how to create content item with relations to other content items
```json
{
  "$type": "ContentItem",
  "contentItemGUID": "e09121ad-dd97-472f-b8f6-85fe5428ed6a",
  "contentItemName": "Content-item-with-relations",
  "contentItemIsReusable": false,
  "contentItemIsSecured": true,
  "contentItemDataClassGuid": "06540294-3b56-4cf7-8773-088bb766ac23",
  "contentItemChannelGuid": "5322a379-5b5f-4220-9383-8e3115e66cd3"
}
```
