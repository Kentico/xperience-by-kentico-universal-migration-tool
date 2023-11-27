using System.Collections.Immutable;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.Services;

namespace Kentico.Xperience.UMT.Examples;

public record SampleInfo(string Header, string Description, Lazy<object?> Sample);

public record SerializedSampleInfo(string Header, string Description, string Sample);

public static class SampleProvider
{
    public static ImmutableDictionary<string, SampleInfo> Samples { get; } = typeof(SampleProvider).Assembly.DefinedTypes.Aggregate(new Dictionary<string, SampleInfo>(), (acc, info) =>
    {
        foreach (var propertyInfo in info.GetProperties(BindingFlags.Static | BindingFlags.Public))
        {
            if (propertyInfo.GetCustomAttribute<SampleAttribute>() is { } attribute && !string.IsNullOrWhiteSpace(attribute.SampleName))
            {
                var lazy = new Lazy<object?>(() => propertyInfo.GetMethod?.Invoke(null, Array.Empty<object>()));

                acc.Add(attribute.SampleName, new SampleInfo(attribute.Header, attribute.Description, lazy));
            }
        }

        return acc;
    }).ToImmutableDictionary();

    public static SerializedSampleInfo? GetSerializedSample(string sampleName, IImportService importService) =>
        Samples.TryGetValue(sampleName, out var sample) && sample.Sample.Value is UmtModel model
            ? new SerializedSampleInfo(sample.Header, sample.Description, importService.SerializeToJson(model, new JsonSerializerOptions
            {
                WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            }))
            : null;

    public static List<IUmtModel> GetFullSample()
    {
        var sourceData = new List<IUmtModel>
        {
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
        return sourceData;
    }
}
