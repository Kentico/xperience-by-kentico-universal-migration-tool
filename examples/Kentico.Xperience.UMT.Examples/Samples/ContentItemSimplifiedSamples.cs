using CMS.ContentEngine;

using Kentico.Xperience.UMT.Examples.Utils;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.Utils;

namespace Kentico.Xperience.UMT.Examples;

public static class ContentItemSimplifiedSamples
{
    public static readonly Guid SampleArticleContentItemGuid = new("37C3F5DD-6F2A-4EFF-B46E-A36EDDEBF572");
    public static readonly Guid SampleFaqContentItemGuid = new("F9CB9484-CE90-460F-A5C8-AD953E2B9286");
    public static readonly Guid SampleEvent2024ContentItemGuid = new("C82CDC96-65EC-4F4C-AEC2-3D657E6D5CE1");
    public static readonly Guid EventInSampleWorkspaceGuid = new("2867F7B2-2DB4-429A-B1B7-7596A502B089");

    public static readonly Guid SampleArticleWebPageGuid = new("4EA03DE4-977E-48AA-9340-BABF3D23BAFA");

    public static readonly Guid SampleArticleSubPageContentItemGuid = new("9ED8DE86-859C-4F6C-94F2-CDD6BAED99FE");
    public static readonly Guid SampleArticleSubPage2ContentItemGuid = new("017EDC1E-95C6-43E4-89D5-716C6AE594B2");
    public static readonly Guid SampleArticleSubPage3ContentItemGuid = new("73298F71-0BB1-4083-A674-A876769E3DD9");
    public static readonly Guid SampleArticleSubPage4ContentItemGuid = new("8E957ECC-083B-4C86-B761-8DB516C13737");
    public static readonly Guid SampleArticleSubPage5ContentItemGuid = new("BB5C0EB4-E688-4A97-99C7-FA97CAD8F1D5");
    public static readonly Guid SampleArticleSubPage6ContentItemGuid = new("1D542076-DD88-4C13-A8AA-0FFECDABBA69");
    public static readonly Guid SampleArticleSubPage7ContentItemGuid = new("FB66242F-4186-4F71-B0B8-FC68B51D52C1");

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
        PageData = new()
        {
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
                ScheduledPublishWhen = new DateTime(2045, 1, 1, 0, 0, 0, 0, 0, DateTimeKind.Utc)
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
                ScheduledUnpublishWhen = new DateTime(2045, 1, 1, 0, 0, 0, 0, 0, DateTimeKind.Utc)
            }
        ],
    };

    public static ContentItemSimplifiedModel CreateSampleContentItemSimplifiedModel(Guid contentItemGuid, string name, string displayName,
        string treePath, string title, string articleText, List<(string Language, VersionStatus Status, bool IsLatest, Guid TeaserGuid)> languageData) => new()
        {
            ContentItemGUID = contentItemGuid,
            Name = name,
            IsSecured = false,
            ContentTypeName = DataClassSamples.ArticleClassSample.ClassName,
            IsReusable = false,
            // channel name is required only for web site content items
            ChannelName = ChannelSamples.SampleChannelForWebSiteChannel.ChannelName,
            // required when content item type is website content item
            PageData = new()
            {
                ParentGuid = SampleArticleWebPageGuid,
                TreePath = treePath,
                PageUrls = [
                    .. languageData.Select(languageVersion => new PageUrlModel
                    {
                        LanguageName = languageVersion.Language,
                        UrlPath = $"{languageVersion.Language.ToLower()}{treePath}{(languageVersion.Status == VersionStatus.Draft ? "-new-draft" : string.Empty)}",
                        PathIsDraft = languageVersion.Status == VersionStatus.Draft,
                        PathIsLatest = languageVersion.IsLatest
                    }),
                    // Reserved URLs for language mutations not yet created
                    .. ContentLanguageSamples.Languages.Select(x => x.ContentLanguageName).Except(languageData.Select(x => x.Language))
                        .Select(language => new PageUrlModel
                        {
                            LanguageName = language,
                            PathIsDraft = false,
                            PathIsLatest = true,
                            UrlPath = $"{language!.ToLower()}{treePath}"
                        })
                ]
            },
            LanguageData = languageData.Select(languageVersion =>
            new ContentItemLanguageData
            {
                LanguageName = languageVersion.Language,
                DisplayName = $"{displayName} - {languageVersion.Language}",
                VersionStatus = languageVersion.Status,
                IsLatest = languageVersion.IsLatest,
                UserGuid = UserSamples.SampleAdminGuid,
                ContentItemData = new Dictionary<string, object?>
                {
                    ["ArticleTitle"] = $"{languageVersion.Language} {title}{(languageVersion.Status == VersionStatus.Draft ? "...new draft" : string.Empty)}",
                    ["ArticleText"] = $"{articleText} for {languageVersion.Language} language{(languageVersion.Status == VersionStatus.Draft ? " ...new draft" : string.Empty)}",
                    ["RelatedArticles"] = null,
                    ["RelatedFaq"] = null
                }
            }).ToList()
        };

    [Sample("ContentItemSimplifiedModel.Sample.ArticleSubPage", "Simplified model for importing webpage content item with parent", "Simplified model for webpage content item sample with parent")]
    public static ContentItemSimplifiedModel SampleArticleSubPageContentItemSimplifiedModel =>
        CreateSampleContentItemSimplifiedModel(
            contentItemGuid: SampleArticleSubPageContentItemGuid,
            name: "SimplifiedModelSampleAsSubPage",
            displayName: "Simplified model sample sub page",
            treePath: "/simplified-sample/sub-page",
            title: "UMT simplified model creation as sub page",
            articleText: "This article is only example of creation UMT simplified model",
            [
                (ContentLanguageSamples.SampleContentLanguageEnUs.ContentLanguageName!, VersionStatus.InitialDraft, true, new Guid("57E26C3F-31B6-4B92-9C45-21723C06AD2E")),
                (ContentLanguageSamples.SampleContentLanguageEnGb.ContentLanguageName!, VersionStatus.Published, true, new Guid("57885CC8-3488-41B1-804F-E61445D6E07F")),
            ]
        );


    [Sample("ContentItemSimplifiedModel.Sample.ArticleSubPage2_Draft", "Simplified model for importing webpage content item with parent, in Draft state", "Simplified model for webpage content item sample with parent [Draft]")]
    public static ContentItemSimplifiedModel SampleArticleSubPage2ContentItemSimplifiedModel_Draft =>
        CreateSampleContentItemSimplifiedModel(
            contentItemGuid: SampleArticleSubPage2ContentItemGuid,
            name: "SimplifiedModelSampleAsSubPage2_Draft",
            displayName: "Simplified model sample sub page 2 [Draft]",
            treePath: "/simplified-sample/sub-page-2",
            title: "UMT simplified model creation as sub page 2 [Draft]",
            articleText: "Created by UMT simplified model in Draft state",
            [
                (ContentLanguageSamples.SampleContentLanguageEnUs.ContentLanguageName!, VersionStatus.Published, false, new Guid("26605C72-B6EC-4F0C-9071-FB55602DCF50")),
                (ContentLanguageSamples.SampleContentLanguageEnUs.ContentLanguageName!, VersionStatus.Draft, true, new Guid("AA7EB6C9-D5C2-4CBC-B0BF-D3A29CDB82C4")),
                (ContentLanguageSamples.SampleContentLanguageEnGb.ContentLanguageName!, VersionStatus.Published, false, new Guid("A40217D8-B1B5-4E0A-B664-B0075A168510")),
                (ContentLanguageSamples.SampleContentLanguageEnGb.ContentLanguageName!, VersionStatus.Draft, true, new Guid("E48B18B5-2428-4B6E-86D1-D826FDEA31E8")),
            ]
        );

    [Sample("ContentItemSimplifiedModel.Sample.ArticleSubPage3_Draft", "Simplified model for importing webpage content item with parent, in Draft state", "Simplified model for webpage content item sample with parent [Draft]")]
    public static ContentItemSimplifiedModel SampleArticleSubPage3ContentItemSimplifiedModel_Draft =>
        CreateSampleContentItemSimplifiedModel(
            contentItemGuid: SampleArticleSubPage3ContentItemGuid,
            name: "SimplifiedModelSampleAsSubPage3_Draft",
            displayName: "Simplified model sample sub page 3 [Draft]",
            treePath: "/simplified-sample/sub-page-3",
            title: "UMT simplified model creation as sub page 3 [Draft]",
            articleText: "Created by UMT simplified model in Draft state",
            [
                (ContentLanguageSamples.SampleContentLanguageEnUs.ContentLanguageName!, VersionStatus.Published, false, new Guid("22B80F00-F0A0-43F0-A31E-CDBA144547DC")),
                (ContentLanguageSamples.SampleContentLanguageEnUs.ContentLanguageName!, VersionStatus.Draft, true, new Guid("51E7B6AC-B571-4688-8210-3F506A84E184")),
                (ContentLanguageSamples.SampleContentLanguageEnGb.ContentLanguageName!, VersionStatus.Published, false, new Guid("18356E9C-F3D6-430E-A89E-922F75149B87")),
                (ContentLanguageSamples.SampleContentLanguageEnGb.ContentLanguageName!, VersionStatus.Draft, true, new Guid("6C36AAC6-495A-4EC7-9ED7-2365A508DC01")),
            ]
        );

    [Sample("ContentItemSimplifiedModel.Sample.ArticleSubPage4", "Simplified model for importing webpage content item with parent", "Simplified model for webpage content item sample with parent")]
    public static ContentItemSimplifiedModel SampleArticleSubPage4ContentItemSimplifiedModel_Scheduled =>
        CreateSampleContentItemSimplifiedModel(
            contentItemGuid: SampleArticleSubPage4ContentItemGuid,
            name: "SimplifiedModelSampleAsSubPage4",
            displayName: "Simplified model sample sub page 4",
            treePath: "/simplified-sample/sub-page-4",
            title: "UMT simplified model creation as sub page 4",
            articleText: "This article is only example of creation UMT simplified model",
            [
                (ContentLanguageSamples.SampleContentLanguageEnUs.ContentLanguageName!, VersionStatus.InitialDraft, true, new Guid("6DFB0834-B61A-4E79-8E12-09E40019FD1D")),
            ]
        ).Apply(x => x.LanguageData.ForEach(ld => ld.ScheduledPublishWhen = new DateTime(2045, 1, 1, 0, 0, 0, 0, 0, DateTimeKind.Utc)));

    [Sample("ContentItemSimplifiedModel.Sample.ArticleSubPage5", "Simplified model for importing webpage content item with parent", "Simplified model for webpage content item sample with parent")]
    public static ContentItemSimplifiedModel SampleArticleSubPage5ContentItemSimplifiedModel_Scheduled =>
        CreateSampleContentItemSimplifiedModel(
            contentItemGuid: SampleArticleSubPage5ContentItemGuid,
            name: "SimplifiedModelSampleAsSubPage5",
            displayName: "Simplified model sample sub page 5",
            treePath: "/simplified-sample/sub-page-5",
            title: "UMT simplified model creation as sub page 5",
            articleText: "This article is only example of creation UMT simplified model",
            [
                (ContentLanguageSamples.SampleContentLanguageEnUs.ContentLanguageName!, VersionStatus.InitialDraft, true, new Guid("BD7C71FF-7953-45B4-B43D-F2926D022157")),
            ]
        ).Apply(x => x.LanguageData.ForEach(ld => ld.ScheduledPublishWhen = new DateTime(2045, 1, 1, 0, 0, 0, 0, 0, DateTimeKind.Utc)));

    [Sample("ContentItemSimplifiedModel.Sample.ArticleSubPage6", "Simplified model for importing webpage content item with parent, in Initial Draft", "Simplified model for webpage content item sample with parent")]
    public static ContentItemSimplifiedModel SampleArticleSubPage6ContentItemSimplifiedModel_InitialDraft =>
        CreateSampleContentItemSimplifiedModel(
            contentItemGuid: SampleArticleSubPage6ContentItemGuid,
            name: "SimplifiedModelSampleAsSubPage6",
            displayName: "Simplified model sample sub page 6",
            treePath: "/simplified-sample/sub-page-6",
            title: "UMT simplified model creation as sub page 6",
            articleText: "This article is only example of creation UMT simplified model",
            [
                (ContentLanguageSamples.SampleContentLanguageEnUs.ContentLanguageName!, VersionStatus.InitialDraft, true, new Guid("22DDD031-C3EF-4079-8E91-6AF58EDA291F")),
            ]
        );

    [Sample("ContentItemSimplifiedModel.Sample.ArticleSubPage7", "Simplified model for importing webpage content item with parent", "Simplified model for webpage content item sample with parent")]
    public static ContentItemSimplifiedModel SampleArticleSubPage7ContentItemSimplifiedModel_Scheduled =>
        CreateSampleContentItemSimplifiedModel(
            contentItemGuid: SampleArticleSubPage7ContentItemGuid,
            name: "SimplifiedModelSampleAsSubPage7",
            displayName: "Simplified model sample sub page 7",
            treePath: "/simplified-sample/sub-page-7",
            title: "UMT simplified model creation as sub page 7",
            articleText: "This article is only example of creation UMT simplified model",
            [
                (ContentLanguageSamples.SampleContentLanguageEnUs.ContentLanguageName!, VersionStatus.InitialDraft, true, new Guid("6AE7CB81-D03F-43AF-9F3F-EA3DBD9983B5")),
            ]
        ).Apply(x => x.LanguageData.ForEach(ld => ld.ScheduledPublishWhen = new DateTime(2045, 1, 1, 0, 0, 0, 0, 0, DateTimeKind.Utc)));


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
                    ["FaqQuestion"] = "en-GB FAQ question text (reusable)",
                    ["FaqAnswer"] = "en-GB FAQ answer text (reusable)"
                },
                ScheduledUnpublishWhen = new DateTime(2045, 1, 1, 0, 0, 0, 0, 0, DateTimeKind.Utc)
            }
        ],
    };


    [Sample("ContentItemSimplifiedModel.Sample.Event2024", "This sample describes how to import reusable content item with asset into XbyK", "Reusable content item sample with assets")]
    public static ContentItemSimplifiedModel SampleEventContentItemWithAsset => new()
    {
        ContentItemGUID = SampleEvent2024ContentItemGuid,
        Name = "SimplifiedModelSampleEventWithAssets",
        IsSecured = false,
        ContentTypeName = DataClassSamples.EventDataClass.ClassName,
        IsReusable = true,
        LanguageData =
        [
            new()
            {
                LanguageName = ContentLanguageSamples.SampleContentLanguageEnUs.ContentLanguageName!,
                DisplayName = "Event sample 2024 - en-US",
                VersionStatus = VersionStatus.InitialDraft,
                UserGuid = UserSamples.SampleAdminGuid,
                ContentItemData = new Dictionary<string, object?>
                {
                    ["EventTitle"] = "en-US Event sample 2024",
                    ["EventText"] = "en-US Event sample 2024 (reusable)",
                    ["EventDate"] = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                    ["EventRecurrentYearly"] = true,
                    ["EventTeaser"] = new AssetDataSource
                    {
                        ContentItemGuid = SampleEvent2024ContentItemGuid,
                        Identifier = new Guid("2A645BAB-F2DC-4B94-A226-FD680B9DF901"),
                        Name = "byteArraySample.jpg",
                        Extension = ".jpg",
                        Size = null,
                        LastModified = null,
                        Data = [137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 1, 27, 0, 0, 0, 101, 8, 6, 0, 0, 0, 125, 114, 71, 36, 0, 0, 0, 1, 115, 82, 71, 66, 0, 174, 206, 28, 233, 0, 0, 0, 4, 103, 65, 77, 65, 0, 0, 177, 143, 11, 252, 97, 5, 0, 0, 0, 9, 112, 72, 89, 115, 0, 0, 14, 195, 0, 0, 14, 195, 1, 199, 111, 168, 100, 0, 0, 16, 4, 73, 68, 65, 84, 120, 94, 237, 221, 9, 144, 28, 85, 29, 6, 240, 255, 28, 59, 187, 155, 13, 225, 190, 33, 92, 65, 64, 5, 4, 65, 64, 19, 146, 128, 6, 11, 84, 228, 12, 144, 226, 50, 104, 84, 10, 77, 208, 226, 80, 32, 137, 28, 22, 96, 129, 160, 168, 33, 86, 37, 168, 225, 190, 20, 17, 68, 67, 18, 238, 51, 6, 57, 148, 8, 36, 28, 145, 35, 145, 43, 201, 94, 115, 57, 223, 236, 123, 181, 157, 151, 215, 51, 221, 51, 61, 111, 142, 253, 126, 85, 157, 237, 215, 51, 243, 182, 123, 178, 239, 155, 215, 175, 143, 137, 229, 11, 132, 136, 168, 198, 226, 234, 39, 17, 81, 77, 49, 108, 136, 200, 9, 134, 13, 17, 57, 193, 176, 33, 34, 39, 24, 54, 68, 228, 4, 195, 134, 136, 156, 96, 216, 16, 145, 19, 12, 27, 34, 114, 130, 97, 67, 68, 78, 48, 108, 136, 200, 9, 134, 13, 17, 57, 193, 176, 33, 34, 39, 24, 54, 68, 228, 68, 75, 93, 245, 157, 125, 101, 137, 100, 151, 191, 32, 217, 55, 255, 35, 185, 119, 151, 75, 238, 127, 111, 75, 126, 245, 251, 146, 239, 89, 35, 146, 73, 23, 182, 54, 46, 177, 84, 135, 196, 134, 111, 40, 177, 141, 54, 151, 248, 102, 219, 73, 124, 155, 93, 36, 49, 114, 119, 73, 140, 218, 91, 226, 155, 108, 173, 106, 34, 162, 168, 53, 117, 216, 228, 63, 90, 37, 233, 103, 30, 144, 204, 146, 133, 146, 121, 241, 49, 201, 247, 245, 168, 71, 42, 147, 216, 118, 148, 36, 247, 28, 35, 201, 125, 15, 149, 228, 167, 14, 82, 75, 137, 40, 10, 77, 25, 54, 233, 197, 15, 74, 250, 161, 219, 37, 253, 244, 95, 213, 146, 232, 197, 183, 216, 94, 218, 70, 31, 37, 169, 113, 199, 75, 124, 83, 246, 120, 136, 170, 213, 84, 97, 147, 126, 228, 46, 233, 187, 111, 78, 97, 87, 233, 69, 181, 196, 141, 212, 33, 39, 72, 251, 225, 147, 37, 190, 245, 206, 106, 9, 17, 133, 213, 20, 97, 147, 121, 110, 145, 244, 222, 249, 11, 201, 190, 242, 15, 181, 164, 62, 218, 15, 63, 67, 218, 143, 157, 42, 177, 246, 78, 181, 132, 136, 130, 106, 232, 176, 193, 192, 110, 239, 188, 203, 164, 127, 193, 45, 106, 73, 253, 197, 55, 217, 74, 58, 78, 60, 87, 218, 62, 255, 53, 181, 132, 136, 130, 104, 216, 176, 193, 160, 111, 207, 156, 139, 36, 183, 106, 133, 90, 210, 88, 176, 107, 213, 249, 141, 139, 11, 239, 32, 207, 30, 32, 10, 162, 33, 195, 166, 239, 158, 89, 210, 123, 243, 21, 170, 212, 184, 18, 59, 239, 41, 157, 83, 174, 148, 196, 118, 187, 170, 37, 68, 228, 167, 225, 194, 166, 103, 238, 116, 233, 255, 219, 31, 84, 169, 241, 197, 186, 54, 148, 97, 103, 93, 43, 201, 61, 71, 171, 37, 68, 100, 211, 80, 97, 211, 253, 171, 179, 37, 253, 232, 31, 85, 169, 185, 12, 155, 246, 107, 105, 219, 111, 130, 42, 17, 145, 169, 97, 6, 28, 154, 57, 104, 160, 251, 234, 239, 72, 102, 241, 124, 85, 34, 34, 83, 67, 132, 77, 207, 220, 25, 53, 13, 154, 248, 230, 219, 21, 167, 90, 91, 123, 205, 153, 146, 93, 186, 88, 149, 136, 200, 171, 238, 187, 81, 125, 127, 190, 94, 122, 111, 186, 92, 149, 162, 149, 58, 248, 24, 233, 156, 178, 238, 64, 115, 223, 157, 215, 74, 255, 67, 119, 72, 110, 229, 91, 106, 73, 180, 16, 106, 195, 103, 220, 94, 188, 246, 138, 136, 6, 213, 181, 103, 83, 60, 89, 175, 70, 65, 227, 167, 253, 232, 239, 21, 67, 168, 86, 16, 98, 221, 179, 207, 83, 37, 34, 210, 234, 22, 54, 249, 222, 181, 210, 51, 103, 186, 42, 185, 149, 216, 227, 115, 106, 174, 54, 112, 142, 80, 223, 221, 215, 169, 18, 17, 65, 221, 194, 6, 103, 6, 231, 86, 190, 169, 74, 110, 225, 214, 18, 181, 214, 123, 219, 85, 146, 125, 237, 159, 170, 68, 68, 117, 9, 155, 204, 243, 15, 75, 255, 131, 55, 171, 82, 227, 194, 238, 86, 199, 49, 223, 87, 165, 240, 122, 111, 249, 153, 154, 35, 162, 186, 132, 77, 239, 157, 215, 170, 185, 240, 208, 248, 49, 213, 114, 220, 5, 244, 224, 50, 198, 120, 42, 13, 156, 204, 11, 143, 74, 250, 145, 187, 85, 137, 104, 104, 115, 30, 54, 233, 71, 255, 84, 209, 225, 97, 28, 229, 233, 186, 96, 94, 177, 241, 99, 66, 16, 108, 240, 243, 69, 53, 57, 164, 109, 30, 197, 170, 102, 80, 25, 151, 94, 16, 81, 29, 194, 166, 239, 254, 57, 106, 46, 156, 206, 41, 151, 75, 114, 143, 3, 85, 105, 64, 49, 128, 126, 60, 47, 210, 192, 49, 131, 70, 67, 224, 84, 34, 251, 214, 82, 233, 127, 248, 46, 85, 34, 26, 186, 156, 134, 13, 142, 210, 84, 50, 104, 138, 198, 111, 6, 141, 22, 101, 224, 248, 5, 13, 160, 254, 74, 127, 71, 255, 252, 121, 106, 142, 104, 232, 114, 122, 82, 95, 247, 181, 103, 73, 250, 201, 191, 168, 82, 112, 104, 228, 182, 158, 141, 23, 206, 111, 89, 123, 233, 164, 117, 78, 214, 243, 11, 15, 60, 103, 245, 212, 177, 170, 52, 160, 84, 208, 104, 31, 77, 218, 69, 205, 133, 55, 124, 250, 109, 146, 248, 196, 190, 170, 20, 141, 185, 115, 231, 202, 162, 69, 139, 84, 105, 192, 216, 177, 99, 229, 180, 211, 78, 83, 165, 117, 45, 95, 190, 92, 102, 206, 156, 169, 74, 235, 154, 62, 125, 186, 236, 184, 227, 142, 170, 212, 252, 78, 63, 253, 116, 89, 184, 112, 97, 113, 155, 176, 109, 227, 198, 141, 83, 143, 80, 189, 56, 11, 155, 252, 154, 15, 229, 227, 41, 159, 85, 165, 240, 42, 9, 156, 228, 30, 7, 72, 215, 5, 55, 22, 231, 189, 204, 176, 9, 18, 52, 107, 47, 57, 73, 50, 255, 122, 82, 149, 194, 75, 77, 56, 69, 58, 79, 141, 246, 188, 34, 52, 40, 4, 142, 23, 26, 214, 140, 25, 51, 84, 105, 93, 227, 199, 143, 47, 54, 64, 211, 130, 5, 11, 90, 170, 49, 218, 222, 151, 101, 203, 150, 181, 84, 152, 54, 35, 103, 187, 81, 248, 22, 132, 106, 32, 32, 122, 102, 157, 91, 104, 240, 79, 168, 37, 235, 67, 32, 97, 151, 74, 67, 56, 232, 224, 241, 74, 63, 124, 167, 154, 27, 8, 164, 114, 65, 211, 51, 235, 156, 170, 130, 6, 50, 53, 188, 57, 123, 16, 8, 32, 91, 208, 52, 203, 167, 62, 214, 221, 156, 108, 208, 123, 51, 131, 6, 16, 64, 84, 95, 206, 194, 6, 227, 53, 213, 10, 26, 56, 232, 169, 104, 232, 233, 224, 249, 120, 237, 192, 235, 207, 145, 222, 59, 174, 81, 143, 14, 140, 7, 149, 130, 231, 227, 90, 170, 106, 229, 62, 120, 183, 110, 23, 105, 162, 97, 218, 118, 159, 16, 50, 126, 189, 160, 70, 130, 245, 71, 175, 204, 59, 221, 112, 195, 13, 234, 81, 106, 22, 238, 194, 230, 197, 199, 212, 92, 117, 130, 6, 142, 134, 231, 175, 189, 100, 82, 113, 183, 9, 147, 25, 28, 222, 231, 154, 162, 10, 26, 45, 243, 210, 227, 106, 206, 29, 124, 210, 163, 113, 154, 176, 75, 129, 221, 167, 86, 131, 237, 178, 237, 46, 97, 44, 139, 234, 203, 73, 216, 100, 151, 189, 32, 249, 238, 213, 170, 84, 189, 114, 129, 147, 121, 201, 63, 136, 76, 126, 117, 68, 29, 52, 144, 89, 250, 172, 154, 115, 199, 111, 247, 97, 206, 156, 202, 78, 65, 104, 6, 230, 24, 84, 169, 113, 44, 114, 199, 77, 216, 212, 224, 123, 158, 252, 2, 7, 183, 144, 8, 51, 190, 130, 58, 80, 151, 87, 45, 130, 6, 178, 203, 158, 87, 115, 110, 248, 141, 211, 180, 218, 128, 176, 73, 247, 218, 112, 236, 3, 19, 131, 166, 49, 56, 57, 26, 213, 251, 251, 139, 165, 239, 254, 245, 7, 237, 162, 128, 221, 32, 12, 242, 226, 39, 2, 194, 12, 142, 32, 162, 168, 35, 168, 13, 126, 249, 152, 196, 55, 222, 82, 149, 170, 83, 234, 104, 148, 30, 231, 48, 5, 253, 148, 247, 14, 180, 226, 240, 58, 202, 122, 23, 165, 212, 225, 117, 192, 235, 204, 67, 242, 167, 158, 122, 234, 58, 99, 68, 186, 78, 192, 114, 172, 151, 185, 251, 131, 231, 190, 254, 250, 235, 197, 231, 153, 161, 137, 231, 154, 189, 23, 253, 122, 219, 239, 183, 213, 175, 233, 109, 213, 191, 203, 187, 94, 80, 234, 181, 38, 172, 39, 38, 212, 133, 159, 168, 11, 245, 224, 245, 59, 236, 176, 67, 241, 125, 11, 90, 87, 171, 113, 18, 54, 107, 175, 60, 67, 50, 75, 234, 51, 62, 128, 0, 193, 128, 113, 108, 179, 109, 37, 191, 106, 69, 113, 23, 171, 218, 35, 75, 213, 232, 186, 240, 38, 73, 238, 30, 205, 45, 46, 252, 194, 6, 127, 208, 59, 237, 180, 147, 90, 50, 8, 127, 244, 65, 198, 105, 208, 200, 253, 206, 199, 209, 208, 96, 16, 32, 182, 224, 178, 173, 23, 118, 219, 16, 0, 230, 114, 205, 86, 31, 194, 210, 12, 25, 63, 222, 222, 154, 237, 247, 251, 245, 230, 170, 221, 86, 47, 219, 239, 181, 193, 123, 81, 42, 172, 91, 149, 147, 176, 89, 115, 254, 17, 146, 125, 227, 223, 170, 20, 76, 172, 115, 184, 36, 63, 253, 5, 145, 82, 223, 62, 217, 189, 90, 210, 207, 21, 62, 193, 178, 25, 181, 96, 93, 126, 231, 217, 160, 247, 130, 221, 45, 191, 30, 140, 238, 233, 4, 225, 119, 120, 221, 207, 176, 51, 175, 142, 236, 11, 238, 252, 194, 6, 141, 218, 214, 19, 192, 185, 38, 229, 132, 105, 224, 128, 70, 99, 142, 255, 216, 214, 11, 191, 95, 247, 24, 252, 224, 57, 168, 75, 135, 66, 173, 195, 38, 236, 182, 226, 245, 182, 176, 198, 118, 161, 174, 114, 219, 231, 133, 247, 45, 76, 143, 169, 21, 56, 9, 155, 143, 207, 60, 72, 242, 31, 190, 167, 74, 229, 37, 119, 223, 95, 134, 77, 251, 141, 196, 134, 111, 164, 150, 248, 203, 127, 184, 82, 186, 175, 155, 186, 222, 160, 48, 2, 3, 23, 106, 250, 65, 216, 120, 15, 129, 107, 184, 194, 59, 204, 117, 80, 126, 245, 248, 233, 56, 249, 66, 105, 255, 114, 52, 159, 106, 97, 26, 181, 223, 39, 187, 151, 237, 83, 30, 245, 225, 83, 29, 63, 117, 136, 153, 245, 155, 117, 7, 253, 132, 183, 241, 134, 87, 45, 195, 6, 143, 227, 121, 97, 217, 194, 53, 108, 104, 105, 8, 155, 114, 189, 165, 86, 226, 230, 208, 119, 239, 26, 53, 19, 76, 251, 177, 211, 2, 5, 13, 224, 94, 191, 29, 39, 156, 163, 74, 131, 188, 231, 218, 216, 32, 80, 16, 72, 94, 232, 205, 132, 189, 224, 18, 187, 103, 161, 244, 174, 85, 51, 181, 97, 11, 26, 252, 81, 151, 11, 26, 52, 22, 51, 104, 240, 26, 244, 134, 208, 32, 116, 35, 67, 163, 53, 63, 141, 131, 54, 90, 188, 78, 215, 129, 117, 178, 241, 174, 63, 158, 131, 231, 219, 158, 139, 117, 195, 99, 122, 50, 215, 169, 28, 219, 58, 163, 14, 252, 46, 172, 31, 234, 180, 189, 103, 102, 168, 224, 189, 177, 5, 141, 94, 63, 93, 151, 109, 253, 240, 126, 135, 233, 13, 53, 59, 39, 97, 147, 207, 164, 213, 92, 0, 137, 182, 66, 163, 15, 55, 166, 145, 216, 101, 239, 194, 150, 36, 84, 105, 64, 144, 91, 127, 198, 141, 160, 48, 195, 167, 22, 66, 189, 23, 17, 193, 9, 112, 229, 254, 168, 109, 13, 6, 141, 196, 132, 70, 131, 158, 142, 23, 234, 46, 247, 201, 142, 215, 33, 184, 16, 90, 104, 136, 104, 164, 182, 250, 189, 235, 137, 231, 233, 231, 155, 80, 31, 30, 211, 147, 173, 49, 251, 177, 245, 186, 244, 250, 97, 189, 244, 239, 181, 133, 132, 185, 173, 230, 64, 52, 232, 192, 210, 235, 142, 159, 126, 151, 75, 148, 123, 223, 90, 137, 155, 158, 77, 136, 239, 195, 142, 117, 118, 225, 223, 129, 66, 80, 104, 192, 185, 172, 42, 12, 200, 173, 12, 255, 29, 225, 149, 28, 133, 202, 134, 29, 108, 142, 215, 246, 45, 199, 31, 182, 9, 13, 4, 93, 253, 82, 112, 244, 196, 132, 70, 137, 198, 103, 78, 182, 231, 150, 99, 6, 20, 216, 66, 164, 92, 40, 70, 193, 47, 32, 76, 8, 7, 221, 51, 241, 78, 222, 208, 48, 195, 2, 143, 225, 61, 178, 193, 107, 77, 182, 117, 105, 85, 78, 194, 38, 86, 106, 144, 215, 148, 203, 169, 153, 224, 210, 139, 255, 174, 230, 6, 149, 11, 1, 4, 139, 121, 84, 42, 183, 106, 69, 168, 192, 193, 115, 195, 158, 143, 19, 75, 117, 168, 185, 218, 192, 225, 85, 219, 31, 53, 26, 113, 169, 221, 29, 219, 39, 44, 186, 249, 182, 201, 214, 51, 8, 210, 179, 49, 217, 150, 213, 139, 45, 248, 0, 235, 136, 0, 247, 78, 122, 189, 109, 193, 88, 106, 155, 234, 21, 174, 141, 194, 77, 216, 116, 141, 80, 115, 229, 229, 187, 63, 46, 94, 71, 148, 123, 251, 181, 242, 211, 127, 95, 149, 254, 133, 183, 74, 207, 236, 31, 169, 87, 15, 42, 119, 190, 12, 6, 118, 77, 120, 62, 174, 165, 194, 107, 189, 215, 83, 217, 38, 188, 30, 207, 13, 11, 223, 13, 94, 107, 104, 16, 182, 79, 106, 221, 83, 177, 169, 245, 31, 125, 35, 5, 75, 84, 219, 26, 69, 61, 67, 41, 108, 220, 156, 103, 243, 147, 137, 146, 121, 249, 25, 85, 114, 11, 23, 90, 234, 19, 246, 180, 106, 111, 23, 81, 141, 174, 31, 206, 150, 228, 62, 135, 168, 82, 117, 108, 71, 93, 16, 50, 8, 20, 252, 17, 227, 113, 91, 55, 31, 61, 31, 243, 83, 214, 118, 68, 197, 22, 88, 126, 80, 159, 174, 211, 182, 94, 216, 29, 177, 125, 178, 199, 98, 235, 239, 50, 155, 127, 146, 88, 47, 115, 55, 16, 129, 106, 235, 193, 65, 185, 223, 31, 102, 253, 202, 49, 215, 31, 117, 160, 46, 27, 252, 159, 152, 231, 63, 149, 122, 126, 171, 113, 211, 179, 113, 48, 240, 234, 7, 151, 30, 160, 7, 130, 128, 193, 133, 152, 184, 1, 86, 61, 79, 234, 139, 57, 248, 26, 25, 208, 161, 98, 210, 33, 100, 126, 162, 218, 122, 30, 104, 8, 122, 156, 166, 220, 84, 73, 67, 173, 70, 53, 61, 2, 236, 106, 154, 252, 174, 34, 199, 182, 33, 232, 188, 147, 55, 148, 205, 247, 13, 143, 249, 173, 155, 25, 112, 48, 148, 46, 16, 117, 18, 54, 137, 173, 119, 86, 115, 209, 67, 175, 5, 231, 211, 108, 56, 239, 213, 226, 13, 209, 109, 71, 148, 176, 219, 83, 234, 228, 59, 156, 91, 131, 215, 99, 66, 79, 168, 150, 71, 165, 18, 219, 212, 238, 189, 48, 149, 11, 28, 47, 219, 31, 125, 169, 6, 136, 215, 123, 167, 106, 26, 127, 37, 74, 53, 234, 114, 108, 193, 136, 250, 176, 93, 94, 88, 134, 49, 42, 252, 244, 78, 222, 128, 177, 213, 101, 6, 18, 160, 110, 212, 53, 148, 185, 9, 155, 29, 246, 80, 115, 209, 194, 185, 52, 56, 67, 88, 135, 3, 238, 226, 23, 246, 126, 196, 230, 73, 124, 197, 58, 35, 190, 137, 186, 150, 24, 185, 123, 225, 159, 164, 42, 185, 225, 55, 126, 131, 198, 224, 109, 92, 104, 52, 102, 195, 193, 39, 49, 186, 253, 248, 169, 159, 143, 134, 164, 7, 137, 245, 132, 70, 111, 235, 25, 69, 5, 235, 101, 171, 31, 235, 166, 39, 51, 40, 74, 65, 125, 120, 95, 188, 176, 13, 216, 46, 212, 133, 109, 196, 238, 17, 126, 154, 176, 30, 222, 117, 193, 123, 107, 174, 27, 234, 194, 107, 245, 186, 161, 46, 91, 208, 96, 61, 194, 172, 119, 179, 115, 19, 54, 56, 15, 38, 98, 8, 5, 219, 141, 175, 16, 18, 65, 47, 53, 128, 182, 49, 71, 171, 185, 65, 168, 163, 22, 129, 147, 24, 245, 25, 53, 231, 22, 26, 150, 25, 36, 160, 63, 181, 1, 13, 166, 84, 47, 72, 135, 140, 249, 137, 13, 97, 198, 118, 162, 134, 245, 195, 20, 150, 223, 58, 163, 46, 219, 54, 106, 230, 123, 132, 247, 205, 118, 88, 31, 74, 173, 27, 94, 55, 84, 198, 106, 52, 55, 99, 54, 35, 54, 45, 244, 110, 62, 169, 74, 213, 243, 11, 26, 205, 12, 137, 182, 125, 15, 149, 246, 163, 206, 146, 246, 175, 78, 145, 196, 174, 251, 168, 165, 3, 252, 2, 165, 22, 129, 19, 213, 5, 152, 97, 249, 5, 9, 120, 119, 129, 240, 60, 219, 39, 117, 41, 149, 14, 172, 134, 133, 223, 19, 102, 189, 202, 65, 93, 126, 39, 218, 249, 241, 219, 86, 244, 78, 240, 254, 6, 173, 11, 117, 248, 253, 127, 180, 50, 39, 97, 3, 201, 189, 198, 168, 185, 234, 148, 11, 26, 240, 94, 39, 213, 121, 250, 79, 100, 216, 15, 174, 151, 142, 99, 167, 22, 47, 107, 24, 62, 227, 118, 73, 141, 59, 94, 61, 58, 112, 136, 220, 79, 212, 129, 147, 220, 115, 180, 154, 115, 15, 13, 193, 175, 231, 226, 221, 93, 64, 195, 65, 163, 42, 215, 91, 193, 227, 104, 172, 46, 130, 6, 244, 250, 135, 9, 135, 114, 80, 151, 222, 214, 82, 245, 226, 113, 28, 33, 43, 181, 173, 232, 61, 234, 51, 164, 253, 234, 210, 219, 224, 42, 160, 27, 141, 147, 67, 223, 144, 93, 250, 172, 172, 153, 57, 216, 200, 43, 17, 36, 104, 188, 55, 190, 138, 111, 59, 74, 54, 184, 98, 253, 27, 141, 103, 95, 89, 34, 107, 166, 15, 92, 59, 133, 32, 169, 228, 107, 98, 194, 194, 21, 236, 93, 231, 255, 78, 149, 154, 135, 222, 21, 192, 164, 27, 81, 189, 27, 138, 94, 31, 208, 235, 84, 42, 44, 130, 50, 183, 85, 79, 149, 194, 238, 24, 234, 194, 251, 21, 197, 250, 53, 59, 103, 97, 3, 171, 207, 57, 76, 114, 43, 94, 81, 165, 112, 16, 10, 165, 174, 226, 6, 243, 14, 123, 109, 7, 30, 33, 195, 206, 178, 156, 188, 247, 222, 155, 178, 122, 218, 96, 131, 113, 17, 56, 157, 147, 47, 149, 212, 33, 39, 168, 18, 209, 208, 227, 108, 55, 10, 82, 163, 191, 174, 230, 194, 67, 175, 166, 148, 106, 110, 229, 137, 0, 9, 114, 19, 117, 236, 82, 85, 2, 151, 40, 180, 141, 62, 82, 149, 136, 134, 38, 183, 97, 51, 110, 98, 161, 229, 133, 188, 200, 82, 41, 117, 43, 135, 40, 238, 25, 28, 36, 112, 114, 171, 42, 235, 213, 180, 141, 159, 88, 8, 156, 16, 215, 135, 17, 181, 32, 167, 97, 19, 27, 177, 137, 180, 79, 56, 69, 149, 194, 241, 187, 179, 94, 20, 65, 163, 149, 10, 28, 60, 134, 175, 132, 169, 68, 251, 132, 147, 213, 28, 209, 208, 229, 52, 108, 32, 117, 248, 100, 53, 23, 14, 26, 187, 247, 155, 44, 33, 202, 160, 209, 116, 224, 120, 47, 212, 196, 188, 249, 221, 224, 65, 165, 190, 56, 73, 226, 91, 173, 127, 63, 96, 162, 161, 198, 233, 0, 177, 214, 123, 219, 85, 210, 119, 247, 117, 170, 20, 14, 206, 248, 197, 137, 120, 8, 128, 114, 65, 19, 116, 128, 216, 15, 198, 105, 108, 189, 169, 192, 146, 109, 178, 193, 213, 11, 37, 190, 201, 86, 106, 1, 209, 208, 229, 188, 103, 3, 29, 199, 76, 149, 248, 150, 235, 95, 12, 23, 4, 238, 247, 171, 111, 3, 81, 107, 85, 5, 77, 65, 199, 113, 103, 51, 104, 136, 148, 186, 132, 13, 238, 86, 215, 113, 226, 121, 170, 16, 94, 181, 33, 224, 2, 110, 218, 222, 254, 149, 111, 169, 18, 17, 213, 39, 108, 10, 218, 246, 159, 32, 169, 195, 236, 215, 148, 68, 37, 247, 110, 248, 219, 87, 70, 165, 227, 148, 139, 212, 28, 17, 65, 221, 194, 6, 58, 11, 13, 50, 185, 219, 126, 170, 20, 61, 124, 199, 120, 255, 252, 155, 84, 105, 80, 124, 139, 237, 213, 92, 109, 116, 158, 113, 89, 164, 215, 130, 17, 181, 130, 186, 12, 16, 123, 229, 222, 123, 163, 120, 39, 191, 220, 7, 193, 191, 87, 42, 172, 228, 94, 7, 23, 175, 184, 198, 23, 223, 73, 97, 115, 243, 31, 173, 148, 190, 123, 127, 171, 30, 141, 86, 251, 17, 223, 148, 142, 147, 42, 223, 69, 36, 106, 85, 117, 15, 27, 200, 188, 252, 180, 172, 189, 236, 148, 194, 76, 191, 90, 210, 156, 82, 99, 142, 150, 206, 111, 95, 169, 74, 68, 228, 85, 215, 221, 40, 45, 185, 219, 254, 210, 117, 246, 172, 226, 192, 113, 179, 194, 97, 118, 6, 13, 145, 191, 134, 105, 221, 201, 189, 15, 150, 174, 115, 231, 14, 236, 234, 52, 25, 244, 104, 108, 231, 243, 16, 209, 160, 134, 216, 141, 242, 202, 46, 127, 81, 186, 175, 155, 86, 252, 154, 150, 102, 128, 195, 219, 29, 39, 158, 171, 74, 68, 228, 167, 225, 194, 6, 240, 221, 81, 61, 179, 207, 151, 244, 83, 247, 171, 37, 13, 40, 22, 147, 206, 201, 151, 73, 106, 124, 117, 247, 232, 33, 26, 42, 26, 50, 108, 52, 28, 49, 234, 189, 241, 167, 170, 212, 56, 240, 93, 228, 56, 143, 38, 49, 178, 54, 55, 114, 39, 106, 69, 13, 29, 54, 144, 125, 115, 169, 244, 221, 122, 165, 164, 23, 63, 168, 150, 212, 81, 91, 187, 116, 28, 55, 173, 120, 120, 155, 136, 194, 105, 248, 176, 209, 210, 79, 221, 39, 125, 247, 204, 146, 236, 107, 207, 171, 37, 110, 165, 190, 116, 178, 180, 31, 249, 93, 137, 111, 188, 133, 90, 66, 68, 97, 52, 77, 216, 104, 233, 39, 238, 149, 254, 249, 55, 174, 115, 83, 243, 90, 137, 117, 116, 73, 106, 252, 196, 98, 208, 196, 183, 28, 169, 150, 18, 81, 37, 154, 46, 108, 52, 92, 138, 144, 126, 252, 30, 73, 63, 253, 64, 241, 44, 228, 40, 225, 140, 227, 182, 3, 14, 151, 20, 110, 229, 153, 76, 169, 165, 68, 84, 141, 166, 13, 27, 47, 4, 79, 230, 165, 199, 139, 223, 224, 128, 221, 172, 220, 251, 239, 168, 71, 2, 136, 39, 138, 223, 216, 137, 203, 25, 240, 189, 78, 248, 186, 149, 88, 215, 134, 234, 65, 34, 138, 74, 75, 132, 141, 41, 191, 250, 131, 226, 21, 223, 8, 157, 252, 234, 247, 37, 223, 179, 70, 36, 147, 46, 108, 109, 92, 36, 213, 81, 8, 147, 17, 18, 223, 104, 243, 226, 205, 177, 226, 53, 252, 30, 114, 34, 26, 212, 146, 97, 67, 68, 141, 167, 121, 47, 70, 34, 162, 166, 194, 176, 33, 34, 39, 24, 54, 68, 228, 4, 195, 134, 136, 156, 96, 216, 16, 145, 19, 12, 27, 34, 114, 130, 97, 67, 68, 78, 48, 108, 136, 200, 9, 134, 13, 17, 57, 193, 176, 33, 34, 39, 24, 54, 68, 228, 4, 195, 134, 136, 156, 96, 216, 16, 145, 19, 12, 27, 34, 114, 130, 97, 67, 68, 78, 196, 222, 126, 107, 5, 239, 103, 67, 68, 53, 23, 187, 75, 250, 25, 54, 77, 228, 253, 196, 219, 242, 78, 219, 50, 233, 143, 245, 168, 37, 68, 205, 129, 187, 81, 77, 132, 65, 67, 205, 75, 228, 255, 109, 76, 38, 177, 80, 147, 243, 22, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130]
                    }
                },
            },
            new()
            {
                LanguageName = ContentLanguageSamples.SampleContentLanguageEnGb.ContentLanguageName!,
                DisplayName = "Event sample 2024 - en-GB",
                VersionStatus = VersionStatus.Published,
                UserGuid = UserSamples.SampleAdminGuid,
                ContentItemData = new Dictionary<string, object?>
                {
                    ["EventTitle"] = "en-GB Event sample 2024",
                    ["EventText"] = "en-GB Event sample 2024 (reusable)",
                    ["EventDate"] = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                    ["EventRecurrentYearly"] = true,
                    ["EventTeaser"] = new AssetUrlSource
                    {
                        ContentItemGuid = SampleEvent2024ContentItemGuid,
                        Identifier = new Guid("28337E24-59EF-4F93-B345-F4998CBBD72B"),
                        Name = "urlSourceSample.jpg",
                        Extension = ".jpg",
                        Size = null,
                        LastModified = null,
                        Url = "https://devnet.kentico.com/DevNet/media/devnet/cms_screen.jpg"
                    },
                },
                ScheduledUnpublishWhen = new DateTime(2045, 1, 1, 0, 0, 0, 0, 0, DateTimeKind.Utc)
            }
        ],
    };

    [Sample("ContentItemSimplifiedModel.Sample.EventInSampleWorkspace", "This sample describes how to import reusable content item into non-default workspace", "Reusable content item sample in non-default workspace")]
    public static ContentItemSimplifiedModel EventInSampleWorkspace => new()
    {
        ContentItemGUID = EventInSampleWorkspaceGuid,
        Name = "EventInSampleWorkspace",
        IsSecured = false,
        ContentTypeName = DataClassSamples.EventDataClass.ClassName,
        IsReusable = true,
        ContentItemWorkspaceGUID = WorkspaceSamples.SampleWorkspaceGuid,
        LanguageData =
        [
            new()
            {
                LanguageName = ContentLanguageSamples.SampleContentLanguageEnUs.ContentLanguageName!,
                DisplayName = "Sample workspace Event - en-US",
                VersionStatus = VersionStatus.Published,
                UserGuid = UserSamples.SampleAdminGuid,
                ContentItemData = new Dictionary<string, object?>
                {
                    ["EventTitle"] = "en-US Sample workspace Event",
                    ["EventText"] = "en-US Sample workspace Event (reusable)",
                    ["EventDate"] = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                    ["EventRecurrentYearly"] = true,
                    ["EventTeaser"] = new AssetDataSource
                    {
                        ContentItemGuid = EventInSampleWorkspaceGuid,
                        Identifier = new Guid("57C26660-EF2F-4288-8F30-886135C2C8FB"),
                        Name = "byteArraySample.jpg",
                        Extension = ".jpg",
                        Size = null,
                        LastModified = null,
                        Data = [137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 1, 27, 0, 0, 0, 101, 8, 6, 0, 0, 0, 125, 114, 71, 36, 0, 0, 0, 1, 115, 82, 71, 66, 0, 174, 206, 28, 233, 0, 0, 0, 4, 103, 65, 77, 65, 0, 0, 177, 143, 11, 252, 97, 5, 0, 0, 0, 9, 112, 72, 89, 115, 0, 0, 14, 195, 0, 0, 14, 195, 1, 199, 111, 168, 100, 0, 0, 16, 4, 73, 68, 65, 84, 120, 94, 237, 221, 9, 144, 28, 85, 29, 6, 240, 255, 28, 59, 187, 155, 13, 225, 190, 33, 92, 65, 64, 5, 4, 65, 64, 19, 146, 128, 6, 11, 84, 228, 12, 144, 226, 50, 104, 84, 10, 77, 208, 226, 80, 32, 137, 28, 22, 96, 129, 160, 168, 33, 86, 37, 168, 225, 190, 20, 17, 68, 67, 18, 238, 51, 6, 57, 148, 8, 36, 28, 145, 35, 145, 43, 201, 94, 115, 57, 223, 236, 123, 181, 157, 151, 215, 51, 221, 51, 61, 111, 142, 253, 126, 85, 157, 237, 215, 51, 243, 182, 123, 178, 239, 155, 215, 175, 143, 137, 229, 11, 132, 136, 168, 198, 226, 234, 39, 17, 81, 77, 49, 108, 136, 200, 9, 134, 13, 17, 57, 193, 176, 33, 34, 39, 24, 54, 68, 228, 4, 195, 134, 136, 156, 96, 216, 16, 145, 19, 12, 27, 34, 114, 130, 97, 67, 68, 78, 48, 108, 136, 200, 9, 134, 13, 17, 57, 193, 176, 33, 34, 39, 24, 54, 68, 228, 68, 75, 93, 245, 157, 125, 101, 137, 100, 151, 191, 32, 217, 55, 255, 35, 185, 119, 151, 75, 238, 127, 111, 75, 126, 245, 251, 146, 239, 89, 35, 146, 73, 23, 182, 54, 46, 177, 84, 135, 196, 134, 111, 40, 177, 141, 54, 151, 248, 102, 219, 73, 124, 155, 93, 36, 49, 114, 119, 73, 140, 218, 91, 226, 155, 108, 173, 106, 34, 162, 168, 53, 117, 216, 228, 63, 90, 37, 233, 103, 30, 144, 204, 146, 133, 146, 121, 241, 49, 201, 247, 245, 168, 71, 42, 147, 216, 118, 148, 36, 247, 28, 35, 201, 125, 15, 149, 228, 167, 14, 82, 75, 137, 40, 10, 77, 25, 54, 233, 197, 15, 74, 250, 161, 219, 37, 253, 244, 95, 213, 146, 232, 197, 183, 216, 94, 218, 70, 31, 37, 169, 113, 199, 75, 124, 83, 246, 120, 136, 170, 213, 84, 97, 147, 126, 228, 46, 233, 187, 111, 78, 97, 87, 233, 69, 181, 196, 141, 212, 33, 39, 72, 251, 225, 147, 37, 190, 245, 206, 106, 9, 17, 133, 213, 20, 97, 147, 121, 110, 145, 244, 222, 249, 11, 201, 190, 242, 15, 181, 164, 62, 218, 15, 63, 67, 218, 143, 157, 42, 177, 246, 78, 181, 132, 136, 130, 106, 232, 176, 193, 192, 110, 239, 188, 203, 164, 127, 193, 45, 106, 73, 253, 197, 55, 217, 74, 58, 78, 60, 87, 218, 62, 255, 53, 181, 132, 136, 130, 104, 216, 176, 193, 160, 111, 207, 156, 139, 36, 183, 106, 133, 90, 210, 88, 176, 107, 213, 249, 141, 139, 11, 239, 32, 207, 30, 32, 10, 162, 33, 195, 166, 239, 158, 89, 210, 123, 243, 21, 170, 212, 184, 18, 59, 239, 41, 157, 83, 174, 148, 196, 118, 187, 170, 37, 68, 228, 167, 225, 194, 166, 103, 238, 116, 233, 255, 219, 31, 84, 169, 241, 197, 186, 54, 148, 97, 103, 93, 43, 201, 61, 71, 171, 37, 68, 100, 211, 80, 97, 211, 253, 171, 179, 37, 253, 232, 31, 85, 169, 185, 12, 155, 246, 107, 105, 219, 111, 130, 42, 17, 145, 169, 97, 6, 28, 154, 57, 104, 160, 251, 234, 239, 72, 102, 241, 124, 85, 34, 34, 83, 67, 132, 77, 207, 220, 25, 53, 13, 154, 248, 230, 219, 21, 167, 90, 91, 123, 205, 153, 146, 93, 186, 88, 149, 136, 200, 171, 238, 187, 81, 125, 127, 190, 94, 122, 111, 186, 92, 149, 162, 149, 58, 248, 24, 233, 156, 178, 238, 64, 115, 223, 157, 215, 74, 255, 67, 119, 72, 110, 229, 91, 106, 73, 180, 16, 106, 195, 103, 220, 94, 188, 246, 138, 136, 6, 213, 181, 103, 83, 60, 89, 175, 70, 65, 227, 167, 253, 232, 239, 21, 67, 168, 86, 16, 98, 221, 179, 207, 83, 37, 34, 210, 234, 22, 54, 249, 222, 181, 210, 51, 103, 186, 42, 185, 149, 216, 227, 115, 106, 174, 54, 112, 142, 80, 223, 221, 215, 169, 18, 17, 65, 221, 194, 6, 103, 6, 231, 86, 190, 169, 74, 110, 225, 214, 18, 181, 214, 123, 219, 85, 146, 125, 237, 159, 170, 68, 68, 117, 9, 155, 204, 243, 15, 75, 255, 131, 55, 171, 82, 227, 194, 238, 86, 199, 49, 223, 87, 165, 240, 122, 111, 249, 153, 154, 35, 162, 186, 132, 77, 239, 157, 215, 170, 185, 240, 208, 248, 49, 213, 114, 220, 5, 244, 224, 50, 198, 120, 42, 13, 156, 204, 11, 143, 74, 250, 145, 187, 85, 137, 104, 104, 115, 30, 54, 233, 71, 255, 84, 209, 225, 97, 28, 229, 233, 186, 96, 94, 177, 241, 99, 66, 16, 108, 240, 243, 69, 53, 57, 164, 109, 30, 197, 170, 102, 80, 25, 151, 94, 16, 81, 29, 194, 166, 239, 254, 57, 106, 46, 156, 206, 41, 151, 75, 114, 143, 3, 85, 105, 64, 49, 128, 126, 60, 47, 210, 192, 49, 131, 70, 67, 224, 84, 34, 251, 214, 82, 233, 127, 248, 46, 85, 34, 26, 186, 156, 134, 13, 142, 210, 84, 50, 104, 138, 198, 111, 6, 141, 22, 101, 224, 248, 5, 13, 160, 254, 74, 127, 71, 255, 252, 121, 106, 142, 104, 232, 114, 122, 82, 95, 247, 181, 103, 73, 250, 201, 191, 168, 82, 112, 104, 228, 182, 158, 141, 23, 206, 111, 89, 123, 233, 164, 117, 78, 214, 243, 11, 15, 60, 103, 245, 212, 177, 170, 52, 160, 84, 208, 104, 31, 77, 218, 69, 205, 133, 55, 124, 250, 109, 146, 248, 196, 190, 170, 20, 141, 185, 115, 231, 202, 162, 69, 139, 84, 105, 192, 216, 177, 99, 229, 180, 211, 78, 83, 165, 117, 45, 95, 190, 92, 102, 206, 156, 169, 74, 235, 154, 62, 125, 186, 236, 184, 227, 142, 170, 212, 252, 78, 63, 253, 116, 89, 184, 112, 97, 113, 155, 176, 109, 227, 198, 141, 83, 143, 80, 189, 56, 11, 155, 252, 154, 15, 229, 227, 41, 159, 85, 165, 240, 42, 9, 156, 228, 30, 7, 72, 215, 5, 55, 22, 231, 189, 204, 176, 9, 18, 52, 107, 47, 57, 73, 50, 255, 122, 82, 149, 194, 75, 77, 56, 69, 58, 79, 141, 246, 188, 34, 52, 40, 4, 142, 23, 26, 214, 140, 25, 51, 84, 105, 93, 227, 199, 143, 47, 54, 64, 211, 130, 5, 11, 90, 170, 49, 218, 222, 151, 101, 203, 150, 181, 84, 152, 54, 35, 103, 187, 81, 248, 22, 132, 106, 32, 32, 122, 102, 157, 91, 104, 240, 79, 168, 37, 235, 67, 32, 97, 151, 74, 67, 56, 232, 224, 241, 74, 63, 124, 167, 154, 27, 8, 164, 114, 65, 211, 51, 235, 156, 170, 130, 6, 50, 53, 188, 57, 123, 16, 8, 32, 91, 208, 52, 203, 167, 62, 214, 221, 156, 108, 208, 123, 51, 131, 6, 16, 64, 84, 95, 206, 194, 6, 227, 53, 213, 10, 26, 56, 232, 169, 104, 232, 233, 224, 249, 120, 237, 192, 235, 207, 145, 222, 59, 174, 81, 143, 14, 140, 7, 149, 130, 231, 227, 90, 170, 106, 229, 62, 120, 183, 110, 23, 105, 162, 97, 218, 118, 159, 16, 50, 126, 189, 160, 70, 130, 245, 71, 175, 204, 59, 221, 112, 195, 13, 234, 81, 106, 22, 238, 194, 230, 197, 199, 212, 92, 117, 130, 6, 142, 134, 231, 175, 189, 100, 82, 113, 183, 9, 147, 25, 28, 222, 231, 154, 162, 10, 26, 45, 243, 210, 227, 106, 206, 29, 124, 210, 163, 113, 154, 176, 75, 129, 221, 167, 86, 131, 237, 178, 237, 46, 97, 44, 139, 234, 203, 73, 216, 100, 151, 189, 32, 249, 238, 213, 170, 84, 189, 114, 129, 147, 121, 201, 63, 136, 76, 126, 117, 68, 29, 52, 144, 89, 250, 172, 154, 115, 199, 111, 247, 97, 206, 156, 202, 78, 65, 104, 6, 230, 24, 84, 169, 113, 44, 114, 199, 77, 216, 212, 224, 123, 158, 252, 2, 7, 183, 144, 8, 51, 190, 130, 58, 80, 151, 87, 45, 130, 6, 178, 203, 158, 87, 115, 110, 248, 141, 211, 180, 218, 128, 176, 73, 247, 218, 112, 236, 3, 19, 131, 166, 49, 56, 57, 26, 213, 251, 251, 139, 165, 239, 254, 245, 7, 237, 162, 128, 221, 32, 12, 242, 226, 39, 2, 194, 12, 142, 32, 162, 168, 35, 168, 13, 126, 249, 152, 196, 55, 222, 82, 149, 170, 83, 234, 104, 148, 30, 231, 48, 5, 253, 148, 247, 14, 180, 226, 240, 58, 202, 122, 23, 165, 212, 225, 117, 192, 235, 204, 67, 242, 167, 158, 122, 234, 58, 99, 68, 186, 78, 192, 114, 172, 151, 185, 251, 131, 231, 190, 254, 250, 235, 197, 231, 153, 161, 137, 231, 154, 189, 23, 253, 122, 219, 239, 183, 213, 175, 233, 109, 213, 191, 203, 187, 94, 80, 234, 181, 38, 172, 39, 38, 212, 133, 159, 168, 11, 245, 224, 245, 59, 236, 176, 67, 241, 125, 11, 90, 87, 171, 113, 18, 54, 107, 175, 60, 67, 50, 75, 234, 51, 62, 128, 0, 193, 128, 113, 108, 179, 109, 37, 191, 106, 69, 113, 23, 171, 218, 35, 75, 213, 232, 186, 240, 38, 73, 238, 30, 205, 45, 46, 252, 194, 6, 127, 208, 59, 237, 180, 147, 90, 50, 8, 127, 244, 65, 198, 105, 208, 200, 253, 206, 199, 209, 208, 96, 16, 32, 182, 224, 178, 173, 23, 118, 219, 16, 0, 230, 114, 205, 86, 31, 194, 210, 12, 25, 63, 222, 222, 154, 237, 247, 251, 245, 230, 170, 221, 86, 47, 219, 239, 181, 193, 123, 81, 42, 172, 91, 149, 147, 176, 89, 115, 254, 17, 146, 125, 227, 223, 170, 20, 76, 172, 115, 184, 36, 63, 253, 5, 145, 82, 223, 62, 217, 189, 90, 210, 207, 21, 62, 193, 178, 25, 181, 96, 93, 126, 231, 217, 160, 247, 130, 221, 45, 191, 30, 140, 238, 233, 4, 225, 119, 120, 221, 207, 176, 51, 175, 142, 236, 11, 238, 252, 194, 6, 141, 218, 214, 19, 192, 185, 38, 229, 132, 105, 224, 128, 70, 99, 142, 255, 216, 214, 11, 191, 95, 247, 24, 252, 224, 57, 168, 75, 135, 66, 173, 195, 38, 236, 182, 226, 245, 182, 176, 198, 118, 161, 174, 114, 219, 231, 133, 247, 45, 76, 143, 169, 21, 56, 9, 155, 143, 207, 60, 72, 242, 31, 190, 167, 74, 229, 37, 119, 223, 95, 134, 77, 251, 141, 196, 134, 111, 164, 150, 248, 203, 127, 184, 82, 186, 175, 155, 186, 222, 160, 48, 2, 3, 23, 106, 250, 65, 216, 120, 15, 129, 107, 184, 194, 59, 204, 117, 80, 126, 245, 248, 233, 56, 249, 66, 105, 255, 114, 52, 159, 106, 97, 26, 181, 223, 39, 187, 151, 237, 83, 30, 245, 225, 83, 29, 63, 117, 136, 153, 245, 155, 117, 7, 253, 132, 183, 241, 134, 87, 45, 195, 6, 143, 227, 121, 97, 217, 194, 53, 108, 104, 105, 8, 155, 114, 189, 165, 86, 226, 230, 208, 119, 239, 26, 53, 19, 76, 251, 177, 211, 2, 5, 13, 224, 94, 191, 29, 39, 156, 163, 74, 131, 188, 231, 218, 216, 32, 80, 16, 72, 94, 232, 205, 132, 189, 224, 18, 187, 103, 161, 244, 174, 85, 51, 181, 97, 11, 26, 252, 81, 151, 11, 26, 52, 22, 51, 104, 240, 26, 244, 134, 208, 32, 116, 35, 67, 163, 53, 63, 141, 131, 54, 90, 188, 78, 215, 129, 117, 178, 241, 174, 63, 158, 131, 231, 219, 158, 139, 117, 195, 99, 122, 50, 215, 169, 28, 219, 58, 163, 14, 252, 46, 172, 31, 234, 180, 189, 103, 102, 168, 224, 189, 177, 5, 141, 94, 63, 93, 151, 109, 253, 240, 126, 135, 233, 13, 53, 59, 39, 97, 147, 207, 164, 213, 92, 0, 137, 182, 66, 163, 15, 55, 166, 145, 216, 101, 239, 194, 150, 36, 84, 105, 64, 144, 91, 127, 198, 141, 160, 48, 195, 167, 22, 66, 189, 23, 17, 193, 9, 112, 229, 254, 168, 109, 13, 6, 141, 196, 132, 70, 131, 158, 142, 23, 234, 46, 247, 201, 142, 215, 33, 184, 16, 90, 104, 136, 104, 164, 182, 250, 189, 235, 137, 231, 233, 231, 155, 80, 31, 30, 211, 147, 173, 49, 251, 177, 245, 186, 244, 250, 97, 189, 244, 239, 181, 133, 132, 185, 173, 230, 64, 52, 232, 192, 210, 235, 142, 159, 126, 151, 75, 148, 123, 223, 90, 137, 155, 158, 77, 136, 239, 195, 142, 117, 118, 225, 223, 129, 66, 80, 104, 192, 185, 172, 42, 12, 200, 173, 12, 255, 29, 225, 149, 28, 133, 202, 134, 29, 108, 142, 215, 246, 45, 199, 31, 182, 9, 13, 4, 93, 253, 82, 112, 244, 196, 132, 70, 137, 198, 103, 78, 182, 231, 150, 99, 6, 20, 216, 66, 164, 92, 40, 70, 193, 47, 32, 76, 8, 7, 221, 51, 241, 78, 222, 208, 48, 195, 2, 143, 225, 61, 178, 193, 107, 77, 182, 117, 105, 85, 78, 194, 38, 86, 106, 144, 215, 148, 203, 169, 153, 224, 210, 139, 255, 174, 230, 6, 149, 11, 1, 4, 139, 121, 84, 42, 183, 106, 69, 168, 192, 193, 115, 195, 158, 143, 19, 75, 117, 168, 185, 218, 192, 225, 85, 219, 31, 53, 26, 113, 169, 221, 29, 219, 39, 44, 186, 249, 182, 201, 214, 51, 8, 210, 179, 49, 217, 150, 213, 139, 45, 248, 0, 235, 136, 0, 247, 78, 122, 189, 109, 193, 88, 106, 155, 234, 21, 174, 141, 194, 77, 216, 116, 141, 80, 115, 229, 229, 187, 63, 46, 94, 71, 148, 123, 251, 181, 242, 211, 127, 95, 149, 254, 133, 183, 74, 207, 236, 31, 169, 87, 15, 42, 119, 190, 12, 6, 118, 77, 120, 62, 174, 165, 194, 107, 189, 215, 83, 217, 38, 188, 30, 207, 13, 11, 223, 13, 94, 107, 104, 16, 182, 79, 106, 221, 83, 177, 169, 245, 31, 125, 35, 5, 75, 84, 219, 26, 69, 61, 67, 41, 108, 220, 156, 103, 243, 147, 137, 146, 121, 249, 25, 85, 114, 11, 23, 90, 234, 19, 246, 180, 106, 111, 23, 81, 141, 174, 31, 206, 150, 228, 62, 135, 168, 82, 117, 108, 71, 93, 16, 50, 8, 20, 252, 17, 227, 113, 91, 55, 31, 61, 31, 243, 83, 214, 118, 68, 197, 22, 88, 126, 80, 159, 174, 211, 182, 94, 216, 29, 177, 125, 178, 199, 98, 235, 239, 50, 155, 127, 146, 88, 47, 115, 55, 16, 129, 106, 235, 193, 65, 185, 223, 31, 102, 253, 202, 49, 215, 31, 117, 160, 46, 27, 252, 159, 152, 231, 63, 149, 122, 126, 171, 113, 211, 179, 113, 48, 240, 234, 7, 151, 30, 160, 7, 130, 128, 193, 133, 152, 184, 1, 86, 61, 79, 234, 139, 57, 248, 26, 25, 208, 161, 98, 210, 33, 100, 126, 162, 218, 122, 30, 104, 8, 122, 156, 166, 220, 84, 73, 67, 173, 70, 53, 61, 2, 236, 106, 154, 252, 174, 34, 199, 182, 33, 232, 188, 147, 55, 148, 205, 247, 13, 143, 249, 173, 155, 25, 112, 48, 148, 46, 16, 117, 18, 54, 137, 173, 119, 86, 115, 209, 67, 175, 5, 231, 211, 108, 56, 239, 213, 226, 13, 209, 109, 71, 148, 176, 219, 83, 234, 228, 59, 156, 91, 131, 215, 99, 66, 79, 168, 150, 71, 165, 18, 219, 212, 238, 189, 48, 149, 11, 28, 47, 219, 31, 125, 169, 6, 136, 215, 123, 167, 106, 26, 127, 37, 74, 53, 234, 114, 108, 193, 136, 250, 176, 93, 94, 88, 134, 49, 42, 252, 244, 78, 222, 128, 177, 213, 101, 6, 18, 160, 110, 212, 53, 148, 185, 9, 155, 29, 246, 80, 115, 209, 194, 185, 52, 56, 67, 88, 135, 3, 238, 226, 23, 246, 126, 196, 230, 73, 124, 197, 58, 35, 190, 137, 186, 150, 24, 185, 123, 225, 159, 164, 42, 185, 225, 55, 126, 131, 198, 224, 109, 92, 104, 52, 102, 195, 193, 39, 49, 186, 253, 248, 169, 159, 143, 134, 164, 7, 137, 245, 132, 70, 111, 235, 25, 69, 5, 235, 101, 171, 31, 235, 166, 39, 51, 40, 74, 65, 125, 120, 95, 188, 176, 13, 216, 46, 212, 133, 109, 196, 238, 17, 126, 154, 176, 30, 222, 117, 193, 123, 107, 174, 27, 234, 194, 107, 245, 186, 161, 46, 91, 208, 96, 61, 194, 172, 119, 179, 115, 19, 54, 56, 15, 38, 98, 8, 5, 219, 141, 175, 16, 18, 65, 47, 53, 128, 182, 49, 71, 171, 185, 65, 168, 163, 22, 129, 147, 24, 245, 25, 53, 231, 22, 26, 150, 25, 36, 160, 63, 181, 1, 13, 166, 84, 47, 72, 135, 140, 249, 137, 13, 97, 198, 118, 162, 134, 245, 195, 20, 150, 223, 58, 163, 46, 219, 54, 106, 230, 123, 132, 247, 205, 118, 88, 31, 74, 173, 27, 94, 55, 84, 198, 106, 52, 55, 99, 54, 35, 54, 45, 244, 110, 62, 169, 74, 213, 243, 11, 26, 205, 12, 137, 182, 125, 15, 149, 246, 163, 206, 146, 246, 175, 78, 145, 196, 174, 251, 168, 165, 3, 252, 2, 165, 22, 129, 19, 213, 5, 152, 97, 249, 5, 9, 120, 119, 129, 240, 60, 219, 39, 117, 41, 149, 14, 172, 134, 133, 223, 19, 102, 189, 202, 65, 93, 126, 39, 218, 249, 241, 219, 86, 244, 78, 240, 254, 6, 173, 11, 117, 248, 253, 127, 180, 50, 39, 97, 3, 201, 189, 198, 168, 185, 234, 148, 11, 26, 240, 94, 39, 213, 121, 250, 79, 100, 216, 15, 174, 151, 142, 99, 167, 22, 47, 107, 24, 62, 227, 118, 73, 141, 59, 94, 61, 58, 112, 136, 220, 79, 212, 129, 147, 220, 115, 180, 154, 115, 15, 13, 193, 175, 231, 226, 221, 93, 64, 195, 65, 163, 42, 215, 91, 193, 227, 104, 172, 46, 130, 6, 244, 250, 135, 9, 135, 114, 80, 151, 222, 214, 82, 245, 226, 113, 28, 33, 43, 181, 173, 232, 61, 234, 51, 164, 253, 234, 210, 219, 224, 42, 160, 27, 141, 147, 67, 223, 144, 93, 250, 172, 172, 153, 57, 216, 200, 43, 17, 36, 104, 188, 55, 190, 138, 111, 59, 74, 54, 184, 98, 253, 27, 141, 103, 95, 89, 34, 107, 166, 15, 92, 59, 133, 32, 169, 228, 107, 98, 194, 194, 21, 236, 93, 231, 255, 78, 149, 154, 135, 222, 21, 192, 164, 27, 81, 189, 27, 138, 94, 31, 208, 235, 84, 42, 44, 130, 50, 183, 85, 79, 149, 194, 238, 24, 234, 194, 251, 21, 197, 250, 53, 59, 103, 97, 3, 171, 207, 57, 76, 114, 43, 94, 81, 165, 112, 16, 10, 165, 174, 226, 6, 243, 14, 123, 109, 7, 30, 33, 195, 206, 178, 156, 188, 247, 222, 155, 178, 122, 218, 96, 131, 113, 17, 56, 157, 147, 47, 149, 212, 33, 39, 168, 18, 209, 208, 227, 108, 55, 10, 82, 163, 191, 174, 230, 194, 67, 175, 166, 148, 106, 110, 229, 137, 0, 9, 114, 19, 117, 236, 82, 85, 2, 151, 40, 180, 141, 62, 82, 149, 136, 134, 38, 183, 97, 51, 110, 98, 161, 229, 133, 188, 200, 82, 41, 117, 43, 135, 40, 238, 25, 28, 36, 112, 114, 171, 42, 235, 213, 180, 141, 159, 88, 8, 156, 16, 215, 135, 17, 181, 32, 167, 97, 19, 27, 177, 137, 180, 79, 56, 69, 149, 194, 241, 187, 179, 94, 20, 65, 163, 149, 10, 28, 60, 134, 175, 132, 169, 68, 251, 132, 147, 213, 28, 209, 208, 229, 52, 108, 32, 117, 248, 100, 53, 23, 14, 26, 187, 247, 155, 44, 33, 202, 160, 209, 116, 224, 120, 47, 212, 196, 188, 249, 221, 224, 65, 165, 190, 56, 73, 226, 91, 173, 127, 63, 96, 162, 161, 198, 233, 0, 177, 214, 123, 219, 85, 210, 119, 247, 117, 170, 20, 14, 206, 248, 197, 137, 120, 8, 128, 114, 65, 19, 116, 128, 216, 15, 198, 105, 108, 189, 169, 192, 146, 109, 178, 193, 213, 11, 37, 190, 201, 86, 106, 1, 209, 208, 229, 188, 103, 3, 29, 199, 76, 149, 248, 150, 235, 95, 12, 23, 4, 238, 247, 171, 111, 3, 81, 107, 85, 5, 77, 65, 199, 113, 103, 51, 104, 136, 148, 186, 132, 13, 238, 86, 215, 113, 226, 121, 170, 16, 94, 181, 33, 224, 2, 110, 218, 222, 254, 149, 111, 169, 18, 17, 213, 39, 108, 10, 218, 246, 159, 32, 169, 195, 236, 215, 148, 68, 37, 247, 110, 248, 219, 87, 70, 165, 227, 148, 139, 212, 28, 17, 65, 221, 194, 6, 58, 11, 13, 50, 185, 219, 126, 170, 20, 61, 124, 199, 120, 255, 252, 155, 84, 105, 80, 124, 139, 237, 213, 92, 109, 116, 158, 113, 89, 164, 215, 130, 17, 181, 130, 186, 12, 16, 123, 229, 222, 123, 163, 120, 39, 191, 220, 7, 193, 191, 87, 42, 172, 228, 94, 7, 23, 175, 184, 198, 23, 223, 73, 97, 115, 243, 31, 173, 148, 190, 123, 127, 171, 30, 141, 86, 251, 17, 223, 148, 142, 147, 42, 223, 69, 36, 106, 85, 117, 15, 27, 200, 188, 252, 180, 172, 189, 236, 148, 194, 76, 191, 90, 210, 156, 82, 99, 142, 150, 206, 111, 95, 169, 74, 68, 228, 85, 215, 221, 40, 45, 185, 219, 254, 210, 117, 246, 172, 226, 192, 113, 179, 194, 97, 118, 6, 13, 145, 191, 134, 105, 221, 201, 189, 15, 150, 174, 115, 231, 14, 236, 234, 52, 25, 244, 104, 108, 231, 243, 16, 209, 160, 134, 216, 141, 242, 202, 46, 127, 81, 186, 175, 155, 86, 252, 154, 150, 102, 128, 195, 219, 29, 39, 158, 171, 74, 68, 228, 167, 225, 194, 6, 240, 221, 81, 61, 179, 207, 151, 244, 83, 247, 171, 37, 13, 40, 22, 147, 206, 201, 151, 73, 106, 124, 117, 247, 232, 33, 26, 42, 26, 50, 108, 52, 28, 49, 234, 189, 241, 167, 170, 212, 56, 240, 93, 228, 56, 143, 38, 49, 178, 54, 55, 114, 39, 106, 69, 13, 29, 54, 144, 125, 115, 169, 244, 221, 122, 165, 164, 23, 63, 168, 150, 212, 81, 91, 187, 116, 28, 55, 173, 120, 120, 155, 136, 194, 105, 248, 176, 209, 210, 79, 221, 39, 125, 247, 204, 146, 236, 107, 207, 171, 37, 110, 165, 190, 116, 178, 180, 31, 249, 93, 137, 111, 188, 133, 90, 66, 68, 97, 52, 77, 216, 104, 233, 39, 238, 149, 254, 249, 55, 174, 115, 83, 243, 90, 137, 117, 116, 73, 106, 252, 196, 98, 208, 196, 183, 28, 169, 150, 18, 81, 37, 154, 46, 108, 52, 92, 138, 144, 126, 252, 30, 73, 63, 253, 64, 241, 44, 228, 40, 225, 140, 227, 182, 3, 14, 151, 20, 110, 229, 153, 76, 169, 165, 68, 84, 141, 166, 13, 27, 47, 4, 79, 230, 165, 199, 139, 223, 224, 128, 221, 172, 220, 251, 239, 168, 71, 2, 136, 39, 138, 223, 216, 137, 203, 25, 240, 189, 78, 248, 186, 149, 88, 215, 134, 234, 65, 34, 138, 74, 75, 132, 141, 41, 191, 250, 131, 226, 21, 223, 8, 157, 252, 234, 247, 37, 223, 179, 70, 36, 147, 46, 108, 109, 92, 36, 213, 81, 8, 147, 17, 18, 223, 104, 243, 226, 205, 177, 226, 53, 252, 30, 114, 34, 26, 212, 146, 97, 67, 68, 141, 167, 121, 47, 70, 34, 162, 166, 194, 176, 33, 34, 39, 24, 54, 68, 228, 4, 195, 134, 136, 156, 96, 216, 16, 145, 19, 12, 27, 34, 114, 130, 97, 67, 68, 78, 48, 108, 136, 200, 9, 134, 13, 17, 57, 193, 176, 33, 34, 39, 24, 54, 68, 228, 4, 195, 134, 136, 156, 96, 216, 16, 145, 19, 12, 27, 34, 114, 130, 97, 67, 68, 78, 196, 222, 126, 107, 5, 239, 103, 67, 68, 53, 23, 187, 75, 250, 25, 54, 77, 228, 253, 196, 219, 242, 78, 219, 50, 233, 143, 245, 168, 37, 68, 205, 129, 187, 81, 77, 132, 65, 67, 205, 75, 228, 255, 109, 76, 38, 177, 80, 147, 243, 22, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130]
                    }
                },
            },
        ],
    };
}
