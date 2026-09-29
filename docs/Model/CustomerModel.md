<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## CustomerModel
Model represents XbyK CustomerInfo.

Model [discriminator](../UmtModel.md#discriminator): `Customer`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|CustomerGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|CustomerFirstName||string?||
|CustomerLastName||string?||
|CustomerEmail||string?||
|CustomerPhone||string?||
|CustomerMemberGUID||System.Guid?|Reference to [MemberInfo](../References.md#MemberInfo) on property CustomerMemberID|
|CustomerCreatedWhen||System.DateTime?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Instance of CustomerInfo - Sample customer without member
Sample demonstrates how to create a customer without member reference
```json
{
  "$type": "Customer",
  "customerGUID": "a1b2c3d4-e5f6-4789-a012-3456789abcde",
  "customerFirstName": "John",
  "customerLastName": "Doe",
  "customerEmail": "john.doe@sample.localhost",
  "customerPhone": "\u002B1-555-0123",
  "customerCreatedWhen": "2024-01-15T10:30:00Z"
}
```
