using Microsoft.Playwright;

namespace TestAfterMigration.Tests
{
    public class Tests_08_ContentTypes : AdminTestBase
    {
        [Test]
        public async Task Test00100_Expected_Content_Types_Created_And_Explorable_Without_Errors()
        {
            await OpenAdminApplication("content-types");

            string[] expectedTypes = new[] { "UMT.Event", "UMT.Faq", "UMT.Article" };

            foreach (string lang in expectedTypes)
            {
                await Page.GetByTestId("table-cell-ClassName").Filter(new LocatorFilterOptions { HasText = lang }).Nth(0).ClickAsync();
                await Debounce();
                await Page.GoBackAsync();
                await Debounce();
            }

            await AssertNoEventlogErrors();
        }
    }
}
