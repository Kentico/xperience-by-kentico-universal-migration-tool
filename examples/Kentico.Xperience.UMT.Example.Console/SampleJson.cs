﻿namespace Kentico.Xperience.UMT.Example.Console;

public static class SampleJson
{
#pragma warning disable S2479
    public const string FULL_SAMPLE = """
                                     [
                                       {
                                         "$type": "UserInfo",
                                         "UserName": "sadmin",
                                         "FirstName": "Sample",
                                         "LastName": "Admin",
                                         "Email": "admin@sample.localhost",
                                         "UserPassword": "[sample hash]",
                                         "UserEnabled": true,
                                         "UserCreated": "1990-01-01T00:00:00",
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
                                         "ClassTableName": "UMT_Article",
                                         "ClassShowTemplateSelection": null,
                                         "ClassLastModified": "2023-12-08T16:43:01.6074471\u002B01:00",
                                         "ClassGUID": "06540294-3b56-4cf7-8773-088bb766ac23",
                                         "ClassContactMapping": null,
                                         "ClassContactOverwriteEnabled": null,
                                         "ClassConnectionString": null,
                                         "ClassDefaultObjectType": null,
                                         "ClassResourceGuid": "0e4beef1-989c-4687-80ca-ae21fec09734",
                                         "ClassCodeGenerationSettings": null,
                                         "ClassHasUnmanagedDbSchema": false,
                                         "ClassType": "Content",
                                         "ClassContentTypeType": "Website",
                                         "ClassWebPageHasUrl": null,
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
                                         "ClassTableName": "UMT_Faq",
                                         "ClassShowTemplateSelection": null,
                                         "ClassLastModified": "2023-12-08T16:43:01.6074708\u002B01:00",
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
                                         "$type": "ContentItem",
                                         "ContentItemGUID": "c354427d-3d02-4876-8ed4-4de817fae929",
                                         "ContentItemName": "NewsLetterExampleName",
                                         "ContentItemIsReusable": true,
                                         "ContentItemIsSecured": true,
                                         "ContentItemDataClassGuid": "978b2cd4-c248-4317-86a1-3bdd17444267",
                                         "ContentItemChannelGuid": "b186b5a3-f408-4e21-a2f9-e51d68ecac38"
                                       },
                                       {
                                         "$type": "ContentItemLanguageMetadata",
                                         "ContentItemLanguageMetadataGUID": "12191a4b-26d8-40bb-a214-73d9874920fd",
                                         "ContentItemLanguageMetadataContentItemGuid": "c354427d-3d02-4876-8ed4-4de817fae929",
                                         "ContentItemLanguageMetadataDisplayName": "Language Metadata Example",
                                         "ContentItemLanguageMetadataLatestVersionStatus": 0,
                                         "ContentItemLanguageMetadataCreatedWhen": "2023-12-06T16:43:01.6084443\u002B01:00",
                                         "ContentItemLanguageMetadataCreatedByUserGuid": "95f42fd4-6a14-4e88-b214-4e136479f788",
                                         "ContentItemLanguageMetadataModifiedWhen": "2023-12-08T16:43:01.6084543\u002B01:00",
                                         "ContentItemLanguageMetadataModifiedByUserGuid": "95f42fd4-6a14-4e88-b214-4e136479f788",
                                         "ContentItemLanguageMetadataHasImageAsset": false,
                                         "ContentItemLanguageMetadataContentLanguageGuid": "f454e93b-5fe9-42a9-b1af-b572234ed9c4"
                                       },
                                       {
                                         "$type": "ContentItemLanguageMetadata",
                                         "ContentItemLanguageMetadataGUID": "65421553-5f92-44b7-a02f-2b9ca083e14a",
                                         "ContentItemLanguageMetadataContentItemGuid": "c354427d-3d02-4876-8ed4-4de817fae929",
                                         "ContentItemLanguageMetadataDisplayName": "Basic Language Metadata Example",
                                         "ContentItemLanguageMetadataLatestVersionStatus": 0,
                                         "ContentItemLanguageMetadataCreatedWhen": "2023-12-06T16:43:01.6089379\u002B01:00",
                                         "ContentItemLanguageMetadataCreatedByUserGuid": null,
                                         "ContentItemLanguageMetadataModifiedWhen": "2023-12-08T16:43:01.6089482\u002B01:00",
                                         "ContentItemLanguageMetadataModifiedByUserGuid": null,
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
                                         "LibraryAccess": null,
                                         "LibraryGUID": "e3a9c50c-2b76-4ba8-ac19-2f0aa64c47d5",
                                         "LibraryLastModified": null
                                       },
                                       {
                                         "$type": "Media_File",
                                         "DataSourcePath": ".\\sample.png",
                                         "FileGUID": "214e29aa-32d5-40d7-9fea-896591439e74",
                                         "FileLibraryGuid": "e3a9c50c-2b76-4ba8-ac19-2f0aa64c47d5",
                                         "FileCreatedByUserGuid": "863f796e-823a-4f5e-bbdb-e4a6f15b349b",
                                         "FileModifiedByUserGuid": null,
                                         "FileName": "NewTestFile.png",
                                         "FileTitle": "Title",
                                         "FileDescription": null,
                                         "FileExtension": ".png",
                                         "FileMimeType": null,
                                         "FilePath": "newPath/somepath",
                                         "FileImageWidth": null,
                                         "FileImageHeight": null,
                                         "FileCreatedWhen": null,
                                         "FileModifiedWhen": null,
                                         "FileCustomData": null
                                       },
                                       {
                                         "$type": "ContentItem",
                                         "ContentItemGUID": "df81215e-1414-4d87-befd-ae123f4e5653",
                                         "ContentItemName": "CreationOfUmtModel",
                                         "ContentItemIsReusable": true,
                                         "ContentItemIsSecured": true,
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
                                         "ArticleText": "This article is only example of creation UMT model for en-US language"
                                       },
                                       {
                                         "$type": "ContentItemData",
                                         "ContentItemDataGUID": "21380f91-279b-44be-aad8-2e62c345a0e9",
                                         "ContentItemDataCommonDataGuid": "49d2caf6-2011-42d7-961d-02614d1b43f4",
                                         "ContentItemContentTypeName": "UMT.Article",
                                         "ArticleTitle": "en-GB UMT model creation",
                                         "ArticleText": "This article is only example of creation UMT model for en-GB language"
                                       },
                                       {
                                         "$type": "ContentItemLanguageMetadata",
                                         "ContentItemLanguageMetadataGUID": "192c63ac-e5be-4b0f-b916-b8af6c7e79a9",
                                         "ContentItemLanguageMetadataContentItemGuid": "df81215e-1414-4d87-befd-ae123f4e5653",
                                         "ContentItemLanguageMetadataDisplayName": "Creation of UMT model",
                                         "ContentItemLanguageMetadataLatestVersionStatus": 2,
                                         "ContentItemLanguageMetadataCreatedWhen": "2023-12-10T00:00:00",
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
                                         "ContentItemLanguageMetadataCreatedWhen": "2023-12-10T00:00:00",
                                         "ContentItemLanguageMetadataCreatedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                         "ContentItemLanguageMetadataModifiedWhen": null,
                                         "ContentItemLanguageMetadataModifiedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                         "ContentItemLanguageMetadataHasImageAsset": false,
                                         "ContentItemLanguageMetadataContentLanguageGuid": "a6c0a558-8b33-47b6-87a8-491b437c9923"
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
                                         "ContentItemGUID": "b64b3e3e-f5a9-4d02-8cdb-6d81805c0fee",
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
                                         "ContentItemLanguageMetadataCreatedWhen": "2023-12-10T00:00:00",
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
                                         "ContentItemLanguageMetadataCreatedWhen": "2023-12-10T00:00:00",
                                         "ContentItemLanguageMetadataCreatedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                         "ContentItemLanguageMetadataModifiedWhen": null,
                                         "ContentItemLanguageMetadataModifiedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
                                         "ContentItemLanguageMetadataHasImageAsset": false,
                                         "ContentItemLanguageMetadataContentLanguageGuid": "a6c0a558-8b33-47b6-87a8-491b437c9923"
                                       }
                                     ]
                                     """;
#pragma warning restore S2479
}