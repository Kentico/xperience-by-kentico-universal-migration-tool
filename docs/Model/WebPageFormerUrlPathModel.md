<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## WebPageFormerUrlPathModel
Model [discriminator](../UmtModel.md#discriminator): `WebPageFormerUrlPath`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|WebPageFormerUrlPathGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|WebPageFormerUrlPath||string?||
|WebPageFormerUrlPathHash||string?||
|WebPageFormerUrlPathWebPageItemGuid\*||System.Guid?|Reference to [WebPageItemInfo](../References.md#WebPageItemInfo) on property WebPageFormerUrlPathWebPageItemID **required**|
|WebPageFormerUrlPathWebsiteChannelGuid\*||System.Guid?|Reference to [WebsiteChannelInfo](../References.md#WebsiteChannelInfo) on property WebPageFormerUrlPathWebsiteChannelID **required**|
|WebPageFormerUrlPathContentLanguageGuid\*||System.Guid?|Reference to [ContentLanguageInfo](../References.md#ContentLanguageInfo) on property WebPageFormerUrlPathContentLanguageID **required**|
|WebPageFormerUrlPathSourceWebPageItemGuid||System.Guid?|Reference to [WebPageItemInfo](../References.md#WebPageItemInfo) on property WebPageFormerUrlPathSourceWebPageItemID|
|WebPageFormerUrlPathIsRedirect\*||bool?||
|WebPageFormerUrlPathIsRedirectScheduled\*||bool?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>

