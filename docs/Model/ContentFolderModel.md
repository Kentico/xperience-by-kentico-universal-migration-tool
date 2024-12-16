<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## ContentFolderModel
Model represents XbyK ContentFolderInfo, enables user to create content item folders with umt

Model [discriminator](../UmtModel.md#discriminator): `ContentFolder`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|ContentFolderGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|ContentFolderParentFolderGUID|parent folder guid. If null is specified, folder is created directly under root|System.Guid?|Reference to [ContentFolderInfo](../References.md#ContentFolderInfo) on property ContentFolderParentFolderID|
|ContentFolderWorkspaceGUID|workspace guid. If null is specified, default workspace is used|System.Guid?|Reference to [ContentFolderInfo](../References.md#ContentFolderInfo) on property ContentFolderWorkspaceID|
|ContentFolderName\*||string?||
|ContentFolderDisplayName\*||string?||
|ContentFolderTreePath\*||string?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Content folder basic sample

```json
{
  "$type": "ContentFolder",
  "ContentFolderGUID": "7665a8fc-53a2-4aff-86e8-99b009104ff2",
  "ContentFolderName": "articles",
  "ContentFolderDisplayName": "Articles",
  "ContentFolderTreePath": "/articles"
}
```
