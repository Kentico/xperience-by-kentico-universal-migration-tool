<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## EmailChannelModel
Model represents EmailChannel

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


### Sample
Sample
```json
{
  "$type": "EmailChannel",
  "EmailChannelGUID": "d9d985a7-64cc-4123-8fe7-0a9d3671f8a3",
  "EmailChannelSendingDomain": "aaaaaaaaaaaabsolutelynew11111111111emaildomainfortryingfinalversionofsample.com",
  "EmailChannelPrimaryContentLanguageGUID": "fd0a0727-fc68-4936-b868-119df0f0ad7a",
  "EmailChannelChannelGuid": "81f8e302-40a3-4286-b772-fb7405f68a08",
  "EmailChannelServiceDomain": "aaaaaaaaaaaaaaaaaaaabsse111111111111ndingdomainfortryingthesamethingbutdiffetrentdomain.com"
}
```
