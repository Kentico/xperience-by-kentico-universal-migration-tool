using Kentico.Xperience.UMT.InfoAdapter;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Services;
using Kentico.Xperience.UMT.Services.Model;
using Microsoft.Extensions.DependencyInjection;

namespace Kentico.Xperience.UMT;

/// <summary>
/// 
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    public static void AddUniversalMigrationToolkit(this IServiceCollection services)
    {
        services.AddOptions<UniversalMigrationToolkitOptions>().Configure(options =>
        {
        });

        RegisterServices(services);
    }

    /// <summary>
    /// Dependency injection registration of UMT services
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configureOptions"></param>
    public static void AddUniversalMigrationToolkit(this IServiceCollection services,
        Action<UniversalMigrationToolkitOptions> configureOptions)
    {
        services.Configure(configureOptions);

        RegisterServices(services);
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddTransient<IImportService, ImportService>();
        services.AddSingleton<IProviderProxyFactory, ProviderProxyFactory>();
        services.AddSingleton<AdapterFactory>();
        services.AddSingleton(s => new UmtModelService(new[] { typeof(ServiceCollectionExtensions).Assembly }));
    }
}
