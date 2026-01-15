using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples
{
    public static class CustomerAddressSamples
    {
        public static readonly Guid SAMPLE_CUSTOMER_ADDRESS_GUID = new("C3D4E5F6-A7B8-4901-C234-56789ABCDEF0");


        [Sample("customeraddress.sample.basic", "Sample demonstrates how to create a customer address", "Instance of CustomerAddressInfo - Sample customer address")]
        public static CustomerAddressModel SampleCustomerAddress => new()
        {
            CustomerAddressGUID = SAMPLE_CUSTOMER_ADDRESS_GUID,
            CustomerAddressCustomerGUID = CustomerSamples.SAMPLE_CUSTOMER_GUID,
            CustomerAddressFirstName = "John",
            CustomerAddressLastName = "Doe",
            CustomerAddressCompany = "Sample Company Inc.",
            CustomerAddressEmail = "john.doe@sample.localhost",
            CustomerAddressPhone = "+1-555-0123",
            CustomerAddressLine1 = "123 Main Street",
            CustomerAddressLine2 = "Suite 100",
            CustomerAddressCity = "New York",
            CustomerAddressZip = "10001"
        };
    }
}
