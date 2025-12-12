using Microsoft.Playwright;

namespace TestAfterMigration.Tests
{
    public class Tests_11_Orders : AdminTestBase
    {
        [Test]
        public async Task Test00100_Expected_Order_Structure_Created_And_Explorable()
        {
            await OpenAdminApplication("orders");

            var orders = await Page.GetByTestId("table-row").AllAsync();
            await ValidateOrder(orders[0], "ORD-2024-002", "46.94");
            await ValidateOrder(orders[1], "ORD-2024-001", "149.95");

            await ValidateOrder1(orders[1]);
            await ValidateOrder2(orders[0]);

            await AssertNoEventlogErrors();
        }


        private async Task ValidateOrder1(ILocator order)
        {
            await OpenAdminApplication("orders");

            await order.ClickAsync();
            await Debounce();

            var addressRow = Page.GetByTestId("billing-address");
            await ValidateOrderAddress(addressRow, "John", "Doe", null, "john.doe@sample.localhost", "+1-555-0123", "123 Main Street", "Suite 100", "New York", "10001");

            await Page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasText = "Ordered items" }).Nth(1).ClickAsync();

            await Debounce();
            var itemRows = await Page.GetByTestId("table-row").AllAsync();

            await ValidateOrderItem(itemRows[0], "PROD-001", "Sample Product", "2", "49.99", "99.98");
            await ValidateOrderItem(itemRows[1], "PROD-002", "Another Sample Product", "1", "29.99", "29.99");
        }


        private async Task ValidateOrder2(ILocator order)
        {
            await OpenAdminApplication("orders");

            await order.ClickAsync();
            await Debounce();

            var addressRow = Page.GetByTestId("billing-address");
            await ValidateOrderAddress(addressRow, "John", "Doe", "Sample Company Inc.", "john.doe@sample.localhost", "+1-555-0123", "123 Main Street", "Suite 100", "New York", "10001");

            await Page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasText = "Ordered items" }).Nth(1).ClickAsync();

            await Debounce();
            var itemRows = await Page.GetByTestId("table-row").AllAsync();

            await ValidateOrderItem(itemRows[0], "PROD-003", "Sample Product with methods", "2", "9.99", "19.98");
        }


        private static async Task ValidateOrder(ILocator orderRow, string orderNumber, string orderGrandTotal)
        {
            var number = await orderRow.GetByTestId("table-cell-OrderNumber").TextContentAsync();
            var grandTotal = await orderRow.GetByTestId("table-cell-OrderGrandTotal").TextContentAsync();

            Assert.Multiple(() =>
            {
                Assert.That(number, Is.EqualTo(orderNumber));
                Assert.That(grandTotal, Is.EqualTo(orderGrandTotal));
            });
        }


        private static async Task ValidateOrderItem(ILocator itemRow, string sku, string name, string quantity, string unitPrice, string totalPrice)
        {
            var itemSku = await itemRow.GetByTestId("table-cell-OrderItemSKU").TextContentAsync();
            var itemName = await itemRow.GetByTestId("table-cell-OrderItemName").TextContentAsync();
            var itemQuantity = await itemRow.GetByTestId("table-cell-OrderItemQuantity").TextContentAsync();
            var itemUnitPrice = await itemRow.GetByTestId("table-cell-OrderItemUnitPrice").TextContentAsync();
            var itemTotalPrice = await itemRow.GetByTestId("table-cell-OrderItemTotalPrice").TextContentAsync();

            Assert.Multiple(() =>
            {
                Assert.That(itemSku, Is.EqualTo(sku));
                Assert.That(itemName, Is.EqualTo(name));
                Assert.That(itemQuantity, Is.EqualTo(quantity));
                Assert.That(itemUnitPrice, Is.EqualTo(unitPrice));
                Assert.That(itemTotalPrice, Is.EqualTo(totalPrice));
            });
        }


        private static async Task ValidateOrderAddress(ILocator addressRow, string addressFirstName, string addressLastName, string? addressCompany, string addressEmail, string phoneNumber, string addressLine1, string addressLine2, string addressCity, string addressZip)
        {
            var firstName = await addressRow.GetByTestId("OrderAddressFirstName").TextContentAsync();
            var lastName = await addressRow.GetByTestId("OrderAddressLastName").TextContentAsync();
            var company = await addressRow.GetByTestId("OrderAddressCompany").TextContentAsync();
            var email = await addressRow.GetByTestId("OrderAddressEmail").TextContentAsync();
            var phone = await addressRow.GetByTestId("OrderAddressPhone").TextContentAsync();
            var line1 = await addressRow.GetByTestId("OrderAddressLine1").TextContentAsync();
            var line2 = await addressRow.GetByTestId("OrderAddressLine2").TextContentAsync();
            var city = await addressRow.GetByTestId("OrderAddressCity").TextContentAsync();
            var zip = await addressRow.GetByTestId("OrderAddressZip").TextContentAsync();

            Assert.Multiple(() =>
            {
                Assert.That(firstName, Is.EqualTo(addressFirstName));
                Assert.That(lastName, Is.EqualTo(addressLastName));
                if (addressCompany != null)
                {
                    Assert.That(company, Is.EqualTo(addressCompany));
                }
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
