<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## ContentItemLanguageMetadataModel
Model [discriminator](../UmtModel.md#discriminator): `ContentItemLanguageMetadata`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|ContentItemLanguageMetadataGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|ContentItemLanguageMetadataContentItemGuid\*||System.Guid?|Reference to [ContentItemInfo](../References.md#ContentItemInfo) on property ContentItemLanguageMetaDataContentItemID **required**|
|ContentItemLanguageMetadataDisplayName\*||string?||
|ContentItemLanguageMetadataLatestVersionStatus\*||CMS.ContentEngine.VersionStatus?||
|ContentItemLanguageMetadataCreatedWhen\*||System.DateTime?||
|ContentItemLanguageMetadataCreatedByUserGuid||System.Guid?|Reference to [UserInfo](../References.md#UserInfo) on property ContentItemLanguageMetadataCreatedByUserID|
|ContentItemLanguageMetadataModifiedWhen||System.DateTime?||
|ContentItemLanguageMetadataModifiedByUserGuid||System.Guid?|Reference to [UserInfo](../References.md#UserInfo) on property ContentItemLanguageMetadataModifiedByUserID|
|ContentItemLanguageMetadataHasImageAsset\*||bool?||
|ContentItemLanguageMetadataContentLanguageGuid\*||System.Guid?|Reference to [ContentLanguageInfo](../References.md#ContentLanguageInfo) on property ContentItemLanguageMetadataContentLanguageID **required**|
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### ContentItemLanguageMetadata Sample
This sample describes how to create class inside XbyK to hold Content Item Language Metadata
```json
{
  "$type": "ContentItemLanguageMetadata",
  "ContentItemLanguageMetadataGUID": "192c63ac-e5be-4b0f-b916-b8af6c7e79a9",
  "ContentItemLanguageMetadataContentItemGuid": "df81215e-1414-4d87-befd-ae123f4e5653",
  "ContentItemLanguageMetadataDisplayName": "Creation of UMT model",
  "ContentItemLanguageMetadataLatestVersionStatus": 2,
  "ContentItemLanguageMetadataCreatedWhen": "2023-12-10T00:00:00Z",
  "ContentItemLanguageMetadataCreatedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
  "ContentItemLanguageMetadataModifiedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
  "ContentItemLanguageMetadataHasImageAsset": false,
  "ContentItemLanguageMetadataContentLanguageGuid": "f454e93b-5fe9-42a9-b1af-b572234ed9c4"
}
```

### ContentItemLanguageMetadata Sample
This sample describes how to create class inside XbyK to hold Content Item Language Metadata
```json
{
  "$type": "ContentItemLanguageMetadata",
  "ContentItemLanguageMetadataGUID": "7f6a0c0d-a2bb-454c-8e16-adcfe0e38d17",
  "ContentItemLanguageMetadataContentItemGuid": "df81215e-1414-4d87-befd-ae123f4e5653",
  "ContentItemLanguageMetadataDisplayName": "Creation of UMT model GB",
  "ContentItemLanguageMetadataLatestVersionStatus": 2,
  "ContentItemLanguageMetadataCreatedWhen": "2023-12-10T00:00:00Z",
  "ContentItemLanguageMetadataCreatedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
  "ContentItemLanguageMetadataModifiedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
  "ContentItemLanguageMetadataHasImageAsset": false,
  "ContentItemLanguageMetadataContentLanguageGuid": "a6c0a558-8b33-47b6-87a8-491b437c9923"
}
```

### Reusable ContentItemLanguageMetadata faq
This sample describes how to create class inside XbyK to hold Content Item Language Metadata
```json
{
  "$type": "ContentItemLanguageMetadata",
  "ContentItemLanguageMetadataGUID": "46353800-21b8-48f6-8681-b19966f4b6eb",
  "ContentItemLanguageMetadataContentItemGuid": "b64b3e3e-f5a9-4d02-8cdb-6d81805c0fee",
  "ContentItemLanguageMetadataDisplayName": "Sample reusable FAQ",
  "ContentItemLanguageMetadataLatestVersionStatus": 2,
  "ContentItemLanguageMetadataCreatedWhen": "2023-12-10T00:00:00Z",
  "ContentItemLanguageMetadataCreatedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
  "ContentItemLanguageMetadataModifiedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
  "ContentItemLanguageMetadataHasImageAsset": false,
  "ContentItemLanguageMetadataContentLanguageGuid": "f454e93b-5fe9-42a9-b1af-b572234ed9c4"
}
```

### Reusable ContentItemLanguageMetadata faq
This sample describes how to create class inside XbyK to hold Content Item Language Metadata
```json
{
  "$type": "ContentItemLanguageMetadata",
  "ContentItemLanguageMetadataGUID": "b15b3d9f-0cb1-405a-bc04-a069daecf72d",
  "ContentItemLanguageMetadataContentItemGuid": "b64b3e3e-f5a9-4d02-8cdb-6d81805c0fee",
  "ContentItemLanguageMetadataDisplayName": "Sample reusable FAQ",
  "ContentItemLanguageMetadataLatestVersionStatus": 2,
  "ContentItemLanguageMetadataCreatedWhen": "2023-12-10T00:00:00Z",
  "ContentItemLanguageMetadataCreatedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
  "ContentItemLanguageMetadataModifiedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
  "ContentItemLanguageMetadataHasImageAsset": false,
  "ContentItemLanguageMetadataContentLanguageGuid": "a6c0a558-8b33-47b6-87a8-491b437c9923"
}
```

### ContentItemLanguageMetadata Sample
This sample describes how to create class inside XbyK to hold Content Item Language Metadata
```json
{
  "$type": "ContentItemLanguageMetadata",
  "ContentItemLanguageMetadataGUID": "9ec48558-4e26-4ddf-9804-fa0fbe95142d",
  "ContentItemLanguageMetadataContentItemGuid": "e09121ad-dd97-472f-b8f6-85fe5428ed6a",
  "ContentItemLanguageMetadataDisplayName": "Content item with relations",
  "ContentItemLanguageMetadataLatestVersionStatus": 0,
  "ContentItemLanguageMetadataCreatedWhen": "2023-12-10T00:00:00Z",
  "ContentItemLanguageMetadataCreatedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
  "ContentItemLanguageMetadataModifiedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
  "ContentItemLanguageMetadataHasImageAsset": false,
  "ContentItemLanguageMetadataContentLanguageGuid": "f454e93b-5fe9-42a9-b1af-b572234ed9c4"
}
```

### ContentItemLanguageMetadata Sample
This sample describes how to create class inside XbyK to hold Content Item Language Metadata
```json
{
  "$type": "ContentItemLanguageMetadata",
  "ContentItemLanguageMetadataGUID": "8a3f1795-c0ac-4501-be4e-6fba0cd11654",
  "ContentItemLanguageMetadataContentItemGuid": "e09121ad-dd97-472f-b8f6-85fe5428ed6a",
  "ContentItemLanguageMetadataDisplayName": "Content item with relations en-GB",
  "ContentItemLanguageMetadataLatestVersionStatus": 2,
  "ContentItemLanguageMetadataCreatedWhen": "2023-12-10T00:00:00Z",
  "ContentItemLanguageMetadataCreatedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
  "ContentItemLanguageMetadataModifiedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
  "ContentItemLanguageMetadataHasImageAsset": false,
  "ContentItemLanguageMetadataContentLanguageGuid": "a6c0a558-8b33-47b6-87a8-491b437c9923"
}
```
