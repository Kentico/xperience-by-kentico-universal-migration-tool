using System.Diagnostics;

using Microsoft.Playwright;

namespace TestAfterMigration.Extensions
{
    public static class PlaywrightExtensions
    {
        public static Task WaitForVisible(this ILocator locator) => locator.Nth(0).WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });

        /// <summary>
        /// Ensures all page loading processes have ended by monitoring that nothing more happens. 
        /// Duration is at least <paramref name="stableDelayMs"/>, so use only when needed if you
        /// have a lot of tests.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pollDelayMs"></param>
        /// <param name="stableDelayMs"></param>
        /// <returns></returns>
        public static async Task Debounce(this IPage page, int pollDelayMs = 100, int stableDelayMs = 500)
        {
            string markupPrevious = "";
            var stopwatch = Stopwatch.StartNew();
            bool isStable = false;
            while (!isStable)
            {
                string markupCurrent = await page.ContentAsync();
                if (markupCurrent == markupPrevious)
                {
                    double elapsed = stopwatch.ElapsedMilliseconds;
                    isStable = stableDelayMs <= elapsed;
                }
                else
                {
                    markupPrevious = markupCurrent;
                    stopwatch.Restart();
                }
                if (!isStable)
                {
                    await Task.Delay(pollDelayMs);
                }
            }
        }

    }
}
