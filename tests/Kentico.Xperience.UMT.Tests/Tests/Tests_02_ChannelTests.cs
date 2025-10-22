using System.Globalization;
using System.Text.RegularExpressions;

using Microsoft.Playwright;

using TestAfterMigration.Extensions;
using TestAfterMigration.Helpers;

namespace TestAfterMigration.Tests
{
    public class Tests_02_ChannelTests : AdminTestBase
    {
        [Test]
        public async Task Test00100_Email_Channel_Was_Created()
        {
            await OpenAdminApplication("channel-management");
            await Assertions.Expect(Page.GetByTestId("table-cell-ChannelDisplayName")
                .Filter(new LocatorFilterOptions { HasText = "email Channel Example" }))
                .ToHaveCountAsync(1);
        }

        [Test]
        public async Task Test00200_Web_Channel_Was_Created()
        {
            await OpenAdminApplication("channel-management");
            await Assertions.Expect(Page.GetByTestId("table-cell-ChannelDisplayName")
                .Filter(new LocatorFilterOptions { HasText = "website Channel Example" }))
                .ToHaveCountAsync(1);
        }

        [Test]
        public async Task Test00300_Web_Channel_Has_Page_In_Different_Publish_States()
        {
            await OpenAdminApplication("website-channel-example");
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
            await OpenAdminApplication("website-channel-example");
            await SelectTopDropdownLanguage("English (United States)");

            var treeItems = await GetPageTreeItems();

            Assert.That(treeItems.Any(x => x.Children.Any()));
        }

        [Test]
        public async Task Test00400_New_Page_Create_And_Delete_Succeeds()
        {
            await OpenAdminApplication("website-channel-example");
            await SelectTopDropdownLanguage("English (United States)");

            string displayName = $"NewPage{Guid.NewGuid()}";
            await Page.GetByTestId("create-page-button").ClickAsync();
            await Page.GetByTestId("DisplayName").FillAsync(displayName);
            await Page.GetByTestId("content-item-action-button-confirmfirstselection").ClickAsync();

            await Page.GetByTestId("ArticleTitle").FillAsync("New Page");

            await Page.GetByTestId("ArticleDecimalNumberSample").FillAsync("123.456");

            await Page.GetByTestId("ArticleText").FillAsync("Text on\nmultiple\nlines".Replace("\n", Environment.NewLine));

            await Page.GetByTestId("button-select-web-page").ClickAsync();
            await Debounce();
            await Page.GetByTestId("table-row").Nth(1).ClickAsync();
            await Page.GetByTestId("confirm-action").ClickAsync();

            await Page.GetByTestId("button-select-existing-content-item").ClickAsync();
            await Debounce();
            await Page.GetByTestId("table-row").Nth(0).ClickAsync();
            await Page.GetByTestId("confirm-action").ClickAsync();

            await Page.GetByTestId("button-select-tag").ClickAsync();
            await Debounce();
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
            await OpenAdminApplication("website-channel-example");
            await SelectTopDropdownLanguage("English (United States)");

            var treeItems = await GetPageTreeItems();
            foreach (var item in treeItems)
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
                await Page.Locator($"div[data-testid=\"application-tile\"]").Filter(new LocatorFilterOptions { HasTextRegex = new Regex($"^{tab}$") }).ClickAsync();
                await Debounce();
                await Assertions.Expect(Page.GetByText("error")).Not.ToBeVisibleAsync();
                await Assertions.Expect(Page.GetByText("exception")).Not.ToBeVisibleAsync();
            }
        }

        [Test]
        public async Task Test00600_English_UK_Is_Populated()
        {
            await OpenAdminApplication("website-channel-example");
            await SelectTopDropdownLanguage("English (United Kingdom)");

            var treeItems = await GetPageTreeItems(rootOnly: true);
            foreach (var item in treeItems.Where(x => !x.Title!.Contains("page with widgets", StringComparison.OrdinalIgnoreCase)))
            {
                await item.ClickAsync();
                await Debounce();
                await Assertions.Expect(Page.GetByText("This page does not exist in the current language")).ToHaveCountAsync(0);
            }
        }

