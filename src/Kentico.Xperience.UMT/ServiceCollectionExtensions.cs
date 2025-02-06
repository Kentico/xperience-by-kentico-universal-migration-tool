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
    public static IServiceCollection AddUniversalMigrationToolkit(this IServiceCollection services) =>
        RegisterServices(services);

    private static IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddTransient<IImportService, ImportService>();
        services.AddTransient<IImporter, Importer>();
        services.AddSingleton<IProviderProxyFactory, ProviderProxyFactory>();
        services.AddSingleton<AdapterFactory>();
        services.AddSingleton<AssetManager>();
        services.AddSingleton(_ => new UmtModelService(new[] { typeof(ServiceCollectionExtensions).Assembly }));

        return services;
    }
}
