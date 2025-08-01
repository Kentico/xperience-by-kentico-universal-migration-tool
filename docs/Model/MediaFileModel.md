<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## MediaFileModel
Model [discriminator](../UmtModel.md#discriminator): `Media_File`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|DataSourcePath||string?||
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
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Sample of media file loaded from disk

```json
{
  "$type": "Media_File",
  "dataSourcePath": "##ASSETDIR##\\sample.png",
  "fileGUID": "214e29aa-32d5-40d7-9fea-896591439e74",
  "fileLibraryGuid": "e3a9c50c-2b76-4ba8-ac19-2f0aa64c47d5",
  "fileCreatedByUserGuid": "863f796e-823a-4f5e-bbdb-e4a6f15b349b",
  "fileName": "NewTestFile",
  "fileTitle": "Title",
  "fileExtension": ".png",
  "filePath": "customdir/NewTestFile.png"
}
```

### Sample of media file downloaded from url

```json
{
  "$type": "Media_File",
  "dataSourceUrl": "https://devnet.kentico.com/DevNet/media/devnet/cms_screen.jpg",
  "fileGUID": "94df1156-c85d-4356-8e28-16d71c6ac899",
  "fileLibraryGuid": "e3a9c50c-2b76-4ba8-ac19-2f0aa64c47d5",
  "fileCreatedByUserGuid": "863f796e-823a-4f5e-bbdb-e4a6f15b349b",
  "fileName": "NewTestFileFromUri",
  "fileTitle": "Old devnet screen",
  "fileExtension": ".jpg",
  "filePath": "customdir/NewTestFileFromUri.jpg"
}
```
