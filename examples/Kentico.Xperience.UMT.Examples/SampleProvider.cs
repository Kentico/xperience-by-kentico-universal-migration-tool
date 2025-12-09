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
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            }))
            : null;

    public static List<IUmtModel> GetFullSample()
    {
        var sourceData = new List<IUmtModel>();

        // taxonomy samples
        sourceData.AddRange([
            TaxonomySamples.SampleTaxonomyCoffee,
            TaxonomySamples.SampleTagCoffeaCanephora,
            TaxonomySamples.SampleTagCoffeaNganda,
            TaxonomySamples.SampleTagCoffeaRobusta,
            TaxonomySamples.SampleTagCoffeaArabica,
        ]);

        // sample data
        sourceData.AddRange([
            UserSamples.SampleAdministrator,

            MemberSamples.SampleMemberNoCustomFields,
            //MemberSamples.SampleMemberWithCustomFields, // Intentionally not included, because the included custom fields are not by default present in boilerplate project

            ContentLanguageSamples.SampleContentLanguageEnUs,
            ContentLanguageSamples.SampleContentLanguageEnGb,
            ContentLanguageSamples.SampleContentLanguageEs,

            ChannelSamples.SampleChannelForEmailChannel,
            ChannelSamples.SampleChannelForWebSiteChannel,
            EmailChannelSamples.SampleEmailChannel,
            WebSiteChannelSamples.SampleWebSiteChannel,

            DataClassSamples.ArticleClassSample,
            DataClassSamples.ArticleAssignedToWebSiteChannel,
            DataClassSamples.ArticleAllowedAsChildOfArticle,
            DataClassSamples.FaqDataClass,
            DataClassSamples.EventDataClass,

            ContentItemSamples.SampleContentItem,
            ContentItemLanguageMetadataSamples.SampleContentItemLanguageMetadataBasic,
            ContentItemLanguageMetadataSamples.SampleContentItemLanguageMetadata,

            WebPageContentItemSamples.SampleWebPageItem,

            AssetSamples.SampleMediaLibrary,
            AssetSamples.SampleMediaFile,
            AssetSamples.SampleMediaFileFromUri
        ]);

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
            ContentItemSamples.SampleArticleWebPathUrlPathModelEnUs,
            ContentItemSamples.SampleArticleVanityUrl1PathModelEnUs,
            ContentItemSamples.SampleArticleVanityUrl2PathModelEnUs,
            ContentItemSamples.SampleArticleWebPathUrlPathModelEnGb,
            ContentItemSamples.SampleArticleWebPathUrlPathModelEs,

            ContentItemSamples.SampleArticleWebPageItem,
            ContentItemSamples.SampleArticleWebPageAcl,

            ContentItemSamples.SampleArticleWebPathFormerUrlPathEnUs,
            ContentItemSamples.SampleArticleWebPathFormerUrlPathEnGb
        });

        sourceData.AddRange(new IUmtModel[]
        {
            ContentItemSamples.SampleArticleContentItemWithRelations, ContentItemSamples.SampleArticleContentItemCommonDataEnUsWithRelations, ContentItemSamples.SampleArticleContentItemCommonDataEnGbWithRelations, ContentItemSamples.SampleArticleDataEnUsWithRelations,
            ContentItemSamples.SampleArticleDataEnUsWithRelationsReference,
            ContentItemSamples.SampleArticleDataEnGbWithRelations,
            ContentItemSamples.SampleArticleDataEnGbWithRelationsReference,
            ContentItemSamples.SampleArticleContentItemLanguageMetadataEnUsWithRelations, ContentItemSamples.SampleArticleContentItemLanguageMetadataEnGbWithRelations,
            ContentItemSamples.SampleArticleWebPageItemWithRelations,
            ContentItemSamples.SampleArticleWebPageUrlWithRelationsEnUs,
            ContentItemSamples.SampleArticleWebPageUrlWithRelations,
            ContentItemSamples.SampleArticleWebPageUrlWithRelationsEs
        });

        // folder samples
        sourceData.AddRange([
            ContentFolderSamples.SampleContentFolder,
            ContentFolderSamples.SampleContentSubFolder,
        ]);

        sourceData.Add(ContentItemSimplifiedSamples.SampleArticleContentItemSimplifiedModel);
        sourceData.Add(ContentItemSimplifiedSamples.SampleArticleSubPageContentItemSimplifiedModel);
        sourceData.Add(ContentItemSimplifiedSamples.SampleArticleSubPage2ContentItemSimplifiedModel_Draft);
        sourceData.Add(ContentItemSimplifiedSamples.SampleArticleSubPage3ContentItemSimplifiedModel_Draft);
        sourceData.Add(ContentItemSimplifiedSamples.SampleArticleSubPage4ContentItemSimplifiedModel_Scheduled);
        sourceData.Add(ContentItemSimplifiedSamples.SampleArticleSubPage5ContentItemSimplifiedModel_Scheduled);
        sourceData.Add(ContentItemSimplifiedSamples.SampleArticleSubPage6ContentItemSimplifiedModel_InitialDraft);
        sourceData.Add(ContentItemSimplifiedSamples.SampleArticleSubPage7ContentItemSimplifiedModel_Scheduled);
        sourceData.Add(ContentItemSimplifiedSamples.SampleArticleSubPage8ContentItemSimplifiedModel_Published);
        sourceData.Add(ContentItemSimplifiedSamples.SampleFaqContentItemSimplifiedModel); // references sample content subfolder
        sourceData.Add(ContentItemSimplifiedSamples.SampleEventContentItemWithAsset);

        sourceData.Add(WorkspaceSamples.SampleWorkspace);
        sourceData.Add(ContentItemSimplifiedSamples.EventInSampleWorkspace);

        sourceData.Add(ContentItemSimplifiedSamples.SampleFaqContentItemSimplifiedLinkedByArticle);
        sourceData.Add(ContentItemSimplifiedSamples.SampleArticleContentItemSimplifiedModelWithLinkedItems);

        sourceData.Add(VisualBuilderSamples.PageWithWidgetsContentType);
        sourceData.Add(VisualBuilderSamples.SimplifiedModel);

        // webpage scope samples
        sourceData.AddRange([
            WebPageScopeSamples.SampleEmptyWebPageScope,
            WebPageScopeSamples.SamplePopulatedWebPageScope,
            WebPageScopeSamples.SampleWebPageScopeContentType,
        ]);

        // ecommerce samples
        sourceData.AddRange([
            CustomerSamples.SampleCustomerBasic,
            CustomerSamples.SampleCustomerWithMember,
            CustomerAddressSamples.SampleCustomerAddress,
            OrderStatusSamples.SampleOrderStatusNew,
            OrderStatusSamples.SampleOrderStatusCompleted,
            OrderStatusNotificationSamples.SampleOrderStatusNotificationNew,
            OrderStatusNotificationSamples.SampleOrderStatusNotificationCompleted,
            OrderSamples.SampleOrder,
            OrderItemSamples.SampleOrderItem,
            OrderItemSamples.SampleOrderItemSecond,
            OrderAddressSamples.SampleOrderAddressBilling,
            OrderAddressSamples.SampleOrderAddressShipping,
        ]);

        return sourceData;
    }
}
