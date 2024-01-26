using CMS.ContentEngine;
using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class ContentItemSimplifiedSamples
{
    public static readonly Guid SampleArticleContentItemGuid = new Guid("37C3F5DD-6F2A-4EFF-B46E-A36EDDEBF572");
    public static readonly Guid SampleFaqContentItemGuid = new Guid("F9CB9484-CE90-460F-A5C8-AD953E2B9286");

    [Sample("ContentItemSimplifiedModel.Sample.Article", "Simplified model for importing webpage content item", "Simplified model for webpage content item sample")]
    public static ContentItemSimplifiedModel SampleArticleContentItemSimplifiedModel => new()
    {
        ContentItemGUID = SampleArticleContentItemGuid,
        Name = "SimplifiedModelSample",
        IsSecured = false,
        ContentTypeName = DataClassSamples.ArticleClassSample.ClassName,
        IsReusable = true,
        // channel name is required only for web site content items
        ChannelName = ChannelSamples.SampleChannelForWebSiteChannel.ChannelName,
        // required when content item type is website content item
        PageData = new() {
            ParentGuid = null,
            TreePath = "/simplified-sample",
            PageUrls = [
                new()
                {
                    UrlPath = "en-us/simplified-sample",
                    PathIsDraft = true,
                    LanguageName = ContentLanguageSamples.SampleContentLanguageEnUs.ContentLanguageName!
                },
                new()
                {
                    UrlPath = "en-gb/simplified-sample",
                    PathIsDraft = true,
                    LanguageName = ContentLanguageSamples.SampleContentLanguageEnGb.ContentLanguageName!
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
                UserGuid = UserSamples.SampleAdminGuid,
                ContentItemData = new Dictionary<string, object?>
                {
                    ["ArticleTitle"] = "en-US UMT simplified model creation",
                    ["ArticleText"] = "This article is only example of creation UMT simplified model for en-US language",
                    ["RelatedArticles"] = null,
                    ["RelatedFaq"] = null
                }
            },
            new()
            {
                LanguageName = ContentLanguageSamples.SampleContentLanguageEnGb.ContentLanguageName!,
                DisplayName = "Simplified model sample - en-gb",
                VersionStatus = VersionStatus.Published,
                UserGuid = UserSamples.SampleAdminGuid,
                ContentItemData = new Dictionary<string, object?>
                {
                    ["ArticleTitle"] = "en-GB UMT simplified model creation",
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
                }
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
                }
            }
        ],
    };
}
