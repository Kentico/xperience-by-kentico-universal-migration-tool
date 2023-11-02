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
  "EmailChannelGUID": "38523545-9bff-4833-bcfc-8aeeefe816ee",
  "EmailChannelSendingDomain": "emailChannelSendingDomainSample.com",
  "EmailChannelPrimaryContentLanguageGUID": "fd0a0727-fc68-4936-b868-119df0f0ad7a",
  "EmailChannelChannelGuid": "23e5e2ef-df79-4c5d-8d31-739c004c2095",
  "EmailChannelServiceDomain": "www.emailChannelSendingDomainSample"
}
```
