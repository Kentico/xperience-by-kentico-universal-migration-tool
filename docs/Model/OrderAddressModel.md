<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## OrderAddressModel
Model represents XbyK OrderAddressInfo.

Model [discriminator](../UmtModel.md#discriminator): `OrderAddress`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|OrderAddressGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|OrderAddressOrderGUID\*||System.Guid?|Reference to [OrderInfo](../References.md#OrderInfo) on property OrderAddressOrderID **required**|
|OrderAddressType||string?||
|OrderAddressFirstName||string?||
|OrderAddressLastName||string?||
|OrderAddressCompany||string?||
|OrderAddressEmail||string?||
|OrderAddressPhone||string?||
|OrderAddressLine1||string?||
|OrderAddressLine2||string?||
|OrderAddressCity||string?||
|OrderAddressZip||string?||
|OrderAddressCountryGUID||System.Guid?|Reference to [CountryInfo](../References.md#CountryInfo) on property OrderAddressCountryID|
|OrderAddressStateGUID||System.Guid?|Reference to [StateInfo](../References.md#StateInfo) on property OrderAddressStateID|
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Sample of order address

```json
{
  "$type": "OrderAddress",
  "orderAddressGUID": "d4e5f6a7-b8c9-4902-e345-6789abcdef01",
  "orderAddressOrderGUID": "c3d4e5f6-a7b8-4901-c234-56789abcdef0",
  "orderAddressType": "Billing",
  "orderAddressFirstName": "John",
  "orderAddressLastName": "Doe",
  "orderAddressCompany": "Acme Corporation",
  "orderAddressEmail": "john.doe@example.com",
  "orderAddressPhone": "+1-555-123-4567",
  "orderAddressLine1": "123 Main Street",
  "orderAddressLine2": "Suite 100",
  "orderAddressCity": "New York",
  "orderAddressZip": "10001",
  "orderAddressCountryGUID": null,
  "orderAddressStateGUID": null
}
```