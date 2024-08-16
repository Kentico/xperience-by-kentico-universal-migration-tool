using CMS.ContentEngine;
using CMS.ContentEngine.Internal;

using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class ContentItemSimplifiedSamples
{
    public static readonly Guid SampleArticleContentItemGuid = new Guid("37C3F5DD-6F2A-4EFF-B46E-A36EDDEBF572");
    public static readonly Guid SampleFaqContentItemGuid = new Guid("F9CB9484-CE90-460F-A5C8-AD953E2B9286");

    public static readonly Guid SampleArticleWebPageGuid = new Guid("4EA03DE4-977E-48AA-9340-BABF3D23BAFA");
    
    public static readonly Guid SampleArticleSubPageContentItemGuid = new Guid("9ED8DE86-859C-4F6C-94F2-CDD6BAED99FE");
    
    [Sample("ContentItemSimplifiedModel.Sample.Article", "Simplified model for importing webpage content item", "Simplified model for webpage content item sample")]
    public static ContentItemSimplifiedModel SampleArticleContentItemSimplifiedModel => new()
    {
        ContentItemGUID = SampleArticleContentItemGuid,
        Name = "SimplifiedModelSample",
        IsSecured = false,
        ContentTypeName = DataClassSamples.ArticleClassSample.ClassName,
        IsReusable = false,
        // channel name is required only for web site content items
        ChannelName = ChannelSamples.SampleChannelForWebSiteChannel.ChannelName,
        // required when content item type is website content item
        PageData = new() {
            PageGuid = SampleArticleWebPageGuid,
            ParentGuid = null,
            TreePath = "/simplified-sample",
            PageUrls = [
                new()
                {
                    UrlPath = "en-us/simplified-sample",
                    LanguageName = ContentLanguageSamples.SampleContentLanguageEnUs.ContentLanguageName!
                },
                new()
                {
                    UrlPath = "en-gb/simplified-sample",
                    LanguageName = ContentLanguageSamples.SampleContentLanguageEnGb.ContentLanguageName!
                },
                new()
                {
                    UrlPath = "es/simplified-sample",
                    LanguageName = ContentLanguageSamples.SampleContentLanguageEs.ContentLanguageName!
                }
            ]
        },
        LanguageData =
        [
            new()
            {
                LanguageName = ContentLanguageSamples.SampleContentLanguageEnUs.ContentLanguageName!,
                DisplayName = "Simplified model sample - en-us",
                VersionStatus = VersionStatus.InitialDraft,
                UserGuid = null,
                ContentItemData = new Dictionary<string, object?>
                {
                    ["ArticleTitle"] = "en-US UMT simplified model creation",
                    ["ArticleText"] = "This article is only example of creation UMT simplified model for en-US language",
                    ["RelatedArticles"] = null,
                    ["RelatedFaq"] = null,
                    ["CoffeaTaxonomy"] = System.Text.Json.JsonSerializer.Serialize(new List<object>
                    {
                        new TagReference{ Identifier = TaxonomySamples.SampleTagCoffeaCanephoraGuid},
                        new {Identifier = TaxonomySamples.SampleTagCoffeaRobustaGuid},
                    })
                },
                ScheduledPublishWhen = new DateTime(2045, 1, 1, 0,0,0,0,0, DateTimeKind.Utc)
            },
            new()
            {
                LanguageName = ContentLanguageSamples.SampleContentLanguageEnGb.ContentLanguageName!,
                DisplayName = "Simplified model sample - en-gb",
                VersionStatus = VersionStatus.Published,
                UserGuid = null,
                ContentItemData = new Dictionary<string, object?>
                {
                    ["ArticleTitle"] = "en-GB UMT simplified model creation",
                    ["ArticleText"] = "This article is only example of creation UMT simplified model for en-GB language",
                    ["RelatedArticles"] = null,
                    ["RelatedFaq"] = null,
                    ["CoffeaTaxonomy"] = System.Text.Json.JsonSerializer.Serialize(new List<object>
                    {
                        new TagReference{ Identifier = TaxonomySamples.SampleTagCoffeaCanephoraGuid},
                        new {Identifier = TaxonomySamples.SampleTagCoffeaRobustaGuid},
                    })
                },
                ScheduledUnpublishWhen = new DateTime(2045, 1, 1, 0,0,0,0,0, DateTimeKind.Utc)
            }
        ],
    };
    
    [Sample("ContentItemSimplifiedModel.Sample.ArticleSubPage", "Simplified model for importing webpage content item with parent", "Simplified model for webpage content item sample with parent")]
    public static ContentItemSimplifiedModel SampleArticleSubPageContentItemSimplifiedModel => new()
    {
        ContentItemGUID = SampleArticleSubPageContentItemGuid,
        Name = "SimplifiedModelSampleAsSubPAge",
        IsSecured = false,
        ContentTypeName = DataClassSamples.ArticleClassSample.ClassName,
        IsReusable = false,
        // channel name is required only for web site content items
        ChannelName = ChannelSamples.SampleChannelForWebSiteChannel.ChannelName,
        // required when content item type is website content item
        PageData = new() {
            ParentGuid = SampleArticleWebPageGuid,
            TreePath = "/simplified-sample/sub-page",
            PageUrls = [
                new()
                {
                    UrlPath = "en-us/simplified-sample/sub-page",
                    LanguageName = ContentLanguageSamples.SampleContentLanguageEnUs.ContentLanguageName!
                },
                new()
                {
                    UrlPath = "en-gb/simplified-sample/sub-page",
                    LanguageName = ContentLanguageSamples.SampleContentLanguageEnGb.ContentLanguageName!
                },
                new()
                {
                    UrlPath = "es/simplified-sample/sub-page",
                    LanguageName = ContentLanguageSamples.SampleContentLanguageEs.ContentLanguageName!
                }
            ]
        },
        LanguageData =
        [
            new()
            {
                LanguageName = ContentLanguageSamples.SampleContentLanguageEnUs.ContentLanguageName!,
                DisplayName = "Simplified model sample sub page - en-us",
                VersionStatus = VersionStatus.InitialDraft,
                UserGuid = UserSamples.SampleAdminGuid,
                ContentItemData = new Dictionary<string, object?>
                {
                    ["ArticleTitle"] = "en-US UMT simplified model creation as sub page",
                    ["ArticleTeaser"] = new AssetFileSource
                    {
                        ContentItemGuid = SampleArticleSubPageContentItemGuid,
                        Identifier = new Guid("CB2B28BB-25BF-47D0-8553-6A1D85D5DC85"),
                        Name = "my superb asset.jpg",
                        Extension = ".jpg",
                        Size = null,
                        LastModified = null,
                        FilePath = @"C:\Users\TK-NITTIN\Pictures\84693449_B.jpg"
                    },
                    ["ArticleText"] = "This article is only example of creation UMT simplified model for en-US language",
                    ["RelatedArticles"] = null,
                    ["RelatedFaq"] = null
                }
            },
            new()
            {
                LanguageName = ContentLanguageSamples.SampleContentLanguageEnGb.ContentLanguageName!,
                DisplayName = "Simplified model sample sub page - en-gb",
                VersionStatus = VersionStatus.Published,
                UserGuid = UserSamples.SampleAdminGuid,
                ContentItemData = new Dictionary<string, object?>
                {
                    ["ArticleTitle"] = "en-GB UMT simplified model creation as sub page",
                    ["ArticleTeaser"] = new AssetUrlSource
                    {
                        ContentItemGuid = SampleArticleSubPageContentItemGuid,
                        Identifier = new Guid("8D6191F6-3B02-4BCE-A48E-4282462549B6"),
                        Name = "cms screen.jpg",
                        Extension = ".jpg",
                        Size = null,
                        LastModified = null,
                        Url = "https://devnet.kentico.com/DevNet/media/devnet/cms_screen.jpg"
                    },
                    ["ArticleText"] = "This article is only example of creation UMT simplified model for en-GB language",
                    ["RelatedArticles"] = null,
                    ["RelatedFaq"] = null
                }
            }
        ],
    };
    
    [Sample("ContentItemSimplifiedModel.Sample.Faq", "This sample describes how to create content item data inside XbyK", "Simplified model for reusable content item sample")]
    public static ContentItemSimplifiedModel SampleFaqContentItemSimplifiedModel => new()
    {
        ContentItemGUID = SampleFaqContentItemGuid,
        Name = "SimplifiedModelSampleReusable",
        IsSecured = false,
        ContentTypeName = DataClassSamples.FaqDataClass.ClassName,
        IsReusable = true,
        ContentItemContentFolderGUID = ContentFolderSamples.SampleContentSubFolder.ContentFolderGUID,
        LanguageData =
        [
            new()
            {
                LanguageName = ContentLanguageSamples.SampleContentLanguageEnUs.ContentLanguageName!,
                DisplayName = "FAQ: reusable simplified model sample - en-us",
                VersionStatus = VersionStatus.InitialDraft,
                UserGuid = UserSamples.SampleAdminGuid,
                ContentItemData = new Dictionary<string, object?>
                {
                    ["FaqQuestion"] = "en-US FAQ question text (reusable)",
                    ["FaqAnswer"] = "en-US FAQ answer text (reusable)"
                },
            },
            new()
            {
                LanguageName = ContentLanguageSamples.SampleContentLanguageEnGb.ContentLanguageName!,
                DisplayName = "FAQ: reusable simplified model sample - en-gb",
                VersionStatus = VersionStatus.Published,
                UserGuid = UserSamples.SampleAdminGuid,
                ContentItemData = new Dictionary<string, object?>
                {
                    ["FaqQuestion"] = "en-US FAQ question text (reusable)",
                    ["FaqAnswer"] = "en-US FAQ answer text (reusable)"
                },
                ScheduledUnpublishWhen = new DateTime(2045, 1, 1, 0,0,0,0,0, DateTimeKind.Utc)
            }
        ],
    };
}
