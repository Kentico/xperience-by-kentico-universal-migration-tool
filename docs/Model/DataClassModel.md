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
  "classDisplayName": "This is Article example",
  "className": "UMT.Article",
  "classShortName": "UMT.Article",
  "classTableName": "UMT_Article",
  "classLastModified": "2024-01-08T22:55:31.7853783\u002B01:00",
  "classGUID": "06540294-3b56-4cf7-8773-088bb766ac23",
  "classHasUnmanagedDbSchema": false,
  "classType": "Content",
  "classContentTypeType": "Website",
  "classWebPageHasUrl": true,
  "fields": [
    {
      "allowEmpty": true,
      "column": "ArticleTitle",
      "columnSize": 200,
      "columnType": "text",
      "enabled": true,
      "guid": "ea7da631-6d9c-413f-a746-93442b623908",
      "visible": true,
      "properties": {
        "fieldCaption": "Article title"
      },
      "settings": {
        "controlName": "Kentico.Administration.TextInput"
      }
    },
    {
      "allowEmpty": true,
      "column": "ArticleDecimalNumberSample",
      "columnSize": 15,
      "columnType": "decimal",
      "enabled": true,
      "guid": "8e749651-773b-47b9-a888-c541c3c3e1b7",
      "visible": true,
      "properties": {
        "fieldCaption": "Article decimal number sample"
      },
      "settings": {
        "controlName": "Kentico.Administration.DecimalNumberInput"
      },
      "precision": 5
    },
    {
      "allowEmpty": true,
      "column": "ArticleText",
      "columnSize": 0,
      "columnType": "longtext",
      "enabled": true,
      "guid": "a54aef74-42b3-438e-92b2-2f5b4386fb57",
      "visible": true,
      "properties": {
        "fieldCaption": "Article text"
      },
      "settings": {
        "controlName": "Kentico.Administration.TextArea"
      }
    },
    {
      "allowEmpty": true,
      "column": "RelatedArticles",
      "columnSize": 0,
      "columnType": "webpages",
      "enabled": true,
      "guid": "4b7a3fec-ee64-4688-b441-fece563b906d",
      "visible": true,
      "properties": {
        "fieldCaption": "Related articles",
        "fieldcaption": "Related articles",
        "fielddescriptionashtml": "False"
      },
      "settings": {
        "controlName": "Kentico.Administration.WebPageSelector",
        "MaximumPages": 5,
        "Sortable": "False",
        "TreePath": "/simplified-sample"
      }
    },
    {
      "allowEmpty": true,
      "column": "RelatedFaq",
      "columnSize": 0,
      "columnType": "contentitemreference",
      "enabled": true,
      "guid": "fc1fde10-11bf-4174-bd64-d1f114e4b421",
      "visible": true,
      "properties": {
        "fieldCaption": "Related articles",
        "fieldcaption": "Related Faq",
        "fielddescriptionashtml": "False"
      },
      "settings": {
        "controlName": "Kentico.Administration.ContentItemSelector",
        "AllowedContentItemTypeIdentifiers": "[\u00227ed6604e-613b-4ce0-8c21-acfb372c416a\u0022]"
      }
    },
    {
      "allowEmpty": true,
      "column": "CoffeaTaxonomy",
      "columnSize": 0,
      "columnType": "taxonomy",
      "enabled": true,
      "guid": "36295d61-7f85-4213-8e5c-06772ed67dfb",
      "visible": true,
      "properties": {
        "fieldCaption": "Taxonomy coffee",
        "explanationtextashtml": "False",
        "fielddescriptionashtml": "False"
      },
      "settings": {
        "controlName": "Kentico.Administration.TagSelector",
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
  "classDisplayName": "Event",
  "className": "UMT.Event",
  "classShortName": "UMT.Event",
  "classTableName": "UMT_Event",
  "classLastModified": "2024-01-08T22:56:12.2515785Z",
  "classGUID": "4712c000-4d63-4333-8708-990603f73a1e",
  "classHasUnmanagedDbSchema": false,
  "classType": "Content",
  "classContentTypeType": "Reusable",
  "fields": [
    {
      "allowEmpty": true,
      "column": "EventTitle",
      "columnSize": 200,
      "columnType": "text",
      "enabled": true,
      "guid": "0e1e63eb-918a-4135-a627-04393672d6f4",
      "visible": true,
      "properties": {
        "fieldCaption": "Title"
      },
      "settings": {
        "controlName": "Kentico.Administration.TextInput"
      }
    },
    {
      "allowEmpty": true,
      "column": "EventText",
      "columnSize": 0,
      "columnType": "longtext",
      "enabled": true,
      "guid": "a54aef74-42b3-438e-92b2-2f5b4386fb57",
      "visible": true,
      "properties": {
        "fieldCaption": "Text"
      },
      "settings": {
        "controlName": "Kentico.Administration.TextArea"
      }
    },
    {
      "allowEmpty": true,
      "column": "EventDate",
      "columnSize": 0,
      "columnType": "datetime",
      "enabled": true,
      "guid": "f3356f35-0a78-4a98-8696-a1becb725b0a",
      "visible": true,
      "properties": {
        "fieldCaption": "Date"
      },
      "settings": {
        "controlName": "Kentico.Administration.DateTimeInput"
      }
    },
    {
      "allowEmpty": true,
      "column": "EventRecurrentYearly",
      "columnSize": 0,
      "columnType": "boolean",
      "enabled": true,
      "guid": "98d2cf95-5027-488a-b833-89510f4662c1",
      "visible": true,
      "properties": {
        "fieldCaption": "Event occurs every year"
      },
      "settings": {
        "controlName": "Kentico.Administration.Checkbox"
      }
    },
    {
      "allowEmpty": true,
      "column": "EventTeaser",
      "columnSize": 0,
      "columnType": "contentitemasset",
      "enabled": true,
      "guid": "89043112-996b-4771-96bb-2347ad6f3526",
      "visible": true,
      "properties": {
        "fieldCaption": "Event teaser"
      },
      "settings": {
        "controlName": "Kentico.Administration.ContentItemAssetUploader",
        "AllowedExtensions": "_INHERITED_"
      }
    },
    {
      "allowEmpty": true,
      "column": "EventTeaserOptimized",
      "columnSize": 0,
      "columnType": "contentitemasset",
      "enabled": true,
      "guid": "4ba81bfd-cd14-4100-8ace-080c25d8ab98",
      "visible": true,
      "properties": {
        "fieldCaption": "Event teaser auto-optimized"
      },
      "settings": {
        "controlName": "Kentico.Administration.ContentItemAssetUploader",
        "AllowedExtensions": "_INHERITED_",
        "IsFormatConversionEnabled": true,
        "InputImageExtensions": "[\u0022jpg\u0022,\u0022png\u0022]",
        "OutputImageExtension": "jpg",
        "OutputQuality": "50"
      }
    }
  ]
}
```

### Faq sample

```json
{
  "$type": "DataClass",
  "classDisplayName": "Faq",
  "className": "UMT.Faq",
  "classShortName": "UMT.Faq",
  "classTableName": "UMT_Faq",
  "classLastModified": "2024-01-08T22:56:07.1472943Z",
  "classGUID": "7ed6604e-613b-4ce0-8c21-acfb372c416a",
  "classHasUnmanagedDbSchema": false,
  "classType": "Content",
  "classContentTypeType": "Reusable",
  "fields": [
    {
      "allowEmpty": false,
      "column": "FaqQuestion",
      "columnSize": 200,
      "columnType": "text",
      "enabled": true,
      "guid": "b7a99ef4-6775-4088-acc7-41c21299aabf",
      "visible": true,
      "properties": {
        "fieldCaption": "Question"
      },
      "settings": {
        "controlName": "Kentico.Administration.TextInput"
      }
    },
    {
      "allowEmpty": false,
      "column": "FaqAnswer",
      "columnSize": 200,
      "columnType": "text",
      "enabled": true,
      "guid": "87995645-5868-470b-b25a-0e2a4e6d0e85",
      "visible": true,
      "properties": {
        "fieldCaption": "Answer"
      },
      "settings": {
        "controlName": "Kentico.Administration.TextInput"
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

