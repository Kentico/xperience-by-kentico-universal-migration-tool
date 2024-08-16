<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## WebPageAclMappingModel
Model represents XbyK WebPageAclMappingInfo

Model [discriminator](../UmtModel.md#discriminator): `WebPageAclMapping`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|WebPageItemGuid\*||System.Guid?|Reference to [WebPageItemInfo](../References.md#WebPageItemInfo) on property WebPageAclMappingWebPageItemID **required**|
|WebPageAclGuid\*||System.Guid?|Reference to [WebPageAclInfo](../References.md#WebPageAclInfo) on property WebPageAclMappingWebPageAclID **required**|
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### ContentItem ACL mapping Sample
This sample describes how to set Web page ACL mapping
```json
{
  "$type": "WebPageAclMapping",
  "WebPageItemGuid": "6e995319-77e7-475e-9ebb-607bdbf5af9a",
  "WebPageAclGuid": "959408c5-d157-4c18-8ae0-a7d9cfb374f5"
}
```

### ContentItem ACL mapping Sample
This sample describes how to set Web page ACL mapping
```json
{
  "$type": "WebPageAclMapping",
  "WebPageItemGuid": "14784bf0-69d0-40cf-8be6-e5a0d897774b",
  "WebPageAclGuid": "105a117d-96b9-4e89-8c9e-d3d414d51f12"
}
```
