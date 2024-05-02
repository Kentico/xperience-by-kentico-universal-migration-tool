<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## ContentItemSimplifiedModel
Model [discriminator](../UmtModel.md#discriminator): `ContentItemSimplified`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|ContentItemGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|ContentItemContentFolderGUID|Reference to content folder|System.Guid?||
|IsSecured||bool?||
|ContentTypeName\*|Content item type name.|string?||
|Name\*|Code name of the content item.|string?||
|IsReusable|Indicates if content item is reusable. By default, item will be created as reusable.|bool||
|ChannelName|ID of a channel the content item is owned by. By default, item won't be owned by a channel.|string?||
|LanguageData||Kentico.Xperience.UMT.Model.ContentItemLanguageData[]||
|PageData||Kentico.Xperience.UMT.Model.PageDataModel?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>

## ContentItemLanguageData

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|LanguageName\*||string||
|DisplayName\*||string||
|VersionStatus||CMS.ContentEngine.VersionStatus||
|UserGuid\*||System.Guid?||
|ContentItemData||System.Collections.Generic.Dictionary<string, object?>?||

<p>*) value is required</p>

## PageDataModel

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|PageUrls||Kentico.Xperience.UMT.Model.PageUrlModel[]||
|ParentGuid||System.Guid?||
|TreePath||string?||
|ItemOrder||int?||

<p>*) value is required</p>

## PageUrlModel

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|UrlPath||string?||
|PathIsDraft||bool?||
|LanguageName||string?||

<p>*) value is required</p>

