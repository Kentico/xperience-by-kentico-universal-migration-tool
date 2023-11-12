<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## ContentItemCommonDataModel
Model [discriminator](../UmtModel.md#discriminator): `ContentItemCommonData`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|ContentItemCommonDataGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|ContentItemCommonDataContentItemGuid\*||System.Guid?|Reference to [ContentItemInfo](../References.md#ContentItemInfo) on property ContentItemCommonDataContentItemID **required**|
|ContentItemDataGuid\*||System.Guid?||
|ContentItemCommonDataContentLanguageGuid\*||System.Guid?|Reference to [ContentLanguageInfo](../References.md#ContentLanguageInfo) on property ContentItemCommonDataContentLanguageID **required**|
|ContentItemCommonDataVersionStatus\*||int?||
|ContentItemCommonDataIsLatest\*||bool?||
|ContentItemCommonDataPageBuilderWidgets||string?||
|ContentItemCommonDataPageTemplateConfiguration||string?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>