        [Test]
        public async Task Test00700_Spanish_Is_Not_Populated()
        {
            await OpenAdminApplication("website-channel-example");
            await SelectTopDropdownLanguage("Spanish");

            var treeItems = await GetPageTreeItems(rootOnly: true);
            foreach (var item in treeItems)
            {
                await item.ClickAsync();
                await Debounce();
                await Assertions.Expect(Page.GetByText("This page does not exist in the current language")).ToHaveCountAsync(1);
            }
        }

        [Test]
        public async Task Test00800_Draft_Can_Be_Published()
        {
            await OpenAdminApplication("website-channel-example");
            await SelectTopDropdownLanguage("English (United States)");
            var treeItems = await GetPageTreeItemsFlat();

            var item = treeItems.First(x => string.Equals(x.Title, "Simplified model sample sub page 2 [Draft] - en-US"));
            await item.ClickAsync();
            await Debounce();

            await Page.GetByTestId("page-menu-actions").GetByTestId("content-item-menu-split-button-publish").ClickAsync();
            await Page.GetByTestId("submit-form-button").ClickAsync();
            await Debounce();
            string? status = await Page.GetByTestId("breadcrumbs-status").TextContentAsync();

            Assert.That("Published" == status);
            await Page.Locator($"div[data-testid=\"application-tile\"]").Filter(new LocatorFilterOptions { HasTextRegex = new Regex($"^Content$") }).ClickAsync();
            await Debounce();
            await Assertions.Expect(Page.GetByTestId("ArticleText")).ToHaveTextAsync("Created by UMT simplified model in Draft state for en-US language ...new draft");
            await AssertNoEventlogErrors();
        }

        [Test]
        public async Task Test00900_Draft_Can_Be_Reverted()
        {
            await OpenAdminApplication("website-channel-example");
            await SelectTopDropdownLanguage("English (United States)");
            var treeItems = await GetPageTreeItemsFlat();

            var item = treeItems.First(x => string.Equals(x.Title, "Simplified model sample sub page 3 [Draft] - en-US"));
            await item.ClickAsync();
            await Debounce();

            await Page.GetByTestId("page-menu-actions").GetByTestId("expand-split-button").ClickAsync();
            await Page.GetByTestId("content-item-action-menu-item-discard").ClickAsync();
            await Page.GetByTestId("confirm-action").ClickAsync();
            await Debounce();
            string? status = await Page.GetByTestId("breadcrumbs-status").TextContentAsync();

            Assert.That("Published" == status);
            await Assertions.Expect(Page.GetByTestId("ArticleText")).ToHaveTextAsync("Created by UMT simplified model in Draft state for en-US language");
            await AssertNoEventlogErrors();
        }

        [Test]
        public async Task Test01000_Edit_And_Publish_Scheduled_Page()
        {
            await OpenAdminApplication("website-channel-example");
            await SelectTopDropdownLanguage("English (United States)");
            var treeItems = await GetPageTreeItemsFlat();

            var item = treeItems.First(x => string.Equals(x.Title, "Simplified model sample sub page 4 - en-US", StringComparison.OrdinalIgnoreCase));
            await item.ClickAsync();
            await Debounce();
            await item.WaitBreadcrumbsLoaded();
            string? status = await Page.GetByTestId("breadcrumbs-status").TextContentAsync();
            Assert.That("Scheduled" == status);

            await Page.GetByTestId("content-item-menu-split-button-cancelscheduledpublishandedit").ClickAsync();
            await Page.GetByTestId("confirm-action").ClickAsync();
            await Debounce();
            await Page.GetByTestId("ArticleTitle").FillAsync("New published value");
            await Page.GetByTestId("content-item-menu-split-button-publish").ClickAsync();
            await Page.GetByTestId("submit-form-button").ClickAsync();
            await Debounce();

            await item.WaitBreadcrumbsLoaded();
            status = await Page.GetByTestId("breadcrumbs-status").TextContentAsync();
            Assert.That("Published" == status);

            await Assertions.Expect(Page.GetByTestId("ArticleTitle")).ToHaveAttributeAsync("value", "New published value");

            await AssertNoEventlogErrors();
        }

