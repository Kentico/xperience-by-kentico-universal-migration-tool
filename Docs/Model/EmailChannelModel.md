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
  "EmailChannelGUID": "60389185-de57-4c7a-a0e5-a51e098b67a6",
  "EmailChannelSendingDomain": "emailChannelSendingDomainSample.com",
  "EmailChannelPrimaryContentLanguageGUID": "fd0a0727-fc68-4936-b868-119df0f0ad7a",
  "EmailChannelChannelGuid": "b90b4535-eb9d-4f2c-9f52-813be4102e00",
  "EmailChannelServiceDomain": "www.emailChannelSendingDomainSample"
}
```
