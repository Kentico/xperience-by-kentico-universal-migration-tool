using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestAfterMigration.Extensions;
using TestAfterMigration.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestAfterMigration.Tests
{
    public class _03_ContentHubTests : AdminTestBase
    {
        [Test]
        public async Task Test00100_Folder_With_Subfolder_Exists()
        {
            await OpenAdminApplication("Content hub");
            await SelectTopDropdownLanguage("English (United States)");

            var folderDiv = page.Locator("div[class*=\"folder-view\"]");
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

            var folderDiv = page.Locator("div[class*=\"folder-view\"]");
            var parentFolder = folderDiv.GetByRole(AriaRole.Treeitem);
            await Assertions.Expect(parentFolder).ToBeVisibleAsync();
            await parentFolder.GetByTestId("tree-item-expand").ClickAsync();
            var childFolder = parentFolder.GetByRole(AriaRole.Treeitem);
            await childFolder.GetByTestId("tree-item-title").ClickAsync();
            await Debounce();
            await Assertions.Expect(page.GetByTestId("table-row")).ToBeVisibleAsync();
        }

        [Test]
        public async Task Test00300_Draft_And_Scheduled_Items_Present()
        {
            await OpenAdminApplication("Content hub");
            await SelectTopDropdownLanguage("English (United States)");

            await page.GetByLabel("All content items").ClickAsync();
            await Debounce();

            await Assertions.Expect(page.GetByTestId("table-row").Filter(new LocatorFilterOptions { HasText = "Draft (Initial)" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByTestId("table-row").Filter(new LocatorFilterOptions { HasText = "Scheduled" })).ToBeVisibleAsync();
        }

        [Test]
        public async Task Test00400_No_Errors_When_Viewing_Tabs()
        {
            await OpenAdminApplication("Content hub");
            await SelectTopDropdownLanguage("English (United States)");

            await page.GetByLabel("All content items").ClickAsync();
            await Debounce();

            int count = await page.GetByTestId("table-row").CountAsync();
            for (int i = 0; i < count; i++)
            {
                var row = page.GetByTestId("table-row").Nth(i);
                await row.ClickAsync();

                await page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasTextRegex = new Regex("^Content$") }).ClickAsync();
                await Debounce();

                await page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasTextRegex = new Regex("^Properties$") }).ClickAsync();
                await Debounce();

                await page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasTextRegex = new Regex("^Usage$") }).ClickAsync();
                await Debounce();

                await page.Locator("a").Filter(new LocatorFilterOptions { HasText = "List of content items" }).Nth(0).ClickAsync();
                await Debounce();
            }

            await AssertNoEventlogErrors();
        }

    }
}
