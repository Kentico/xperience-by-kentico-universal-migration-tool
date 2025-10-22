using Microsoft.Playwright;

namespace TestAfterMigration.Tests
{
    public class Tests_07_Users : AdminTestBase
    {
        [Test]
        public async Task Test00100_sadmin_Explorable_Without_Errors()
        {
            await OpenAdminApplication("users");

            await Page.GetByTestId("table-cell-UserName").Filter(new LocatorFilterOptions { HasText = "sadmin" }).Nth(0).ClickAsync();
            await Debounce();

            await AssertNoEventlogErrors();
        }
    }
}
