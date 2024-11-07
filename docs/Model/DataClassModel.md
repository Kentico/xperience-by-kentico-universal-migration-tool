<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## DataClassModel
Model represents XbyK DataClassInfo


|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|ClassDisplayName\*|Friendly name for class|string?||
|ClassName\*|Class unique codename|string?||
|ClassShortName||string?||
|ClassTableName|SQL Table name|string?||
|ClassShowTemplateSelection||bool?||
|ClassLastModified\*|last modification performed through API / UI|System.DateTime?||
|ClassGUID\*|UniqueId of DataClass|System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|ClassContactMapping||string?||
|ClassContactOverwriteEnabled||bool?||
|ClassConnectionString||string?||
|ClassDefaultObjectType||string?||
|ClassResourceGuid|Relation to CMS Resource (Custom module), set if dataclass is part custom module|System.Guid?|Reference to [ResourceInfo](../References.md#ResourceInfo) on property ClassResourceID|
|ClassCodeGenerationSettings||string?||
|ClassHasUnmanagedDbSchema\*|only if consumer wishes to manage SQL table manually|bool?||
|ClassType\*||string?||
|ClassContentTypeType||string?||
|ClassWebPageHasUrl||bool?||
|Fields|custom data fields for DataClass|Kentico.Xperience.UMT.Model.FormField[]||

<p>*) value is required</p>


### Article sample
This sample describes how to create class inside XbyK to hold Article data
```json
{
  "$type": "DataClass",
  "ClassDisplayName": "This is Article example",
  "ClassName": "UMT.Article",
  "ClassShortName": "UMT.Article",
  "ClassTableName": "UMT_Article",
  "ClassLastModified": "2024-01-08T22:55:31.7853783\u002B01:00",
  "ClassGUID": "06540294-3b56-4cf7-8773-088bb766ac23",
  "ClassHasUnmanagedDbSchema": false,
  "ClassType": "Content",
  "ClassContentTypeType": "Website",
  "ClassWebPageHasUrl": true,
  "Fields": [
    {
      "AllowEmpty": true,
      "Column": "ArticleTitle",
      "ColumnSize": 200,
      "ColumnType": "text",
      "Enabled": true,
      "Guid": "ea7da631-6d9c-413f-a746-93442b623908",
      "Visible": true,
      "Properties": {
        "FieldCaption": "Article title"
      },
      "Settings": {
        "ControlName": "Kentico.Administration.TextInput"
      }
    },
    {
      "AllowEmpty": true,
      "Column": "ArticleDecimalNumberSample",
      "ColumnSize": 15,
      "ColumnType": "decimal",
      "Enabled": true,
      "Guid": "8e749651-773b-47b9-a888-c541c3c3e1b7",
      "Visible": true,
      "Properties": {
        "FieldCaption": "Article decimal number sample"
      },
      "Settings": {
        "ControlName": "Kentico.Administration.DecimalNumberInput"
      },
      "Precision": 5
    },
    {
      "AllowEmpty": true,
      "Column": "ArticleText",
      "ColumnSize": 0,
      "ColumnType": "longtext",
      "Enabled": true,
      "Guid": "a54aef74-42b3-438e-92b2-2f5b4386fb57",
      "Visible": true,
      "Properties": {
        "FieldCaption": "Article text"
      },
      "Settings": {
        "ControlName": "Kentico.Administration.TextArea"
      }
    },
    {
      "AllowEmpty": true,
      "Column": "RelatedArticles",
      "ColumnSize": 0,
      "ColumnType": "webpages",
      "Enabled": true,
      "Guid": "4b7a3fec-ee64-4688-b441-fece563b906d",
      "Visible": true,
      "Properties": {
        "FieldCaption": "Related articles",
        "fieldcaption": "Related articles",
        "fielddescriptionashtml": "False"
      },
      "Settings": {
        "ControlName": "Kentico.Administration.WebPageSelector",
        "MaximumPages": 5,
        "Sortable": "False",
        "TreePath": "/Articles"
      }
    },
    {
      "AllowEmpty": true,
      "Column": "RelatedFaq",
      "ColumnSize": 0,
      "ColumnType": "contentitemreference",
      "Enabled": true,
      "Guid": "fc1fde10-11bf-4174-bd64-d1f114e4b421",
      "Visible": true,
      "Properties": {
        "FieldCaption": "Related articles",
        "fieldcaption": "Related Faq",
        "fielddescriptionashtml": "False"
      },
      "Settings": {
        "ControlName": "Kentico.Administration.ContentItemSelector",
        "AllowedContentItemTypeIdentifiers": "[\u00227ed6604e-613b-4ce0-8c21-acfb372c416a\u0022]"
      }
    },
    {
      "AllowEmpty": true,
      "Column": "CoffeaTaxonomy",
      "ColumnSize": 0,
      "ColumnType": "taxonomy",
      "Enabled": true,
      "Guid": "36295d61-7f85-4213-8e5c-06772ed67dfb",
      "Visible": true,
      "Properties": {
        "FieldCaption": "Taxonomy coffee",
        "explanationtextashtml": "False",
        "fielddescriptionashtml": "False"
      },
      "Settings": {
        "ControlName": "Kentico.Administration.TagSelector",
        "TaxonomyGroup": "[\u0022bd88fd9b-8d36-4d02-a4a6-9a2b26c48488\u0022]"
      }
    }
  ]
}
```

### Event sample

