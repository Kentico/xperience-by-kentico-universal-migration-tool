#pragma warning disable S1135 // this is sample, todos are here for end user
// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
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
string workDir = Directory.GetCurrentDirectory();
// note - this is currently required for asset import when UMT is used in other place then Kentico Xperience itself 
Directory.SetCurrentDirectory(root.GetValue<string>("WebApplicationPhysicalPath") ?? throw new InvalidOperationException("WebApplicationPhysicalPath must be set to valid directory path"));

CMSApplication.Init();

var services = new ServiceCollection();
services.AddLogging(b => b.AddDebug().AddSimpleConsole(options => options.SingleLine = true).AddConfiguration(root.GetSection("Logging")));
services.AddUniversalMigrationToolkit();

var serviceProvider = services.BuildServiceProvider();
var importService = serviceProvider.GetRequiredService<IImportService>();

// sample data
List<IUmtModel> sourceData = null!;

bool useSerializedSample = true;
#pragma warning disable S2583 // this is sample, sample user have to change value on demand
if (useSerializedSample)
#pragma warning restore S2583
{
    string path = Path.GetFullPath(Path.Combine(workDir, "../../../../../docs/Samples/basic.json"));
    string sampleText = (await File.ReadAllTextAsync(path) ?? throw new InvalidOperationException("Failed to load sample"))
        .Replace("##ASSETDIR##", workDir.Replace(@"\", @"\\"));
        
    sourceData = importService.FromJsonString(sampleText)?.ToList() ?? new List<IUmtModel>();
}
else
{
    sourceData = SampleProvider.GetFullSample();
    
    foreach (var umtModel in sourceData)
    {
        // update path to media files
        if (umtModel is MediaFileModel mediaFileModel)
        {
            mediaFileModel.DataSourcePath = mediaFileModel.DataSourcePath?.Replace("##ASSETDIR##", workDir);
        }

        foreach ((string? key, object? value) in umtModel.CustomProperties)
        {
            switch (value)
            {
                case AssetFileSource assetSource:
                {
                    assetSource.FilePath = assetSource.FilePath?.Replace("##ASSETDIR##", workDir);
                    umtModel.CustomProperties[key] = assetSource;
                    break;
                }
            }
        }

        if (umtModel is ContentItemSimplifiedModel contentItemSimplifiedModel)
        {
            Debug.Assert(contentItemSimplifiedModel.LanguageData != null, "contentItemSimplifiedModel.LanguageData != null");
#pragma warning disable S3267
            foreach (var contentItemLanguageData in contentItemSimplifiedModel.LanguageData)
#pragma warning restore S3267
            {
                Debug.Assert(contentItemLanguageData.ContentItemData != null, "contentItemLanguageData.ContentItemData != null");
                foreach ((string? _, object? value) in contentItemLanguageData.ContentItemData)
                {
                    switch (value)
                    {
                        case AssetFileSource assetSource:
                        {
                            assetSource.FilePath = assetSource.FilePath?.Replace("##ASSETDIR##", workDir);
                            break;
                        }
                    }
                }
            }
        }
    }
}

bool variantWithObserver = true;
#pragma warning disable S2583 // this is sample, sample user have to change value on demand 
if (variantWithObserver)
#pragma warning restore S2583
{
    // simplified usage for streamlined import
    
    // create observer to track import state
    var importObserver = new ImportStateObserver();

    // listen to validation errors
    importObserver.ValidationError += (model, uniqueId, errors) =>
    {
        Console.WriteLine($"Validation error in model '{model.PrintMe()}': {JsonSerializer.Serialize(errors)}");
    };

    // listen to successfully adapted and persisted objects
    importObserver.ImportedInfo += (model, info) =>
    {
        Console.WriteLine($"{model.PrintMe()} imported");
    };

    // listen for exception occurence
    importObserver.Exception += (model, uniqueId, exception) =>
    {
        Console.WriteLine($"Error in model {model.PrintMe()}: '{uniqueId}': {exception}");
    };

    // initiate import
    var observer = importService.StartImport(sourceData, importObserver);

    // wait until import finishes
    await observer.ImportCompletedTask;
}
else
{
    // sample with more control over process
    var importer = serviceProvider.GetRequiredService<IImporter>();
    foreach (var umtModel in sourceData)
    {
        var result = await importer.ImportAsync(umtModel);
        switch (result)
        {
            // OK
            case { Success: true, Imported: {} }:
            {
                Console.WriteLine($"{umtModel.PrintMe()} imported");
                break;
            }
            // some exception was thrown when importing
            case { Success: false, Exception: { } exception }:
            {
                Console.WriteLine($"Error in model {umtModel.PrintMe()}: {exception}");
                break;
            }
            // validation error were found on input model
            case { Success: false, ModelValidationResults: { } validationResults }:
            {
                Console.WriteLine($"Validation error in model '{umtModel.PrintMe()}': {JsonSerializer.Serialize(validationResults)}");
                break;
            }
            default:
            {
                Console.WriteLine($"UNEXPECTED CASE occured on model: {umtModel.PrintMe()}");
                break;
            }
        }
    }
}

Console.WriteLine("Finished!");

#pragma warning restore S1135
