<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## MediaLibraryModel
Model [discriminator](../UmtModel.md#discriminator): `Media_Library`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|LibraryName\*||string?||
|LibraryDisplayName\*||string?||
|LibraryDescription||string?||
|LibraryFolder\*||string?||
|LibraryGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|LibraryLastModified||System.DateTime?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Sample of media library

```json
{
  "$type": "Media_Library",
  "libraryName": "LibrarySample",
  "libraryDisplayName": "LibraryDisplayedName",
  "libraryDescription": "TestLibrary",
  "libraryFolder": "TestFolder",
  "libraryGUID": "e3a9c50c-2b76-4ba8-ac19-2f0aa64c47d5"
}
```
