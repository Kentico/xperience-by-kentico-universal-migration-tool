using Microsoft.Playwright;

using TestAfterMigration.Enums;
using TestAfterMigration.Extensions;
using TestAfterMigration.Helpers;

namespace TestAfterMigration.Tests
{
    public class AdminTestBase
    {
        protected IPlaywright Playwright = null!;
        protected IBrowser Browser = null!;
        protected IBrowserContext Context = null!;
        protected IPage Page = null!;
        protected static string BaseURL => Environment.GetEnvironmentVariable("BASE_URL") ?? "";
        protected static string AdministratorUser => Environment.GetEnvironmentVariable("ADMINISTRATION_USER") ?? "";
        protected static string AdministratorPassword => Environment.GetEnvironmentVariable("ADMINISTRATION_PASSWORD") ?? "";

        private bool IsCIEnvironment => Environment.GetEnvironmentVariable("CI") == "false";

        [SetUp]
        public async Task Setup()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            Playwright.Selectors.SetTestIdAttribute("data-testid");
            if (IsCIEnvironment)
            {
                Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = true,
                });

                Context = await Browser.NewContextAsync();

                await Context.Tracing.StartAsync(new()
                {
                    Title = TestContext.CurrentContext.Test.ClassName + "." + TestContext.CurrentContext.Test.Name,
                    Screenshots = true,
                    Snapshots = true,
                    Sources = true
                });
            }
            else
            {
                Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false,
                });

                Context = await Browser.NewContextAsync();
            }

            Page = await Context.NewPageAsync();
            await LoginAdmin();
        }

        [TearDown]
        public async Task TearDown()
        {
            await Page.CloseAsync();
            if (IsCIEnvironment)
            {
                await Context.Tracing.StopAsync(new()
                {
                    Path = Path.Combine(
                        TestContext.CurrentContext.WorkDirectory,
                        "playwright-traces",
                        "trace.zip"
                    )
                });
            }
            await Browser.CloseAsync();
        }

        protected async Task LoginAdmin()
        {
            await Page.GotoAsync($"{BaseURL}/admin");
            await Debounce();

            if (await Page.Locator("input[name='userName']").IsVisibleAsync())
            {
                await Page.FillAsync("input[name='userName']", AdministratorUser);
                await Page.FillAsync("input[name='password']", AdministratorPassword);
                await Page.ClickAsync("button[type='submit']");
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
            await Page.ClickAsync($"button[aria-label='{applicationName}']");
            await Debounce();
        }

        protected async Task SelectInAdminFormDropDown(string inputTestID, string[] itemTestIDs)
        {
            await Page.GetByTestId(inputTestID).ClickAsync();
            await Debounce();
            foreach (string itemTestID in itemTestIDs)
            {
                var item = Page.GetByTestId(itemTestID);
                await item.ClickAsync();
            }
        }

        protected async Task<IReadOnlyList<ILocator>> GetTableRows()
        {
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            return await Page.GetByRole(AriaRole.Row).AllAsync();
        }

        protected Task WaitForPageTreeLoaded() => Page.GetByRole(AriaRole.Treeitem).WaitForVisible();

        protected async Task<IEnumerable<PageTreeItem>> GetPageTreeItems(bool rootOnly = false)
        {
            await WaitForPageTreeLoaded();
            return await GetTreeNodeChildren(Page.GetByRole(AriaRole.Treeitem).Nth(0), rootOnly, true);
        }

        protected async Task<IEnumerable<PageTreeItem>> GetPageTreeItemsFlat(bool rootOnly = false) => (await GetPageTreeItems(rootOnly)).SelectMany(x => new PageTreeItem[] { x }.Concat(x.Children));

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

            foreach (var childLocator in await parentNode.GetByRole(AriaRole.Treeitem).AllAsync())
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
        protected Task Debounce(int pollDelayMs = 100, int stableDelayMs = 500) => Page.Debounce(pollDelayMs, stableDelayMs);

        protected async Task AssertNoEventlogErrors()
        {
            await OpenAdminApplication("Event log");

            var logs = await GetEventLogRowsFirstPage(EventLogSeverity.Error);

            Assert.That(logs.Count == 0);
        }

        private async Task<IReadOnlyList<ILocator>> GetEventLogRowsFirstPage(EventLogSeverity severity)
        {
            if (await Page.GetByText("There are no records to display").CountAsync() != 0)
            {
                return [];
            }
            await SetFilter("type", severity switch { EventLogSeverity.Info => "info", EventLogSeverity.Warning => "warning", EventLogSeverity.Error => "error", _ => throw new NotImplementedException() });

            var rows = await GetTableRows();
            return rows;
        }

        protected async Task SetFilter(string inputTestID, params string[] optionTestID)
        {
            await Page.GetByTestId("filter-button").ClickAsync();

            await SelectInAdminFormDropDown(inputTestID, optionTestID);
            await Page.GetByTestId("submit-button").ClickAsync();

            await Debounce();
        }

        protected async Task SelectTopDropdownLanguage(string languageTitle)
        {
            await Page.GetByTestId("LanguageSelector").ClickAsync();
            await Page.GetByTestId("LanguageSelector").GetByTestId("menu-item").Filter(new LocatorFilterOptions { HasText = languageTitle }).ClickAsync();
            await Debounce();
        }
    }
}