        [Test]
        public async Task Test01100_Edit_And_Reschedule_Scheduled_Page()
        {
            await OpenAdminApplication("website-channel-example");
            await SelectTopDropdownLanguage("English (United States)");
            var treeItems = await GetPageTreeItemsFlat();

            var item = treeItems.First(x => string.Equals(x.Title, "Simplified model sample sub page 5 - en-US", StringComparison.OrdinalIgnoreCase));
            await item.ClickAsync();
            await Debounce();
            await item.WaitBreadcrumbsLoaded();
            string? status = await Page.GetByTestId("breadcrumbs-status").TextContentAsync();
            Assert.That("Scheduled" == status);

            await Page.GetByTestId("content-item-menu-split-button-cancelscheduledpublishandedit").ClickAsync();
            await Page.GetByTestId("confirm-action").ClickAsync();
            await Debounce();
            await Page.GetByTestId("ArticleTitle").FillAsync("New scheduled value");
            await Page.GetByTestId("content-item-menu-split-button-publish").ClickAsync();
            await Page.GetByTestId("schedule-publish").ClickAsync();
            await Debounce();

            DateTime scheduledDate = DateTime.Now.AddDays(365);
            var spanValues = new Dictionary<string, string>
            {
                ["day, Date picker"] = scheduledDate.Day.ToString("D2"),
                ["month, Date picker"] = scheduledDate.Month.ToString("D2"),
                ["year, Date picker"] = scheduledDate.Year.ToString("D4"),
                ["hour, Date picker"] = "03",
                ["minute, Date picker"] = "00",
            };
            foreach (var (ariaLabel, value) in spanValues)
            {
                await Page.GetByLabel(ariaLabel).FillAsync(value.ToString());
            }

            // Make UI recognize the new date input
            await Page.WaitForTimeoutAsync(3000);
            await Page.GetByTestId("schedule-publish").ClickAsync();
            await Debounce();

            await Page.GetByTestId("submit-form-button").ClickAsync();
            await Debounce();

            await item.WaitBreadcrumbsLoaded();
            status = await Page.GetByTestId("breadcrumbs-status").TextContentAsync();
            Assert.That("Scheduled" == status);

            await Assertions.Expect(Page.GetByTestId("ArticleTitle")).ToHaveAttributeAsync("value", "New scheduled value");

            await AssertNoEventlogErrors();
        }

        [Test]
        public async Task Test01200_Publish_Initial_Draft()
        {
            await OpenAdminApplication("website-channel-example");
            await SelectTopDropdownLanguage("English (United States)");
            var treeItems = await GetPageTreeItemsFlat();

            var item = treeItems.First(x => string.Equals(x.Title, "Simplified model sample sub page 6 - en-US", StringComparison.OrdinalIgnoreCase));
            await item.ClickAsync();
            await Debounce();
            await item.WaitBreadcrumbsLoaded();
            string? status = await Page.GetByTestId("breadcrumbs-status").TextContentAsync();
            Assert.That("Draft (Initial)" == status);

            await Page.GetByTestId("content-item-menu-split-button-publish").ClickAsync();
            await Debounce();
            await Page.GetByTestId("submit-form-button").ClickAsync();
            await Debounce();

            await item.WaitBreadcrumbsLoaded();
            status = await Page.GetByTestId("breadcrumbs-status").TextContentAsync();
            Assert.That("Published" == status);

            await Assertions.Expect(Page.GetByTestId("ArticleTitle")).ToHaveAttributeAsync("value", "en-US UMT simplified model creation as sub page 6");

            await AssertNoEventlogErrors();
        }

