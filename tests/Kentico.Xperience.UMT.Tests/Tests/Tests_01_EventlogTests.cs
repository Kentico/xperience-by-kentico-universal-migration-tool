namespace TestAfterMigration.Tests
{
    public class Tests_01_EventlogTests : AdminTestBase
    {
        [Test]
        public async Task Test00100_EventlogHasNoErrors() => await AssertNoEventlogErrors();
    }
}
