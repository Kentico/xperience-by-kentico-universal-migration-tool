<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## WebPageItemModel
Model [discriminator](../UmtModel.md#discriminator): `WebPageItem`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|WebPageItemGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|WebPageItemParentGuid||System.Guid?|Reference to [WebPageItemInfo](../References.md#WebPageItemInfo) on property WebPageItemParentID|
|WebPageItemName\*||string?||
|WebPageItemTreePath\*||string?||
|WebPageItemWebsiteChannelGuid\*||System.Guid?|Reference to [WebsiteChannelInfo](../References.md#WebsiteChannelInfo) on property WebPageItemWebsiteChannelID **required**|
|WebPageItemContentItemGuid\*||System.Guid?|Reference to [ContentItemInfo](../References.md#ContentItemInfo) on property WebPageItemContentItemID **required**|
|WebPageItemOrder\*||int?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>

