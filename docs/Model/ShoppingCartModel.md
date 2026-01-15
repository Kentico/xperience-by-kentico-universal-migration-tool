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

### Sample of shopping cart

```json
{
  "$type": "ShoppingCart",
  "shoppingCartGUID": "b8c9d0e1-f2a3-4124-a567-89abcdef0123",
  "shoppingCartUniqueIdentifier": "cart-abc123def456",
  "shoppingCartModifiedWhen": "2024-02-15T14:20:00Z",
  "shoppingCartMemberGUID": null,
  "shoppingCartData": null
}
```
