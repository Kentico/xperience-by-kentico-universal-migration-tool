using System.Text.RegularExpressions;

using Microsoft.Playwright;

namespace TestAfterMigration.Tests
{
    public class Tests_03_ContentHubTests : AdminTestBase
    {
        private async Task OpenContentHub(string workspace = "Default")
        {
            await OpenAdminApplication("Content hub");
            await SelectTopDropdownLanguage("English (United States)");
            await SelectTopDropdownWorkspace(workspace);
        }

        private async Task SelectTopDropdownWorkspace(string workspaceTitle)
        {
            if (!(await Page.GetByTestId("WorkspaceSelector").TextContentAsync())?.Contains(workspaceTitle, StringComparison.OrdinalIgnoreCase) ?? false)
            {
                await Page.GetByTestId("WorkspaceSelector").Locator("div[class^=\"select_\"]").Nth(0).ClickAsync();
                await Page.GetByTestId("WorkspaceSelector").GetByTestId("WorkspaceSelectorDropdownActionMenu").GetByTestId("menu-item").Filter(new LocatorFilterOptions { HasText = workspaceTitle }).ClickAsync();
                await Debounce();
            }
        }

        public new async Task SelectTopDropdownLanguage(string languageTitle)
        {
            await Page.GetByTestId("WorkspaceSelector").Locator("div[class^=\"select_\"]").Nth(1).ClickAsync();
            await Page.GetByTestId("WorkspaceSelector").GetByTestId("WorkspaceSelectorDropdownActionMenu").GetByTestId("menu-item").Filter(new LocatorFilterOptions { HasText = languageTitle }).ClickAsync();
            await Debounce();
        }

        [Test]
        public async Task Test00100_Folder_With_Subfolder_Exists()
        {
            await OpenContentHub();

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
            await OpenContentHub();

            var folderDiv = Page.Locator("div[class*=\"folder-view\"]");
            var parentFolder = folderDiv.GetByRole(AriaRole.Treeitem);
            await Assertions.Expect(parentFolder).ToBeVisibleAsync();
            await parentFolder.GetByTestId("tree-item-expand").ClickAsync();
            var childFolder = parentFolder.GetByRole(AriaRole.Treeitem);
            await childFolder.GetByTestId("tree-item-title").ClickAsync();
            await Debounce();
            await Assertions.Expect(Page.GetByTestId("table-row").First).ToBeVisibleAsync();
        }

        [Test]
        public async Task Test00300_Draft_And_Scheduled_Items_Present()
        {
            await OpenContentHub();

            await Page.GetByLabel("All content items").ClickAsync();
            await Debounce();

            await Assertions.Expect(Page.GetByTestId("table-row").Filter(new LocatorFilterOptions { HasText = "Draft (Initial)" })).Not.ToHaveCountAsync(0);
            await Assertions.Expect(Page.GetByTestId("table-row").Filter(new LocatorFilterOptions { HasText = "Scheduled" })).Not.ToHaveCountAsync(0);
        }

        [Test]
        public async Task Test00400_No_Errors_When_Viewing_Tabs()
        {
            await OpenContentHub();

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

        [Test]
        public async Task Test00500_Published_Item_Exists_In_Sample_Workspace()
        {
            await OpenContentHub("Sample Workspace");

            await Page.GetByLabel("All content items").ClickAsync();
            await Debounce();

            await Assertions.Expect(Page.GetByTestId("table-row").Filter(new LocatorFilterOptions { HasText = "Published" })).Not.ToHaveCountAsync(0);
        }

        [Test]
        public async Task Test00600_Event_Sample_Optimized_Image_Is_Uploaded()
        {
            await OpenContentHub();

            await Page.GetByRole(AriaRole.Row).Filter(new LocatorFilterOptions { HasText = "Event Sample 2024" }).ClickAsync();

            await Assertions.Expect(Page.GetByTestId("EventTeaserOptimized").GetByTestId("asset-tile-preview")).ToHaveCountAsync(1);
        }

        [Test]
        public async Task Test00700_Reusable_Item_Usage_When_Linked_From_Content_Item()
        {
            await OpenContentHub();
            await Page.GetByLabel("All content items").ClickAsync();
            await Debounce();

            var search = Page.GetByTestId("search-input");
            await search.FillAsync("FAQ: reusable simplified model sample linked by an article - en-us");

            await Page.Keyboard.PressAsync("Enter");
            await Debounce();

            await Page.GetByTestId("table-row").ClickAsync();
            await Debounce();

            await Page.GetByText("Usage").ClickAsync();
            await Debounce();

            var usageInChannelsButton = Page.GetByText("In channels");
            await Assertions.Expect(usageInChannelsButton).ToBeEnabledAsync();

            await usageInChannelsButton.ClickAsync();
            await Debounce();

            search = Page.GetByTestId("search-input");
            await search.FillAsync("Simplified model sample with linked items - en-us");
            await Page.Keyboard.PressAsync("Enter");

            await Assertions.Expect(Page.GetByTestId("table-row")).Not.ToHaveCountAsync(0);

            await Debounce();
        }

        [Test]
        public async Task Test00800_Former_URLs_Exists()
        {
            await OpenAdminApplication("Former URLs");

            await Assertions.Expect(Page.GetByTestId("table-cell-WebPageFormerUrlPath")).Not.ToHaveCountAsync(0);
        }

    }
}
