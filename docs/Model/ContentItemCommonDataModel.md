<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## ContentItemCommonDataModel
Model [discriminator](../UmtModel.md#discriminator): `ContentItemCommonData`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|ContentItemCommonDataGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|ContentItemCommonDataContentItemGuid\*||System.Guid?|Reference to [ContentItemInfo](../References.md#ContentItemInfo) on property ContentItemCommonDataContentItemID **required**|
|ContentItemCommonDataContentLanguageGuid\*||System.Guid?|Reference to [ContentLanguageInfo](../References.md#ContentLanguageInfo) on property ContentItemCommonDataContentLanguageID **required**|
|ContentItemCommonDataVersionStatus\*||CMS.ContentEngine.VersionStatus?||
|ContentItemCommonDataIsLatest\*||bool?||
|ContentItemCommonDataVisualBuilderWidgets||string?||
|ContentItemCommonDataVisualBuilderTemplateConfiguration||string?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### ContentItemData article sample (en-US)
This sample describes how to create content item data inside XbyK
```json
{
  "$type": "ContentItemData",
  "contentItemDataGUID": "9a5b10e0-d0e6-4de9-9d82-6d8deeea1849",
  "contentItemDataCommonDataGuid": "8f070195-2f39-463e-b7eb-c180c05fd5e0",
  "contentItemContentTypeName": "UMT.Article",
  "ArticleTitle": "en-US UMT model creation",
  "ArticleText": "This article is only example of creation UMT model for en-US language",
  "RelatedArticles": null,
  "RelatedFaq": null,
  "CoffeaTaxonomy": "[{\u0022Identifier\u0022:\u0022ffe48372-2bac-4a14-ad8c-c86f3f54c7c5\u0022}]",
  "ArticleDecimalNumberSample": 123456.12345
}
```

### ContentItemData article sample (en-GB)
This sample describes how to create content item data inside XbyK
```json
{
  "$type": "ContentItemData",
  "contentItemDataGUID": "21380f91-279b-44be-aad8-2e62c345a0e9",
  "contentItemDataCommonDataGuid": "49d2caf6-2011-42d7-961d-02614d1b43f4",
  "contentItemContentTypeName": "UMT.Article",
  "ArticleTitle": "en-GB UMT model creation",
  "ArticleText": "This article is only example of creation UMT model for en-GB language",
  "RelatedArticles": null,
  "RelatedFaq": null,
  "CoffeaTaxonomy": "[{\u0022Identifier\u0022:\u0022ffe48372-2bac-4a14-ad8c-c86f3f54c7c5\u0022}]",
  "ArticleDecimalNumberSample": 123456.12345
}
```

### Reusable ContentItemData faq (en-US)
This sample describes how to reusable create content item data inside XbyK
```json
{
  "$type": "ContentItemData",
  "contentItemDataGUID": "d29e7c59-09d5-443c-999d-063ba62e5f97",
  "contentItemDataCommonDataGuid": "2b1987bf-680b-48c0-85ce-47ff9fde24c7",
  "contentItemContentTypeName": "UMT.Faq",
  "FaqQuestion": "en-US FAQ question text",
  "FaqAnswer": "en-US FAQ answer text"
}
```

### Reusable ContentItemData faq sample (en-GB)
This sample describes how to create content item data inside XbyK
```json
{
  "$type": "ContentItemData",
  "contentItemDataGUID": "93269639-1c4a-48b8-b367-0da00268eeb0",
  "contentItemDataCommonDataGuid": "96016b05-b3d3-42f9-b5aa-71e2f816eb8f",
  "contentItemContentTypeName": "UMT.Faq",
  "FaqQuestion": "en-GB FAQ question text",
  "FaqAnswer": "en-GB FAQ answer text"
}
```

### ContentItemCommonData basic Sample
This sample describes how to create content item common data inside XbyK
```json
{
  "$type": "ContentItemCommonData",
  "contentItemCommonDataGUID": "56f0e676-8fcc-4a5d-8b69-f6eca372b998",
  "contentItemCommonDataContentItemGuid": "e09121ad-dd97-472f-b8f6-85fe5428ed6a",
  "contentItemCommonDataContentLanguageGuid": "f454e93b-5fe9-42a9-b1af-b572234ed9c4",
  "contentItemCommonDataVersionStatus": 0,
  "contentItemCommonDataIsLatest": true,
  "contentItemCommonDataVisualBuilderTemplateConfiguration": "{\u0022identifier\u0022:\u0022ArticlePageDefaultTemplate\u0022}"
}
```
