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
  "WebsiteChannelGUID": "a6ba6fcb-9d05-4abe-afb4-74b153c90db7",
  "WebsiteChannelChannelGuid": "5322a379-5b5f-4220-9383-8e3115e66cd3",
  "WebsiteChannelDomain": "websitesamplewebsitedomain.com",
  "WebsiteChannelHomePage": "home",
  "WebsiteChannelPrimaryContentLanguageGuid": "f454e93b-5fe9-42a9-b1af-b572234ed9c4",
  "WebsiteChannelDefaultCookieLevel": 1000,
  "WebsiteChannelStoreFormerUrls": false
}
```
