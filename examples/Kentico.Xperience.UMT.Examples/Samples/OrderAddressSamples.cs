using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class OrderAddressSamples
{
    public static readonly Guid SAMPLE_ORDER_ADDRESS_BILLING_GUID = new("B1C2D3E4-F5A6-4789-B012-3456789ABCDE");
    public static readonly Guid SAMPLE_ORDER_ADDRESS_SHIPPING_GUID = new("A3B4C5D6-E7F8-4901-A234-56789ABCDEF0");
    public static readonly Guid SAMPLE_ORDER_WITH_METHODS_ADDRESS_BILLING_GUID = new("F2A3B4C5-D6E7-4890-F123-456789ABCDE1");

    [Sample("orderaddress.sample.billing", "Sample demonstrates how to create a billing address for an order", "Instance of OrderAddressInfo - Sample billing address")]
    public static OrderAddressModel SampleOrderAddressBilling => new()
    {
        OrderAddressGUID = SAMPLE_ORDER_ADDRESS_BILLING_GUID,
        OrderAddressOrderGUID = OrderSamples.SAMPLE_ORDER_GUID,
        OrderAddressType = "billing",
        OrderAddressFirstName = "John",
        OrderAddressLastName = "Doe",
        OrderAddressCompany = "Sample Company Inc.",
        OrderAddressEmail = "john.doe@sample.localhost",
        OrderAddressPhone = "+1-555-0123",
        OrderAddressLine1 = "123 Main Street",
        OrderAddressLine2 = "Suite 100",
        OrderAddressCity = "New York",
        OrderAddressZip = "10001"
    };


    [Sample("orderaddress.sample.shipping", "Sample demonstrates how to create a shipping address for an order", "Instance of OrderAddressInfo - Sample shipping address")]
    public static OrderAddressModel SampleOrderAddressShipping => new()
    {
        OrderAddressGUID = SAMPLE_ORDER_ADDRESS_SHIPPING_GUID,
        OrderAddressOrderGUID = OrderSamples.SAMPLE_ORDER_GUID,
        OrderAddressType = "shipping",
        OrderAddressFirstName = "John",
        OrderAddressLastName = "Doe",
        OrderAddressCompany = "Sample Company Inc.",
        OrderAddressEmail = "john.doe@sample.localhost",
        OrderAddressPhone = "+1-555-0123",
        OrderAddressLine1 = "456 Oak Avenue",
        OrderAddressLine2 = "Apt 5B",
        OrderAddressCity = "Brooklyn",
        OrderAddressZip = "11201"
    };


    public static OrderAddressModel SampleOrderWithMethodsAddressBilling => new()
    {
        OrderAddressGUID = SAMPLE_ORDER_WITH_METHODS_ADDRESS_BILLING_GUID,
        OrderAddressOrderGUID = OrderSamples.SAMPLE_ORDER_WITH_METHODS_GUID,
        OrderAddressType = "billing",
        OrderAddressFirstName = "John",
        OrderAddressLastName = "Doe",
        OrderAddressCompany = "Sample Company Inc.",
        OrderAddressEmail = "john.doe@sample.localhost",
        OrderAddressPhone = "+1-555-0123",
        OrderAddressLine1 = "123 Main Street",
        OrderAddressLine2 = "Suite 100",
        OrderAddressCity = "New York",
        OrderAddressZip = "10001"
    };
}
