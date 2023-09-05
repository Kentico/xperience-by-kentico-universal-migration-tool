using CMS.DataEngine;
// using CMS.DocumentEngine; => obsolete
using FluentAssertions;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kentico.Xperience.UMT;

[Collection("UMT.Tests")]
public class ImportServiceTests
{
    [Fact]
    public async Task ImportService_NestedPagesImportAsync()
    {
        var provider = KenticoFixture.GetUmtServiceProvider();
        var importService = provider.GetRequiredService<IImportService>();

        var firstNodeGuid = new Guid("DCBDE667-AC3F-4EF1-B092-61D7C3912E2C");
        var firstDocumentGuid = new Guid("945AAABC-940B-42F6-BF99-3FCD6FFAB03B");
        var secondNodeGuid = new Guid("BD089033-A00E-40F1-AFF3-00992293DF10");
        var secondDocumentGuid = new Guid("03F3CDDF-B8AA-41A3-BC5D-7FD6D9909FD2");

        var observer = new ImportStateObserver();
        var actualResults = new List<BaseInfo>();
        observer.ImportedInfo += info => { actualResults.Add(info); };

        observer = importService.StartImport(new[]
        {
            new TreeNodeModel
            {
                NodeOwnerGuid = KenticoFixture.AdminUserGuid,
                NodeClassGuid = new Guid("299C6ED4-4889-4173-AD19-158A3AD77AFE"), // custom page class Guid ("UMT.Page")
                NodeParentGuid = KenticoFixture.RootNodeGuid,
                CustomProperties =
                {
                    { "Perex", "Testing perex" }
                },
                NodeGUID = firstNodeGuid,
                NodeAlias = "umt.test.nestedpages1.nodealias",
                NodeName = "umt.test.nestedpages1.ndoename",
                // NodeOrder = null,
                DocumentCulture = "en-US",
                DocumentName = "umt.test.nestedpages1.documentname",
                DocumentLastPublished = new DateTime(2023, 01, 01),
                DocumentModifiedWhen = new DateTime(2023, 01, 01),
                DocumentCreatedWhen = new DateTime(2023, 01, 01),
                DocumentPublishFrom = new DateTime(2023, 01, 01),
                DocumentPublishTo = new DateTime(2026, 01, 01), // root node
                DocumentGUID = firstDocumentGuid,
                DocumentCreatedByUserGuid = KenticoFixture.AdminUserGuid,
                DocumentModifiedByUserGuid = KenticoFixture.AdminUserGuid,
            },
            new TreeNodeModel
            {
                NodeOwnerGuid = KenticoFixture.AdminUserGuid,
                NodeClassGuid = new Guid("299C6ED4-4889-4173-AD19-158A3AD77AFE"), // custom page class Guid ("UMT.Page")
                NodeParentGuid = firstNodeGuid, // parent is first node
                CustomProperties =
                {
                    { "Perex", "Testing perex" }
                },
                NodeGUID = secondNodeGuid,
                NodeAlias = "umt.test.nestedpages2.nodealias",
                NodeName = "umt.test.nestedpages2.ndoename",
                // NodeOrder = null,
                DocumentCulture = "en-US",
                DocumentName = "umt.test.nestedpages2.documentname",
                DocumentLastPublished = new DateTime(2023, 01, 01),
                DocumentModifiedWhen = new DateTime(2023, 01, 01),
                DocumentCreatedWhen = new DateTime(2023, 01, 01),
                DocumentPublishFrom = new DateTime(2023, 01, 01),
                DocumentPublishTo = new DateTime(2026, 01, 01), // root node
                DocumentGUID = secondDocumentGuid,
                DocumentCreatedByUserGuid = KenticoFixture.AdminUserGuid,
                DocumentModifiedByUserGuid = KenticoFixture.AdminUserGuid,
            }
        }, new ImporterContext("Boilerplate", "en-US"), observer);

        await observer.ImportCompletedTask;
        
        actualResults.Should().SatisfyRespectively(
            first =>
            {
                var node = first.Should().BeOfType<TreeNode>().Subject;
                node.NodeGUID.Should().Be(firstNodeGuid);
                node.DocumentGUID.Should().Be(firstDocumentGuid);
            },
            second =>
            {
                var node = second.Should().BeOfType<TreeNode>().Subject;
                node.NodeGUID.Should().Be(secondNodeGuid);
                node.DocumentGUID.Should().Be(secondDocumentGuid);
                node.Parent.NodeGUID.Should().Be(firstNodeGuid);
            }
        );
    }
}
