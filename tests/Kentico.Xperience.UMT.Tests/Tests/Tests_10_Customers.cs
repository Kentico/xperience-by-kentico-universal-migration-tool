using Microsoft.Playwright;

namespace TestAfterMigration.Tests
{
    public class Tests_10_Customers : AdminTestBase
    {
        [Test]
        public async Task Test00100_Expected_Customer_Structure_Created_And_Explorable()
        {
            await OpenAdminApplication("customers");

            var customers = await Page.GetByTestId("table-row").AllAsync();
            await ValidateCustomer(customers[0], "John", "Doe", "john.doe@sample.localhost");
            await ValidateCustomer(customers[1], "Jane", "Smith", "jane.smith@sample.localhost");

            await customers[0].ClickAsync();
            await Debounce();
            await Page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasText = "Addresses" }).Nth(1).ClickAsync();

            await Debounce();
            var addresses = await Page.GetByTestId("table-row").AllAsync();

            Assert.That(addresses, Has.Count.EqualTo(1), "Expected 1 address");

            await ValidateAddresses(addresses[0], "John", "Doe", "Sample Company Inc.", "john.doe@sample.localhost", "+1-555-0123", "123 Main Street", "Suite 100", "New York", "10001");

            await AssertNoEventlogErrors();
        }


        private static async Task ValidateCustomer(ILocator customerRow, string customerFirstName, string customerLastName, string customerEmail)
        {
            var firstName = await customerRow.GetByTestId("table-cell-CustomerFirstName").TextContentAsync();
            var lastName = await customerRow.GetByTestId("table-cell-CustomerLastName").TextContentAsync();
            var email = await customerRow.GetByTestId("table-cell-CustomerEmail").TextContentAsync();

            Assert.Multiple(() =>
            {
                Assert.That(firstName, Is.EqualTo(customerFirstName));
                Assert.That(lastName, Is.EqualTo(customerLastName));
                Assert.That(email, Is.EqualTo(customerEmail));
            });
        }


        private static async Task ValidateAddresses(ILocator addressRow, string addressFirstName, string addressLastName, string addressCompany, string addressEmail, string phoneNumber, string addressLine1, string addressLine2, string addressCity, string addressZip)
        {
            var firstName = await addressRow.GetByTestId("table-cell-CustomerAddressFirstName").TextContentAsync();
            var lastName = await addressRow.GetByTestId("table-cell-CustomerAddressLastName").TextContentAsync();
            var company = await addressRow.GetByTestId("table-cell-CustomerAddressCompany").TextContentAsync();
            var email = await addressRow.GetByTestId("table-cell-CustomerAddressEmail").TextContentAsync();
            var phone = await addressRow.GetByTestId("table-cell-CustomerAddressPhone").TextContentAsync();
            var line1 = await addressRow.GetByTestId("table-cell-CustomerAddressLine1").TextContentAsync();
            var line2 = await addressRow.GetByTestId("table-cell-CustomerAddressLine2").TextContentAsync();
            var city = await addressRow.GetByTestId("table-cell-CustomerAddressCity").TextContentAsync();
            var zip = await addressRow.GetByTestId("table-cell-CustomerAddressZip").TextContentAsync();

            Assert.Multiple(() =>
            {
                Assert.That(firstName, Is.EqualTo(addressFirstName));
                Assert.That(lastName, Is.EqualTo(addressLastName));
                Assert.That(company, Is.EqualTo(addressCompany));
                Assert.That(email, Is.EqualTo(addressEmail));
                Assert.That(phone, Is.EqualTo(phoneNumber));
                Assert.That(line1, Is.EqualTo(addressLine1));
                Assert.That(line2, Is.EqualTo(addressLine2));
                Assert.That(city, Is.EqualTo(addressCity));
                Assert.That(zip, Is.EqualTo(addressZip));
            });
        }
    }
}
