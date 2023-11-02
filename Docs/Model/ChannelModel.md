<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## ChannelModel
Model [discriminator](../UmtModel.md#discriminator): `Channel`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|ChannelDisplayName\*||string?||
|ChannelName\*||string?||
|ChannelGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|ChannelType\*||CMS.ContentEngine.ChannelType?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Sample
Channel for EmailChannel
```json
{
  "$type": "Channel",
  "ChannelDisplayName": "absoluteluz11Newemailchannelllllll",
  "ChannelName": "abs11Newexampleemailchannellllll",
  "ChannelGUID": "dfc3d631-dbf9-44c7-8907-06a0d8315b7d",
  "ChannelType": 1
}
```
