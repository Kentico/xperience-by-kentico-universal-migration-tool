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

### Reusable ContentItemCommonData Faq
This sample describes how to create reusable content item common data inside XbyK
```json
{
  "$type": "ContentItemCommonData",
  "contentItemCommonDataGUID": "2b1987bf-680b-48c0-85ce-47ff9fde24c7",
  "contentItemCommonDataContentItemGuid": "b64b3e3e-f5a9-4d02-8cdb-6d81805c0fee",
  "contentItemCommonDataContentLanguageGuid": "f454e93b-5fe9-42a9-b1af-b572234ed9c4",
  "contentItemCommonDataVersionStatus": 2,
  "contentItemCommonDataIsLatest": true
}
```

### Reusable ContentItemCommonData faq
This sample describes how to create content item common data inside XbyK
```json
{
  "$type": "ContentItemCommonData",
  "contentItemCommonDataGUID": "96016b05-b3d3-42f9-b5aa-71e2f816eb8f",
  "contentItemCommonDataContentItemGuid": "b64b3e3e-f5a9-4d02-8cdb-6d81805c0fee",
  "contentItemCommonDataContentLanguageGuid": "a6c0a558-8b33-47b6-87a8-491b437c9923",
  "contentItemCommonDataVersionStatus": 2,
  "contentItemCommonDataIsLatest": true
}
```

### ContentItemData article sample (en-US)
This sample describes how to create content item data inside XbyK
```json
{
  "$type": "ContentItemData",
  "contentItemDataGUID": "b6847866-12b1-4a4a-aba7-d93860102bc8",
  "contentItemDataCommonDataGuid": "56f0e676-8fcc-4a5d-8b69-f6eca372b998",
  "contentItemContentTypeName": "UMT.Article",
  "ArticleTitle": "en-US UMT model creation",
  "ArticleText": "This article is only example of creation UMT model for en-US language",
  "RelatedArticles": "[{\u0022WebPageGuid\u0022:\u00226e995319-77e7-475e-9ebb-607bdbf5af9a\u0022}]",
  "RelatedFaq": [
    {
      "identifier": "b64b3e3e-f5a9-4d02-8cdb-6d81805c0fee"
    }
  ],
  "ArticleDecimalNumberSample": 123456.12345
}
```

### ContentItemData article sample (en-GB)
This sample describes how to create content item data inside XbyK
```json
{
  "$type": "ContentItemData",
  "contentItemDataGUID": "a80f91ff-4cfc-4e28-982a-e4a434517680",
  "contentItemDataCommonDataGuid": "a790b2d4-5ac1-4fb0-812c-2ad2171c61c9",
  "contentItemContentTypeName": "UMT.Article",
  "ArticleTitle": "en-GB UMT model creation",
  "ArticleText": "This article is only example of creation UMT model for en-GB language",
  "RelatedArticles": "[{\u0022WebPageGuid\u0022:\u00226e995319-77e7-475e-9ebb-607bdbf5af9a\u0022}]",
  "RelatedFaq": [
    {
      "identifier": "b64b3e3e-f5a9-4d02-8cdb-6d81805c0fee"
    }
  ],
  "ArticleDecimalNumberSample": 123456.12345
}
```
