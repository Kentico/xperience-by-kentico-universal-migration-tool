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
    public class _05_ChannelManagementTests : AdminTestBase
    {
        [Test]
        public async Task Test00100_Email_Channel_Exists_And_Is_Explorable()
        {
            await OpenAdminApplication("Channel management");

            await page.GetByTestId("table-cell-ChannelType").Filter(new LocatorFilterOptions { HasText = "Email" }).Nth(0).ClickAsync();
            await Debounce();

            await Assertions.Expect(page.GetByTestId("ChannelDisplayName")).Not.ToBeEmptyAsync();
            await Assertions.Expect(page.GetByTestId("ChannelType")).Not.ToBeEmptyAsync();
            await Assertions.Expect(page.GetByTestId("ChannelSize")).Not.ToBeEmptyAsync();
            await Assertions.Expect(page.GetByTestId("EmailChannelSendingDomain")).Not.ToBeEmptyAsync();
            await Assertions.Expect(page.GetByTestId("EmailChannelServiceDomain")).Not.ToBeEmptyAsync();

            await page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasTextRegex = new Regex("^General$") }).ClickAsync();
            await Debounce();

            await page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasTextRegex = new Regex("^Allowed content types$") }).ClickAsync();
            await Debounce();

            await page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasTextRegex = new Regex("^Sender addresses$") }).ClickAsync();
            await Debounce();

            await AssertNoEventlogErrors();
        }

        [Test]
        public async Task Test00200_Website_Channel_Exists_And_Is_Explorable()
        {
            await OpenAdminApplication("Channel management");

            await page.GetByTestId("table-cell-ChannelType").Filter(new LocatorFilterOptions { HasText = "Website" }).Nth(0).ClickAsync();
            await Debounce();

            await Assertions.Expect(page.GetByTestId("ChannelDisplayName")).Not.ToBeEmptyAsync();
            await Assertions.Expect(page.GetByTestId("ChannelType")).Not.ToBeEmptyAsync();
            await Assertions.Expect(page.GetByTestId("ChannelSize")).Not.ToBeEmptyAsync();
            await Assertions.Expect(page.GetByTestId("WebsiteChannelDomain")).Not.ToBeEmptyAsync();
            await Assertions.Expect(page.GetByTestId("WebsiteChannelDomain")).Not.ToBeEmptyAsync();

            await page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasTextRegex = new Regex("^General$") }).ClickAsync();
            await Debounce();
            
            await page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasTextRegex = new Regex("^Allowed content types$") }).ClickAsync();
            await Debounce();
            await Assertions.Expect(page.GetByTestId("table-row")).ToHaveCountAsync(1);

            await page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasTextRegex = new Regex("^Channel settings$") }).ClickAsync();
            await Debounce();

            await AssertNoEventlogErrors();
        }
    }
}
