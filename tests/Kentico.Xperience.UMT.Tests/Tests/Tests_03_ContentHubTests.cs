using Microsoft.Playwright;

using System.Text.RegularExpressions;

namespace TestAfterMigration.Tests
{
    public class Tests_03_ContentHubTests : AdminTestBase
    {
        [Test]
        public async Task Test00100_Folder_With_Subfolder_Exists()
        {
            await OpenAdminApplication("Content hub");
            await SelectTopDropdownLanguage("English (United States)");

            var folderDiv = Page.Locator("div[class*=\"folder-view\"]");
            var parentFolder = folderDiv.GetByRole(AriaRole.Treeitem);
            await Assertions.Expect(parentFolder).ToBeVisibleAsync();
            await parentFolder.GetByTestId("tree-item-expand").ClickAsync();
            await Debounce();
            await Assertions.Expect(parentFolder.GetByRole(AriaRole.Treeitem)).ToBeVisibleAsync();
        }

        [Test]
        public async Task Test00200_Child_Folder_Contains_Item()
        {
            await OpenAdminApplication("Content hub");
            await SelectTopDropdownLanguage("English (United States)");

            var folderDiv = Page.Locator("div[class*=\"folder-view\"]");
            var parentFolder = folderDiv.GetByRole(AriaRole.Treeitem);
            await Assertions.Expect(parentFolder).ToBeVisibleAsync();
            await parentFolder.GetByTestId("tree-item-expand").ClickAsync();
            var childFolder = parentFolder.GetByRole(AriaRole.Treeitem);
            await childFolder.GetByTestId("tree-item-title").ClickAsync();
            await Debounce();
            await Assertions.Expect(Page.GetByTestId("table-row")).ToBeVisibleAsync();
        }

        [Test]
        public async Task Test00300_Draft_And_Scheduled_Items_Present()
        {
            await OpenAdminApplication("Content hub");
            await SelectTopDropdownLanguage("English (United States)");

            await Page.GetByLabel("All content items").ClickAsync();
            await Debounce();

            await Assertions.Expect(Page.GetByTestId("table-row").Filter(new LocatorFilterOptions { HasText = "Draft (Initial)" })).ToBeVisibleAsync();
            await Assertions.Expect(Page.GetByTestId("table-row").Filter(new LocatorFilterOptions { HasText = "Scheduled" })).ToBeVisibleAsync();
        }

        [Test]
        public async Task Test00400_No_Errors_When_Viewing_Tabs()
        {
            await OpenAdminApplication("Content hub");
            await SelectTopDropdownLanguage("English (United States)");

            await Page.GetByLabel("All content items").ClickAsync();
            await Debounce();

            int count = await Page.GetByTestId("table-row").CountAsync();
            for (int i = 0; i < count; i++)
            {
                var row = Page.GetByTestId("table-row").Nth(i);
                await row.ClickAsync();

                await Page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasTextRegex = new Regex("^Content$") }).ClickAsync();
                await Debounce();

                await Page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasTextRegex = new Regex("^Properties$") }).ClickAsync();
                await Debounce();

                await Page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasTextRegex = new Regex("^Usage$") }).ClickAsync();
                await Debounce();

                await Page.Locator("a").Filter(new LocatorFilterOptions { HasText = "List of content items" }).Nth(0).ClickAsync();
                await Debounce();
            }

            await AssertNoEventlogErrors();
        }

    }
}
