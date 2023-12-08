<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## MediaFileModel
Model [discriminator](../UmtModel.md#discriminator): `Media_File`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|DataSourcePath||string?||
|DataSourceBase64||string?||
|DataSourceUrl||string?||
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


### Sample of media file

```json
{
  "$type": "Media_File",
  "DataSourcePath": ".\\sample.png",
  "DataSourceBase64": "",
  "FileGUID": "214e29aa-32d5-40d7-9fea-896591439e74",
  "FileLibraryGuid": "e3a9c50c-2b76-4ba8-ac19-2f0aa64c47d5",
  "FileCreatedByUserGuid": "863f796e-823a-4f5e-bbdb-e4a6f15b349b",
  "FileName": "NewTestFile.png",
  "FileTitle": "Title",
  "FileExtension": ".png",
  "FilePath": "newPath/somepath",
  "": ""
}
```
