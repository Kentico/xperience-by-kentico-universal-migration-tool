<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## WebsiteChannelModel
Model represents XbyK WebSiteChannelInfo

Model [discriminator](../UmtModel.md#discriminator): `WebSiteChannel`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|WebsiteChannelGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|WebsiteChannelChannelGuid\*||System.Guid?|Reference to [ChannelInfo](../References.md#ChannelInfo) on property WebsiteChannelChannelID **required**|
|WebsiteChannelDomain|required for PathPrefix routing, must be null for LanguageDomains routing (domains live in WebsiteChannelDomainOptions configuration)|string?||
|WebsiteChannelHomePage||string?||
|WebsiteChannelPrimaryContentLanguageGuid|required for PathPrefix routing, must be null for LanguageDomains routing (a language-domains channel has no primary language)|System.Guid?|Reference to [ContentLanguageInfo](../References.md#ContentLanguageInfo) on property WebsiteChannelPrimaryContentLanguageID|
|WebsiteChannelDefaultCookieLevel\*||int?||
|WebsiteChannelStoreFormerUrls\*||bool?||
|WebsiteChannelLanguageRoutingMode||CMS.Websites.WebsiteChannelLanguageRoutingMode?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### WebSiteChannel Sample
This sample describes how to create class inside XbyK to hold WebSiteChannel language data
```json
{
  "$type": "WebSiteChannel",
  "websiteChannelGUID": "a6ba6fcb-9d05-4abe-afb4-74b153c90db7",
  "websiteChannelChannelGuid": "5322a379-5b5f-4220-9383-8e3115e66cd3",
  "websiteChannelDomain": "websitesamplewebsitedomain.com",
  "websiteChannelHomePage": "home",
  "websiteChannelPrimaryContentLanguageGuid": "f454e93b-5fe9-42a9-b1af-b572234ed9c4",
  "websiteChannelDefaultCookieLevel": 1000,
  "websiteChannelStoreFormerUrls": false,
  "websiteChannelLanguageRoutingMode": 0
}
```

### WebSiteChannel Sample with language-specific domains
This sample describes how to create a WebSiteChannel that serves each language on its own domain (language-specific domains). Such channel has no database domain and no primary language - the per-language domains are configured in the application's WebsiteChannelDomainOptions
```json
{
  "$type": "WebSiteChannel",
  "websiteChannelGUID": "3a6c4e10-16c1-45d7-88e5-ef6b9c1d24ab",
  "websiteChannelChannelGuid": "0b41bf6e-9d8f-45f0-a9b3-8218ca733fe1",
  "websiteChannelHomePage": "home",
  "websiteChannelDefaultCookieLevel": 1000,
  "websiteChannelStoreFormerUrls": false,
  "websiteChannelLanguageRoutingMode": 1
}
```
