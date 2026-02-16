<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## WebPageFolderModel
Model represents a composite model for creating web page folders in XbyK. Folders are special content items with no content type that organize web pages in the content tree. Internally orchestrates creation of ContentItem, WebPageItem, and ContentItemLanguageMetadata.

Model [discriminator](../UmtModel.md#discriminator): `WebPageFolder`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|WebPageFolderGUID\*|Unique identifier for the folder. Used for both ContentItem and WebPageItem GUIDs.|System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|WebPageFolderName\*|Code name of the folder|string?||
|WebPageFolderDisplayName\*|Display name of the folder shown in the admin UI|string?||
|WebPageFolderTreePath\*|Tree path of the folder (e.g., "/articles/reviews")|string?||
|WebPageFolderParentGUID|GUID of the parent folder or page. If null, folder is created at the root|System.Guid?|Reference to [WebPageItemInfo](../References.md#WebPageItemInfo) on property WebPageItemParentID|
|WebsiteChannelName\*|Code name of the website channel where the folder will be created|string?||
|LanguageName\*|Language code for the folder's display name (e.g., "en")|string?||
|WebPageFolderOrder|Order of the folder within its parent. If null, defaults to 0|int?||

<p>*) value is required</p>


### Web Page Folder Sample
This sample describes how to create a web page folder in the content tree
```json
{
  "$type": "WebPageFolder",
  "webPageFolderGUID": "f47ac10b-58cc-4372-a567-0e02b2c3d479",
  "webPageFolderName": "TestFolder",
  "webPageFolderDisplayName": "Test Folder",
  "webPageFolderTreePath": "/test-folder",
  "webPageFolderParentGUID": null,
  "websiteChannelName": "websitechannelExample",
  "languageName": "en-US",
  "webPageFolderOrder": 0
}
```

### Nested Web Page Folder Sample
This sample describes how to create a nested web page folder
```json
{
  "$type": "WebPageFolder",
  "webPageFolderGUID": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
  "webPageFolderName": "NestedTestFolder",
  "webPageFolderDisplayName": "Nested Test Folder",
  "webPageFolderTreePath": "/test-folder/nested-folder",
  "webPageFolderParentGUID": "f47ac10b-58cc-4372-a567-0e02b2c3d479",
  "websiteChannelName": "websitechannelExample",
  "languageName": "en-US",
  "webPageFolderOrder": 0
}
```
