using Microsoft.Playwright;

using TestAfterMigration.Extensions;

namespace TestAfterMigration.Helpers
{
    public class PageTreeItem(IPage page, string nodeID)
    {
        public async Task LoadInfo() => Title = (await TitleElement.TextContentAsync())!;

        public string? Title { get; private set; } = null;
        public ILocator Locator => page.Locator($"[data-testid-nodeid=\"{nodeID}\"]");
        public IEnumerable<PageTreeItem> Children { get; set; } = [];
        public ILocator TitleElement => Locator.GetByTestId("tree-item-title").Nth(0);
        public Task ClickAsync() => TitleElement.ClickAsync();

        /// <summary>
        /// Beware this method doesn't work when name is too long, 
        /// because ellipsis is rendered instead of full page name, 
        /// which this method requires
        /// </summary>
        /// <returns></returns>
        public async Task WaitBreadcrumbsLoaded()
        {
            await page.Debounce();
            await Locator.Page.GetByTestId("breadcrumbs").WaitForVisible();
            await page.Debounce();
        }
    }
}
