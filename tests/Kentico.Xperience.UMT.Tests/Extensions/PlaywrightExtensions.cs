using System.Diagnostics;
using System.Text.RegularExpressions;

using Microsoft.Playwright;

namespace TestAfterMigration.Extensions
{
    public static class PlaywrightExtensions
    {
        // The admin UI regenerates random ids of form elements (id="input-lmh3qj", for="textarea-n905cc", ...)
        // on every render, so they must be ignored when comparing markup snapshots for stability.
        private static readonly Regex VolatileElementIdRegex = new("(?:input|textarea|select)-[a-z0-9]+", RegexOptions.Compiled);

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
        public static async Task Debounce(this IPage page, int pollDelayMs = 100, int stableDelayMs = 500, int timeoutMs = 60000)
        {
            await Task.Delay(500);
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await Task.Delay(1000);

            string markupPrevious = "";
            var totalStopwatch = Stopwatch.StartNew();
            var stopwatch = Stopwatch.StartNew();
            bool isStable = false;
            while (!isStable)
            {
                if (totalStopwatch.ElapsedMilliseconds > timeoutMs)
                {
                    throw new Exception($"Debounce timeout - page markup did not stabilize within {timeoutMs}ms");
                }

                string markupCurrent;
                try
                {
                    markupCurrent = await page.ContentAsync();
                }
                catch (PlaywrightException)
                {
                    await Task.Delay(pollDelayMs);
                    continue;
                }

                markupCurrent = VolatileElementIdRegex.Replace(markupCurrent, "volatile-id");

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
