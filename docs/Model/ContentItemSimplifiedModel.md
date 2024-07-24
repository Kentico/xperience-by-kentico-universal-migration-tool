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
|ScheduledPublishWhen|Date and time on which draft content item will be published, must be set in future|System.DateTime?||
|ScheduledUnpublishWhen|Date and time on which published content item will be unpublished, must be set in future|System.DateTime?||
|ContentItemData||System.Collections.Generic.Dictionary<string, object?>?||

<p>*) value is required</p>

## PageDataModel

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|PageUrls|PageUrlModel item is required for each content language that exist in XbyK instance without regards to created LanguageData (urls are pre-created for non-existing language versions)|Kentico.Xperience.UMT.Model.PageUrlModel[]||
|PageGuid|Required only if page needs to be referenced as a parent by any child page|System.Guid?||
|ParentGuid||System.Guid?||
|TreePath||string?||
|ItemOrder||int?||

<p>*) value is required</p>

## PageUrlModel
Defines url for web page item


|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|UrlPath||string?||
|PathIsDraft|currently unused, until simplified model supports Draft content items (and not only Published or InitialDraft)|bool?||
|LanguageName||string?||

<p>*) value is required</p>

