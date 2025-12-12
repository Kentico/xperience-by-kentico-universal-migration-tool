<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## CustomerModel
Model represents XbyK .

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

