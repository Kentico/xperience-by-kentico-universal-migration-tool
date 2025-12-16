<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## CustomerAddressModel
Model represents XbyK CustomerAddressInfo.

Model [discriminator](../UmtModel.md#discriminator): `CustomerAddress`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|CustomerAddressGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|CustomerAddressCustomerGUID||System.Guid?|Reference to [CustomerInfo](../References.md#CustomerInfo) on property CustomerAddressCustomerID|
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

