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
  "ChannelDisplayName": "ChannelForEmailChannelExample",
  "ChannelName": "ChannelForEmailChannelExampleNotDisplayed",
  "ChannelGUID": "23e5e2ef-df79-4c5d-8d31-739c004c2095",
  "ChannelType": 1
}
```
