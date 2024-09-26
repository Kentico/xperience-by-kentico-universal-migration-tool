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
    public class _08_ContentTypeTests : AdminTestBase
    {
        [Test]
        public async Task Test00100_Expected_Content_Types_Created_And_Explorable_Without_Errors()
        {
            await OpenAdminApplication("Content types");

            var expectedTypes = new[] { "UMT.Event", "UMT.Faq", "UMT.Article" };

            foreach (var lang in expectedTypes)
            {
                await page.GetByTestId("table-cell-ClassName").Filter(new LocatorFilterOptions { HasText = lang }).Nth(0).ClickAsync();
                await Debounce();
                await page.GoBackAsync();
                await Debounce();
            }

            await AssertNoEventlogErrors();
        }
    }
}