```json
{
  "$type": "DataClass",
  "ClassDisplayName": "Event",
  "ClassName": "UMT.Event",
  "ClassShortName": "UMT.Event",
  "ClassTableName": "UMT_Event",
  "ClassLastModified": "2024-01-08T22:56:12.2515785Z",
  "ClassGUID": "4712c000-4d63-4333-8708-990603f73a1e",
  "ClassHasUnmanagedDbSchema": false,
  "ClassType": "Content",
  "ClassContentTypeType": "Reusable",
  "Fields": [
    {
      "AllowEmpty": true,
      "Column": "EventTitle",
      "ColumnSize": 200,
      "ColumnType": "text",
      "Enabled": true,
      "Guid": "0e1e63eb-918a-4135-a627-04393672d6f4",
      "Visible": true,
      "Properties": {
        "FieldCaption": "Title"
      },
      "Settings": {
        "ControlName": "Kentico.Administration.TextInput"
      }
    },
    {
      "AllowEmpty": true,
      "Column": "EventText",
      "ColumnSize": 0,
      "ColumnType": "longtext",
      "Enabled": true,
      "Guid": "a54aef74-42b3-438e-92b2-2f5b4386fb57",
      "Visible": true,
      "Properties": {
        "FieldCaption": "Text"
      },
      "Settings": {
        "ControlName": "Kentico.Administration.TextArea"
      }
    },
    {
      "AllowEmpty": true,
      "Column": "EventDate",
      "ColumnSize": 0,
      "ColumnType": "datetime",
      "Enabled": true,
      "Guid": "f3356f35-0a78-4a98-8696-a1becb725b0a",
      "Visible": true,
      "Properties": {
        "FieldCaption": "Date"
      },
      "Settings": {
        "ControlName": "Kentico.Administration.DateTimeInput"
      }
    },
    {
      "AllowEmpty": true,
      "Column": "EventRecurrentYearly",
      "ColumnSize": 0,
      "ColumnType": "boolean",
      "Enabled": true,
      "Guid": "98d2cf95-5027-488a-b833-89510f4662c1",
      "Visible": true,
      "Properties": {
        "FieldCaption": "Event occurs every year"
      },
      "Settings": {
        "ControlName": "Kentico.Administration.Checkbox"
      }
    },
    {
      "AllowEmpty": true,
      "Column": "EventTeaser",
      "ColumnSize": 0,
      "ColumnType": "contentitemasset",
      "Enabled": true,
      "Guid": "89043112-996b-4771-96bb-2347ad6f3526",
      "Visible": true,
      "Properties": {
        "FieldCaption": "Event teaser"
      },
      "Settings": {
        "ControlName": "Kentico.Administration.ContentItemAssetUploader",
        "AllowedExtensions": "_INHERITED_"
      }
    }
  ]
}
```

### Faq sample

```json
{
  "$type": "DataClass",
  "ClassDisplayName": "Faq",
  "ClassName": "UMT.Faq",
  "ClassShortName": "UMT.Faq",
  "ClassTableName": "UMT_Faq",
  "ClassLastModified": "2024-01-08T22:56:07.1472943Z",
  "ClassGUID": "7ed6604e-613b-4ce0-8c21-acfb372c416a",
  "ClassHasUnmanagedDbSchema": false,
  "ClassType": "Content",
  "ClassContentTypeType": "Reusable",
  "Fields": [
    {
      "AllowEmpty": false,
      "Column": "FaqQuestion",
      "ColumnSize": 200,
      "ColumnType": "text",
      "Enabled": true,
      "Guid": "b7a99ef4-6775-4088-acc7-41c21299aabf",
      "Visible": true,
      "Properties": {
        "FieldCaption": "Question"
      },
      "Settings": {
        "ControlName": "Kentico.Administration.TextInput"
      }
    },
    {
      "AllowEmpty": false,
      "Column": "FaqAnswer",
      "ColumnSize": 200,
      "ColumnType": "text",
      "Enabled": true,
      "Guid": "87995645-5868-470b-b25a-0e2a4e6d0e85",
      "Visible": true,
      "Properties": {
        "FieldCaption": "Answer"
      },
      "Settings": {
        "ControlName": "Kentico.Administration.TextInput"
      }
    }
  ]
}
```
## FormField
Represents information about custom data field


|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|AllowEmpty|marks field as nullable|bool||
|Column\*|Name of column, this will be used for column naming in SQL Table|string?||
|ColumnSize||int||
|ColumnType\*|Column type, defines used type from vector [.NET type, SQL type, xsd schema type] [enumeration](../Enums/ColumnType.md)|string?||
|Enabled||bool||
|Guid\*|Unique identification of field|System.Guid?||
|Visible|Field visibility in administration form|bool||
|Properties|[definition](#FormFieldProperties)|Kentico.Xperience.UMT.Model.FormFieldProperties||
|Settings|[definition](#FormFieldSettings)|Kentico.Xperience.UMT.Model.FormFieldSettings||
|Precision|Specifies precision, relevant for fields with ColumnType "decimal"|int?||

<p>*) value is required</p>

## FormFieldProperties
additional form field properties, they may differ by property type


|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|FieldCaption|Friendly name displayed in form|string?||
|CustomProperties||System.Collections.Generic.Dictionary<string, object?>||

<p>*) value is required</p>

## FormFieldSettings
settings related to form field


|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|ControlName|Admin UI Component used for field data editing [(for pages use enumeration here)](../Enums/FormComponents.md#module-kenticoxperienceadminbasedll.md)|string?||
|CustomProperties||System.Collections.Generic.Dictionary<string, object?>||

<p>*) value is required</p>

