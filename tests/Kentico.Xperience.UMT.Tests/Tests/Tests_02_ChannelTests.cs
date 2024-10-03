using Microsoft.Playwright;
using System.Reflection;
using TestAfterMigration.Extensions;
using TestAfterMigration.Helpers;

namespace TestAfterMigration.Tests
{
    public class Tests_02_ChannelTests : AdminTestBase
    {
        [Test]
        public async Task Test00100_Email_Channel_Was_Created()
        {
            await OpenAdminApplication("Channel management");
            await Assertions.Expect(Page.GetByTestId("table-cell-ChannelDisplayName")
                .Filter(new LocatorFilterOptions { HasText = "email Channel Example" }))
                .ToHaveCountAsync(1);
        }

        [Test]
        public async Task Test00200_Web_Channel_Was_Created()
        {
            await OpenAdminApplication("Channel management");
            await Assertions.Expect(Page.GetByTestId("table-cell-ChannelDisplayName")
                .Filter(new LocatorFilterOptions { HasText = "website Channel Example" }))
                .ToHaveCountAsync(1);
        }

        [Test]
        public async Task Test00300_Web_Channel_Has_Page_In_Different_Publish_States()
        {
            await OpenAdminApplication("website Channel Example");
            await SelectTopDropdownLanguage("English (United States)");

            string[] expectedStates = ["Draft (Initial)", "Published", "Scheduled"];

            var pageStates = new HashSet<string?>();
            var treeItems = await GetPageTreeItems();
            foreach (var item in treeItems)
            {
                await item.ClickAsync();
                await item.WaitBreadcrumbsLoaded();
                string? status = await Page.GetByTestId("breadcrumbs-status").TextContentAsync();
                pageStates.Add(status);
            }

            foreach (string state in expectedStates)
            {
                Assert.That(pageStates.Contains(state, StringComparer.OrdinalIgnoreCase));
            }
        }

        [Test]
        public async Task Test00400_Web_Channel_Has_Page_With_Child()
        {
            await OpenAdminApplication("website Channel Example");
            await SelectTopDropdownLanguage("English (United States)");

            var treeItems = await GetPageTreeItems();

            Assert.That(treeItems.Any(x => x.Children.Any()));
        }

        [Test]
        public async Task Test00400_New_Page_Create_And_Delete_Succeeds()
        {
            await OpenAdminApplication("website Channel Example");
            await SelectTopDropdownLanguage("English (United States)");

            string displayName = $"NewPage{Guid.NewGuid()}";
            await Page.GetByTestId("create-page-button").ClickAsync();
            await Page.GetByTestId("DisplayName").FillAsync(displayName);
            await Page.GetByTestId("content-item-action-button-confirmfirstselection").ClickAsync();

            await Page.GetByTestId("ArticleTitle").FillAsync("New Page");

            await Page.GetByTestId("ArticleDecimalNumberSample").FillAsync("123.456");

            await Page.GetByTestId("ArticleText").FillAsync("Text on\nmultiple\nlines".Replace("\n", Environment.NewLine));

            await Page.GetByTestId("file-input-upload").SetInputFilesAsync(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "Resources", "kentico_brand.png"));

            await Page.GetByTestId("button-select-web-page").ClickAsync();
            await Page.GetByTestId("table-row").Nth(1).ClickAsync();
            await Page.GetByTestId("confirm-action").ClickAsync();

            await Page.GetByTestId("button-select-existing-content-item").ClickAsync();
            await Page.GetByTestId("table-row").Nth(0).ClickAsync();
            await Page.GetByTestId("confirm-action").ClickAsync();

            await Page.GetByTestId("button-select-tag").ClickAsync();
            await Page.GetByTestId("CoffeaTaxonomy.Select").GetByRole(AriaRole.Treeitem).Nth(0).ClickAsync();
            await Page.GetByTestId("confirm-action").ClickAsync();

            await Page.GetByTestId("content-item-menu-split-button-publish").ClickAsync();
            await Page.GetByTestId("submit-form-button").ClickAsync();

            await Debounce();
            await Page.GetByTestId("submit-form-button").ClickAsync();

            var treeItem = (await GetPageTreeItems(rootOnly: true)).First(x => x.Title == displayName);
            await ValidatePageTreePageTabs(treeItem);
            await treeItem.Locator.HoverAsync();
            await treeItem.Locator.Locator("div[class*=\"trailing-cell\"]").ClickAsync();
            await Page.GetByTestId("delete-action").ClickAsync();
            await Page.GetByTestId("confirm-action").ClickAsync();

            await Assertions.Expect(Page.GetByText("successfully deleted").Nth(0)).ToBeVisibleAsync();
        }

        [Test]
        public async Task Test00500_Web_Channel_No_Errors_When_Viewing_Tabs()
        {
            await OpenAdminApplication("website Channel Example");
            await SelectTopDropdownLanguage("English (United States)");

            var treeItems = await GetPageTreeItems();
            foreach (var item in treeItems.SelectMany(x => x.Family()))
            {
                await ValidatePageTreePageTabs(item);
            }

            await AssertNoEventlogErrors();
        }

        private async Task ValidatePageTreePageTabs(PageTreeItem item)
        {
            await item.ClickAsync();
            await Debounce();
            foreach (string tab in new string[] { "Preview", "Content", "URLs", "Properties" })
            {
                await Page.Locator($"button[aria-label=\"{tab}\"]").ClickAsync();
                await Debounce();
                await Assertions.Expect(Page.GetByText("error")).Not.ToBeVisibleAsync();
                await Assertions.Expect(Page.GetByText("exception")).Not.ToBeVisibleAsync();
            }
        }

        [Test]
        public async Task Test00600_English_UK_Is_Populated()
        {
            await OpenAdminApplication("website Channel Example");
            await SelectTopDropdownLanguage("English (United Kingdom)");

            var treeItems = await GetPageTreeItems(rootOnly: true);
            foreach (var item in treeItems)
            {
                await item.ClickAsync();
                await Debounce();
                await Assertions.Expect(Page.GetByText("This page does not exist in the current language")).ToHaveCountAsync(0);
            }
        }

        [Test]
        public async Task Test00700_Spanish_Is_Not_Populated()
        {
            await OpenAdminApplication("website Channel Example");
            await SelectTopDropdownLanguage("Spanish");

            var treeItems = await GetPageTreeItems(rootOnly: true);
            foreach (var item in treeItems)
            {
                await item.ClickAsync();
                await Debounce();
                await Assertions.Expect(Page.GetByText("This page does not exist in the current language")).ToHaveCountAsync(1);
            }
        }
    }
}