        [Test]
        public async Task Test01300_Cancel_Scheduled_Publish()
        {
            await OpenAdminApplication("website-channel-example");
            await SelectTopDropdownLanguage("English (United States)");
            var treeItems = await GetPageTreeItemsFlat();

            var item = treeItems.First(x => string.Equals(x.Title, "Simplified model sample sub page 7 - en-US", StringComparison.OrdinalIgnoreCase));
            await item.ClickAsync();
            await Debounce();
            await item.WaitBreadcrumbsLoaded();
            string? status = await Page.GetByTestId("breadcrumbs-status").TextContentAsync();
            Assert.That("Scheduled" == status);

            await Page.GetByTestId("page-menu-actions").GetByTestId("expand-split-button").ClickAsync();
            await Page.GetByTestId("content-item-action-menu-item-cancelscheduledpublish").ClickAsync();
            await Debounce();
            await Page.GetByTestId("confirm-action").ClickAsync();
            await Debounce();

            await item.WaitBreadcrumbsLoaded();
            status = await Page.GetByTestId("breadcrumbs-status").TextContentAsync();
            Assert.That("Draft (Initial)" == status);

            await Assertions.Expect(Page.GetByTestId("ArticleTitle")).ToHaveAttributeAsync("value", "en-US UMT simplified model creation as sub page 7");

            await AssertNoEventlogErrors();
        }

        [Test]
        public async Task Test01400_Page_Children_Limitation_Works()
        {
            await OpenAdminApplication("website-channel-example");
            await SelectTopDropdownLanguage("English (United States)");

            var treeItems = await GetPageTreeItemsFlat();

            async Task ExpectChildrenAllowed(string pageTitleSubstring, bool allowed)
            {
                var subpage4 = treeItems.First(x => x.Title?.Contains(pageTitleSubstring, StringComparison.OrdinalIgnoreCase) == true);
                await subpage4.ClickAsync();
                await Debounce();
                await Page.GetByTestId("create-page-button").ClickAsync();
                var typeSelectorTile = Page.GetByTestId("item-tile").Nth(0);

                if (allowed)
                {
                    await Assertions.Expect(typeSelectorTile).ToBeVisibleAsync();
                    await Assertions.Expect(typeSelectorTile).ToHaveAttributeAsync("aria-label", "This is Article example");
                }
                else
                {
                    await Assertions.Expect(typeSelectorTile).Not.ToBeVisibleAsync();
                }
            }

            await ExpectChildrenAllowed("Simplified model sample sub page 4", false);
            await ExpectChildrenAllowed("Simplified model sample sub page 5", true);
            await ExpectChildrenAllowed("Simplified model sample sub page 6", true);
        }

        [Test]
        public async Task Test01500_Vanity_URLs_Show_In_Page_URLs()
        {
            await OpenAdminApplication("website-channel-example");
            await SelectTopDropdownLanguage("English (United States)");

            var treeItems = await GetPageTreeItemsFlat();

            var item = treeItems.First(x => string.Equals(x.Title, "Creation of UMT model", StringComparison.OrdinalIgnoreCase));
            await item.ClickAsync();

            await Page.Locator($"div[data-testid=\"application-tile\"]").Filter(new LocatorFilterOptions { HasTextRegex = new Regex($"^URLs$") }).ClickAsync();
            await Debounce();

            Task ExpectVanityURLRowVisible(string url) => Assertions.Expect(Page
                .GetByTestId("edit-page")
                .GetByRole(AriaRole.Row)
                .Filter(new() { Has = Page.GetByRole(AriaRole.Cell).Filter(new() { HasText = "Vanity URL" }) })
                .Filter(new() { Has = Page.GetByRole(AriaRole.Cell).Filter(new() { HasText = url }) })
                .Nth(0))
                .ToBeVisibleAsync();

            await ExpectVanityURLRowVisible("https://websitesamplewebsitedomain.com/creation-of-umt-model-vanity-1");
            await ExpectVanityURLRowVisible("https://websitesamplewebsitedomain.com/creation-of-umt-model-vanity-2");
        }

        [Test]
        public async Task Test01600_Vanity_URLs_Show_In_URLs_App()
        {
            await OpenAdminApplication("urls");

            await Page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasTextRegex = new Regex("^Vanity URLs$") }).ClickAsync();
            await Debounce();

            await Assertions.Expect(Page.GetByText("creation-of-umt-model-vanity-1")).ToBeVisibleAsync();
            await Assertions.Expect(Page.GetByText("creation-of-umt-model-vanity-2")).ToBeVisibleAsync();
        }
    }
}
