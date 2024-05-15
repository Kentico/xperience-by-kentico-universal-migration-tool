using CMS.ContentEngine;
using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class ContentItemSamples
{
    public static readonly Guid CONTENT_ITEM_GUID = new Guid("C354427D-3D02-4876-8ED4-4DE817FAE929");
    public static readonly Guid CONTENT_ITEM_FAQ_SAMPLE_GUID = new Guid("B28A0F09-9102-4E48-B6FE-3C405FEEAFB5");

    [Sample("contentitem.sample", "This sample describes how to create class inside XbyK to hold Content Item data", "ContentItem basic Sample")]
    public static ContentItemModel SampleContentItem => new()
    {
        ContentItemGUID = CONTENT_ITEM_GUID,
        ContentItemChannelGuid = new Guid("B186B5A3-F408-4E21-A2F9-E51D68ECAC38"),
        ContentItemDataClassGuid = new Guid("978B2CD4-C248-4317-86A1-3BDD17444267"),
        ContentItemIsSecured = true,
        ContentItemIsReusable = true,
        ContentItemName = "NewsLetterExampleName",
    };


    #region "Sample article content item"

    public static readonly Guid SampleArticleContentItemGuid = new Guid("DF81215E-1414-4D87-BEFD-AE123F4E5653");
    public static readonly Guid SampleArticleCommonDataGuidEnUs = new Guid("8F070195-2F39-463E-B7EB-C180C05FD5E0");
    public static readonly Guid SampleArticleCommonDataGuidEnGb = new Guid("49D2CAF6-2011-42D7-961D-02614D1B43F4");

    [Sample("ContentItemModel.Sample.Article", "This sample describes how to create content item data inside XbyK", "ContentItem basic Sample")]
    public static ContentItemModel SampleArticleContentItem => new()
    {
        ContentItemGUID = SampleArticleContentItemGuid,
        ContentItemChannelGuid = ChannelSamples.WEBSITE_CHANNEL_SAMPLE_GUID,
        ContentItemDataClassGuid = DataClassSamples.ARTICLE_SAMPLE_GUID,
        // ContentItemIsSecured = true,
        ContentItemIsReusable = false,
        ContentItemName = "CreationOfUmtModel"
    };

    #region "EnUs version"

    [Sample("ContentItemCommonDataModel.Sample.Article.enUS", "This sample describes how to create content item common data inside XbyK", "ContentItemCommonData basic Sample")]
    public static ContentItemCommonDataModel SampleArticleContentItemCommonDataEnUs => new()
    {
        ContentItemCommonDataGUID = SampleArticleCommonDataGuidEnUs,
        ContentItemCommonDataContentItemGuid = SampleArticleContentItemGuid,
        ContentItemCommonDataContentLanguageGuid = ContentLanguageSamples.CONTENT_LANGUAGE_ENUS_SAMPLE_GUID,
        ContentItemCommonDataVersionStatus = VersionStatus.Published,
        ContentItemCommonDataIsLatest = true,
        ContentItemCommonDataPageBuilderWidgets = null,
        ContentItemCommonDataPageTemplateConfiguration = null
    };

    [Sample("ContentItemDataModel.Sample.Article.enUS", "This sample describes how to create content item data inside XbyK", "ContentItemData article sample (en-US)")]
    public static ContentItemDataModel SampleArticleDataEnUs => new()
    {
        ContentItemDataGUID = new Guid("9A5B10E0-D0E6-4DE9-9D82-6D8DEEEA1849"),
        ContentItemDataCommonDataGuid = SampleArticleCommonDataGuidEnUs,
        ContentItemContentTypeName = DataClassSamples.ARTICLE_SAMPLE_CLASS_NAME,
        CustomProperties = new Dictionary<string, object?>
        {
            ["ArticleTitle"] = "en-US UMT model creation", 
            ["ArticleText"] = "This article is only example of creation UMT model for en-US language",
            ["RelatedArticles"] = null,
            ["RelatedFaq"] = null,
            ["CoffeaTaxonomy"] = System.Text.Json.JsonSerializer.Serialize(new List<object>
            {
                new {Identifier = TaxonomySamples.SampleTagCoffeaArabicaGuid},
            })
        }
    };


    [Sample("contentitemlanguagemetadata.sample.article.enus", "This sample describes how to create class inside XbyK to hold Content Item Language Metadata", "ContentItemLanguageMetadata Sample")]
    public static ContentItemLanguageMetadataModel SampleArticleContentItemLanguageMetadataEnUs => new()
    {
        ContentItemLanguageMetadataGUID = new Guid("192C63AC-E5BE-4B0F-B916-B8AF6C7E79A9"),
        ContentItemLanguageMetadataContentItemGuid = SampleArticleContentItemGuid,
        ContentItemLanguageMetadataContentLanguageGuid = ContentLanguageSamples.CONTENT_LANGUAGE_ENUS_SAMPLE_GUID,
        ContentItemLanguageMetadataDisplayName = "Creation of UMT model",
        ContentItemLanguageMetadataCreatedWhen = new DateTime(2023, 12, 10, 0,0,0,0, DateTimeKind.Utc),
        ContentItemLanguageMetadataHasImageAsset = false,
        ContentItemLanguageMetadataCreatedByUserGuid = UserSamples.SampleAdminGuid,
        ContentItemLanguageMetadataModifiedByUserGuid = UserSamples.SampleAdminGuid,
        ContentItemLanguageMetadataLatestVersionStatus = VersionStatus.Published,
    };

    [Sample("webpageitem.urlpath.sample.article.enus", "", "Page url path sample")]
    public static WebPageUrlPathModel SampleArticleWebPathUrlPathModelEnUs => new()
    {
        WebPageUrlPathGUID = new Guid("2BDA2458-E262-4825-B51B-5A7B345ED7BD"),
        WebPageUrlPath = "en-US/creation-of-umt-model",
        WebPageUrlPathHash = null,
        WebPageUrlPathWebPageItemGuid = SampleArticleWebPageItem.WebPageItemGUID,
        WebPageUrlPathWebsiteChannelGuid = WebSiteChannelSamples.WebsiteChannelGuid,
        WebPageUrlPathContentLanguageGuid = ContentLanguageSamples.CONTENT_LANGUAGE_ENUS_SAMPLE_GUID,
        WebPageUrlPathIsLatest = true,
        WebPageUrlPathIsDraft = false
    };
    
    #endregion

    #region "EnGb version"

    [Sample("ContentItemCommonDataModel.Sample.Article.enGB", "This sample describes how to create content item common data inside XbyK", "ContentItemCommonData basic Sample")]
    public static ContentItemCommonDataModel SampleArticleContentItemCommonDataEnGb => new()
    {
        ContentItemCommonDataGUID = SampleArticleCommonDataGuidEnGb,
        ContentItemCommonDataContentItemGuid = SampleArticleContentItemGuid,
        ContentItemCommonDataContentLanguageGuid = ContentLanguageSamples.CONTENT_LANGUAGE_ENGB_SAMPLE_GUID,
        ContentItemCommonDataVersionStatus = VersionStatus.Published,
        ContentItemCommonDataIsLatest = true,
        ContentItemCommonDataPageBuilderWidgets = null,
        ContentItemCommonDataPageTemplateConfiguration = null
    };

    [Sample("ContentItemDataModel.Sample.Article.enGB", "This sample describes how to create content item data inside XbyK", "ContentItemData article sample (en-GB)")]
    public static ContentItemDataModel SampleArticleDataEnGb => new()
    {
        ContentItemDataGUID = new Guid("21380F91-279B-44BE-AAD8-2E62C345A0E9"),
        ContentItemDataCommonDataGuid = SampleArticleCommonDataGuidEnGb,
        ContentItemContentTypeName = DataClassSamples.ARTICLE_SAMPLE_CLASS_NAME,
        CustomProperties = new Dictionary<string, object?>
        {
            ["ArticleTitle"] = "en-GB UMT model creation", 
            ["ArticleText"] = "This article is only example of creation UMT model for en-GB language",
            ["RelatedArticles"] = null,
            ["RelatedFaq"] = null,
            ["CoffeaTaxonomy"] = System.Text.Json.JsonSerializer.Serialize(new List<object>
            {
                new {Identifier = TaxonomySamples.SampleTagCoffeaArabicaGuid},
            })
        }
    };

    [Sample("contentitemlanguagemetadata.sample.article.engb", "This sample describes how to create class inside XbyK to hold Content Item Language Metadata", "ContentItemLanguageMetadata Sample")]
    public static ContentItemLanguageMetadataModel SampleArticleContentItemLanguageMetadataEnGb => new()
    {
        ContentItemLanguageMetadataGUID = new Guid("7F6A0C0D-A2BB-454C-8E16-ADCFE0E38D17"),
        ContentItemLanguageMetadataContentItemGuid = SampleArticleContentItemGuid,
        ContentItemLanguageMetadataContentLanguageGuid = ContentLanguageSamples.CONTENT_LANGUAGE_ENGB_SAMPLE_GUID,
        ContentItemLanguageMetadataDisplayName = "Creation of UMT model GB",
        ContentItemLanguageMetadataCreatedWhen = new DateTime(2023, 12, 10, 0,0,0,0, DateTimeKind.Utc),
        ContentItemLanguageMetadataHasImageAsset = false,
        ContentItemLanguageMetadataCreatedByUserGuid = UserSamples.SampleAdminGuid,
        ContentItemLanguageMetadataModifiedByUserGuid = UserSamples.SampleAdminGuid,
        ContentItemLanguageMetadataLatestVersionStatus = VersionStatus.Published,
    };
    
    [Sample("webpageitem.urlpath.sample.article.engb", "", "Page url path sample")]
    public static WebPageUrlPathModel SampleArticleWebPathUrlPathModelEnGb => new()
    {
        WebPageUrlPathGUID = new Guid("8083FA41-03FE-49C3-87FB-4F7C530B14CF"),
        WebPageUrlPath = "en-GB/creation-of-umt-model",
        WebPageUrlPathHash = null,
        WebPageUrlPathWebPageItemGuid = SampleArticleWebPageItem.WebPageItemGUID,
        WebPageUrlPathWebsiteChannelGuid = WebSiteChannelSamples.WebsiteChannelGuid,
        WebPageUrlPathContentLanguageGuid = ContentLanguageSamples.CONTENT_LANGUAGE_ENGB_SAMPLE_GUID,
        WebPageUrlPathIsLatest = true,
        WebPageUrlPathIsDraft = false
    };

    #endregion

    [Sample("webpageitem.sample.article", "This sample describes how to create class inside XbyK to hold WebPage Item data", "ContentItem Sample")]
    public static WebPageItemModel SampleArticleWebPageItem => new()
    {
        WebPageItemGUID = new Guid("6E995319-77E7-475E-9EBB-607BDBF5AF9A"),
        WebPageItemContentItemGuid = SampleArticleContentItemGuid,
        WebPageItemName = "CreationOfUmtModelUs",
        WebPageItemOrder = 1,
        WebPageItemTreePath = "/creation-of-umt-model",
        WebPageItemWebsiteChannelGuid = WebSiteChannelSamples.WebsiteChannelGuid
    };
    
    

    #endregion
    
    #region "Sample article content item with relations to FAQ and first item"

    public static readonly Guid SampleArticleContentItemGuidWithRelations = new Guid("E09121AD-DD97-472F-B8F6-85FE5428ED6A");
    public static readonly Guid SampleArticleCommonDataGuidEnUsWithRelations = new Guid("56F0E676-8FCC-4A5D-8B69-F6ECA372B998");
    public static readonly Guid SampleArticleCommonDataGuidEnGbWithRelations = new Guid("A790B2D4-5AC1-4FB0-812C-2AD2171C61C9");

    [Sample("ContentItemModel.Sample.Article.WithRelations", "This sample describes how to create content item with relations to other content items", "ContentItem with relations sample")]
    public static ContentItemModel SampleArticleContentItemWithRelations => new()
    {
        ContentItemGUID = SampleArticleContentItemGuidWithRelations,
        ContentItemChannelGuid = ChannelSamples.WEBSITE_CHANNEL_SAMPLE_GUID,
        ContentItemDataClassGuid = DataClassSamples.ARTICLE_SAMPLE_GUID,
        ContentItemIsSecured = true,
        ContentItemIsReusable = false,
        ContentItemName = "Content-item-with-relations"
    };

    #region "EnUs version"

    [Sample("ContentItemCommonDataModel.Sample.Article.enUS.WithRelations", "This sample describes how to create content item common data inside XbyK", "ContentItemCommonData basic Sample")]
    public static ContentItemCommonDataModel SampleArticleContentItemCommonDataEnUsWithRelations => new()
    {
        ContentItemCommonDataGUID = SampleArticleCommonDataGuidEnUsWithRelations,
        ContentItemCommonDataContentItemGuid = SampleArticleContentItemGuidWithRelations,
        ContentItemCommonDataContentLanguageGuid = ContentLanguageSamples.CONTENT_LANGUAGE_ENUS_SAMPLE_GUID,
        ContentItemCommonDataVersionStatus = VersionStatus.InitialDraft,
        ContentItemCommonDataIsLatest = true,
        ContentItemCommonDataPageBuilderWidgets = null,
        ContentItemCommonDataPageTemplateConfiguration = null
    };

    [Sample("ContentItemDataModel.Sample.Article.enUS.WithRelations", "This sample describes how to create content item data inside XbyK", "ContentItemData article sample (en-US)")]
    public static ContentItemDataModel SampleArticleDataEnUsWithRelations => new()
    {
        ContentItemDataGUID = new Guid("B6847866-12B1-4A4A-ABA7-D93860102BC8"),
        ContentItemDataCommonDataGuid = SampleArticleCommonDataGuidEnUsWithRelations,
        ContentItemContentTypeName = DataClassSamples.ARTICLE_SAMPLE_CLASS_NAME,
        CustomProperties = new Dictionary<string, object?>
        {
            ["ArticleTitle"] = "en-US UMT model creation", 
            ["ArticleText"] = "This article is only example of creation UMT model for en-US language",
            ["RelatedArticles"] = $$"""[{"WebPageGuid":"{{SampleArticleWebPageItem.WebPageItemGUID}}"}]""",
            ["RelatedFaq"] = $$"""
                             [{"Identifier":"{{SampleFaqContentItemGuid}}"}]
                             """
        }
    };

    [Sample("ContentItemReferenceModel.Sample.Article.enUS.WithRelations", "Sample of relation between 2 content items inside XbyK", "ContentItemReference article sample (en-US)")]
    public static ContentItemReferenceModel SampleArticleDataEnUsWithRelationsReference => new()
    {
        ContentItemReferenceGUID = new Guid("186E37C6-5C55-4637-8FEB-EC5CB6547ABA"),
        ContentItemReferenceSourceCommonDataGuid = SampleArticleContentItemCommonDataEnUs.ContentItemCommonDataGUID,
        ContentItemReferenceTargetItemGuid = SampleFaqContentItemGuid,
        ContentItemReferenceGroupGUID = DataClassSamples.RelatedFaqFieldGuid
    };


    [Sample("contentitemlanguagemetadata.sample.article.enus.WithRelations", "This sample describes how to create class inside XbyK to hold Content Item Language Metadata", "ContentItemLanguageMetadata Sample")]
    public static ContentItemLanguageMetadataModel SampleArticleContentItemLanguageMetadataEnUsWithRelations => new()
    {
        ContentItemLanguageMetadataGUID = new Guid("9EC48558-4E26-4DDF-9804-FA0FBE95142D"),
        ContentItemLanguageMetadataContentItemGuid = SampleArticleContentItemGuidWithRelations,
        ContentItemLanguageMetadataContentLanguageGuid = ContentLanguageSamples.CONTENT_LANGUAGE_ENUS_SAMPLE_GUID,
        ContentItemLanguageMetadataDisplayName = "Content item with relations",
        ContentItemLanguageMetadataCreatedWhen = new DateTime(2023, 12, 10, 0,0,0,0, DateTimeKind.Utc),
        ContentItemLanguageMetadataHasImageAsset = false,
        ContentItemLanguageMetadataCreatedByUserGuid = UserSamples.SampleAdminGuid,
        ContentItemLanguageMetadataModifiedByUserGuid = UserSamples.SampleAdminGuid,
        ContentItemLanguageMetadataLatestVersionStatus = VersionStatus.InitialDraft,
    };
    
    [Sample("webpageitem.urlpath.sample.article.WithRelations.enus", "", "Page url path sample")]
    public static WebPageUrlPathModel SampleArticleWebPageUrlWithRelationsEnUs => new()
    {
        WebPageUrlPathGUID = new Guid("C0F97BA5-7A64-4309-8D58-6054FC90AC66"),
        WebPageUrlPath = "en-US/content-item-with-relations",
        WebPageUrlPathHash = null,
        WebPageUrlPathWebPageItemGuid = SampleArticleWebPageItemWithRelations.WebPageItemGUID,
        WebPageUrlPathWebsiteChannelGuid = WebSiteChannelSamples.WebsiteChannelGuid,
        WebPageUrlPathContentLanguageGuid = ContentLanguageSamples.CONTENT_LANGUAGE_ENUS_SAMPLE_GUID,
        WebPageUrlPathIsLatest = true,
        WebPageUrlPathIsDraft = false
    };

    #endregion

    #region "EnGb version"

    [Sample("ContentItemCommonDataModel.Sample.Article.enGB.WithRelations", "This sample describes how to create content item common data inside XbyK", "ContentItemCommonData basic Sample")]
    public static ContentItemCommonDataModel SampleArticleContentItemCommonDataEnGbWithRelations => new()
    {
        ContentItemCommonDataGUID = SampleArticleCommonDataGuidEnGbWithRelations,
        ContentItemCommonDataContentItemGuid = SampleArticleContentItemGuidWithRelations,
        ContentItemCommonDataContentLanguageGuid = ContentLanguageSamples.CONTENT_LANGUAGE_ENGB_SAMPLE_GUID,
        ContentItemCommonDataVersionStatus = VersionStatus.Published,
        ContentItemCommonDataIsLatest = true,
        ContentItemCommonDataPageBuilderWidgets = null,
        ContentItemCommonDataPageTemplateConfiguration = null
    };

    [Sample("ContentItemDataModel.Sample.Article.enGB.WithRelations", "This sample describes how to create content item data inside XbyK", "ContentItemData article sample (en-GB)")]
    public static ContentItemDataModel SampleArticleDataEnGbWithRelations => new()
    {
        ContentItemDataGUID = new Guid("A80F91FF-4CFC-4E28-982A-E4A434517680"),
        ContentItemDataCommonDataGuid = SampleArticleCommonDataGuidEnGbWithRelations,
        ContentItemContentTypeName = DataClassSamples.ARTICLE_SAMPLE_CLASS_NAME,
        CustomProperties = new Dictionary<string, object?>
        {
            ["ArticleTitle"] = "en-GB UMT model creation", 
            ["ArticleText"] = "This article is only example of creation UMT model for en-GB language",
            ["RelatedArticles"] = $$"""[{"WebPageGuid":"{{SampleArticleWebPageItem.WebPageItemGUID}}"}]""",
            ["RelatedFaq"] = $$"""
                               [{"Identifier":"{{SampleFaqContentItemGuid}}"}]
                               """
        }
    };
    
    [Sample("ContentItemReferenceModel.Sample.Article.enGB.WithRelations", "Sample of relation between 2 content items inside XbyK", "ContentItemReference article sample (en-GB)")]
    public static ContentItemReferenceModel SampleArticleDataEnGbWithRelationsReference => new()
    {
        ContentItemReferenceGUID = new Guid("E95EEFE5-5B89-43AB-91C9-777BE00D5680"),
        ContentItemReferenceSourceCommonDataGuid = SampleArticleContentItemCommonDataEnGb.ContentItemCommonDataGUID,
        ContentItemReferenceTargetItemGuid = SampleFaqContentItemGuid,
        ContentItemReferenceGroupGUID = DataClassSamples.RelatedFaqFieldGuid
    };

    [Sample("contentitemlanguagemetadata.sample.article.engb.WithRelations", "This sample describes how to create class inside XbyK to hold Content Item Language Metadata", "ContentItemLanguageMetadata Sample")]
    public static ContentItemLanguageMetadataModel SampleArticleContentItemLanguageMetadataEnGbWithRelations => new()
    {
        ContentItemLanguageMetadataGUID = new Guid("8A3F1795-C0AC-4501-BE4E-6FBA0CD11654"),
        ContentItemLanguageMetadataContentItemGuid = SampleArticleContentItemGuidWithRelations,
        ContentItemLanguageMetadataContentLanguageGuid = ContentLanguageSamples.CONTENT_LANGUAGE_ENGB_SAMPLE_GUID,
        ContentItemLanguageMetadataDisplayName = "Content item with relations en-GB",
        ContentItemLanguageMetadataCreatedWhen = new DateTime(2023, 12, 10, 0,0,0,0, DateTimeKind.Utc),
        ContentItemLanguageMetadataHasImageAsset = false,
        ContentItemLanguageMetadataCreatedByUserGuid = UserSamples.SampleAdminGuid,
        ContentItemLanguageMetadataModifiedByUserGuid = UserSamples.SampleAdminGuid,
        ContentItemLanguageMetadataLatestVersionStatus = VersionStatus.Published,
    };
    
    [Sample("webpageitem.urlpath.sample.article.WithRelations", "", "Page url path sample")]
    public static WebPageUrlPathModel SampleArticleWebPageUrlWithRelations => new()
    {
        WebPageUrlPathGUID = new Guid("CCB7AF1F-57D9-405A-84FA-D0F4129A17DA"),
        WebPageUrlPath = "en-GB/content-item-with-relations",
        WebPageUrlPathHash = null,
        WebPageUrlPathWebPageItemGuid = SampleArticleWebPageItemWithRelations.WebPageItemGUID,
        WebPageUrlPathWebsiteChannelGuid = WebSiteChannelSamples.WebsiteChannelGuid,
        WebPageUrlPathContentLanguageGuid = ContentLanguageSamples.CONTENT_LANGUAGE_ENGB_SAMPLE_GUID,
        WebPageUrlPathIsLatest = true,
        WebPageUrlPathIsDraft = false
    };

    #endregion
    


    [Sample("webpageitem.sample.article.WithRelations", "This sample describes how to create class inside XbyK to hold WebPage Item data with relations", "ContentItem Sample")]
    public static WebPageItemModel SampleArticleWebPageItemWithRelations => new()
    {
        WebPageItemGUID = new Guid("14784BF0-69D0-40CF-8BE6-E5A0D897774B"),
        WebPageItemContentItemGuid = SampleArticleContentItemGuidWithRelations,
        WebPageItemName = "ContentItemWithRelations",
        WebPageItemOrder = 1,
        WebPageItemTreePath = "/content-item-with-relations",
        WebPageItemWebsiteChannelGuid = WebSiteChannelSamples.WebsiteChannelGuid
    };

    #endregion

    #region "Sample faq content item"

    public static readonly Guid SampleFaqContentItemGuid = new Guid("B64B3E3E-F5A9-4D02-8CDB-6D81805C0FEE");
    public static readonly Guid SampleFaqCommonDataGuidEnUs = new Guid("2B1987BF-680B-48C0-85CE-47FF9FDE24C7");
    public static readonly Guid SampleFaqCommonDataGuidEnGb = new Guid("96016B05-B3D3-42F9-B5AA-71E2F816EB8F");

    [Sample("ContentItemModel.Sample.Faq", "This sample describes how to create reusable content item data inside XbyK", "Reusable ContentItem Faq")]
    public static ContentItemModel SampleFaqContentItem => new()
    {
        ContentItemGUID = SampleFaqContentItemGuid,
        // ContentItemChannelGuid = ChannelSamples.WEBSITE_CHANNEL_SAMPLE_GUID,
        ContentItemDataClassGuid = DataClassSamples.FAQ_SAMPLE_GUID,
        ContentItemIsSecured = true,
        ContentItemIsReusable = true,
        ContentItemName = "SampleReusableFaq"
    };

    #region "EnUs version"

    [Sample("ContentItemCommonDataModel.Sample.Faq.enUS", "This sample describes how to create reusable content item common data inside XbyK", "Reusable ContentItemCommonData Faq")]
    public static ContentItemCommonDataModel SampleFaqContentItemCommonDataEnUs => new()
    {
        ContentItemCommonDataGUID = SampleFaqCommonDataGuidEnUs,
        ContentItemCommonDataContentItemGuid = SampleFaqContentItemGuid,
        ContentItemCommonDataContentLanguageGuid = ContentLanguageSamples.CONTENT_LANGUAGE_ENUS_SAMPLE_GUID,
        ContentItemCommonDataVersionStatus = VersionStatus.Published,
        ContentItemCommonDataIsLatest = true,
        ContentItemCommonDataPageBuilderWidgets = null,
        ContentItemCommonDataPageTemplateConfiguration = null
    };

    [Sample("ContentItemDataModel.Sample.Faq.enUS", "This sample describes how to reusable create content item data inside XbyK", "Reusable ContentItemData faq (en-US)")]
    public static ContentItemDataModel SampleFaqDataEnUs => new()
    {
        ContentItemDataGUID = new Guid("D29E7C59-09D5-443C-999D-063BA62E5F97"),
        ContentItemDataCommonDataGuid = SampleFaqCommonDataGuidEnUs,
        ContentItemContentTypeName = DataClassSamples.FAQ_SAMPLE_CLASS_NAME,
        CustomProperties = new Dictionary<string, object?>
        {
            ["FaqQuestion"] = "en-US FAQ question text",
            ["FaqAnswer"] = "en-US FAQ answer text"
        }
    };


    [Sample("contentitemlanguagemetadata.sample.faq.enus", "This sample describes how to create class inside XbyK to hold Content Item Language Metadata", "Reusable ContentItemLanguageMetadata faq")]
    public static ContentItemLanguageMetadataModel SampleFaqContentItemLanguageMetadataEnUs => new()
    {
        ContentItemLanguageMetadataGUID = new Guid("46353800-21B8-48F6-8681-B19966F4B6EB"),
        ContentItemLanguageMetadataContentItemGuid = SampleFaqContentItemGuid,
        ContentItemLanguageMetadataContentLanguageGuid = ContentLanguageSamples.CONTENT_LANGUAGE_ENUS_SAMPLE_GUID,
        ContentItemLanguageMetadataDisplayName = "Sample reusable FAQ",
        ContentItemLanguageMetadataCreatedWhen = new DateTime(2023, 12, 10, 0,0,0,0, DateTimeKind.Utc),
        ContentItemLanguageMetadataHasImageAsset = false,
        ContentItemLanguageMetadataCreatedByUserGuid = UserSamples.SampleAdminGuid,
        ContentItemLanguageMetadataModifiedByUserGuid = UserSamples.SampleAdminGuid,
        ContentItemLanguageMetadataLatestVersionStatus = VersionStatus.Published,
    };

    #endregion

    #region "EnGb version"

    [Sample("ContentItemCommonDataModel.Sample.Faq.enGB", "This sample describes how to create content item common data inside XbyK", "Reusable ContentItemCommonData faq")]
    public static ContentItemCommonDataModel SampleFaqContentItemCommonDataEnGb => new()
    {
        ContentItemCommonDataGUID = SampleFaqCommonDataGuidEnGb,
        ContentItemCommonDataContentItemGuid = SampleFaqContentItemGuid,
        ContentItemCommonDataContentLanguageGuid = ContentLanguageSamples.CONTENT_LANGUAGE_ENGB_SAMPLE_GUID,
        ContentItemCommonDataVersionStatus = VersionStatus.Published,
        ContentItemCommonDataIsLatest = true,
        ContentItemCommonDataPageBuilderWidgets = null,
        ContentItemCommonDataPageTemplateConfiguration = null
    };

    [Sample("ContentItemDataModel.Sample.Faq.enGB", "This sample describes how to create content item data inside XbyK", "Reusable ContentItemData faq sample (en-GB)")]
    public static ContentItemDataModel SampleFaqDataEnGb => new()
    {
        ContentItemDataGUID = new Guid("93269639-1C4A-48B8-B367-0DA00268EEB0"),
        ContentItemDataCommonDataGuid = SampleFaqCommonDataGuidEnGb,
        ContentItemContentTypeName = DataClassSamples.FAQ_SAMPLE_CLASS_NAME,
        CustomProperties = new Dictionary<string, object?>
        {
            ["FaqQuestion"] = "en-GB FAQ question text",
            ["FaqAnswer"] = "en-GB FAQ answer text"
        }
    };

    [Sample("contentitemlanguagemetadata.sample.faq.engb", "This sample describes how to create class inside XbyK to hold Content Item Language Metadata", "Reusable ContentItemLanguageMetadata faq")]
    public static ContentItemLanguageMetadataModel SampleFaqContentItemLanguageMetadataEnGb => new()
    {
        ContentItemLanguageMetadataGUID = new Guid("B15B3D9F-0CB1-405A-BC04-A069DAECF72D"),
        ContentItemLanguageMetadataContentItemGuid = SampleFaqContentItemGuid,
        ContentItemLanguageMetadataContentLanguageGuid = ContentLanguageSamples.CONTENT_LANGUAGE_ENGB_SAMPLE_GUID,
        ContentItemLanguageMetadataDisplayName = "Sample reusable FAQ",
        ContentItemLanguageMetadataCreatedWhen = new DateTime(2023, 12, 10, 0,0,0,0, DateTimeKind.Utc),
        ContentItemLanguageMetadataHasImageAsset = false,
        ContentItemLanguageMetadataCreatedByUserGuid = UserSamples.SampleAdminGuid,
        ContentItemLanguageMetadataModifiedByUserGuid = UserSamples.SampleAdminGuid,
        ContentItemLanguageMetadataLatestVersionStatus = VersionStatus.Published,
    };

    #endregion

    #endregion
}
