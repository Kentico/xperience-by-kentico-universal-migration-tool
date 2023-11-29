#pragma warning disable S1135 // this is sample, todos are here for end user
// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using CMS.Core;
using CMS.DataEngine;
using Kentico.Xperience.UMT;
using Kentico.Xperience.UMT.Examples;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var root = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false)
    .AddJsonFile("appsettings.local.json", true)
    .Build();

Service.Use<IConfiguration>(root);
CMS.Base.SystemContext.WebApplicationPhysicalPath = root.GetValue<string>("WebApplicationPhysicalPath");

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
    Console.WriteLine($"{info[info.TypeInfo.DisplayNameColumn] ?? info[info.TypeInfo.GUIDColumn]} imported");
};

// listen for exception occurence
importObserver.Exception += (model, uniqueId, exception) =>
{
    Console.WriteLine($"Error: '{uniqueId}': {exception}");
};

// sample data
var sourceData = new List<IUmtModel>
{
    // TODO: use your data
    UserSamples.SampleAdministrator,
    ContentLanguageSamples.SampleContentLanguageEnUs,
    ContentLanguageSamples.SampleContentLanguageEnGb,

    ChannelSamples.SampleChannelForEmailChannel,
    ChannelSamples.SampleChannelForWebSiteChannel,
    EmailChannelSamples.SampleEmailChannel,
    WebSiteChannelSamples.SampleWebSiteChannel,
    
    DataClassSamples.ArticleClassSample,
    DataClassSamples.FaqDataClass,
    
    ContentItemSamples.SampleContentItem,
    ContentItemLanguageMetadataSamples.SampleContentItemLanguageMetadata,
    ContentItemLanguageMetadataSamples.SampleContentItemLanguageMetadataBasic,
    
    WebPageContentItemSamples.SampleWebPageItem,

    AssetSamples.SampleMediaLibrary,
    AssetSamples.SampleMediaFile
};

// sample website content item
sourceData.AddRange(new IUmtModel[]
{
    ContentItemSamples.SampleArticleContentItem,
    
    ContentItemSamples.SampleArticleContentItemCommonDataEnUs,
    ContentItemSamples.SampleArticleContentItemCommonDataEnGb,
    
    ContentItemSamples.SampleArticleDataEnUs,
    ContentItemSamples.SampleArticleDataEnGb,
    
    ContentItemSamples.SampleArticleContentItemLanguageMetadataEnUs,
    ContentItemSamples.SampleArticleContentItemLanguageMetadataEnGb,
    
    ContentItemSamples.SampleArticleWebPageItem,
});

// sample reusable content item
sourceData.AddRange(new IUmtModel[]
{
    ContentItemSamples.SampleFaqContentItem,
    
    ContentItemSamples.SampleFaqContentItemCommonDataEnUs,
    ContentItemSamples.SampleFaqContentItemCommonDataEnGb,
    
    ContentItemSamples.SampleFaqDataEnUs,
    ContentItemSamples.SampleFaqDataEnGb,
    
    ContentItemSamples.SampleFaqContentItemLanguageMetadataEnUs,
    ContentItemSamples.SampleFaqContentItemLanguageMetadataEnGb,
});

// initiate import
var observer = importService.StartImport(sourceData, importObserver);

// wait until import finishes
await observer.ImportCompletedTask;

Console.WriteLine("Finished!");

#pragma warning restore S1135
