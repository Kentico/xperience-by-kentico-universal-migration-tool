<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## ChannelModel
Model represents XbyK ChannelInfo

Model [discriminator](../UmtModel.md#discriminator): `Channel`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|ChannelDisplayName\*||string?||
|ChannelName\*||string?||
|ChannelGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|ChannelType\*||CMS.ContentEngine.ChannelType?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Channel Sample for Email Channel Sample
This sample describes how to create class inside XbyK to hold Channel data to be used with EmailChannel data
```json
{
  "$type": "Channel",
  "ChannelDisplayName": "email Channel Example",
  "ChannelName": "emailChannelExampleBasic",
  "ChannelGUID": "fc847362-e4b0-40ae-8235-f20098daf09f",
  "ChannelType": 1
}
```
