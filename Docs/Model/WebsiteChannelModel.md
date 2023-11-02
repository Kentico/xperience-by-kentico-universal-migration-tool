<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## WebsiteChannelModel
Model represents EmailChannel

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


### Sample
Sample
```json
{
  "$type": "WebSiteChannel",
  "WebsiteChannelGUID": "93b54c82-dcda-452d-ae99-de16c0b01f19",
  "WebsiteChannelChannelGuid": "08e00761-2cd3-40f8-9a21-c97060da30ff",
  "WebsiteChannelDomain": "examplewebsitedomain.sk",
  "WebsiteChannelHomePage": "home",
  "WebsiteChannelPrimaryContentLanguageGuid": "fd0a0727-fc68-4936-b868-119df0f0ad7a",
  "WebsiteChannelDefaultCookieLevel": 1000,
  "WebsiteChannelStoreFormerUrls": false
}
```
