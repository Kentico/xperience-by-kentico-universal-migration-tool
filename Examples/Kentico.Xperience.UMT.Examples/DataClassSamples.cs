using CMS.DataEngine;
using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class DataClassSamples
{
    public static readonly Guid FAQ_SAMPLE_GUID = new Guid("7ED6604E-613B-4CE0-8C21-ACFB372C416A");
    public static readonly Guid ARTICLE_SAMPLE_GUID = new Guid("06540294-3B56-4CF7-8773-088BB766AC23");
    public const string ARTICLE_SAMPLE_CLASS_NAME = "UMT.Article";
    public const string FAQ_SAMPLE_CLASS_NAME = "UMT.Faq";

    [Sample("dataclass.article", "This sample describes how to create class inside XbyK to hold Article data", "Article sample")]
    // ReSharper disable once UnusedMember.Global #used implicitly by xml doc <sample>
    public static DataClassModel ArticleClassSample => new()
    {
        ClassName = ARTICLE_SAMPLE_CLASS_NAME,
        ClassType = ClassType.CONTENT_TYPE,
        ClassContentTypeType = ClassContentTypeType.WEBSITE,
        ClassGUID = ARTICLE_SAMPLE_GUID,
        ClassLastModified = DateTime.Now,
        ClassResourceGuid = new Guid("0E4BEEF1-989C-4687-80CA-AE21FEC09734"),
        ClassDisplayName = "This is Article example",
        ClassTableName = "UMT_Article",
        ClassHasUnmanagedDbSchema = false,
        Fields = new List<FormField>
        {
            new()
            {
                Column = "ArticleTitle",
                ColumnType = "text",
                ColumnSize = 200,
                AllowEmpty = true,
                Visible = true,
                Enabled = true,
                Guid = new Guid("EA7DA631-6D9C-413F-A746-93442B623908"),
                Properties = new FormFieldProperties
                {
                    FieldCaption = "Article title",
                },
                Settings = new FormFieldSettings
                {
                    ControlName = "Kentico.Administration.TextInput"
                }
            },
            new()
            {
                Column = "ArticleText",
                ColumnType = "longtext",
                AllowEmpty = true,
                Visible = true,
                Enabled = true,
                Guid = new Guid("A54AEF74-42B3-438E-92B2-2F5B4386FB57"),
                Properties = new FormFieldProperties
                {
                    FieldCaption = "Article text",
                },
                Settings = new FormFieldSettings
                {
                    ControlName = "Kentico.Administration.TextArea"
                }
            }
        }
    };

    [Sample("dataclass.faq", "", "Faq sample")]
    public static DataClassModel FaqDataClass => new()
    {
        ClassName = "UMT.Faq",
        ClassType = ClassType.CONTENT_TYPE,
        ClassGUID = FAQ_SAMPLE_GUID,
        ClassContentTypeType = ClassContentTypeType.REUSABLE,
        ClassLastModified = DateTime.Now,
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
        ClassGUID = Guid.NewGuid(),
        ClassLastModified = DateTime.Now,
        ClassResourceGuid = new Guid("FF8285C1-9D1A-49B3-8C9D-7502E1E533F7"),
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
