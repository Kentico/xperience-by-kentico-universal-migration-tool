using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class CustomerSamples
{
    public static readonly Guid SAMPLE_CUSTOMER_GUID = new("A1B2C3D4-E5F6-4789-A012-3456789ABCDE");

    [Sample("customer.sample.basic", "Sample demonstrates how to create a customer without member reference", "Instance of dataclass CustomerInfo - Sample customer without member")]
    public static CustomerModel SampleCustomerBasic => new()
    {
        CustomerGUID = SAMPLE_CUSTOMER_GUID,
        CustomerFirstName = "John",
        CustomerLastName = "Doe",
        CustomerEmail = "john.doe@sample.localhost",
        CustomerPhone = "+1-555-0123",
        CustomerCreatedWhen = new DateTime(2024, 01, 15, 10, 30, 0, DateTimeKind.Utc)
    };


    [Sample("customer.sample.withmember", "Sample demonstrates how to create a customer with member reference", "Instance of dataclass CustomerInfo - Sample customer with member")]
    public static CustomerModel SampleCustomerWithMember => new()
    {
        CustomerGUID = new Guid("B2C3D4E5-F6A7-4890-B123-456789ABCDEF"),
        CustomerFirstName = "Jane",
        CustomerLastName = "Smith",
        CustomerEmail = "jane.smith@sample.localhost",
        CustomerPhone = "+1-555-0456",
        CustomerMemberGUID = MemberSamples.SampleMemberNoCustomFields.MemberGUID,
        CustomerCreatedWhen = new DateTime(2024, 02, 20, 14, 15, 0, DateTimeKind.Utc)
    };
}

