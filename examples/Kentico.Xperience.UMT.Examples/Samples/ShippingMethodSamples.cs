using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class ShippingMethodSamples
{
    public static readonly Guid SAMPLE_SHIPPING_METHOD_STANDARD_GUID = new("E5F6A7B8-C9D0-4123-E456-789ABCDEF012");
    public static readonly Guid SAMPLE_SHIPPING_METHOD_EXPRESS_GUID = new("F6A7B8C9-D0E1-4234-F567-89ABCDEF0123");


    [Sample("shippingmethod.sample.standard", "Sample demonstrates how to create a standard shipping method", "Instance of ShippingMethodInfo - Sample standard shipping method")]
    public static ShippingMethodModel SampleShippingMethodStandard => new()
    {
        ShippingMethodGUID = SAMPLE_SHIPPING_METHOD_STANDARD_GUID,
        ShippingMethodName = "StandardShipping",
        ShippingMethodDisplayName = "Standard Shipping",
        ShippingMethodDescription = "Standard shipping method with 5-7 business days delivery",
        ShippingMethodEnabled = true,
        ShippingMethodPrice = 9.99m
    };


    [Sample("shippingmethod.sample.express", "Sample demonstrates how to create an express shipping method", "Instance of ShippingMethodInfo - Sample express shipping method")]
    public static ShippingMethodModel SampleShippingMethodExpress => new()
    {
        ShippingMethodGUID = SAMPLE_SHIPPING_METHOD_EXPRESS_GUID,
        ShippingMethodName = "ExpressShipping",
        ShippingMethodDisplayName = "Express Shipping",
        ShippingMethodDescription = "Express shipping method with 1-2 business days delivery",
        ShippingMethodEnabled = true,
        ShippingMethodPrice = 24.99m
    };
}

