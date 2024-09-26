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
    public class _04_MediaLibraryTests : AdminTestBase
    {
        [Test]
        public async Task Test00100_Expected_Library_Structure_Was_Created()
        {
            await OpenAdminApplication("Media libraries");

            await page.GetByTestId("table-row").ClickAsync();     // also checks that an item exists
            await Debounce();

            var topFolder = page.GetByRole(AriaRole.Treeitem).Nth(0);
            await Assertions.Expect(topFolder).ToBeVisibleAsync();

            var childFolder = topFolder.GetByRole(AriaRole.Treeitem).Nth(0);
            await Assertions.Expect(childFolder).ToBeVisibleAsync();
        }

        [Test]
        public async Task Test00200_Subfolder_Contains_2_Images()
        {
            await OpenAdminApplication("Media libraries");

            await page.GetByTestId("table-row").ClickAsync();     // also checks that an item exists
            await Debounce();

            var topFolder = page.GetByRole(AriaRole.Treeitem).Nth(0);
            var childFolder = topFolder.GetByRole(AriaRole.Treeitem).Nth(0);

            await childFolder.ClickAsync();
            await Debounce();

            await Assertions.Expect(page.GetByTestId("asset-tile-preview")).ToHaveCountAsync(2);
        }

        [Test]
        public async Task Test00300_Subfolder_Images_Can_Be_Explored()
        {
            for (int i = 0; i < 2; i++)
            {
                await OpenAdminApplication("Media libraries");

                await page.GetByTestId("table-row").ClickAsync();     // also checks that an item exists
                await Debounce();

                var topFolder = page.GetByRole(AriaRole.Treeitem).Nth(0);
                var childFolder = topFolder.GetByRole(AriaRole.Treeitem).Nth(0);

                await childFolder.ClickAsync();
                await Debounce();

                await page.GetByTestId("asset-tile-preview").Nth(i).ClickAsync();
                await Assertions.Expect(page.GetByTestId("FileName")).Not.ToBeEmptyAsync();
                await Assertions.Expect(page.GetByTestId("FileTitle")).Not.ToBeEmptyAsync();

                string imageURL = $"{BaseURL}{await page.GetByTestId("MediaFileURL").Locator("a").GetAttributeAsync("href")}";
                var response = await new HttpClient().GetAsync(imageURL);

                Assert.That(response.IsSuccessStatusCode && response.Content.Headers.ContentType!.MediaType!.StartsWith("image"));
            }
        }
    }
}
