using CMS.Base;
using CMS.ContentEngine;
using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class ContentItemLanguageMetadataSamples
{
    public static readonly Guid CONTENT_ITEM_LANGUAGE_METADATA_GUID_SAMPLE_BASIC = new Guid("65421553-5F92-44B7-A02F-2B9CA083E14A");
    public static readonly Guid CONTENT_ITEM_LANGUAGE_METADATA_GUID_SAMPLE = new Guid("12191A4B-26D8-40BB-A214-73D9874920FD");

    [Sample("contentitemlanguagemetadatabasic.sample", "This sample describes how to create class inside XbyK to hold Content Item Language Metadata", "ContentItemLanguageMetadata basic Sample")]
    public static ContentItemLanguageMetadataModel SampleContentItemLanguageMetadataBasic => new()
    {
        ContentItemLanguageMetadataGUID = CONTENT_ITEM_LANGUAGE_METADATA_GUID_SAMPLE_BASIC,
        ContentItemLanguageMetadataContentItemGuid = ContentItemSamples.CONTENT_ITEM_GUID,
        ContentItemLanguageMetadataContentLanguageGuid = ContentLanguageSamples.CONTENT_LANGUAGE_ENUS_SAMPLE_GUID,
        ContentItemLanguageMetadataDisplayName = "Basic Language Metadata Example",
        ContentItemLanguageMetadataCreatedWhen = new DateTime(638403513489503105L, DateTimeKind.Utc).AddDays(-2),
        ContentItemLanguageMetadataModifiedWhen = new DateTime(638403513520392925L, DateTimeKind.Utc),
        ContentItemLanguageMetadataHasImageAsset = false,
        ContentItemLanguageMetadataLatestVersionStatus = VersionStatus.Draft
    };

    [Sample("contentitemlanguagemetadata.sample", "This sample describes how to create class inside XbyK to hold Content Item Language Metadata", "ContentItemLanguageMetadata Sample")]
    public static ContentItemLanguageMetadataModel SampleContentItemLanguageMetadata => new()
    {
        ContentItemLanguageMetadataGUID = CONTENT_ITEM_LANGUAGE_METADATA_GUID_SAMPLE,
        ContentItemLanguageMetadataContentItemGuid = ContentItemSamples.CONTENT_ITEM_GUID,
        ContentItemLanguageMetadataContentLanguageGuid = ContentLanguageSamples.CONTENT_LANGUAGE_ENUS_SAMPLE_GUID,
        ContentItemLanguageMetadataDisplayName = "Language Metadata Example",
        ContentItemLanguageMetadataCreatedWhen = new DateTime(638403513583208748L, DateTimeKind.Utc).AddDays(-2),
        ContentItemLanguageMetadataModifiedWhen = new DateTime(638403513611939486L, DateTimeKind.Utc),
        ContentItemLanguageMetadataHasImageAsset = false,
        ContentItemLanguageMetadataCreatedByUserGuid = new Guid("95F42FD4-6A14-4E88-B214-4E136479F788"),
        ContentItemLanguageMetadataModifiedByUserGuid = new Guid("95F42FD4-6A14-4E88-B214-4E136479F788"),
        ContentItemLanguageMetadataLatestVersionStatus = VersionStatus.Published,
        ContentItemLanguageMetadataScheduledUnpublishWhen = new DateTime(2045, 1, 1, 0,0,0,0,0, DateTimeKind.Utc)
    };
}
