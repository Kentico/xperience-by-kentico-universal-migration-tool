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


### Simplified model for webpage content item sample with parent
Simplified model for importing webpage content item with parent
```json
{
  "$type": "ContentItemSimplified",
  "ContentItemGUID": "9ed8de86-859c-4f6c-94f2-cdd6baed99fe",
  "IsSecured": false,
  "ContentTypeName": "UMT.Article",
  "Name": "SimplifiedModelSampleAsSubPAge",
  "IsReusable": false,
  "ChannelName": "websitechannelExample",
  "LanguageData": [
    {
      "LanguageName": "en-US",
      "DisplayName": "Simplified model sample sub page - en-us",
      "VersionStatus": 0,
      "UserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
      "ContentItemData": {
        "ArticleTitle": "en-US UMT simplified model creation as sub page",
        "ArticleTeaser": {
          "$assetType": "AssetFile",
          "FilePath": "##ASSETDIR##\\sample.png",
          "ContentItemGuid": "9ed8de86-859c-4f6c-94f2-cdd6baed99fe",
          "Identifier": "cb2b28bb-25bf-47d0-8553-6a1d85d5dc85",
          "Name": "my superb asset.jpg",
          "Extension": ".jpg"
        },
        "ArticleText": "This article is only example of creation UMT simplified model for en-US language",
        "RelatedArticles": null,
        "RelatedFaq": null
      }
    },
    {
      "LanguageName": "en-GB",
      "DisplayName": "Simplified model sample sub page - en-gb",
      "VersionStatus": 2,
      "UserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
      "ContentItemData": {
        "ArticleTitle": "en-GB UMT simplified model creation as sub page",
        "ArticleTeaser": {
          "$assetType": "AssetUrl",
          "Url": "https://devnet.kentico.com/DevNet/media/devnet/cms_screen.jpg",
          "ContentItemGuid": "9ed8de86-859c-4f6c-94f2-cdd6baed99fe",
          "Identifier": "8d6191f6-3b02-4bce-a48e-4282462549b6",
          "Name": "cms screen.jpg",
          "Extension": ".jpg"
        },
        "ArticleText": "This article is only example of creation UMT simplified model for en-GB language",
        "RelatedArticles": null,
        "RelatedFaq": null
      }
    }
  ],
  "PageData": {
    "PageUrls": [
      {
        "UrlPath": "en-us/simplified-sample/sub-page",
        "LanguageName": "en-US"
      },
      {
        "UrlPath": "en-gb/simplified-sample/sub-page",
        "LanguageName": "en-GB"
      },
      {
        "UrlPath": "es/simplified-sample/sub-page",
        "LanguageName": "es"
      }
    ],
    "ParentGuid": "4ea03de4-977e-48aa-9340-babf3d23bafa",
    "TreePath": "/simplified-sample/sub-page"
  }
}
```

### Simplified model for webpage content item sample
Simplified model for importing webpage content item
```json
{
  "$type": "ContentItemSimplified",
  "ContentItemGUID": "37c3f5dd-6f2a-4eff-b46e-a36eddebf572",
  "IsSecured": false,
  "ContentTypeName": "UMT.Article",
  "Name": "SimplifiedModelSample",
  "IsReusable": false,
  "ChannelName": "websitechannelExample",
  "LanguageData": [
    {
      "LanguageName": "en-US",
      "DisplayName": "Simplified model sample - en-us",
      "VersionStatus": 0,
      "ScheduledPublishWhen": "2045-01-01T00:00:00Z",
      "ContentItemData": {
        "ArticleTitle": "en-US UMT simplified model creation",
        "ArticleText": "This article is only example of creation UMT simplified model for en-US language",
        "RelatedArticles": null,
        "RelatedFaq": null,
        "CoffeaTaxonomy": "[{\u0022Identifier\u0022:\u0022a6e3cc11-95a8-482c-beb4-58bbef6e7bdd\u0022},{\u0022Identifier\u0022:\u0022bb181050-79b0-4f42-9280-ef486a139623\u0022}]"
      }
    },
    {
      "LanguageName": "en-GB",
      "DisplayName": "Simplified model sample - en-gb",
      "VersionStatus": 2,
      "ScheduledUnpublishWhen": "2045-01-01T00:00:00Z",
      "ContentItemData": {
        "ArticleTitle": "en-GB UMT simplified model creation",
        "ArticleText": "This article is only example of creation UMT simplified model for en-GB language",
        "RelatedArticles": null,
        "RelatedFaq": null,
        "CoffeaTaxonomy": "[{\u0022Identifier\u0022:\u0022a6e3cc11-95a8-482c-beb4-58bbef6e7bdd\u0022},{\u0022Identifier\u0022:\u0022bb181050-79b0-4f42-9280-ef486a139623\u0022}]"
      }
    }
  ],
  "PageData": {
    "PageUrls": [
      {
        "UrlPath": "en-us/simplified-sample",
        "LanguageName": "en-US"
      },
      {
        "UrlPath": "en-gb/simplified-sample",
        "LanguageName": "en-GB"
      },
      {
        "UrlPath": "es/simplified-sample",
        "LanguageName": "es"
      }
    ],
    "PageGuid": "4ea03de4-977e-48aa-9340-babf3d23bafa",
    "TreePath": "/simplified-sample"
  }
}
```
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

