<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## MediaFileModel
Model [discriminator](../UmtModel.md#discriminator): `Media_File`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|DataSourcePath||string?||
|FileGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|FileLibraryGuid\*||System.Guid?|Reference to [MediaLibraryInfo](../References.md#MediaLibraryInfo) on property FileLibraryID **required**|
|FileCreatedByUserGuid||System.Guid?|Reference to [UserInfo](../References.md#UserInfo) on property FileCreatedByUserID|
|FileModifiedByUserGuid||System.Guid?|Reference to [UserInfo](../References.md#UserInfo) on property FileModifiedByUserID|
|FileName\*||string?||
|FileTitle||string?||
|FileDescription||string?||
|FileExtension||string?||
|FileMimeType||string?||
|FilePath||string?||
|FileImageWidth||int?||
|FileImageHeight||int?||
|FileCreatedWhen||System.DateTime?||
|FileModifiedWhen||System.DateTime?||
|FileCustomData||string?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>

