﻿using Microsoft.Playwright;
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
        public async Task WaitBreadcrumbsLoaded()
        {
            string pageTitle = (await Locator.GetByTestId("tree-item-title").Nth(0).TextContentAsync())!;
            await Locator.Page.GetByTestId("breadcrumbs").GetByText(pageTitle).WaitForVisible();
        }
    }
}