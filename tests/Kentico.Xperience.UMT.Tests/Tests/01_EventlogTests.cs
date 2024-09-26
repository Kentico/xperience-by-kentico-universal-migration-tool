namespace TestAfterMigration.Tests
{
    public class _01_EventlogTests : AdminTestBase
    {
        [Test]
        public async Task Test00100_EventlogHasNoErrors() => await AssertNoEventlogErrors();
    }
}
