using FluentAssertions;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.Serialization;
using Kentico.Xperience.UMT.Services.Model;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Kentico.Xperience.UMT;

[Collection("UMT.Tests")]
public class SerializerTests
{
    [Fact]
    public void ImportService_NestedPagesImport()
    {
        var provider = KenticoFixture.GetUmtServiceProvider();
        var modelService = provider.GetRequiredService<UmtModelService>();

        var firstNodeGuid = new Guid("DCBDE667-AC3F-4EF1-B092-61D7C3912E2C");
        var firstDocumentGuid = new Guid("945AAABC-940B-42F6-BF99-3FCD6FFAB03B");
        var secondNodeGuid = new Guid("BD089033-A00E-40F1-AFF3-00992293DF10");
        var secondDocumentGuid = new Guid("03F3CDDF-B8AA-41A3-BC5D-7FD6D9909FD2");

        

        var options = JsonConvert.DefaultSettings?.Invoke() ?? new JsonSerializerSettings();
        var converter = new UmtModelJsonConverter(modelService.GetAll());
        options.Converters.Add(converter);
        
        string actual = JsonConvert.SerializeObject(new[]
        {
            new TreeNodeModel
            {
                NodeOwnerGuid = KenticoFixture.AdminUserGuid,
                NodeClassGuid = new Guid("ADEAF5CE-13CB-4457-A0BE-EFE29E23F513"), // custom page class Guid ("UMT.Page")
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
                NodeClassGuid = new Guid("ADEAF5CE-13CB-4457-A0BE-EFE29E23F513"), // custom page class Guid ("UMT.Page")
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
        }, options);

        actual.Should().NotBeNullOrWhiteSpace();

        actual.Should().Be("""[{"$type":"TreeNode","NodeClassGuid":"adeaf5ce-13cb-4457-a0be-efe29e23f513","NodeOwnerGuid":"6415b8ce-8072-4bcd-8e48-9d7178b826b7","NodeParentGuid":"acdd2058-bde0-4c9d-8332-45f417220571","NodeGUID":"dcbde667-ac3f-4ef1-b092-61d7c3912e2c","NodeAlias":"umt.test.nestedpages1.nodealias","NodeName":"umt.test.nestedpages1.ndoename","NodeOrder":null,"DocumentCulture":"en-US","DocumentName":"umt.test.nestedpages1.documentname","DocumentLastPublished":"2023-01-01T00:00:00","DocumentModifiedWhen":"2023-01-01T00:00:00","DocumentCreatedWhen":"2023-01-01T00:00:00","DocumentPublishFrom":"2023-01-01T00:00:00","DocumentPublishTo":"2026-01-01T00:00:00","DocumentGUID":"945aaabc-940b-42f6-bf99-3fcd6ffab03b","DocumentCreatedByUserGuid":"6415b8ce-8072-4bcd-8e48-9d7178b826b7","DocumentModifiedByUserGuid":"6415b8ce-8072-4bcd-8e48-9d7178b826b7","NodeIsPage":true,"References":null,"_CustomProperties":{"Perex":"Testing perex"}},{"$type":"TreeNode","NodeClassGuid":"adeaf5ce-13cb-4457-a0be-efe29e23f513","NodeOwnerGuid":"6415b8ce-8072-4bcd-8e48-9d7178b826b7","NodeParentGuid":"dcbde667-ac3f-4ef1-b092-61d7c3912e2c","NodeGUID":"bd089033-a00e-40f1-aff3-00992293df10","NodeAlias":"umt.test.nestedpages2.nodealias","NodeName":"umt.test.nestedpages2.ndoename","NodeOrder":null,"DocumentCulture":"en-US","DocumentName":"umt.test.nestedpages2.documentname","DocumentLastPublished":"2023-01-01T00:00:00","DocumentModifiedWhen":"2023-01-01T00:00:00","DocumentCreatedWhen":"2023-01-01T00:00:00","DocumentPublishFrom":"2023-01-01T00:00:00","DocumentPublishTo":"2026-01-01T00:00:00","DocumentGUID":"03f3cddf-b8aa-41a3-bc5d-7fd6d9909fd2","DocumentCreatedByUserGuid":"6415b8ce-8072-4bcd-8e48-9d7178b826b7","DocumentModifiedByUserGuid":"6415b8ce-8072-4bcd-8e48-9d7178b826b7","NodeIsPage":true,"References":null,"_CustomProperties":{"Perex":"Testing perex"}}]""");
    }
}
