<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## ContentItemReferenceModel
Model [discriminator](../UmtModel.md#discriminator): `ContentItemReference`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|ContentItemReferenceGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|ContentItemReferenceSourceCommonDataGuid\*||System.Guid?|Reference to [ContentItemCommonDataInfo](../References.md#ContentItemCommonDataInfo) on property ContentItemReferenceSourceCommonDataID **required**|
|ContentItemReferenceTargetItemGuid\*||System.Guid?|Reference to [ContentItemInfo](../References.md#ContentItemInfo) on property ContentItemReferenceTargetItemID **required**|
|ContentItemReferenceGroupGUID\*||System.Guid?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### ContentItemReference article sample (en-US)
Sample of relation between 2 content items inside XbyK
```json
{
  "$type": "ContentItemReference",
  "ContentItemReferenceGUID": "186e37c6-5c55-4637-8feb-ec5cb6547aba",
  "ContentItemReferenceSourceCommonDataGuid": "8f070195-2f39-463e-b7eb-c180c05fd5e0",
  "ContentItemReferenceTargetItemGuid": "b64b3e3e-f5a9-4d02-8cdb-6d81805c0fee",
  "ContentItemReferenceGroupGUID": "fc1fde10-11bf-4174-bd64-d1f114e4b421"
}
```

### ContentItemReference article sample (en-GB)
Sample of relation between 2 content items inside XbyK
```json
{
  "$type": "ContentItemReference",
  "ContentItemReferenceGUID": "e95eefe5-5b89-43ab-91c9-777be00d5680",
  "ContentItemReferenceSourceCommonDataGuid": "49d2caf6-2011-42d7-961d-02614d1b43f4",
  "ContentItemReferenceTargetItemGuid": "b64b3e3e-f5a9-4d02-8cdb-6d81805c0fee",
  "ContentItemReferenceGroupGUID": "fc1fde10-11bf-4174-bd64-d1f114e4b421"
}
```
