<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## CustomerAddressModel
Model represents XbyK CustomerAddressInfo.

Model [discriminator](../UmtModel.md#discriminator): `CustomerAddress`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|CustomerAddressGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|CustomerAddressCustomerGUID||System.Guid?|Reference to [CustomerInfo](../References.md#CustomerInfo) on property CustomerAddressCustomerID **required**|
|CustomerAddressFirstName||string?||
|CustomerAddressLastName||string?||
|CustomerAddressCompany||string?||
|CustomerAddressEmail||string?||
|CustomerAddressPhone||string?||
|CustomerAddressLine1||string?||
|CustomerAddressLine2||string?||
|CustomerAddressCity||string?||
|CustomerAddressZip||string?||
|CustomerAddressCountryGUID||System.Guid?|Reference to [CountryInfo](../References.md#CountryInfo) on property CustomerAddressCountryID|
|CustomerAddressStateGUID||System.Guid?|Reference to [StateInfo](../References.md#StateInfo) on property CustomerAddressStateID|
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Sample of customer address

```json
{
  "$type": "CustomerAddress",
  "customerAddressGUID": "b2c3d4e5-f6a7-4890-b123-456789abcdef",
  "customerAddressCustomerGUID": "a1b2c3d4-e5f6-4789-a012-3456789abcde",
  "customerAddressFirstName": "John",
  "customerAddressLastName": "Doe",
  "customerAddressCompany": "Acme Corporation",
  "customerAddressEmail": "john.doe@example.com",
  "customerAddressPhone": "+1-555-123-4567",
  "customerAddressLine1": "123 Main Street",
  "customerAddressLine2": "Suite 100",
  "customerAddressCity": "New York",
  "customerAddressZip": "10001",
  "customerAddressCountryGUID": null,
  "customerAddressStateGUID": null
}
```