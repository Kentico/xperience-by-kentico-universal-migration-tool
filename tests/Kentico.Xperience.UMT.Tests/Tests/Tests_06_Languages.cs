using Microsoft.Playwright;

namespace TestAfterMigration.Tests
{
    public class Tests_06_Languages : AdminTestBase
    {
        [Test]
        public async Task Test00100_All_Expected_Languages_Present_And_Clickable_Without_Errors()
        {
            await OpenAdminApplication("languages");

            string[] expectedLanguages = new[] { "English", "English (United Kingdom)", "English (United States)", "Spanish" };

            foreach (string lang in expectedLanguages)
            {
                await Page.GetByTestId("table-cell-ContentLanguageDisplayName").Filter(new LocatorFilterOptions { HasText = lang }).Nth(0).ClickAsync();
                await Debounce();
                await Page.GoBackAsync();
                await Debounce();
            }

            await AssertNoEventlogErrors();
        }
    }
}
