<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## EmailChannelModel
Model represents XbyK EmailChannelInfo

Model [discriminator](../UmtModel.md#discriminator): `EmailChannel`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|EmailChannelGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|EmailChannelSendingDomain\*||string?||
|EmailChannelPrimaryContentLanguageGUID\*||System.Guid?|Reference to [ContentLanguageInfo](../References.md#ContentLanguageInfo) on property EmailChannelPrimaryContentLanguageID **required**|
|EmailChannelChannelGuid\*||System.Guid?|Reference to [ChannelInfo](../References.md#ChannelInfo) on property EmailChannelChannelID **required**|
|EmailChannelServiceDomain\*||string?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### EmailChannel Sample
This sample describes how to create class inside XbyK to hold EmailChannel data
```json
{
  "$type": "EmailChannel",
  "emailChannelGUID": "2c7309ec-1e24-4715-ae6c-8c7efc98a4c5",
  "emailChannelSendingDomain": "emailChannelsample.com",
  "emailChannelPrimaryContentLanguageGUID": "f454e93b-5fe9-42a9-b1af-b572234ed9c4",
  "emailChannelChannelGuid": "fc847362-e4b0-40ae-8235-f20098daf09f",
  "emailChannelServiceDomain": "www.emailChannelSendingDomainSample"
}
```
