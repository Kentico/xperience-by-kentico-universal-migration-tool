using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAfterMigration.Extensions
{
    public static class PlaywrightExtensions
    {
        public static Task WaitForVisible(this ILocator locator) => locator.Nth(0).WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
    }
}
