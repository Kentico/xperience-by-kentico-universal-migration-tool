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


### Instance of CustomerAddressInfo - Sample customer address
Sample demonstrates how to create a customer address
```json
{
  "$type": "CustomerAddress",
  "customerAddressGUID": "c3d4e5f6-a7b8-4901-c234-56789abcdef0",
  "customerAddressCustomerGUID": "a1b2c3d4-e5f6-4789-a012-3456789abcde",
  "customerAddressFirstName": "John",
  "customerAddressLastName": "Doe",
  "customerAddressCompany": "Sample Company Inc.",
  "customerAddressEmail": "john.doe@sample.localhost",
  "customerAddressPhone": "\u002B1-555-0123",
  "customerAddressLine1": "123 Main Street",
  "customerAddressLine2": "Suite 100",
  "customerAddressCity": "New York",
  "customerAddressZip": "10001"
}
```
