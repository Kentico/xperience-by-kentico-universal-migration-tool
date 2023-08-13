//using System.Text.Json;
//using CMS.DataEngine;
//using CMS.DocumentEngine;

using System.Text.Json;
using CMS.DataEngine;
using CMS.DocumentEngine;
using FluentAssertions;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.Services;
using Microsoft.Extensions.DependencyInjection;
// using Kentico.Xperience.UMT.Model;
// using Kentico.Xperience.UMT.Services;
// using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Kentico.Xperience.UMT;

internal class SampleTests
{
    [TestFixture]
    internal class ModelTests : UmtTests
    {
        [Test]
        public async Task ImportService_SampleTest()
        {
            var root = RootNode;
            root.NodeGUID.Should().Be(RootNodeGuid);

            1.Should().NotBe(2);
            1.Should().Be(1);

            var importService = ServiceProvider.GetRequiredService<IImportService>();

            // create observer to track import state
            var importObserver = new ImportStateObserver();

            // listen to validation errors
            importObserver.ValidationError += (model, uniqueId, errors) =>
            {
                Console.WriteLine($"Validation error '{uniqueId}': {JsonSerializer.Serialize(errors)}");
            };

            var imported = new List<BaseInfo>();
            // listen to successfully adapted and persisted objects
            importObserver.ImportedInfo += info =>
            {
                imported.Add(info);
                if (info is TreeNode tn)
                {
                    Console.WriteLine($"Imported node: {tn.NodeAlias}");
                }
                else
                {
                    Console.WriteLine($"Imported: {info[info.TypeInfo.CodeNameColumn]}");
                }
            };

            // listen for exception occurence
            importObserver.Exception += (model, uniqueId, exception) =>
            {
                Console.WriteLine($"Error: '{uniqueId}': {exception}");
            };

            // sample data
            var sourceData = new UmtModel[]
            {
                // TODO: use your data
                UserSamples.FreddyAdministrator, DataClassSamples.ArticleClassSample, DataClassSamples.EventDataClass, TreeNodeSamples.YearlyEvent, TreeNodeSamples.SingleOccurenceEvent,
            };

            // fill context
            var context = new ImporterContext(
                // TODO: change site name
                "Boilerplate",
                // TODO: change culture if needed
                "en-US"
            );

            // initiate import
            var observer = importService.StartImport(sourceData, context, importObserver);

            // wait until import finishes
            await observer.ImportCompletedTask;

            imported.Should().SatisfyRespectively(
                user =>
                {
                },
                articleClass =>
                {
                },
                eventClass =>
                {
                },
                eventInstance =>
                {
                },
                eventInstance =>
                {
                }
            );

#pragma warning restore S1135
        }
    }
}
