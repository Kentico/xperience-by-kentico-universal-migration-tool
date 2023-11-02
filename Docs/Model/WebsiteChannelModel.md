<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## WebsiteChannelModel
Model represents XbyK WebSiteChannelInfo

Model [discriminator](../UmtModel.md#discriminator): `WebSiteChannel`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|WebsiteChannelGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|WebsiteChannelChannelGuid\*||System.Guid?|Reference to [ChannelInfo](../References.md#ChannelInfo) on property WebsiteChannelChannelID **required**|
|WebsiteChannelDomain\*||string?||
|WebsiteChannelHomePage||string?||
|WebsiteChannelPrimaryContentLanguageGuid\*||System.Guid?|Reference to [ContentLanguageInfo](../References.md#ContentLanguageInfo) on property WebsiteChannelPrimaryContentLanguageID **required**|
|WebsiteChannelDefaultCookieLevel\*||int?||
|WebsiteChannelStoreFormerUrls\*||bool?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### WebSiteChannel Sample
This sample describes how to create class inside XbyK to hold WebSiteChannel language data
```json
{
  "$type": "WebSiteChannel",
  "WebsiteChannelGUID": "7e4c44b5-b595-495a-8b46-11171918191e",
  "WebsiteChannelChannelGuid": "3acd3312-0f35-42d0-b6cc-16eb5bf4a1bc",
  "WebsiteChannelDomain": "samplewebsitedomain.com",
  "WebsiteChannelHomePage": "home",
  "WebsiteChannelPrimaryContentLanguageGuid": "fd0a0727-fc68-4936-b868-119df0f0ad7a",
  "WebsiteChannelDefaultCookieLevel": 1000,
  "WebsiteChannelStoreFormerUrls": false
}
```
