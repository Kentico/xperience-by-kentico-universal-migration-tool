<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## ContentTypeChannelModel
Model represents XbyK ContentTypeChannelInfo

Model [discriminator](../UmtModel.md#discriminator): `ContentTypeChannel`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|ContentTypeChannelChannelGuid\*||System.Guid?|Reference to [ChannelInfo](../References.md#ChannelInfo) on property ContentTypeChannelChannelID **required**|
|ContentTypeChannelContentTypeGuid\*||System.Guid?|Reference to [DataClassInfo](../References.md#DataClassInfo) on property ContentTypeChannelContentTypeID **required**|
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Sample of content type assignment to channel

```json
{
  "$type": "ContentTypeChannel",
  "contentTypeChannelChannelGuid": "5322a379-5b5f-4220-9383-8e3115e66cd3",
  "contentTypeChannelContentTypeGuid": "06540294-3b56-4cf7-8773-088bb766ac23"
}
```
