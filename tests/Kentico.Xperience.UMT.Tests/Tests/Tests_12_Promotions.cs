using Microsoft.Playwright;

namespace TestAfterMigration.Tests;

public class Tests_12_Promotions : AdminTestBase
{
    private const string CATALOG_PROMOTION_DISPLAY_NAME = "Buy One Get One Free";
    private const string CATALOG_PROMOTION_ACTIVE_TO = "03/31/2024";
    private const string CATALOG_PROMOTION_CREATED = "02/01/2024";
    private const string CATALOG_PROMOTION_REDEEMED = "1";

    private const string ORDER_PROMOTION_DISPLAY_NAME = "10% Off Your Order";
    private const string ORDER_PROMOTION_ACTIVE_TO = "12/31/2024";
    private const string ORDER_PROMOTION_CREATED = "01/01/2024";
    private const string ORDER_PROMOTION_REDEEMED = "1";


    [Test]
    public async Task Test00100_Expected_Promotion_Structure_Created_And_Explorable()
    {
        await OpenAdminApplication("Promotions");

        await NavigateToCatalogDiscountsTab();

        var catalogPromotions = await Page.GetByTestId("table-row").AllAsync();
        Assert.That(catalogPromotions, Has.Count.EqualTo(1), "Expected 1 catalog promotion");

        await ValidatePromotionListRow(
            catalogPromotions[0],
            displayName: CATALOG_PROMOTION_DISPLAY_NAME,
            activeTo: CATALOG_PROMOTION_ACTIVE_TO,
            created: CATALOG_PROMOTION_CREATED,
            redeemed: CATALOG_PROMOTION_REDEEMED
        );

        await NavigateToOrderDiscountsTab();

        var orderPromotions = await Page.GetByTestId("table-row").AllAsync();
        Assert.That(orderPromotions, Has.Count.EqualTo(1), "Expected 1 order promotion");

        await ValidatePromotionListRow(
            orderPromotions[0],
            displayName: ORDER_PROMOTION_DISPLAY_NAME,
            activeTo: ORDER_PROMOTION_ACTIVE_TO,
            created: ORDER_PROMOTION_CREATED,
            redeemed: ORDER_PROMOTION_REDEEMED
        );

        await AssertNoEventlogErrors();
    }


    private async Task NavigateToCatalogDiscountsTab()
    {
        await Page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasText = "Catalog discounts" }).ClickAsync();
        await Debounce();
    }


    private async Task NavigateToOrderDiscountsTab()
    {
        await Page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasText = "Order discounts" }).ClickAsync();
        await Debounce();
    }


    private static async Task ValidatePromotionListRow(
        ILocator promotionRow,
        string displayName,
        string activeTo,
        string created,
        string redeemed
        )
    {
        var actualDisplayName = await promotionRow.GetByTestId("table-cell-PromotionDisplayName").TextContentAsync();
        var actualActiveTo = await promotionRow.GetByTestId("table-cell-PromotionActiveToWhen").TextContentAsync();
        var actualCreated = await promotionRow.GetByTestId("table-cell-PromotionCreatedWhen").TextContentAsync();
        var actualRedeemed = await promotionRow.GetByTestId("table-cell-Redeemed").TextContentAsync();

        Assert.Multiple(() =>
        {
            Assert.That(actualDisplayName, Is.EqualTo(displayName));
            Assert.That(actualActiveTo, Does.Contain(activeTo));
            Assert.That(actualCreated, Does.Contain(created));
            Assert.That(actualRedeemed, Is.EqualTo(redeemed));
        });
    }
}
