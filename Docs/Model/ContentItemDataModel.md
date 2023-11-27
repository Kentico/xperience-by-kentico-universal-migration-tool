<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## ContentItemDataModel
Model represents XbyK ContentItemDataInfo

Model [discriminator](../UmtModel.md#discriminator): `ContentItemData`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|ContentItemDataGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|ContentItemDataCommonDataGuid\*||System.Guid?|Reference to [ContentItemCommonDataInfo](../References.md#ContentItemCommonDataInfo) on property ContentItemDataCommonDataID **required**|
|ContentItemContentTypeName\*||string?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### ContentItemData article sample (en-US)
This sample describes how to create content item data inside XbyK
```json
{
  "$type": "ContentItemData",
  "ContentItemDataGUID": "9a5b10e0-d0e6-4de9-9d82-6d8deeea1849",
  "ContentItemDataCommonDataGuid": "8f070195-2f39-463e-b7eb-c180c05fd5e0",
  "ContentItemContentTypeName": "UMT.Article",
  "ArticleTitle": "en-US UMT model creation",
  "ArticleText": "This article is only example of creation UMT model for en-US language"
}
```

### ContentItemData article sample (en-GB)
This sample describes how to create content item data inside XbyK
```json
{
  "$type": "ContentItemData",
  "ContentItemDataGUID": "21380f91-279b-44be-aad8-2e62c345a0e9",
  "ContentItemDataCommonDataGuid": "49d2caf6-2011-42d7-961d-02614d1b43f4",
  "ContentItemContentTypeName": "UMT.Article",
  "ArticleTitle": "en-GB UMT model creation",
  "ArticleText": "This article is only example of creation UMT model for en-GB language"
}
```
