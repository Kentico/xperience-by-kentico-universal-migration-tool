using CMS.Core;
using CMS.DataEngine;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Services.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class KenticoFixture : IDisposable
{
    public static readonly Guid AdminUserGuid = new("6415B8CE-8072-4BCD-8E48-9D7178B826B7");
    public static readonly Guid RootNodeGuid = new("ACDD2058-BDE0-4C9D-8332-45F417220571");
    
#pragma warning disable S3887 // intentional - tests will be refactored (reliance on local database SHALL be removed)
    public static readonly List<BaseInfo> ObjectsToDelete = new();
#pragma warning restore S3887

    public static readonly UmtModelService ModelService = new(new[] { typeof(UmtModelService).Assembly });

    public KenticoFixture()
    {
        var root = new ConfigurationRoot(new List<IConfigurationProvider>(new[] { new MemoryConfigurationProvider(new MemoryConfigurationSource()) }));
        root[ConfigurationPath.Combine("ConnectionStrings", "CMSConnectionString")] =
            "Data Source=.;Initial Catalog=Kentico14_CLI_26_04_00;Integrated Security=True;Persist Security Info=False;Connect Timeout=60;Encrypt=False;Current Language=English;";
        Service.Use<IConfiguration>(root);
        CMSApplication.Init();
    }

    public void Dispose()
    {
        // ... clean up test data from the database ...

        foreach (var baseInfo in ObjectsToDelete)
        {
            try
            {
                baseInfo.Delete();
            }
            catch
            {
                // ignored
            }
        }
    }

    internal static ILogger<TLoggerCategory> CreateLogger<TLoggerCategory>()
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging(b => b.AddDebug())
            .BuildServiceProvider();
        var factory = serviceProvider.GetRequiredService<ILoggerFactory>();
        var logger = factory.CreateLogger<TLoggerCategory>();
        return logger;
    }

    internal static ILoggerFactory GetLoggerFactory()
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging(b => b.AddDebug())
            .BuildServiceProvider();
        return serviceProvider.GetRequiredService<ILoggerFactory>();
    }

    internal static IServiceProvider GetUmtServiceProvider()
    {
        var services = new ServiceCollection();
        services.AddLogging(b => b.AddDebug());
        services.AddUniversalMigrationToolkit();
        return services.BuildServiceProvider();
    }
    
    public static ServiceCollection FakeDiContainer(ProviderProxyContext fakedContext)
    {
        var services = new ServiceCollection();
        services.AddUniversalMigrationToolkit();
        services.AddLogging(b => b.AddDebug());
        services.Replace(ServiceDescriptor.Transient<IProviderProxyFactory>(s => new FakeProviderProxyFactory(fakedContext)));
        
        var root = new ConfigurationRoot(new List<IConfigurationProvider>(new[] { new MemoryConfigurationProvider(new MemoryConfigurationSource()) }));
        root[ConfigurationPath.Combine("ConnectionStrings", "CMSConnectionString")] =
            "Data Source=.;Initial Catalog=Kentico14_CLI_26_04_00;Integrated Security=True;Persist Security Info=False;Connect Timeout=60;Encrypt=False;Current Language=English;";
        Service.Use<IConfiguration>(root);
        CMSApplication.Init();
        
        return services;
    }
}

[CollectionDefinition("UMT.Tests")]
public class DatabaseCollection : ICollectionFixture<KenticoFixture>
{
}
