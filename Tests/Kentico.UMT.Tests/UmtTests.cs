using CMS.Core;
using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.SiteProvider;
using CMS.Tests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Tests.DocumentEngine;

namespace Kentico.Xperience.UMT;

internal abstract class UmtTests : UnitTests
{
    public const string FakeSiteName = "Boilerplate";
    public const string FakeCulture = "en-US";
    public static readonly Guid RootNodeGuid = TreeNodeSamples.SiteRootNodeGuid;
    
    private static int nodeCount = 0;
    
    protected IServiceCollection Services = null!;
    protected IServiceProvider ServiceProvider = null!;

    private static TreeNode? rootNode;
    public static TreeNode RootNode => rootNode ??= CreateNode("/", "CMS.Root", RootNodeGuid);

    [SetUp]
    public void SetUp()
    {
        Services = new ServiceCollection();
        Services.AddLogging(b => b.AddDebug());
        Services.AddUniversalMigrationToolkit();
        ServiceProvider = Services.BuildServiceProvider();
        
        // Registers the page type class
        // The 'CustomPageType' class is generated for a page type from the Xperience Page types application
        DocumentGenerator.RegisterDocumentType<TreeNode>("CMS.Root");

        // Fakes the page type to allow creation of fake page data
        Fake().DocumentType<TreeNode>("CMS.Root");
        
        Fake<SiteInfo, SiteInfoProvider>().WithData(
            new SiteInfo { SiteName = FakeSiteName }
        );
    }
    
    
    private static TreeNode CreateNode(string nodeAliasPath, string contentType, Guid nodeGuid, string culture = FakeCulture, string site = FakeSiteName)
    {
        nodeCount++;
        var nodeSite = SiteInfo.Provider.Get(site);
        var node = TreeNode.New(contentType).With(p =>
        {
            p.DocumentCulture = culture;
            p.DocumentName = Guid.NewGuid().ToString();
            p.SetValue(nameof(TreeNode.DocumentID), nodeCount);
            p.SetValue(nameof(TreeNode.NodeGUID), nodeGuid);
            p.SetValue(nameof(TreeNode.NodeSiteID), nodeSite.SiteID);
            p.SetValue(nameof(TreeNode.DocumentCreatedWhen), new DateTime(2022, 1, 1));
            p.SetValue(nameof(TreeNode.NodeAliasPath), nodeAliasPath);
        });

        return node;
    }


    [TearDown]
    public void TearDown()
    {
        // Method intentionally left empty.
    }
}

