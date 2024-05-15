namespace Kentico.Xperience.UMT.Example.Console;

public static class SampleJson
{
#pragma warning disable S2479
    public const string FULL_SAMPLE = """
                                      [
                                       {
                                         "$type": "Taxonomy",
                                         "TaxonomyName": "CoffeaGenus",
                                         "TaxonomyGUID": "bd88fd9b-8d36-4d02-a4a6-9a2b26c48488",
                                         "TaxonomyTitle": "Coffea genus",
                                         "TaxonomyDescription": "Coffea is a genus of flowering plants in the family Rubiaceae",
                                         "TaxonomyTranslations": {
                                           "f454e93b-5fe9-42a9-b1af-b572234ed9c4": {
                                             "Title": "Coffea enUS"
                                           },
                                           "a6c0a558-8b33-47b6-87a8-491b437c9923": {
                                             "Title": "Coffea enGB"
                                           }
                                         }
                                       },
                                       {
                                         "$type": "Tag",
                                         "TagName": "CoffeaCanephora",
                                         "TagGUID": "a6e3cc11-95a8-482c-beb4-58bbef6e7bdd",
                                         "TagTaxonomyGUID": "bd88fd9b-8d36-4d02-a4a6-9a2b26c48488",
                                         "TagParentGUID": null,
                                         "TagOrder": null,
                                         "TagTitle": "Coffea canephora (Coffea robusta)",
                                         "TagDescription": "Coffea canephora (especially C. canephora var. robusta, so predominantly cultivated that it is often simply termed Coffea robusta, or commonly robusta coffee)",
                                         "TagTranslations": {
                                           "f454e93b-5fe9-42a9-b1af-b572234ed9c4": {
                                             "Title": "Coffea canephora enUS",
                                             "Description": "ENUS Robusta is a species of flowering plant in the family Rubiaceae. Though widely known by the synonym Coffea robusta, the plant is currently scientifically identified as Coffea canephora, which has two main varieties, C. c. robusta and C. c. nganda.[2] The plant has a shallow root system and grows as a robust tree or shrub to about 10 metres (30 feet) tall. It flowers irregularly, taking about 10\u201411 months for the berries to ripen, producing oval-shaped beans."
                                           },
                                           "a6c0a558-8b33-47b6-87a8-491b437c9923": {
                                             "Title": "Coffea canephora enGB",
                                             "Description": "ENGB Robusta is a species of flowering plant in the family Rubiaceae. Though widely known by the synonym Coffea robusta, the plant is currently scientifically identified as Coffea canephora, which has two main varieties, C. c. robusta and C. c. nganda.[2] The plant has a shallow root system and grows as a robust tree or shrub to about 10 metres (30 feet) tall. It flowers irregularly, taking about 10\u201411 months for the berries to ripen, producing oval-shaped beans."
                                           }
                                         }
                                       },
                                       {
                                         "$type": "Tag",
                                         "TagName": "CoffeaNganda",
                                         "TagGUID": "b351f88c-7e0c-4339-bcf8-ed86bb8a2804",
                                         "TagTaxonomyGUID": "bd88fd9b-8d36-4d02-a4a6-9a2b26c48488",
                                         "TagParentGUID": "a6e3cc11-95a8-482c-beb4-58bbef6e7bdd",
                                         "TagOrder": null,
                                         "TagTitle": "Coffea nganda",
                                         "TagDescription": "Coffea nganda variety of coffea canephora",
                                         "TagTranslations": {
                                           "f454e93b-5fe9-42a9-b1af-b572234ed9c4": {
                                             "Title": "Coffea nganda enUS",
                                             "Description": "ENUS Coffea nganda variety of coffea canephora."
                                           },
                                           "a6c0a558-8b33-47b6-87a8-491b437c9923": {
                                             "Title": "Coffea nganda enGB",
                                             "Description": "ENGB Coffea nganda variety of coffea canephora."
                                           }
                                         }
                                       },
                                       {
                                         "$type": "Tag",
                                         "TagName": "CoffeaRobusta",
                                         "TagGUID": "bb181050-79b0-4f42-9280-ef486a139623",
                                         "TagTaxonomyGUID": "bd88fd9b-8d36-4d02-a4a6-9a2b26c48488",
                                         "TagParentGUID": "a6e3cc11-95a8-482c-beb4-58bbef6e7bdd",
                                         "TagOrder": null,
                                         "TagTitle": "Coffea robusta",
                                         "TagDescription": "Coffea robusta variety of coffea canephora",
                                         "TagTranslations": {
                                           "f454e93b-5fe9-42a9-b1af-b572234ed9c4": {
                                             "Title": "Coffea robusta enUS",
                                             "Description": "ENUS Coffea robusta variety of coffea canephora."
                                           },
                                           "a6c0a558-8b33-47b6-87a8-491b437c9923": {
                                             "Title": "Coffea robusta enGB",
                                             "Description": "ENGB Coffea robusta variety of coffea canephora."
                                           }
                                         }
                                       },
                                       {
                                         "$type": "Tag",
                                         "TagName": "CoffeaArabica",
                                         "TagGUID": "ffe48372-2bac-4a14-ad8c-c86f3f54c7c5",
                                         "TagTaxonomyGUID": "bd88fd9b-8d36-4d02-a4a6-9a2b26c48488",
                                         "TagParentGUID": null,
                                         "TagOrder": null,
                                         "TagTitle": "Coffea arabica",
                                         "TagDescription": "Coffea arabica (/\u0259\u02C8r\u00E6b\u026Ak\u0259/), also known as the Arabica coffee, is a species of flowering plant in the coffee and madder family Rubiaceae.",
                                         "TagTranslations": {
                                           "f454e93b-5fe9-42a9-b1af-b572234ed9c4": {
                                             "Title": "Coffea arabica enUS",
                                             "Description": "ENUS Wild plants grow between 9 and 12 m (30 and 39 ft) tall, and have an open branching system; the leaves are opposite, simple elliptic-ovate to oblong, 6\u201312 cm (2.5\u20134.5 in) long and 4\u20138 cm (1.5\u20133 in) broad, glossy dark green. The flowers are white, 10\u201315 mm in diameter, and grow in axillary clusters. The seeds are contained in a drupe (commonly called a \u0022cherry\u0022) 10\u201315 mm in diameter, maturing bright red to purple and typically containing two seeds, often called coffee beans."
                                           },
                                           "a6c0a558-8b33-47b6-87a8-491b437c9923": {
                                             "Title": "Coffea arabica enGB",
                                             "Description": "ENGB Wild plants grow between 9 and 12 m (30 and 39 ft) tall, and have an open branching system; the leaves are opposite, simple elliptic-ovate to oblong, 6\u201312 cm (2.5\u20134.5 in) long and 4\u20138 cm (1.5\u20133 in) broad, glossy dark green. The flowers are white, 10\u201315 mm in diameter, and grow in axillary clusters. The seeds are contained in a drupe (commonly called a \u0022cherry\u0022) 10\u201315 mm in diameter, maturing bright red to purple and typically containing two seeds, often called coffee beans."
                                           }
                                         }
                                       },
                                       {
                                         "$type": "UserInfo",
                                         "UserName": "sadmin",
                                         "FirstName": "Sample",
                                         "LastName": "Admin",
                                         "Email": "admin@sample.localhost",
                                         "UserPassword": "[sample hash]",
                                         "UserEnabled": true,
                                         "UserCreated": "1990-01-01T00:00:00Z",
                                         "LastLogon": null,
                                         "UserGUID": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                         "UserLastModified": null,
                                         "UserSecurityStamp": null,
                                         "UserPasswordLastChanged": null,
                                         "UserIsPendingRegistration": false,
                                         "UserRegistrationLinkExpiration": null,
                                         "UserAdministrationAccess": true,
                                         "UserIsExternal": false
                                       },
                                       {
                                         "$type": "ContentLanguage",
                                         "ContentLanguageGUID": "f454e93b-5fe9-42a9-b1af-b572234ed9c4",
                                         "ContentLanguageDisplayName": "English (United States)",
                                         "ContentLanguageName": "en-US",
                                         "ContentLanguageIsDefault": false,
                                         "ContentLanguageFallbackContentLanguageGuid": null,
                                         "ContentLanguageCultureFormat": "en-US"
                                       },
                                       {
                                         "$type": "ContentLanguage",
                                         "ContentLanguageGUID": "a6c0a558-8b33-47b6-87a8-491b437c9923",
                                         "ContentLanguageDisplayName": "English (United Kingdom)",
                                         "ContentLanguageName": "en-GB",
                                         "ContentLanguageIsDefault": false,
                                         "ContentLanguageFallbackContentLanguageGuid": null,
                                         "ContentLanguageCultureFormat": "en-GB"
                                       },
                                       {
                                         "$type": "Channel",
                                         "ChannelDisplayName": "email Channel Example",
                                         "ChannelName": "emailChannelExampleBasic",
                                         "ChannelGUID": "fc847362-e4b0-40ae-8235-f20098daf09f",
                                         "ChannelType": 1
                                       },
                                       {
                                         "$type": "Channel",
                                         "ChannelDisplayName": "website Channel Example",
                                         "ChannelName": "websitechannelExample",
                                         "ChannelGUID": "5322a379-5b5f-4220-9383-8e3115e66cd3",
                                         "ChannelType": 0
                                       },
                                       {
                                         "$type": "EmailChannel",
                                         "EmailChannelGUID": "2c7309ec-1e24-4715-ae6c-8c7efc98a4c5",
                                         "EmailChannelSendingDomain": "emailChannelsample.com",
                                         "EmailChannelPrimaryContentLanguageGUID": "f454e93b-5fe9-42a9-b1af-b572234ed9c4",
                                         "EmailChannelChannelGuid": "fc847362-e4b0-40ae-8235-f20098daf09f",
                                         "EmailChannelServiceDomain": "www.emailChannelSendingDomainSample"
                                       },
                                       {
                                         "$type": "WebSiteChannel",
                                         "WebsiteChannelGUID": "a6ba6fcb-9d05-4abe-afb4-74b153c90db7",
                                         "WebsiteChannelChannelGuid": "5322a379-5b5f-4220-9383-8e3115e66cd3",
                                         "WebsiteChannelDomain": "websitesamplewebsitedomain.com",
                                         "WebsiteChannelHomePage": "home",
                                         "WebsiteChannelPrimaryContentLanguageGuid": "f454e93b-5fe9-42a9-b1af-b572234ed9c4",
                                         "WebsiteChannelDefaultCookieLevel": 1000,
                                         "WebsiteChannelStoreFormerUrls": false
                                       },
                                       {
                                         "$type": "DataClass",
                                         "ClassDisplayName": "This is Article example",
                                         "ClassName": "UMT.Article",
                                         "ClassShortName": "UMT.Article",
                                         "ClassTableName": "UMT_Article",
                                         "ClassShowTemplateSelection": null,
                                         "ClassLastModified": "2024-01-08T22:55:31.7853783\u002B01:00",
                                         "ClassGUID": "06540294-3b56-4cf7-8773-088bb766ac23",
                                         "ClassContactMapping": null,
                                         "ClassContactOverwriteEnabled": null,
                                         "ClassConnectionString": null,
                                         "ClassDefaultObjectType": null,
                                         "ClassResourceGuid": null,
                                         "ClassCodeGenerationSettings": null,
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
                                       },
                                       {
                                         "$type": "ContentTypeChannel",
                                         "ContentTypeChannelChannelGuid": "5322a379-5b5f-4220-9383-8e3115e66cd3",
                                         "ContentTypeChannelContentTypeGuid": "06540294-3b56-4cf7-8773-088bb766ac23"
                                       },
                                       {
                                         "$type": "DataClass",
                                         "ClassDisplayName": "Faq",
                                         "ClassName": "UMT.Faq",
                                         "ClassShortName": "UMT.Faq",
                                         "ClassTableName": "UMT_Faq",
                                         "ClassShowTemplateSelection": null,
                                         "ClassLastModified": "2024-01-08T22:56:07.1472943Z",
                                         "ClassGUID": "7ed6604e-613b-4ce0-8c21-acfb372c416a",
                                         "ClassContactMapping": null,
                                         "ClassContactOverwriteEnabled": null,
                                         "ClassConnectionString": null,
                                         "ClassDefaultObjectType": null,
                                         "ClassResourceGuid": null,
                                         "ClassCodeGenerationSettings": null,
                                         "ClassHasUnmanagedDbSchema": false,
                                         "ClassType": "Content",
                                         "ClassContentTypeType": "Reusable",
                                         "ClassWebPageHasUrl": null,
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
                                       },
                                       {
                                         "$type": "DataClass",
                                         "ClassDisplayName": "Event",
                                         "ClassName": "UMT.Event",
                                         "ClassShortName": "UMT.Event",
                                         "ClassTableName": "UMT_Event",
                                         "ClassShowTemplateSelection": null,
                                         "ClassLastModified": "2024-01-08T22:56:12.2515785Z",
                                         "ClassGUID": "4712c000-4d63-4333-8708-990603f73a1e",
                                         "ClassContactMapping": null,
                                         "ClassContactOverwriteEnabled": null,
                                         "ClassConnectionString": null,
                                         "ClassDefaultObjectType": null,
                                         "ClassResourceGuid": null,
                                         "ClassCodeGenerationSettings": null,
                                         "ClassHasUnmanagedDbSchema": false,
                                         "ClassType": "Content",
                                         "ClassContentTypeType": "Reusable",
                                         "ClassWebPageHasUrl": null,
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
                                       },
                                       {
                                         "$type": "ContentItem",
                                         "ContentItemGUID": "c354427d-3d02-4876-8ed4-4de817fae929",
                                         "ContentItemContentFolderGUID": null,
                                         "ContentItemName": "NewsLetterExampleName",
                                         "ContentItemIsReusable": true,
                                         "ContentItemIsSecured": true,
                                         "ContentItemDataClassGuid": "978b2cd4-c248-4317-86a1-3bdd17444267",
                                         "ContentItemChannelGuid": "b186b5a3-f408-4e21-a2f9-e51d68ecac38"
                                       },
                                       {
                                         "$type": "ContentItemLanguageMetadata",
                                         "ContentItemLanguageMetadataGUID": "65421553-5f92-44b7-a02f-2b9ca083e14a",
                                         "ContentItemLanguageMetadataContentItemGuid": "c354427d-3d02-4876-8ed4-4de817fae929",
                                         "ContentItemLanguageMetadataDisplayName": "Basic Language Metadata Example",
                                         "ContentItemLanguageMetadataLatestVersionStatus": 1,
                                         "ContentItemLanguageMetadataCreatedWhen": "2024-01-06T22:55:48.9503105Z",
                                         "ContentItemLanguageMetadataCreatedByUserGuid": null,
                                         "ContentItemLanguageMetadataModifiedWhen": "2024-01-08T22:55:52.0392925Z",
                                         "ContentItemLanguageMetadataModifiedByUserGuid": null,
                                         "ContentItemLanguageMetadataHasImageAsset": false,
                                         "ContentItemLanguageMetadataContentLanguageGuid": "f454e93b-5fe9-42a9-b1af-b572234ed9c4"
                                       },
                                       {
                                         "$type": "ContentItemLanguageMetadata",
                                         "ContentItemLanguageMetadataGUID": "12191a4b-26d8-40bb-a214-73d9874920fd",
                                         "ContentItemLanguageMetadataContentItemGuid": "c354427d-3d02-4876-8ed4-4de817fae929",
                                         "ContentItemLanguageMetadataDisplayName": "Language Metadata Example",
                                         "ContentItemLanguageMetadataLatestVersionStatus": 2,
                                         "ContentItemLanguageMetadataCreatedWhen": "2024-01-06T22:55:58.3208748Z",
                                         "ContentItemLanguageMetadataCreatedByUserGuid": "95f42fd4-6a14-4e88-b214-4e136479f788",
                                         "ContentItemLanguageMetadataModifiedWhen": "2024-01-08T22:56:01.1939486Z",
                                         "ContentItemLanguageMetadataModifiedByUserGuid": "95f42fd4-6a14-4e88-b214-4e136479f788",
                                         "ContentItemLanguageMetadataHasImageAsset": false,
                                         "ContentItemLanguageMetadataContentLanguageGuid": "f454e93b-5fe9-42a9-b1af-b572234ed9c4"
                                       },
                                       {
                                         "$type": "WebPageItem",
                                         "WebPageItemGUID": "6e995319-77e7-475e-9ebb-607bdbf5af9a",
                                         "WebPageItemParentGuid": null,
                                         "WebPageItemName": "NewWebPageItem",
                                         "WebPageItemTreePath": "/home",
                                         "WebPageItemWebsiteChannelGuid": "a6ba6fcb-9d05-4abe-afb4-74b153c90db7",
                                         "WebPageItemContentItemGuid": "c354427d-3d02-4876-8ed4-4de817fae929",
                                         "WebPageItemOrder": 1
                                       },
                                       {
                                         "$type": "Media_Library",
                                         "LibraryName": "LibrarySample",
                                         "LibraryDisplayName": "LibraryDisplayedName",
                                         "LibraryDescription": "TestLibrary",
                                         "LibraryFolder": "TestFolder",
                                         "LibraryGUID": "e3a9c50c-2b76-4ba8-ac19-2f0aa64c47d5",
                                         "LibraryLastModified": null
                                       },
                                       {
                                         "$type": "Media_File",
                                         "DataSourcePath": null,
                                         "DataSourceUrl": "https://devnet.kentico.com/DevNet/media/devnet/cms_screen.jpg",
                                         "FileGUID": "94df1156-c85d-4356-8e28-16d71c6ac899",
                                         "FileLibraryGuid": "e3a9c50c-2b76-4ba8-ac19-2f0aa64c47d5",
                                         "FileCreatedByUserGuid": "863f796e-823a-4f5e-bbdb-e4a6f15b349b",
                                         "FileModifiedByUserGuid": null,
                                         "FileName": "NewTestFileFromUri",
                                         "FileTitle": "Old devnet screen",
                                         "FileDescription": null,
                                         "FileExtension": ".jpg",
                                         "FileMimeType": null,
                                         "FilePath": "customdir/NewTestFileFromUri.jpg",
                                         "FileImageWidth": null,
                                         "FileImageHeight": null,
                                         "FileCreatedWhen": null,
                                         "FileModifiedWhen": null
                                       },
                                       {
                                         "$type": "ContentItem",
                                         "ContentItemGUID": "b64b3e3e-f5a9-4d02-8cdb-6d81805c0fee",
                                         "ContentItemContentFolderGUID": null,
                                         "ContentItemName": "SampleReusableFaq",
                                         "ContentItemIsReusable": true,
                                         "ContentItemIsSecured": true,
                                         "ContentItemDataClassGuid": "7ed6604e-613b-4ce0-8c21-acfb372c416a",
                                         "ContentItemChannelGuid": null
                                       },
                                       {
                                         "$type": "ContentItemCommonData",
                                         "ContentItemCommonDataGUID": "2b1987bf-680b-48c0-85ce-47ff9fde24c7",
                                         "ContentItemCommonDataContentItemGuid": "b64b3e3e-f5a9-4d02-8cdb-6d81805c0fee",
                                         "ContentItemCommonDataContentLanguageGuid": "f454e93b-5fe9-42a9-b1af-b572234ed9c4",
                                         "ContentItemCommonDataVersionStatus": 2,
                                         "ContentItemCommonDataIsLatest": true,
                                         "ContentItemCommonDataPageBuilderWidgets": null,
                                         "ContentItemCommonDataPageTemplateConfiguration": null
                                       },
                                       {
                                         "$type": "ContentItemCommonData",
                                         "ContentItemCommonDataGUID": "96016b05-b3d3-42f9-b5aa-71e2f816eb8f",
                                         "ContentItemCommonDataContentItemGuid": "b64b3e3e-f5a9-4d02-8cdb-6d81805c0fee",
                                         "ContentItemCommonDataContentLanguageGuid": "a6c0a558-8b33-47b6-87a8-491b437c9923",
                                         "ContentItemCommonDataVersionStatus": 2,
                                         "ContentItemCommonDataIsLatest": true,
                                         "ContentItemCommonDataPageBuilderWidgets": null,
                                         "ContentItemCommonDataPageTemplateConfiguration": null
                                       },
                                       {
                                         "$type": "ContentItemData",
                                         "ContentItemDataGUID": "d29e7c59-09d5-443c-999d-063ba62e5f97",
                                         "ContentItemDataCommonDataGuid": "2b1987bf-680b-48c0-85ce-47ff9fde24c7",
                                         "ContentItemContentTypeName": "UMT.Faq",
                                         "FaqQuestion": "en-US FAQ question text",
                                         "FaqAnswer": "en-US FAQ answer text"
                                       },
                                       {
                                         "$type": "ContentItemData",
                                         "ContentItemDataGUID": "93269639-1c4a-48b8-b367-0da00268eeb0",
                                         "ContentItemDataCommonDataGuid": "96016b05-b3d3-42f9-b5aa-71e2f816eb8f",
                                         "ContentItemContentTypeName": "UMT.Faq",
                                         "FaqQuestion": "en-GB FAQ question text",
                                         "FaqAnswer": "en-GB FAQ answer text"
                                       },
                                       {
                                         "$type": "ContentItemLanguageMetadata",
                                         "ContentItemLanguageMetadataGUID": "46353800-21b8-48f6-8681-b19966f4b6eb",
                                         "ContentItemLanguageMetadataContentItemGuid": "b64b3e3e-f5a9-4d02-8cdb-6d81805c0fee",
                                         "ContentItemLanguageMetadataDisplayName": "Sample reusable FAQ",
                                         "ContentItemLanguageMetadataLatestVersionStatus": 2,
                                         "ContentItemLanguageMetadataCreatedWhen": "2023-12-10T00:00:00Z",
                                         "ContentItemLanguageMetadataCreatedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                         "ContentItemLanguageMetadataModifiedWhen": null,
                                         "ContentItemLanguageMetadataModifiedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                         "ContentItemLanguageMetadataHasImageAsset": false,
                                         "ContentItemLanguageMetadataContentLanguageGuid": "f454e93b-5fe9-42a9-b1af-b572234ed9c4"
                                       },
                                       {
                                         "$type": "ContentItemLanguageMetadata",
                                         "ContentItemLanguageMetadataGUID": "b15b3d9f-0cb1-405a-bc04-a069daecf72d",
                                         "ContentItemLanguageMetadataContentItemGuid": "b64b3e3e-f5a9-4d02-8cdb-6d81805c0fee",
                                         "ContentItemLanguageMetadataDisplayName": "Sample reusable FAQ",
                                         "ContentItemLanguageMetadataLatestVersionStatus": 2,
                                         "ContentItemLanguageMetadataCreatedWhen": "2023-12-10T00:00:00Z",
                                         "ContentItemLanguageMetadataCreatedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                         "ContentItemLanguageMetadataModifiedWhen": null,
                                         "ContentItemLanguageMetadataModifiedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                         "ContentItemLanguageMetadataHasImageAsset": false,
                                         "ContentItemLanguageMetadataContentLanguageGuid": "a6c0a558-8b33-47b6-87a8-491b437c9923"
                                       },
                                       {
                                         "$type": "ContentItem",
                                         "ContentItemGUID": "df81215e-1414-4d87-befd-ae123f4e5653",
                                         "ContentItemContentFolderGUID": null,
                                         "ContentItemName": "CreationOfUmtModel",
                                         "ContentItemIsReusable": false,
                                         "ContentItemIsSecured": false,
                                         "ContentItemDataClassGuid": "06540294-3b56-4cf7-8773-088bb766ac23",
                                         "ContentItemChannelGuid": "5322a379-5b5f-4220-9383-8e3115e66cd3"
                                       },
                                       {
                                         "$type": "ContentItemCommonData",
                                         "ContentItemCommonDataGUID": "8f070195-2f39-463e-b7eb-c180c05fd5e0",
                                         "ContentItemCommonDataContentItemGuid": "df81215e-1414-4d87-befd-ae123f4e5653",
                                         "ContentItemCommonDataContentLanguageGuid": "f454e93b-5fe9-42a9-b1af-b572234ed9c4",
                                         "ContentItemCommonDataVersionStatus": 2,
                                         "ContentItemCommonDataIsLatest": true,
                                         "ContentItemCommonDataPageBuilderWidgets": null,
                                         "ContentItemCommonDataPageTemplateConfiguration": null
                                       },
                                       {
                                         "$type": "ContentItemCommonData",
                                         "ContentItemCommonDataGUID": "49d2caf6-2011-42d7-961d-02614d1b43f4",
                                         "ContentItemCommonDataContentItemGuid": "df81215e-1414-4d87-befd-ae123f4e5653",
                                         "ContentItemCommonDataContentLanguageGuid": "a6c0a558-8b33-47b6-87a8-491b437c9923",
                                         "ContentItemCommonDataVersionStatus": 2,
                                         "ContentItemCommonDataIsLatest": true,
                                         "ContentItemCommonDataPageBuilderWidgets": null,
                                         "ContentItemCommonDataPageTemplateConfiguration": null
                                       },
                                       {
                                         "$type": "ContentItemData",
                                         "ContentItemDataGUID": "9a5b10e0-d0e6-4de9-9d82-6d8deeea1849",
                                         "ContentItemDataCommonDataGuid": "8f070195-2f39-463e-b7eb-c180c05fd5e0",
                                         "ContentItemContentTypeName": "UMT.Article",
                                         "ArticleTitle": "en-US UMT model creation",
                                         "ArticleText": "This article is only example of creation UMT model for en-US language",
                                         "RelatedArticles": null,
                                         "RelatedFaq": null,
                                         "CoffeaTaxonomy": "[{\u0022Identifier\u0022:\u0022ffe48372-2bac-4a14-ad8c-c86f3f54c7c5\u0022}]"
                                       },
                                       {
                                         "$type": "ContentItemData",
                                         "ContentItemDataGUID": "21380f91-279b-44be-aad8-2e62c345a0e9",
                                         "ContentItemDataCommonDataGuid": "49d2caf6-2011-42d7-961d-02614d1b43f4",
                                         "ContentItemContentTypeName": "UMT.Article",
                                         "ArticleTitle": "en-GB UMT model creation",
                                         "ArticleText": "This article is only example of creation UMT model for en-GB language",
                                         "RelatedArticles": null,
                                         "RelatedFaq": null,
                                         "CoffeaTaxonomy": "[{\u0022Identifier\u0022:\u0022ffe48372-2bac-4a14-ad8c-c86f3f54c7c5\u0022}]"
                                       },
                                       {
                                         "$type": "ContentItemLanguageMetadata",
                                         "ContentItemLanguageMetadataGUID": "192c63ac-e5be-4b0f-b916-b8af6c7e79a9",
                                         "ContentItemLanguageMetadataContentItemGuid": "df81215e-1414-4d87-befd-ae123f4e5653",
                                         "ContentItemLanguageMetadataDisplayName": "Creation of UMT model",
                                         "ContentItemLanguageMetadataLatestVersionStatus": 2,
                                         "ContentItemLanguageMetadataCreatedWhen": "2023-12-10T00:00:00Z",
                                         "ContentItemLanguageMetadataCreatedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                         "ContentItemLanguageMetadataModifiedWhen": null,
                                         "ContentItemLanguageMetadataModifiedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                         "ContentItemLanguageMetadataHasImageAsset": false,
                                         "ContentItemLanguageMetadataContentLanguageGuid": "f454e93b-5fe9-42a9-b1af-b572234ed9c4"
                                       },
                                       {
                                         "$type": "ContentItemLanguageMetadata",
                                         "ContentItemLanguageMetadataGUID": "7f6a0c0d-a2bb-454c-8e16-adcfe0e38d17",
                                         "ContentItemLanguageMetadataContentItemGuid": "df81215e-1414-4d87-befd-ae123f4e5653",
                                         "ContentItemLanguageMetadataDisplayName": "Creation of UMT model GB",
                                         "ContentItemLanguageMetadataLatestVersionStatus": 2,
                                         "ContentItemLanguageMetadataCreatedWhen": "2023-12-10T00:00:00Z",
                                         "ContentItemLanguageMetadataCreatedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                         "ContentItemLanguageMetadataModifiedWhen": null,
                                         "ContentItemLanguageMetadataModifiedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                         "ContentItemLanguageMetadataHasImageAsset": false,
                                         "ContentItemLanguageMetadataContentLanguageGuid": "a6c0a558-8b33-47b6-87a8-491b437c9923"
                                       },
                                       {
                                         "$type": "WebPageUrlPath",
                                         "WebPageUrlPathGUID": "2bda2458-e262-4825-b51b-5a7b345ed7bd",
                                         "WebPageUrlPath": "en-US/creation-of-umt-model",
                                         "WebPageUrlPathHash": null,
                                         "WebPageUrlPathWebPageItemGuid": "6e995319-77e7-475e-9ebb-607bdbf5af9a",
                                         "WebPageUrlPathWebsiteChannelGuid": "a6ba6fcb-9d05-4abe-afb4-74b153c90db7",
                                         "WebPageUrlPathContentLanguageGuid": "f454e93b-5fe9-42a9-b1af-b572234ed9c4",
                                         "WebPageUrlPathIsLatest": true,
                                         "WebPageUrlPathIsDraft": false
                                       },
                                       {
                                         "$type": "WebPageUrlPath",
                                         "WebPageUrlPathGUID": "8083fa41-03fe-49c3-87fb-4f7c530b14cf",
                                         "WebPageUrlPath": "en-GB/creation-of-umt-model",
                                         "WebPageUrlPathHash": null,
                                         "WebPageUrlPathWebPageItemGuid": "6e995319-77e7-475e-9ebb-607bdbf5af9a",
                                         "WebPageUrlPathWebsiteChannelGuid": "a6ba6fcb-9d05-4abe-afb4-74b153c90db7",
                                         "WebPageUrlPathContentLanguageGuid": "a6c0a558-8b33-47b6-87a8-491b437c9923",
                                         "WebPageUrlPathIsLatest": true,
                                         "WebPageUrlPathIsDraft": false
                                       },
                                       {
                                         "$type": "WebPageItem",
                                         "WebPageItemGUID": "6e995319-77e7-475e-9ebb-607bdbf5af9a",
                                         "WebPageItemParentGuid": null,
                                         "WebPageItemName": "CreationOfUmtModelUs",
                                         "WebPageItemTreePath": "/creation-of-umt-model",
                                         "WebPageItemWebsiteChannelGuid": "a6ba6fcb-9d05-4abe-afb4-74b153c90db7",
                                         "WebPageItemContentItemGuid": "df81215e-1414-4d87-befd-ae123f4e5653",
                                         "WebPageItemOrder": 1
                                       },
                                       {
                                         "$type": "ContentItem",
                                         "ContentItemGUID": "e09121ad-dd97-472f-b8f6-85fe5428ed6a",
                                         "ContentItemContentFolderGUID": null,
                                         "ContentItemName": "Content-item-with-relations",
                                         "ContentItemIsReusable": false,
                                         "ContentItemIsSecured": true,
                                         "ContentItemDataClassGuid": "06540294-3b56-4cf7-8773-088bb766ac23",
                                         "ContentItemChannelGuid": "5322a379-5b5f-4220-9383-8e3115e66cd3"
                                       },
                                       {
                                         "$type": "ContentItemCommonData",
                                         "ContentItemCommonDataGUID": "56f0e676-8fcc-4a5d-8b69-f6eca372b998",
                                         "ContentItemCommonDataContentItemGuid": "e09121ad-dd97-472f-b8f6-85fe5428ed6a",
                                         "ContentItemCommonDataContentLanguageGuid": "f454e93b-5fe9-42a9-b1af-b572234ed9c4",
                                         "ContentItemCommonDataVersionStatus": 0,
                                         "ContentItemCommonDataIsLatest": true,
                                         "ContentItemCommonDataPageBuilderWidgets": null,
                                         "ContentItemCommonDataPageTemplateConfiguration": null
                                       },
                                       {
                                         "$type": "ContentItemCommonData",
                                         "ContentItemCommonDataGUID": "a790b2d4-5ac1-4fb0-812c-2ad2171c61c9",
                                         "ContentItemCommonDataContentItemGuid": "e09121ad-dd97-472f-b8f6-85fe5428ed6a",
                                         "ContentItemCommonDataContentLanguageGuid": "a6c0a558-8b33-47b6-87a8-491b437c9923",
                                         "ContentItemCommonDataVersionStatus": 2,
                                         "ContentItemCommonDataIsLatest": true,
                                         "ContentItemCommonDataPageBuilderWidgets": null,
                                         "ContentItemCommonDataPageTemplateConfiguration": null
                                       },
                                       {
                                         "$type": "ContentItemData",
                                         "ContentItemDataGUID": "b6847866-12b1-4a4a-aba7-d93860102bc8",
                                         "ContentItemDataCommonDataGuid": "56f0e676-8fcc-4a5d-8b69-f6eca372b998",
                                         "ContentItemContentTypeName": "UMT.Article",
                                         "ArticleTitle": "en-US UMT model creation",
                                         "ArticleText": "This article is only example of creation UMT model for en-US language",
                                         "RelatedArticles": "[{\u0022WebPageGuid\u0022:\u00226e995319-77e7-475e-9ebb-607bdbf5af9a\u0022}]",
                                         "RelatedFaq": "[{\u0022Identifier\u0022:\u0022b64b3e3e-f5a9-4d02-8cdb-6d81805c0fee\u0022}]"
                                       },
                                       {
                                         "$type": "ContentItemReference",
                                         "ContentItemReferenceGUID": "186e37c6-5c55-4637-8feb-ec5cb6547aba",
                                         "ContentItemReferenceSourceCommonDataGuid": "8f070195-2f39-463e-b7eb-c180c05fd5e0",
                                         "ContentItemReferenceTargetItemGuid": "b64b3e3e-f5a9-4d02-8cdb-6d81805c0fee",
                                         "ContentItemReferenceGroupGUID": "fc1fde10-11bf-4174-bd64-d1f114e4b421"
                                       },
                                       {
                                         "$type": "ContentItemData",
                                         "ContentItemDataGUID": "a80f91ff-4cfc-4e28-982a-e4a434517680",
                                         "ContentItemDataCommonDataGuid": "a790b2d4-5ac1-4fb0-812c-2ad2171c61c9",
                                         "ContentItemContentTypeName": "UMT.Article",
                                         "ArticleTitle": "en-GB UMT model creation",
                                         "ArticleText": "This article is only example of creation UMT model for en-GB language",
                                         "RelatedArticles": "[{\u0022WebPageGuid\u0022:\u00226e995319-77e7-475e-9ebb-607bdbf5af9a\u0022}]",
                                         "RelatedFaq": "[{\u0022Identifier\u0022:\u0022b64b3e3e-f5a9-4d02-8cdb-6d81805c0fee\u0022}]"
                                       },
                                       {
                                         "$type": "ContentItemReference",
                                         "ContentItemReferenceGUID": "e95eefe5-5b89-43ab-91c9-777be00d5680",
                                         "ContentItemReferenceSourceCommonDataGuid": "49d2caf6-2011-42d7-961d-02614d1b43f4",
                                         "ContentItemReferenceTargetItemGuid": "b64b3e3e-f5a9-4d02-8cdb-6d81805c0fee",
                                         "ContentItemReferenceGroupGUID": "fc1fde10-11bf-4174-bd64-d1f114e4b421"
                                       },
                                       {
                                         "$type": "ContentItemLanguageMetadata",
                                         "ContentItemLanguageMetadataGUID": "9ec48558-4e26-4ddf-9804-fa0fbe95142d",
                                         "ContentItemLanguageMetadataContentItemGuid": "e09121ad-dd97-472f-b8f6-85fe5428ed6a",
                                         "ContentItemLanguageMetadataDisplayName": "Content item with relations",
                                         "ContentItemLanguageMetadataLatestVersionStatus": 0,
                                         "ContentItemLanguageMetadataCreatedWhen": "2023-12-10T00:00:00Z",
                                         "ContentItemLanguageMetadataCreatedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                         "ContentItemLanguageMetadataModifiedWhen": null,
                                         "ContentItemLanguageMetadataModifiedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                         "ContentItemLanguageMetadataHasImageAsset": false,
                                         "ContentItemLanguageMetadataContentLanguageGuid": "f454e93b-5fe9-42a9-b1af-b572234ed9c4"
                                       },
                                       {
                                         "$type": "ContentItemLanguageMetadata",
                                         "ContentItemLanguageMetadataGUID": "8a3f1795-c0ac-4501-be4e-6fba0cd11654",
                                         "ContentItemLanguageMetadataContentItemGuid": "e09121ad-dd97-472f-b8f6-85fe5428ed6a",
                                         "ContentItemLanguageMetadataDisplayName": "Content item with relations en-GB",
                                         "ContentItemLanguageMetadataLatestVersionStatus": 2,
                                         "ContentItemLanguageMetadataCreatedWhen": "2023-12-10T00:00:00Z",
                                         "ContentItemLanguageMetadataCreatedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                         "ContentItemLanguageMetadataModifiedWhen": null,
                                         "ContentItemLanguageMetadataModifiedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                         "ContentItemLanguageMetadataHasImageAsset": false,
                                         "ContentItemLanguageMetadataContentLanguageGuid": "a6c0a558-8b33-47b6-87a8-491b437c9923"
                                       },
                                       {
                                         "$type": "WebPageItem",
                                         "WebPageItemGUID": "14784bf0-69d0-40cf-8be6-e5a0d897774b",
                                         "WebPageItemParentGuid": null,
                                         "WebPageItemName": "ContentItemWithRelations",
                                         "WebPageItemTreePath": "/content-item-with-relations",
                                         "WebPageItemWebsiteChannelGuid": "a6ba6fcb-9d05-4abe-afb4-74b153c90db7",
                                         "WebPageItemContentItemGuid": "e09121ad-dd97-472f-b8f6-85fe5428ed6a",
                                         "WebPageItemOrder": 1
                                       },
                                       {
                                         "$type": "WebPageUrlPath",
                                         "WebPageUrlPathGUID": "c0f97ba5-7a64-4309-8d58-6054fc90ac66",
                                         "WebPageUrlPath": "en-US/content-item-with-relations",
                                         "WebPageUrlPathHash": null,
                                         "WebPageUrlPathWebPageItemGuid": "14784bf0-69d0-40cf-8be6-e5a0d897774b",
                                         "WebPageUrlPathWebsiteChannelGuid": "a6ba6fcb-9d05-4abe-afb4-74b153c90db7",
                                         "WebPageUrlPathContentLanguageGuid": "f454e93b-5fe9-42a9-b1af-b572234ed9c4",
                                         "WebPageUrlPathIsLatest": true,
                                         "WebPageUrlPathIsDraft": false
                                       },
                                       {
                                         "$type": "WebPageUrlPath",
                                         "WebPageUrlPathGUID": "ccb7af1f-57d9-405a-84fa-d0f4129a17da",
                                         "WebPageUrlPath": "en-GB/content-item-with-relations",
                                         "WebPageUrlPathHash": null,
                                         "WebPageUrlPathWebPageItemGuid": "14784bf0-69d0-40cf-8be6-e5a0d897774b",
                                         "WebPageUrlPathWebsiteChannelGuid": "a6ba6fcb-9d05-4abe-afb4-74b153c90db7",
                                         "WebPageUrlPathContentLanguageGuid": "a6c0a558-8b33-47b6-87a8-491b437c9923",
                                         "WebPageUrlPathIsLatest": true,
                                         "WebPageUrlPathIsDraft": false
                                       },
                                       {
                                         "$type": "ContentFolder",
                                         "ContentFolderGUID": "7665a8fc-53a2-4aff-86e8-99b009104ff2",
                                         "ContentFolderParentFolderGUID": null,
                                         "ContentFolderName": "articles",
                                         "ContentFolderDisplayName": "Articles",
                                         "ContentFolderTreePath": "/articles"
                                       },
                                       {
                                         "$type": "ContentFolder",
                                         "ContentFolderGUID": "ae29c1d1-217a-45da-8b30-585d1881387e",
                                         "ContentFolderParentFolderGUID": "7665a8fc-53a2-4aff-86e8-99b009104ff2",
                                         "ContentFolderName": "obsolete",
                                         "ContentFolderDisplayName": "Obsolete",
                                         "ContentFolderTreePath": "/articles/obsolete"
                                       },
                                       {
                                         "$type": "ContentItemSimplified",
                                         "ContentItemGUID": "37c3f5dd-6f2a-4eff-b46e-a36eddebf572",
                                         "ContentItemContentFolderGUID": null,
                                         "IsSecured": false,
                                         "ContentTypeName": "UMT.Article",
                                         "Name": "SimplifiedModelSample",
                                         "IsReusable": true,
                                         "ChannelName": "websitechannelExample",
                                         "LanguageData": [
                                           {
                                             "LanguageName": "en-US",
                                             "DisplayName": "Simplified model sample - en-us",
                                             "VersionStatus": 0,
                                             "UserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                             "ContentItemData": {
                                               "ArticleTitle": "en-US UMT simplified model creation",
                                               "ArticleText": "This article is only example of creation UMT simplified model for en-US language",
                                               "RelatedArticles": null,
                                               "RelatedFaq": null,
                                               "CoffeaTaxonomy": "[{\u0022Identifier\u0022:\u0022a6e3cc11-95a8-482c-beb4-58bbef6e7bdd\u0022},{\u0022Identifier\u0022:\u0022bb181050-79b0-4f42-9280-ef486a139623\u0022}]"
                                             }
                                           },
                                           {
                                             "LanguageName": "en-GB",
                                             "DisplayName": "Simplified model sample - en-gb",
                                             "VersionStatus": 2,
                                             "UserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                             "ContentItemData": {
                                               "ArticleTitle": "en-GB UMT simplified model creation",
                                               "ArticleText": "This article is only example of creation UMT simplified model for en-GB language",
                                               "RelatedArticles": null,
                                               "RelatedFaq": null,
                                               "CoffeaTaxonomy": "[{\u0022Identifier\u0022:\u0022a6e3cc11-95a8-482c-beb4-58bbef6e7bdd\u0022},{\u0022Identifier\u0022:\u0022bb181050-79b0-4f42-9280-ef486a139623\u0022}]"
                                             }
                                           }
                                         ],
                                         "PageData": {
                                           "PageUrls": [
                                             {
                                               "UrlPath": "en-us/simplified-sample",
                                               "PathIsDraft": true,
                                               "LanguageName": "en-US"
                                             },
                                             {
                                               "UrlPath": "en-gb/simplified-sample",
                                               "PathIsDraft": true,
                                               "LanguageName": "en-GB"
                                             }
                                           ],
                                           "ParentGuid": null,
                                           "TreePath": "/simplified-sample",
                                           "ItemOrder": null
                                         }
                                       },
                                       {
                                         "$type": "ContentItemSimplified",
                                         "ContentItemGUID": "f9cb9484-ce90-460f-a5c8-ad953e2b9286",
                                         "ContentItemContentFolderGUID": "ae29c1d1-217a-45da-8b30-585d1881387e",
                                         "IsSecured": false,
                                         "ContentTypeName": "UMT.Faq",
                                         "Name": "SimplifiedModelSampleReusable",
                                         "IsReusable": true,
                                         "ChannelName": null,
                                         "LanguageData": [
                                           {
                                             "LanguageName": "en-US",
                                             "DisplayName": "FAQ: reusable simplified model sample - en-us",
                                             "VersionStatus": 0,
                                             "UserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                             "ContentItemData": {
                                               "FaqQuestion": "en-US FAQ question text (reusable)",
                                               "FaqAnswer": "en-US FAQ answer text (reusable)"
                                             }
                                           },
                                           {
                                             "LanguageName": "en-GB",
                                             "DisplayName": "FAQ: reusable simplified model sample - en-gb",
                                             "VersionStatus": 2,
                                             "UserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                             "ContentItemData": {
                                               "FaqQuestion": "en-US FAQ question text (reusable)",
                                               "FaqAnswer": "en-US FAQ answer text (reusable)"
                                             }
                                           }
                                         ],
                                         "PageData": null
                                       }
                                     ]
                                     """;
#pragma warning restore S2479
}
