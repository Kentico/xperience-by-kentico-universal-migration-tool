
using Microsoft.Playwright;
using TestAfterMigration.Enums;
using TestAfterMigration.Extensions;
using TestAfterMigration.Helpers;

namespace TestAfterMigration.Tests
{
    public class AdminTestBase
    {
        protected IPlaywright playwright = null!;
        protected IBrowser browser = null!;
        protected IPage page = null!;
        protected string BaseURL => Environment.GetEnvironmentVariable("BASE_URL") ?? "";
        protected string AdministratorUser => Environment.GetEnvironmentVariable("ADMINISTRATION_USER") ?? "";
        protected string AdministratorPassword => Environment.GetEnvironmentVariable("ADMINISTRATION_PASSWORD") ?? "";

        [SetUp]
        public async Task Setup()
        {
            playwright = await Playwright.CreateAsync();
            playwright.Selectors.SetTestIdAttribute("data-testid");

            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });

            page = await browser.NewPageAsync();
            await LoginAdmin();
        }

        [TearDown]
        public async Task TearDown()
        {
            await page.CloseAsync();
            await browser.CloseAsync();
        }

        protected async Task LoginAdmin()
        {
            await page.GotoAsync($"{BaseURL}/admin");
            await Debounce();

            if (await page.Locator("input[name='userName']").IsVisibleAsync())
            {
                await page.FillAsync("input[name='userName']", AdministratorUser);
                await page.FillAsync("input[name='password']", AdministratorPassword);
                await page.ClickAsync("button[type='submit']");
            }
            await Debounce();
        }

        /// <summary>
        /// Consider using <see cref="Debounce"/> after calling this method based on complexity of concrete application page
        /// </summary>
        /// <param name="applicationName"></param>
        /// <returns></returns>
        protected async Task OpenAdminApplication(string applicationName)
        {
            await LoginAdmin();
            await page.ClickAsync($"button[aria-label='{applicationName}']");
            await Debounce();
        }

        protected async Task SelectInAdminFormDropDown(string dropdownTitle, string itemTestID)
        {
            var dropdownArrow = page.Locator($":below(:text(\"{dropdownTitle}\"))[data-testid=\"xp-chevron-down\"]").First;
            await dropdownArrow.ClickAsync();
            var item = page.GetByTestId(itemTestID);
            await item.ClickAsync();
        }

        protected async Task<IReadOnlyList<ILocator>> GetTableRows()
        {
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            return await page.GetByRole(AriaRole.Row).AllAsync();
        }

        protected Task WaitForPageTreeLoaded() => page.GetByRole(AriaRole.Treeitem).WaitForVisible();

        protected async Task<IEnumerable<PageTreeItem>> GetPageTreeItems(bool rootOnly = false)
        {
            await WaitForPageTreeLoaded();
            return await GetTreeNodeChildren(page.GetByRole(AriaRole.Treeitem).Nth(0), rootOnly, true);
        }

        private async Task<IEnumerable<PageTreeItem>> GetTreeNodeChildren(ILocator parentNode, bool rootOnly, bool isChannelRoot)
        {
            var children = new List<PageTreeItem>();
            var expand = parentNode.GetByTestId("tree-item-expand");
            bool scanSubChildren = !isChannelRoot && !rootOnly && await expand.IsVisibleAsync();

            if (scanSubChildren)
            {
                await expand.ClickAsync();
                await parentNode.GetByRole(AriaRole.Treeitem).WaitForVisible();
            }

            foreach (var childLocator in (await parentNode.GetByRole(AriaRole.Treeitem).AllAsync()))
            {
                var item = new PageTreeItem(parentNode.Page, (await childLocator.GetAttributeAsync("data-testid-nodeid"))!);
                await item.LoadInfo();
                children.Add(item);
            }

            foreach (var child in children)
            {
                child.Children = await GetTreeNodeChildren(child.Locator, rootOnly, false);
            }
            return children.ToArray();
        }

        /// <summary>
        /// Ensures all page loading processes have ended by monitoring that nothing more happens. 
        /// Duration is at least <paramref name="stableDelayMs"/>, so use only when needed if you
        /// have a lot of tests.
        /// </summary>
        /// <param name="pollDelayMs"></param>
        /// <param name="stableDelayMs"></param>
        /// <returns></returns>
        protected async Task Debounce(int pollDelayMs = 100, int stableDelayMs = 500)
        {
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            var markupPrevious = "";
            var timerStart = DateTime.Now;
            var isStable = false;
            while (!isStable)
            {
                var markupCurrent = await page.ContentAsync();
                if (markupCurrent == markupPrevious)
                {
                    var elapsed = (DateTime.Now - timerStart).TotalMilliseconds;
                    isStable = stableDelayMs <= elapsed;
                }
                else
                {
                    markupPrevious = markupCurrent;
                }
                if (!isStable) await Task.Delay(pollDelayMs);
            }
        }

        protected async Task AssertNoEventlogErrors()
        {
            await OpenAdminApplication("Event log");

            var logs = await GetEventLogRowsFirstPage(EventLogSeverity.Error);

            Assert.That(logs.Count == 0);
        }

        private async Task<IReadOnlyList<ILocator>> GetEventLogRowsFirstPage(EventLogSeverity severity)
        {
            if (await page.GetByText("There are no records to display").CountAsync() != 0)
            {
                return [];
            }
            await page.GetByTestId("filter-button").ClickAsync();

            var severityOptionTestID = severity switch { EventLogSeverity.Info => "info", EventLogSeverity.Warning => "warning", EventLogSeverity.Error => "error", _ => throw new NotImplementedException() };

            await SelectInAdminFormDropDown("Type", severityOptionTestID);
            await page.GetByTestId("submit-button").ClickAsync();

            await Debounce();

            var rows = await GetTableRows();
            return rows;
        }

        protected async Task SelectTopDropdownLanguage(string languageTitle)
        {
            await page.GetByTestId("LanguageSelector").ClickAsync();
            await page.GetByTestId("LanguageSelector").GetByTestId("menu-item").Filter(new LocatorFilterOptions { HasText = languageTitle }).ClickAsync();
        }
    }
}
