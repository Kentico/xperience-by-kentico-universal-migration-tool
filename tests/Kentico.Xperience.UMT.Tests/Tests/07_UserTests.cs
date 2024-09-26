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
    public class _07_UserTests : AdminTestBase
    {
        [Test]
        public async Task Test00100_sadmin_Explorable_Without_Errors()
        {
            await OpenAdminApplication("Users");

            await page.GetByTestId("table-cell-UserName").Filter(new LocatorFilterOptions { HasText = "sadmin" }).Nth(0).ClickAsync();
            await Debounce();

            await AssertNoEventlogErrors();
        }
    }
}
