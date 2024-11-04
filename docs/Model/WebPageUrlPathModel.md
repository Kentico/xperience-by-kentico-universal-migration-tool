<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## WebPageUrlPathModel
Model [discriminator](../UmtModel.md#discriminator): `WebPageUrlPath`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|WebPageUrlPathGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|WebPageUrlPath||string?||
|WebPageUrlPathHash||string?||
|WebPageUrlPathWebPageItemGuid\*||System.Guid?|Reference to [WebPageItemInfo](../References.md#WebPageItemInfo) on property WebPageUrlPathWebPageItemID **required**|
|WebPageUrlPathWebsiteChannelGuid\*||System.Guid?|Reference to [WebsiteChannelInfo](../References.md#WebsiteChannelInfo) on property WebPageUrlPathWebsiteChannelID **required**|
|WebPageUrlPathContentLanguageGuid\*||System.Guid?|Reference to [ContentLanguageInfo](../References.md#ContentLanguageInfo) on property WebPageUrlPathContentLanguageID **required**|
|WebPageUrlPathIsLatest||bool?||
|WebPageUrlPathIsDraft||bool?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>

