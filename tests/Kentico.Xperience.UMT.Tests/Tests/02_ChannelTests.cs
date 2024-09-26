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
    public class _02_ChannelTests : AdminTestBase
    {
        [Test]
        public async Task Test00100_Email_Channel_Was_Created()
        {
            await OpenAdminApplication("Channel management");
            await Assertions.Expect(page.GetByTestId("table-cell-ChannelDisplayName")
                .Filter(new LocatorFilterOptions { HasText = "email Channel Example" }))
                .ToHaveCountAsync(1);
        }

        [Test]
        public async Task Test00200_Web_Channel_Was_Created()
        {
            await OpenAdminApplication("Channel management");
            await Assertions.Expect(page.GetByTestId("table-cell-ChannelDisplayName")
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
                var status = await page.GetByTestId("breadcrumbs-status").TextContentAsync();
                pageStates.Add(status);
            }

            foreach (var state in expectedStates)
            {
                Assert.That(pageStates.Contains(state, StringComparer.OrdinalIgnoreCase));
            }
        }

        [Test]
        public async Task Test00400_Web_Channel_Has_Page_With_Child()
        {
            await OpenAdminApplication("website Channel Example");
            await SelectTopDropdownLanguage("English (United States)");

            var pageStates = new HashSet<string>();
            var treeItems = await GetPageTreeItems();

            Assert.That(treeItems.Any(x => x.Children.Count() != 0));
        }

        [Test]
        public async Task Test00400_New_Page_Create_And_Delete_Succeeds()
        {
            await OpenAdminApplication("website Channel Example");
            await SelectTopDropdownLanguage("English (United States)");

            string displayName = $"NewPage{Guid.NewGuid()}";
            await page.GetByTestId("create-page-button").ClickAsync();
            await page.GetByTestId("DisplayName").FillAsync(displayName);
            await page.GetByTestId("content-item-action-button-confirmfirstselection").ClickAsync();

            await page.GetByTestId("ArticleTitle").FillAsync("New Page");

            await page.GetByTestId("ArticleDecimalNumberSample").FillAsync("123.456");

            await page.GetByTestId("ArticleText").FillAsync("Text on\nmultiple\nlines".Replace("\n", Environment.NewLine));

            await page.GetByTestId("file-input-upload").SetInputFilesAsync(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "Resources", "kentico_brand.png"));

            await page.GetByTestId("button-select-web-page").ClickAsync();
            await page.GetByTestId("table-row").Nth(1).ClickAsync();
            await page.GetByTestId("confirm-action").ClickAsync();

            await page.GetByTestId("button-select-existing-content-item").ClickAsync();
            await page.GetByTestId("table-row").Nth(0).ClickAsync();
            await page.GetByTestId("confirm-action").ClickAsync();

            await page.GetByTestId("button-select-tag").ClickAsync();
            await page.GetByTestId("CoffeaTaxonomy.Select").GetByRole(AriaRole.Treeitem).Nth(0).ClickAsync();
            await page.GetByTestId("confirm-action").ClickAsync();

            await page.GetByTestId("content-item-menu-split-button-publish").ClickAsync();
            await page.GetByTestId("submit-form-button").ClickAsync();

            await Debounce();
            await page.GetByTestId("submit-form-button").ClickAsync();

            var treeItem = (await GetPageTreeItems(rootOnly: true)).First(x => x.Title == displayName);
            await ValidatePageTreePageTabs(treeItem);
            await treeItem.Locator.HoverAsync();
            await treeItem.Locator.Locator("div[class*=\"trailing-cell\"]").ClickAsync();
            await page.GetByTestId("delete-action").ClickAsync();
            await page.GetByTestId("confirm-action").ClickAsync();

            await Assertions.Expect(page.GetByText("successfully deleted").Nth(0)).ToBeVisibleAsync();
        }

        [Test]
        public async Task Test00500_Web_Channel_No_Errors_When_Viewing_Tabs()
        {
            await OpenAdminApplication("website Channel Example");
            await SelectTopDropdownLanguage("English (United States)");

            var pageStates = new HashSet<string>();
            var treeItems = await GetPageTreeItems();
            foreach (var item in treeItems.SelectMany(x => x.Family()))
            {
                await ValidatePageTreePageTabs(item);
            }

            await AssertNoEventlogErrors();
        }

        private async Task ValidatePageTreePageTabs(PageTreeItem item)
        {
            var title = await item.TitleElement.TextContentAsync();
            await item.ClickAsync();
            await Debounce();
            foreach (var tab in new string[] { "Preview", "Content", "URLs", "Properties" })
            {
                await page.Locator($"button[aria-label=\"{tab}\"]").ClickAsync();
                await Debounce();
                await Assertions.Expect(page.GetByText("error")).Not.ToBeVisibleAsync();
                await Assertions.Expect(page.GetByText("exception")).Not.ToBeVisibleAsync();
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
                await Assertions.Expect(page.GetByText("This page does not exist in the current language")).ToHaveCountAsync(0);
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
                await Assertions.Expect(page.GetByText("This page does not exist in the current language")).ToHaveCountAsync(1);
            }
        }
    }
}
