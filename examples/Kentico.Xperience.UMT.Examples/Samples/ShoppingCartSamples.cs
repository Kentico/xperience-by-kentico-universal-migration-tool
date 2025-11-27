using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class ShoppingCartSamples
{
    public static readonly Guid SAMPLE_SHOPPING_CART_WITH_MEMBER_GUID = new("C3D4E5F6-A7B8-4901-C234-56789ABCDEF0");
    public static readonly Guid SAMPLE_SHOPPING_CART_ANONYMOUS_GUID = new("D4E5F6A7-B8C9-4012-D345-6789ABCDEF01");

    [Sample("shoppingcart.sample.withmember", "Sample demonstrates how to create a shopping cart for a member", "Instance of dataclass ShoppingCartInfo - Sample shopping cart with member")]
    public static ShoppingCartModel SampleShoppingCartWithMember => new()
    {
        ShoppingCartGUID = SAMPLE_SHOPPING_CART_WITH_MEMBER_GUID,
        ShoppingCartUniqueIdentifier = Guid.NewGuid().ToString(),
        ShoppingCartModifiedWhen = DateTime.UtcNow,
        ShoppingCartMemberGUID = MemberSamples.SampleMemberNoCustomFields.MemberGUID,
        ShoppingCartData = "sample data"
    };


    [Sample("shoppingcart.sample.anonymous", "Sample demonstrates how to create an anonymous shopping cart", "Instance of dataclass ShoppingCartInfo - Sample anonymous shopping cart")]
    public static ShoppingCartModel SampleShoppingCartAnonymous => new()
    {
        ShoppingCartGUID = SAMPLE_SHOPPING_CART_ANONYMOUS_GUID,
        ShoppingCartUniqueIdentifier = Guid.NewGuid().ToString(),
        ShoppingCartModifiedWhen = DateTime.UtcNow,
        ShoppingCartMemberGUID = null,
        ShoppingCartData = "sample data"
    };
}

