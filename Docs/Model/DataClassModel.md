<!-- generated file with tool "Kentico.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## DataClassModel
Model represents XbyK DataClassInfo

Model [discriminator](../UmtModel.md#discriminator): `DataClass`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|ClassDisplayName\*|Friendly name for class|string?||
|ClassName\*|Class unique codename|string?||
|ClassIsDocumentType\*|If data class represents Page/TreeNode set to true, otherwise false|bool?||
|ClassIsCoupledClass\*|if DataClass contains custom data this will be true, if not set to false|bool?||
|ClassNodeNameSource\*|Source field name for node name, this has impact on generated URL of page|string?||
|ClassTableName\*|SQL Table name|string?||
|ClassShowAsSystemTable|Marks DataClass as internal, for all custom classes managed by consumer value will be false|bool?||
|ClassUsePublishFromTo||bool?||
|ClassShowTemplateSelection||bool?||
|ClassNodeAliasSource\*|Defines property that will XbyK API use for Page Alias|string?||
|ClassLastModified|last modification performed through API / UI|System.DateTime?||
|ClassGUID|UniqueId of DataClass|System.Guid|[UniqueId](../UmtModel.md#UniqueId)|
|ClassShowColumns||string?||
|ClassInheritsFromClassGUID|in case of inheritance set parent class GUID|System.Guid?|Reference to [DataClassInfo](../References.md#DataClassInfo) on property ClassInheritsFromClassID|
|ClassContactMapping||string?||
|ClassContactOverwriteEnabled||bool?||
|ClassConnectionString||string?||
|ClassDefaultObjectType||string?||
|ClassIsForm||bool?||
|ClassResourceGUID|Relation to CMS Resource (Custom module), set if dataclass is part custom module|System.Guid?|Reference to [ResourceInfo](../References.md#ResourceInfo) on property ClassResourceID|
|ClassCustomizedColumns||string?||
|ClassCodeGenerationSettings||string?||
|ClassIconClass||string?||
|ClassURLPattern||string?||
|ClassUsesPageBuilder\*|Page Builder feature, if enabled ClassHasURL is required too|bool?||
|ClassHasURL\*||bool?||
|ClassHasMetadata\*||bool?||
|ClassIsPage|If true, DataClass represents Page/TreeNode|bool?||
|ClassHasUnmanagedDbSchema\*|only if consumer wishes to manage SQL table manually|bool?||
|ClassPrimaryKeyName\*|primary key name in database table|string?||
|Fields|custom data fields for DataClass|Kentico.UMT.Model.FormField[]||

<p>*) value is required</p>


### Article sample
This sample describes how to create class inside XbyK to hold Article data
```json
{
  "$type": "DataClass",
  "ClassDisplayName": "Article",
  "ClassName": "UMT.Article",
  "ClassIsDocumentType": true,
  "ClassIsCoupledClass": true,
  "ClassNodeNameSource": "ArticleTitle",
  "ClassTableName": "UMT_Article",
  "ClassShowAsSystemTable": false,
  "ClassNodeAliasSource": "ArticleTitle",
  "ClassGUID": "2cb15794-9ab1-450f-b69b-ebdee1f5b5fe",
  "ClassIsForm": false,
  "ClassUsesPageBuilder": true,
  "ClassHasURL": true,
  "ClassHasMetadata": true,
  "ClassIsPage": true,
  "ClassHasUnmanagedDbSchema": false,
  "ClassPrimaryKeyName": "ArticleID",
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
  "ClassIsDocumentType": true,
  "ClassIsCoupledClass": true,
  "ClassNodeNameSource": "EventTitle",
  "ClassTableName": "UMT_Event",
  "ClassShowAsSystemTable": false,
  "ClassNodeAliasSource": "EventTitle",
  "ClassGUID": "3d36917e-de3e-4db3-9d71-7961d250085d",
  "ClassIsForm": false,
  "ClassUsesPageBuilder": true,
  "ClassHasURL": true,
  "ClassHasMetadata": true,
  "ClassIsPage": true,
  "ClassHasUnmanagedDbSchema": false,
  "ClassPrimaryKeyName": "EventID",
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
|Properties|[definition](#FormFieldProperties)|Kentico.UMT.Model.FormFieldProperties||
|Settings|[definition](#FormFieldSettings)|Kentico.UMT.Model.FormFieldSettings||

<p>*) value is required</p>

## FormFieldProperties
additional form field properties, they may differ by property type


|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|FieldCaption|Friendly name displayed in form|string||

<p>*) value is required</p>

## FormFieldSettings
settings related to form field


|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|ControlName|Admin UI Component used for field data editing [(for pages use enumeration here)](../Enums/FormComponents.md#module-kenticoxperienceadminbasedll.md)|string||

<p>*) value is required</p>

