using Microsoft.Extensions.DependencyInjection;

namespace Kentico.Xperience.UMT.Tests.X.TestsWithDb;

public class DefaultFixture : IDisposable
{
    private readonly ServiceProvider serviceProvider;

    public DefaultFixture()
    {
        var serviceCollection = new ServiceCollection();
        serviceProvider = serviceCollection.BuildServiceProvider();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            serviceProvider.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~DefaultFixture() => Dispose(false);
}

[CollectionDefinition("DefaultCollection")]
public class DefaultCollection : ICollectionFixture<DefaultFixture> { }
