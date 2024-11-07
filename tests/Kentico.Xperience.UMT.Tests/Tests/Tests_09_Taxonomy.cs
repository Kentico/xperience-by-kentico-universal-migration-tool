using Microsoft.Playwright;

namespace TestAfterMigration.Tests
{
    public class Tests_09_Taxonomy : AdminTestBase
    {
        [Test]
        public async Task Test00100_Expected_Taxonomy_Structure_Created_And_Explorable()
        {
            // await OpenAdminApplication("Taxonomies");

            // await Page.GetByTestId("table-row").ClickAsync();     // also checks that an item exists
            // await Debounce();

            // await Assertions.Expect(Page.GetByRole(AriaRole.Treeitem)).ToHaveCountAsync(3);

            // var tagWithChildren = Page.GetByRole(AriaRole.Treeitem).Nth(1);
            // await Assertions.Expect(tagWithChildren).ToBeVisibleAsync();

            // await tagWithChildren.GetByTestId("tree-item-expand").ClickAsync();
            // await Debounce();

            // await Assertions.Expect(tagWithChildren.GetByRole(AriaRole.Treeitem)).ToHaveCountAsync(2);

            // foreach (var item in await Page.GetByRole(AriaRole.Treeitem).AllAsync())
            // {
            //     await item.ClickAsync();
            //     await Debounce();
            // }

            // await AssertNoEventlogErrors();
        }
    }
}
