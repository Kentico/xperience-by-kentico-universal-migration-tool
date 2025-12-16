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

