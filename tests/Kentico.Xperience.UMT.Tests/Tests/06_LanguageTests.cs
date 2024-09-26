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
    public class _06_LanguageTests : AdminTestBase
    {
        [Test]
        public async Task Test00100_All_Expected_Languages_Present_And_Clickable_Without_Errors()
        {
            await OpenAdminApplication("Languages");

            var expectedLanguages = new[] { "English - (default)", "English (United Kingdom)", "English (United States)", "Spanish" };

            foreach (var lang in expectedLanguages)
            {
                await page.GetByTestId("table-cell-ContentLanguageDisplayName").Filter(new LocatorFilterOptions { HasText = lang }).Nth(0).ClickAsync();
                await Debounce();
                await page.GoBackAsync();
                await Debounce();
            }

            await AssertNoEventlogErrors();
        }
    }
}
