using CMS.ContentEngine;
using CMS.DataEngine;

using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class VisualBuilderSamples
{
    [Sample("VisualBuilderSamples.SimplifiedModel", "Simplified model of a webpage with visual builder widgets. To be used with Kentico.Xperience.UMT.Example.Target project (see its README)", "Simplified model of a webpage with visual builder widgets")]
    public static ContentItemSimplifiedModel SimplifiedModel => new()
    {
        ContentItemGUID = new("0C6AD176-2C53-4C95-901A-6C155C843951"),
        Name = "VisualBuilderPageSimplifiedModelSample",
        IsSecured = false,
        ContentTypeName = PageWithWidgetsContentType.ClassName,
        IsReusable = false,
        ChannelName = ChannelSamples.SampleChannelForWebSiteChannel.ChannelName,
        PageData = new()
        {
            PageGuid = new("0C6AD176-2C53-4C95-901A-6C155C843951"),
            ParentGuid = null,
            TreePath = "/page-with-widgets-simplified",
            PageUrls = [
                new()
                {
                    UrlPath = "en-us/page-with-widgets-simplified",
                    LanguageName = ContentLanguageSamples.SampleContentLanguageEnUs.ContentLanguageName!
                },
                new()
                {
                    UrlPath = "es/page-with-widgets-simplified",
                    LanguageName = ContentLanguageSamples.SampleContentLanguageEs.ContentLanguageName!
                }
            ]
        },
        LanguageData =
        [
            new()
            {
                LanguageName = ContentLanguageSamples.SampleContentLanguageEnUs.ContentLanguageName!,
                DisplayName = "Page with widgets (simplified model) - en-us",
                VersionStatus = VersionStatus.Published,
                UserGuid = null,
                ContentItemData = [],

                // Value can be of any JSON-serializable type (anonymous, POCO, dictionary, ... or any combination of those)
                VisualBuilderTemplateConfiguration = new { Identifier = "PageWithWidgetsDefaultTemplate" },

                // Value can be of any JSON-serializable type (anonymous, POCO, dictionary, ... or any combination of those)
                VisualBuilderWidgets = new { EditableAreas = new[] {
                    new {
                        Identifier = "main-area",
                        Sections = new[] {
                            new {
                                Identifier = new Guid("D3D434FD-6A8C-464F-88AD-A02A991FBB9B"),
                                Type = "SingleColumnSection",
                                Properties = new {
                                    BackgroundColor = "#EEE"
                                },
                                Zones = new[] {
                                    new {
                                        Identifier = new Guid("0513C5D5-3CF0-4BFA-A106-61B2CA10D23E"),
                                        Name = "main-zone",
                                        Widgets = new[] {
                                            new {
                                                Identifier = new Guid("5432D27D-52EB-45F5-8107-3CB08A331CF8"),
                                                Type = "UMT.SampleWidget",
                                                Variants = new[] {
                                                    new {
                                                        Identifier = new Guid("E0CD9100-D93C-4371-9A05-A3AA781BC526"),
                                                        Properties = new {
                                                            Heading = "Widget #1",
                                                            LinkedArticles = new[] { ContentItemSimplifiedSamples.SampleArticleSubPageContentItemGuid, ContentItemSimplifiedSamples.SampleArticleSubPage2ContentItemGuid }
                                                                .Select(x => new { Identifier = x }).ToArray()
                                                        }
                                                    }
                                                }
                                            },
                                            new {
                                                Identifier = new Guid("BCA45FE2-2579-4A9F-8672-FFD14196E294"),
                                                Type = "UMT.SampleWidget",
                                                Variants = new[] {
                                                    new {
                                                        Identifier = new Guid("7F01C403-4F94-4E3C-97DE-2676E8A5CEE8"),
                                                        Properties = new {
                                                            Heading = "Widget #2",
                                                            LinkedArticles = new[] { ContentItemSimplifiedSamples.SampleArticleSubPage3ContentItemGuid, ContentItemSimplifiedSamples.SampleArticleSubPage4ContentItemGuid, ContentItemSimplifiedSamples.SampleArticleSubPage5ContentItemGuid }
                                                                .Select(x => new { Identifier = x }).ToArray()
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                }
            }
        ]
    };

    [Sample("VisualBuilderSamples.PageWithWidgetsContentType", "Content type of a page with widgets", "Page with widgets content type")]
    public static DataClassModel PageWithWidgetsContentType => new()
    {
        ClassName = "UMT.PageWithWidgets",
        ClassType = ClassType.CONTENT_TYPE,
        ClassContentTypeType = ClassContentTypeType.WEBSITE,
        ClassGUID = new Guid("4154293B-994C-4FE2-A7DD-DE89FFD1A1C1"),
        ClassLastModified = new DateTime(638403513317853783L, DateTimeKind.Local),
        ClassDisplayName = "Page with widgets",
        ClassTableName = "UMT_PageWithWidgets",
        ClassHasUnmanagedDbSchema = false,
        ClassWebPageHasUrl = true,
    };
}
