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


### Instance of OrderAddressInfo - Sample billing address
Sample demonstrates how to create a billing address for an order
```json
{
  "$type": "OrderAddress",
  "orderAddressGUID": "b1c2d3e4-f5a6-4789-b012-3456789abcde",
  "orderAddressOrderGUID": "e1f2a3b4-c5d6-4789-e012-3456789abcde",
  "orderAddressType": "billing",
  "orderAddressFirstName": "John",
  "orderAddressLastName": "Doe",
  "orderAddressCompany": "Sample Company Inc.",
  "orderAddressEmail": "john.doe@sample.localhost",
  "orderAddressPhone": "\u002B1-555-0123",
  "orderAddressLine1": "123 Main Street",
  "orderAddressLine2": "Suite 100",
  "orderAddressCity": "New York",
  "orderAddressZip": "10001"
}
```
