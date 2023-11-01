#pragma warning disable S1135 // this is sample, todos are here for end user
// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using Azure.Identity;
using CMS.Core;
using CMS.DataEngine;
// using CMS.DocumentEngine; => obsolete
using Kentico.Xperience.UMT;
using Kentico.Xperience.UMT.Examples;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var root = new ConfigurationRoot(new List<IConfigurationProvider>(new[] { new MemoryConfigurationProvider(new MemoryConfigurationSource()) }));

root[ConfigurationPath.Combine("ConnectionStrings", "CMSConnectionString")]
    // TODO: change connection string to target XbyK instance
    = "Data Source=localhost;Initial Catalog=FixingKbank;Integrated Security=True;Persist Security Info=False;Connect Timeout=60;Encrypt=False;Current Language=English;";

Service.Use<IConfiguration>(root);
CMSApplication.Init();

var services = new ServiceCollection();
services.AddLogging(b => b.AddDebug());
services.AddUniversalMigrationToolkit();

var serviceProvider = services.BuildServiceProvider();
var importService = serviceProvider.GetRequiredService<IImportService>();

// create observer to track import state
var importObserver = new ImportStateObserver();

// listen to validation errors
importObserver.ValidationError += (model, uniqueId, errors) =>
{
    Console.WriteLine($"Validation error '{uniqueId}': {JsonSerializer.Serialize(errors)}");
};

// listen to successfully adapted and persisted objects
importObserver.ImportedInfo += info =>
{
    // TODO tomas.krch: 2023-10-30 TreeNode obsolete... refactor
    // if (info is TreeNode tn)
    // {
    //     Console.WriteLine($"Imported node: {tn.NodeAlias}");
    // }
    // else
    // {
    //     Console.WriteLine($"Imported: {info[info.TypeInfo.CodeNameColumn]}");    
    // }
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
    UserSamples.SampleAdministrator,
    WebSiteChannelSamples.SampleWebSiteChannel,
    EmailChannelSamples.SampleEmailChannel
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

#pragma warning restore S1135
