using System.Text.RegularExpressions;

using Microsoft.Playwright;

namespace TestAfterMigration.Tests
{
    public class Tests_05_ChannelManagementTests : AdminTestBase
    {
        [Test]
        public async Task Test00100_Email_Channel_Exists_And_Is_Explorable()
        {
            await OpenAdminApplication("channel-management");

            await Page.GetByTestId("table-cell-ChannelType").Filter(new LocatorFilterOptions { HasText = "Email" }).Nth(0).ClickAsync();
            await Debounce();

            await Assertions.Expect(Page.GetByTestId("ChannelDisplayName")).Not.ToBeEmptyAsync();
            await Assertions.Expect(Page.GetByTestId("ChannelType")).Not.ToBeEmptyAsync();
            await Assertions.Expect(Page.GetByTestId("ChannelSize")).Not.ToBeEmptyAsync();
            await Assertions.Expect(Page.GetByTestId("EmailChannelSendingDomain")).Not.ToBeEmptyAsync();
            await Assertions.Expect(Page.GetByTestId("EmailChannelServiceDomain")).Not.ToBeEmptyAsync();

            await Page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasTextRegex = new Regex("^General$") }).ClickAsync();
            await Debounce();

            await Page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasTextRegex = new Regex("^Allowed content types$") }).ClickAsync();
            await Debounce();

            await Page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasTextRegex = new Regex("^Sender addresses$") }).ClickAsync();
            await Debounce();

            await AssertNoEventlogErrors();
        }

        [Test]
        public async Task Test00200_Website_Channel_Exists_And_Is_Explorable()
        {
            await OpenAdminApplication("channel-management");

            await Page.GetByTestId("table-cell-ChannelType").Filter(new LocatorFilterOptions { HasText = "Website" }).Nth(0).ClickAsync();
            await Debounce();

            await Assertions.Expect(Page.GetByTestId("ChannelDisplayName")).Not.ToBeEmptyAsync();
            await Assertions.Expect(Page.GetByTestId("ChannelType")).Not.ToBeEmptyAsync();
            await Assertions.Expect(Page.GetByTestId("ChannelSize")).Not.ToBeEmptyAsync();
            await Assertions.Expect(Page.GetByTestId("WebsiteChannelDomain")).Not.ToBeEmptyAsync();
            await Assertions.Expect(Page.GetByTestId("WebsiteChannelDomain")).Not.ToBeEmptyAsync();

            await Page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasTextRegex = new Regex("^General$") }).ClickAsync();
            await Debounce();

            await Page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasTextRegex = new Regex("^Allowed content types$") }).ClickAsync();
            await Debounce();
            await Assertions.Expect(Page.GetByTestId("table-row")).ToHaveCountAsync(1);

            await Page.GetByTestId("vertical-menu-item").Filter(new LocatorFilterOptions { HasTextRegex = new Regex("^Channel settings$") }).ClickAsync();
            await Debounce();

            await AssertNoEventlogErrors();
        }
    }
}
