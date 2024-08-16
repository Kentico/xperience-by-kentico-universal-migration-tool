using CMS.DataEngine;
using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class DataClassSamples
{
    public static readonly Guid FAQ_SAMPLE_GUID = new Guid("7ED6604E-613B-4CE0-8C21-ACFB372C416A");
    public static readonly Guid ARTICLE_SAMPLE_GUID = new Guid("06540294-3B56-4CF7-8773-088BB766AC23");
    public const string ARTICLE_SAMPLE_CLASS_NAME = "UMT.Article";
    public const string FAQ_SAMPLE_CLASS_NAME = "UMT.Faq";
    public static readonly Guid RelatedFaqFieldGuid = new Guid("fc1fde10-11bf-4174-bd64-d1f114e4b421");

    [Sample("dataclass.article", "This sample describes how to create class inside XbyK to hold Article data", "Article sample")]
    // ReSharper disable once UnusedMember.Global #used implicitly by xml doc <sample>
    public static DataClassModel ArticleClassSample => new()
    {
        ClassName = ARTICLE_SAMPLE_CLASS_NAME,
        ClassType = ClassType.CONTENT_TYPE,
        ClassContentTypeType = ClassContentTypeType.WEBSITE,
        ClassGUID = ARTICLE_SAMPLE_GUID,
        ClassLastModified = new DateTime(638403513317853783L, DateTimeKind.Local),
        // ClassResourceGuid = new Guid("0E4BEEF1-989C-4687-80CA-AE21FEC09734"),
        ClassDisplayName = "This is Article example",
        ClassTableName = "UMT_Article",
        ClassHasUnmanagedDbSchema = false,
        ClassWebPageHasUrl = true,
        Fields =
        [
            new()
            {
                Column = "ArticleTitle",
                ColumnType = "text",
                ColumnSize = 200,
                AllowEmpty = true,
                Visible = true,
                Enabled = true,
                Guid = new Guid("EA7DA631-6D9C-413F-A746-93442B623908"),
                Properties = new FormFieldProperties { FieldCaption = "Article title", },
                Settings = new FormFieldSettings { ControlName = "Kentico.Administration.TextInput" }
            },
            
            new()
            {
                Column = "ArticleTeaser",
                ColumnType = "contentitemasset",
                AllowEmpty = true,
                Visible = true,
                Enabled = true,
                Guid = new Guid("89043112-996B-4771-96BB-2347AD6F3526"),
                Properties = new FormFieldProperties { FieldCaption = "Article teaser", },
                Settings = new FormFieldSettings
                {
                    CustomProperties = new Dictionary<string, object?>
                    {
                        { "AllowedExtensions", "_INHERITED_" }  
                    },
                    ControlName = "Kentico.Administration.ContentItemAssetUploader"
                }
            },
            new()
            {
                Column = "ArticleDecimalNumberSample",
                ColumnType = "decimal",
                ColumnSize = 15,
                Precision = 5,
                AllowEmpty = true,
                Visible = true,
                Enabled = true,
                Guid = new Guid("8E749651-773B-47B9-A888-C541C3C3E1B7"),
                Properties = new FormFieldProperties { FieldCaption = "Article decimal number sample", },
                Settings = new FormFieldSettings { ControlName = "Kentico.Administration.DecimalNumberInput" }
            },

            new()
            {
                Column = "ArticleText",
                ColumnType = "longtext",
                AllowEmpty = true,
                Visible = true,
                Enabled = true,
                Guid = new Guid("A54AEF74-42B3-438E-92B2-2F5B4386FB57"),
                Properties = new FormFieldProperties { FieldCaption = "Article text", },
                Settings = new FormFieldSettings { ControlName = "Kentico.Administration.TextArea" }
            },

            new()
            {
                Column = "RelatedArticles",
                ColumnType = "webpages",
                AllowEmpty = true,
                Visible = true,
                Enabled = true,
                Guid = new Guid("4b7a3fec-ee64-4688-b441-fece563b906d"),
                Properties = new FormFieldProperties
                {
                    FieldCaption = "Related articles",
                    CustomProperties =
                    {
                        {"fieldcaption", "Related articles"},
                        {"fielddescriptionashtml", "False"}
                    }
                },
                Settings = new FormFieldSettings {
                    ControlName = "Kentico.Administration.WebPageSelector",
                    CustomProperties =
                    {
                        { "MaximumPages", 5 }, 
                        { "Sortable", "False" }, 
                        { "TreePath", "/Articles" },
                    } 
                }
            },

            new()
            {
                Column = "RelatedFaq",
                ColumnType = "contentitemreference",
                Visible = true,
                Enabled = true,
                AllowEmpty = true,
                Guid = RelatedFaqFieldGuid,
                Properties = new FormFieldProperties
                {
                    FieldCaption = "Related articles",
                    CustomProperties =
                    {
                        {"fieldcaption", "Related Faq"},
                        {"fielddescriptionashtml", "False"}
                    }
                },
                Settings = new FormFieldSettings {
                    ControlName = "Kentico.Administration.ContentItemSelector",
                    CustomProperties =
                    {
                        { "AllowedContentItemTypeIdentifiers", """
                                                               ["7ed6604e-613b-4ce0-8c21-acfb372c416a"]
                                                               """ }
                    } 
                }
            },
            
            new()
            {
                Column = "CoffeaTaxonomy",
                ColumnType = "taxonomy",
                AllowEmpty = true,
                Visible = true,
                Enabled = true,
                Guid = new Guid("36295D61-7F85-4213-8E5C-06772ED67DFB"),
                Properties = new FormFieldProperties
                {
                    FieldCaption = "Taxonomy coffee",
                    CustomProperties =
                    {
                        {"explanationtextashtml", "False"},
                        {"fielddescriptionashtml", "False"}
                    }
                },
                Settings = new FormFieldSettings {
                    ControlName = "Kentico.Administration.TagSelector",
                    CustomProperties =
                    {
                        { "TaxonomyGroup", $"[\"{TaxonomySamples.SampleTaxonomyCoffeeGuid}\"]" },
                    } 
                }
            },
        ]
    };

    [Sample("contenttypechannel.article", "", "Sample of content type assignment to channel")]
    public static ContentTypeChannelModel ArticleAssignedToWebSiteChannel => new ContentTypeChannelModel
    {
        ContentTypeChannelChannelGuid = ChannelSamples.WEBSITE_CHANNEL_SAMPLE_GUID,
        ContentTypeChannelContentTypeGuid = DataClassSamples.ARTICLE_SAMPLE_GUID
    };
    

    [Sample("dataclass.faq", "", "Faq sample")]
    public static DataClassModel FaqDataClass => new()
    {
        ClassName = "UMT.Faq",
        ClassType = ClassType.CONTENT_TYPE,
        ClassGUID = FAQ_SAMPLE_GUID,
        ClassContentTypeType = ClassContentTypeType.REUSABLE,
        ClassLastModified = new DateTime(638403513671472943L, DateTimeKind.Utc),
        ClassDisplayName = "Faq",
        ClassTableName = "UMT_Faq",
        ClassHasUnmanagedDbSchema = false,
        Fields = new List<FormField>
        { 
            new()
            { 
                Column = "FaqQuestion",
                ColumnType = "text",
                ColumnSize = 200,
                AllowEmpty = false,
                Visible = true,
                Enabled = true,
                Guid = new Guid("B7A99EF4-6775-4088-ACC7-41C21299AABF"),
                Properties = new FormFieldProperties
                {
                    FieldCaption = "Question",
                },
                Settings = new FormFieldSettings
                {
                    ControlName = "Kentico.Administration.TextInput"
                }
            },
            new()
            {
                Column = "FaqAnswer",
                ColumnType = "text",
                ColumnSize = 200,
                AllowEmpty = false,
                Visible = true,
                Enabled = true,
                Guid = new Guid("87995645-5868-470B-B25A-0E2A4E6D0E85"),
                Properties = new FormFieldProperties
                {
                    FieldCaption = "Answer",
                },
                Settings = new FormFieldSettings
                {
                    ControlName = "Kentico.Administration.TextInput"
                }
            }
        }
    };

    [Sample("dataclass.event", "", "Event sample")]
    // ReSharper disable once UnusedMember.Global #used implicitly by xml doc <sample>
    public static DataClassModel EventDataClass => new()
    {
        ClassName = "UMT.Event",
        ClassType = ClassType.CONTENT_TYPE,
        ClassContentTypeType = ClassContentTypeType.REUSABLE,
        ClassGUID = new Guid("4712C000-4D63-4333-8708-990603F73A1E"),
        ClassLastModified = new DateTime(638403513722515785L, DateTimeKind.Utc),
        // ClassResourceGuid = new Guid("FF8285C1-9D1A-49B3-8C9D-7502E1E533F7"),
        ClassDisplayName = "Event",
        ClassTableName = "UMT_Event",
        ClassHasUnmanagedDbSchema = false,
        Fields = new List<FormField>
        {
            new()
            {
                Column = "EventTitle",
                ColumnType = "text",
                ColumnSize = 200,
                AllowEmpty = true,
                Visible = true,
                Enabled = true,
                Guid = new Guid("0E1E63EB-918A-4135-A627-04393672D6F4"),
                Properties = new FormFieldProperties
                {
                    FieldCaption = "Title",
                },
                Settings = new FormFieldSettings
                {
                    ControlName = "Kentico.Administration.TextInput"
                }
            },
            new()
            {
                Column = "EventText",
                ColumnType = "longtext",
                AllowEmpty = true,
                Visible = true,
                Enabled = true,
                Guid = new Guid("A54AEF74-42B3-438E-92B2-2F5B4386FB57"),
                Properties = new FormFieldProperties
                {
                    FieldCaption = "Text",
                },
                Settings = new FormFieldSettings
                {
                    ControlName = "Kentico.Administration.TextArea"
                }
            },
            new()
            {
                Column = "EventDate",
                ColumnType = "datetime",
                AllowEmpty = true,
                Visible = true,
                Enabled = true,
                Guid = new Guid("F3356F35-0A78-4A98-8696-A1BECB725B0A"),
                Properties = new FormFieldProperties
                {
                    FieldCaption = "Date",
                },
                Settings = new FormFieldSettings
                {
                    ControlName = "Kentico.Administration.DateTimeInput"
                }
            },
            new()
            {
                Column = "EventRecurrentYearly",
                ColumnType = "boolean",
                AllowEmpty = true,
                Visible = true,
                Enabled = true,
                Guid = new Guid("98D2CF95-5027-488A-B833-89510F4662C1"),
                Properties = new FormFieldProperties
                {
                    FieldCaption = "Event occurs every year",
                },
                Settings = new FormFieldSettings
                {
                    ControlName = "Kentico.Administration.Checkbox"
                }
            }
        }
    };
}
