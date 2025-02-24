<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## WebPageScopeModel
Model represents XbyK WebPageScopeInfo

Model [discriminator](../UmtModel.md#discriminator): `WebPageScope`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|WebPageScopeGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|WebPageScopeWebsiteChannelGuid\*||System.Guid?|Reference to [WebsiteChannelInfo](../References.md#WebsiteChannelInfo) on property WebPageScopeWebsiteChannelID **required**|
|WebPageScopeWebPageItemGuid||System.Guid?|Reference to [WebPageItemInfo](../References.md#WebPageItemInfo) on property WebPageScopeWebPageItemID|
|WebPageScopeIncludeChildren\*||bool?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>

