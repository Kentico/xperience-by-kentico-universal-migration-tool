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

