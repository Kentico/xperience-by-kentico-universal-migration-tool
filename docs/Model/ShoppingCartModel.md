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


### Instance of ShoppingCartInfo - Sample anonymous shopping cart
Sample demonstrates how to create an anonymous shopping cart
```json
{
  "$type": "ShoppingCart",
  "shoppingCartGUID": "e5f6a7b8-c9d0-4123-e456-789abcdef012",
  "shoppingCartUniqueIdentifier": "identifier2",
  "shoppingCartModifiedWhen": "2024-03-15T09:30:00Z",
  "shoppingCartData": "{\u0022Items\u0022:[{\u0022ProductIdentifier\u0022:{\u0022VariantIdentifier\u0022:null,\u0022Identifier\u0022:132},\u0022Quantity\u0022:4},{\u0022ProductIdentifier\u0022:{\u0022VariantIdentifier\u0022:null,\u0022Identifier\u0022:108},\u0022Quantity\u0022:1}]}"
}
```
