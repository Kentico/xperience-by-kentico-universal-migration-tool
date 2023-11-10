<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## ContentItemModel
Model [discriminator](../UmtModel.md#discriminator): `ContentItem`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|ContentItemGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|ContentItemName\*||string?||
|ContentItemIsReusable\*||bool?||
|ContentItemIsSecured\*||bool?||
|ContentItemDataClassGuid||System.Guid?|Reference to [DataClassInfo](../References.md#DataClassInfo) on property ContentItemContentTypeID|
|ContentItemChannelGuid\*||System.Guid?|Reference to [ChannelInfo](../References.md#ChannelInfo) on property ContentItemChannelID|
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>

