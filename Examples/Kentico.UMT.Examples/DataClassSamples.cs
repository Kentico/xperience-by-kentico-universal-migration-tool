using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT;

public static class DataClassSamples
{
    [Sample("dataclass.article", "This sample describes how to create class inside XbyK to hold Article data", "Article sample")]
    // ReSharper disable once UnusedMember.Global #used implicitly by xml doc <sample>
    public static DataClassModel ArticleClassSample => new()
    {
        ClassName = "UMT.Article",
        ClassDisplayName = "Article",
        ClassTableName = "UMT_Article",
        ClassPrimaryKeyName = "ArticleID",
        ClassGuid = new Guid("2CB15794-9AB1-450F-B69B-EBDEE1F5B5FE"),
        ClassNodeNameSource = "ArticleTitle",
        ClassNodeAliasSource = "ArticleTitle",
        ClassUsesPageBuilder = true,
        ClassHasUrl = true, // Cannot set info object, domain validation failed (Field name: ClassHasURL): Page Builder can only be used together with the URL feature.
        ClassHasMetadata = true,
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


    [Sample("dataclass.event", "", "Event sample")]
    // ReSharper disable once UnusedMember.Global #used implicitly by xml doc <sample>
    public static DataClassModel EventDataClass => new()
    {
        ClassName = "UMT.Event",
        ClassDisplayName = "Event",
        ClassTableName = "UMT_Event",
        ClassPrimaryKeyName = "EventID",
        ClassGuid = new Guid("3D36917E-DE3E-4DB3-9D71-7961D250085D"),
        ClassNodeAliasSource = "EventTitle",
        ClassNodeNameSource = "EventTitle",
        ClassUsesPageBuilder = true,
        ClassHasUrl = true, // Cannot set info object, domain validation failed (Field name: ClassHasURL): Page Builder can only be used together with the URL feature.
        ClassHasMetadata = true,
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
