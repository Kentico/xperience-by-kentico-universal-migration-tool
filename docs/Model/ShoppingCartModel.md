<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## ShoppingCartModel
Model represents XbyK ShoppingCartInfo.

Model [discriminator](../UmtModel.md#discriminator): `ShoppingCart`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|ShoppingCartGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|ShoppingCartUniqueIdentifier\*||string?||
|ShoppingCartModifiedWhen||System.DateTime?||
|ShoppingCartMemberGUID|reference to member|System.Guid?|Reference to [MemberInfo](../References.md#MemberInfo) on property ShoppingCartMemberID|
|ShoppingCartData||string?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>

