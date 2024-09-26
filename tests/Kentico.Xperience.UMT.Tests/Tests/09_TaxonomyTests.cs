using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestAfterMigration.Extensions;
using TestAfterMigration.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestAfterMigration.Tests
{
    public class _09_TaxonomyTests : AdminTestBase
    {
        [Test]
        public async Task Test00100_Expected_Taxonomy_Structure_Created_And_Explorable()
        {
            await OpenAdminApplication("Taxonomies");

            await page.GetByTestId("table-row").ClickAsync();     // also checks that an item exists
            await Debounce();

            await Assertions.Expect(page.GetByRole(AriaRole.Treeitem)).ToHaveCountAsync(3);

            var tagWithChildren = page.GetByRole(AriaRole.Treeitem).Nth(1);
            await Assertions.Expect(tagWithChildren).ToBeVisibleAsync();

            await tagWithChildren.GetByTestId("tree-item-expand").ClickAsync();
            await Debounce();

            await Assertions.Expect(tagWithChildren.GetByRole(AriaRole.Treeitem)).ToHaveCountAsync(2);

            foreach (var item in await page.GetByRole(AriaRole.Treeitem).AllAsync())
            {
                await item.ClickAsync();
                await Debounce();
            }

            await AssertNoEventlogErrors();
        }
    }
}
