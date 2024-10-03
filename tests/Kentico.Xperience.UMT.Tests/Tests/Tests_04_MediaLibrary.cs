using Microsoft.Playwright;

namespace TestAfterMigration.Tests
{
    public class Tests_04_MediaLibrary : AdminTestBase
    {
        [Test]
        public async Task Test00100_Expected_Library_Structure_Was_Created()
        {
            await OpenAdminApplication("Media libraries");

            await Page.GetByTestId("table-row").ClickAsync();     // also checks that an item exists
            await Debounce();

            var topFolder = Page.GetByRole(AriaRole.Treeitem).Nth(0);
            await Assertions.Expect(topFolder).ToBeVisibleAsync();

            var childFolder = topFolder.GetByRole(AriaRole.Treeitem).Nth(0);
            await Assertions.Expect(childFolder).ToBeVisibleAsync();
        }

        [Test]
        public async Task Test00200_Subfolder_Contains_2_Images()
        {
            await OpenAdminApplication("Media libraries");

            await Page.GetByTestId("table-row").ClickAsync();     // also checks that an item exists
            await Debounce();

            var topFolder = Page.GetByRole(AriaRole.Treeitem).Nth(0);
            var childFolder = topFolder.GetByRole(AriaRole.Treeitem).Nth(0);

            await childFolder.ClickAsync();
            await Debounce();

            await Assertions.Expect(Page.GetByTestId("asset-tile-preview")).ToHaveCountAsync(2);
        }

        [Test]
        public async Task Test00300_Subfolder_Images_Can_Be_Explored()
        {
            for (int i = 0; i < 2; i++)
            {
                await OpenAdminApplication("Media libraries");

                await Page.GetByTestId("table-row").ClickAsync();     // also checks that an item exists
                await Debounce();

                var topFolder = Page.GetByRole(AriaRole.Treeitem).Nth(0);
                var childFolder = topFolder.GetByRole(AriaRole.Treeitem).Nth(0);

                await childFolder.ClickAsync();
                await Debounce();

                await Page.GetByTestId("asset-tile-preview").Nth(i).ClickAsync();
                await Assertions.Expect(Page.GetByTestId("FileName")).Not.ToBeEmptyAsync();
                await Assertions.Expect(Page.GetByTestId("FileTitle")).Not.ToBeEmptyAsync();

                string imageURL = $"{BaseURL}{await Page.GetByTestId("MediaFileURL").Locator("a").GetAttributeAsync("href")}";
                var response = await new HttpClient().GetAsync(imageURL);

                Assert.That(response.IsSuccessStatusCode && response.Content.Headers.ContentType!.MediaType!.StartsWith("image"));
            }
        }
    }
}
