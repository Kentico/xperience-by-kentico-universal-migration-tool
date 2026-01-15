using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class ShippingMethodSamples
{
    public static readonly Guid SAMPLE_SHIPPING_METHOD_STANDARD_GUID = new("A1B2C3D4-E5F6-4789-ABCD-1234567890AB");
    public static readonly Guid SAMPLE_SHIPPING_METHOD_EXPRESS_GUID = new("B1B2C3D4-E5F6-4789-ABCD-0123456789AB");


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

