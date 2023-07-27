using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT;

public static class Initializer
{
    public static IServiceProvider GetUmtServiceProvider()
    {
        var services = new ServiceCollection();
        services.AddLogging(b => b.AddDebug());
        services.AddUniversalMigrationToolkit();
        return services.BuildServiceProvider();
    }
}
