using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class ShippingMethodSamples
{
    public static readonly Guid SAMPLE_SHIPPING_METHOD_STANDARD_GUID = new("C9D0E1F2-A3B4-4567-C890-DEF012345678");
    public static readonly Guid SAMPLE_SHIPPING_METHOD_EXPRESS_GUID = new("D0E1F2A3-B4C5-4678-D901-EF0123456789");

    [Sample("shippingmethod.sample.standard", "Sample demonstrates how to create a standard shipping method", "Instance of dataclass ShippingMethodInfo - Sample standard shipping method")]
    public static ShippingMethodModel SampleShippingMethodStandard => new()
    {
        ShippingMethodGUID = SAMPLE_SHIPPING_METHOD_STANDARD_GUID,
        ShippingMethodName = "Standard",
        ShippingMethodDisplayName = "Standard Shipping",
        ShippingMethodDescription = "Standard shipping (5-7 business days)",
        ShippingMethodEnabled = true,
        ShippingMethodPrice = 5.99m
    };


    [Sample("shippingmethod.sample.express", "Sample demonstrates how to create an express shipping method", "Instance of dataclass ShippingMethodInfo - Sample express shipping method")]
    public static ShippingMethodModel SampleShippingMethodExpress => new()
    {
        ShippingMethodGUID = SAMPLE_SHIPPING_METHOD_EXPRESS_GUID,
        ShippingMethodName = "Express",
        ShippingMethodDisplayName = "Express Shipping",
        ShippingMethodDescription = "Express shipping (1-2 business days)",
        ShippingMethodEnabled = true,
        ShippingMethodPrice = 15.99m
    };
}

