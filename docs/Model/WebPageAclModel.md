<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## WebPageAclModel
Model represents XbyK WebPageAclInfo

Model [discriminator](../UmtModel.md#discriminator): `WebPageAcl`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|WebPageAclGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|WebPageAclWebsiteChannelGUID\*||System.Guid?|Reference to [WebsiteChannelInfo](../References.md#WebsiteChannelInfo) on property WebPageAclWebsiteChannelID **required**|
|WebPageAclWebPageItemGUID\*||System.Guid?|Reference to [WebPageItemInfo](../References.md#WebPageItemInfo) on property WebPageAclWebPageItemID **required**|
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### ContentItem ACL Sample
This sample describes how to set Web page ACL
```json
{
  "$type": "WebPageAcl",
  "webPageAclGUID": "dcfbda0a-8b7a-4a29-896a-54ed556c65d6",
  "webPageAclWebsiteChannelGUID": "a6ba6fcb-9d05-4abe-afb4-74b153c90db7",
  "webPageAclWebPageItemGUID": "6e995319-77e7-475e-9ebb-607bdbf5af9a"
}
```
