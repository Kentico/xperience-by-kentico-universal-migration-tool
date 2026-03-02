using Microsoft.Playwright;

namespace TestAfterMigration.Tests;

public class Tests_11_Orders : AdminTestBase
{
    [Test]
    public async Task Test00100_Expected_Order_Structure_Created_And_Explorable()
    {
        await OpenAdminApplication("Orders");

        var orders = await Page.GetByTestId("table-row").AllAsync();
        await ValidateOrder(orders[0], "ORD-2024-002", "46.94");
        await ValidateOrder(orders[1], "ORD-2024-001", "149.95");

        await ValidateOrder1(orders[1]);
        await ValidateOrder2(orders[0]);

        await AssertNoEventlogErrors();
    }


    private async Task ValidateOrder1(ILocator order)
    {
        await OpenAdminApplication("Orders");

        await order.ClickAsync();
        await Debounce();

        await ValidateOrderAddress("John", "Doe", null, "john.doe@sample.localhost", "+1-555-0123", "123 Main Street", "Suite 100", "New York", "10001");
        await ValidateOrderDiscounts("Buy One Get One Free (49.99)", "10% Off Your Order (12.99)");

        await Page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasText = "Ordered items" }).Nth(1).ClickAsync();

        await Debounce();
        var itemRows = await Page.GetByTestId("table-row").AllAsync();

        await ValidateOrderItem(itemRows[0], "PROD-001", "Sample Product", "2", "49.99", "99.98", "7.99", "0.08%");
        await ValidateOrderItem(itemRows[1], "PROD-002", "Another Sample Product", "1", "29.99", "29.99", "8.00", "0.1%");
    }


    private async Task ValidateOrder2(ILocator order)
    {
        await OpenAdminApplication("Orders");

        await order.ClickAsync();
        await Debounce();

        await ValidateOrderAddress("John", "Doe", "Sample Company Inc.", "john.doe@sample.localhost", "+1-555-0123", "123 Main Street", "Suite 100", "New York", "10001");
        // No discounts applied
        await ValidateOrderDiscounts();

        await Page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasText = "Ordered items" }).Nth(1).ClickAsync();

        await Debounce();
        var itemRows = await Page.GetByTestId("table-row").AllAsync();

        await ValidateOrderItem(itemRows[0], "PROD-003", "Sample Product with methods", "2", "9.99", "19.98", "7.99", "0.08%");
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


    private static async Task ValidateOrderItem(ILocator itemRow, string sku, string name, string quantity, string unitPrice,
        string totalPrice, string totalTax, string taxRate)
    {
        var itemSku = await itemRow.GetByTestId("table-cell-OrderItemSKU").First.TextContentAsync();
        var itemName = await itemRow.GetByTestId("table-cell-OrderItemName").First.TextContentAsync();
        var itemQuantity = await itemRow.GetByTestId("table-cell-OrderItemQuantity").First.TextContentAsync();
        var itemUnitPrice = await itemRow.GetByTestId("table-cell-OrderItemUnitPrice").First.TextContentAsync();
        var itemTotalPrice = await itemRow.GetByTestId("table-cell-OrderItemTotalPrice").First.TextContentAsync();
        var itemTotalTax = await itemRow.GetByTestId("table-cell-OrderItemTotalTax").First.TextContentAsync();
        var itemTaxRate = await itemRow.GetByTestId("table-cell-OrderItemTaxRate").First.TextContentAsync();

        Assert.Multiple(() =>
        {
            Assert.That(itemSku, Is.EqualTo(sku));
            Assert.That(itemName, Is.EqualTo(name));
            Assert.That(itemQuantity, Is.EqualTo(quantity));
            Assert.That(itemUnitPrice, Is.EqualTo(unitPrice));
            Assert.That(itemTotalPrice, Is.EqualTo(totalPrice));
            Assert.That(itemTotalTax, Is.EqualTo(totalTax));
            Assert.That(itemTaxRate, Is.EqualTo(taxRate));
        });
    }


    private async Task ValidateOrderAddress(string addressFirstName, string addressLastName, string? addressCompany, string addressEmail,
        string phoneNumber, string addressLine1, string addressLine2, string addressCity, string addressZip)
    {
        var addressRow = Page.GetByTestId("billing-address");

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


    private async Task ValidateOrderDiscounts(string? catalogDiscount = null, string? orderDiscount = null)
    {
        var discountRow = Page.GetByTestId("order-promotions");

        if (catalogDiscount == null && orderDiscount == null)
        {
            var count = await discountRow.CountAsync();
            Assert.That(count, Is.EqualTo(0), "Order promotions section should not exist when no discounts are applied");
            return;
        }

        if (catalogDiscount != null)
        {
            var catalogDiscountValue = await discountRow.GetByTestId("CatalogPromotion").TextContentAsync();
            Assert.That(catalogDiscountValue, Is.EqualTo(catalogDiscount));
        }

        if (orderDiscount != null)
        {
            var orderDiscountValue = await discountRow.GetByTestId("OrderPromotion").TextContentAsync();
            Assert.That(orderDiscountValue, Is.EqualTo(orderDiscount));
        }
    }
}
