using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class ContentLanguageSamples
{
    public static readonly Guid CONTENT_LANGUAGE_ENUS_SAMPLE_GUID = new("F454E93B-5FE9-42A9-B1AF-B572234ED9C4");
    public static readonly Guid CONTENT_LANGUAGE_ENGB_SAMPLE_GUID = new("A6C0A558-8B33-47B6-87A8-491B437C9923");
    public static readonly Guid CONTENT_LANGUAGE_ES_SAMPLE_GUID = new("4C80C6DD-A5C2-443D-873A-E9C328024B7C");

    public static ContentLanguageModel[] Languages => [SampleContentLanguageEnUs, SampleContentLanguageEnGb, SampleContentLanguageEs];

    [Sample("contentlanguage.sample.en-us", "This sample describes how to create content language for English (United States)", "ContentLanguage Sample - English US")]
    public static ContentLanguageModel SampleContentLanguageEnUs => new()
    {
        ContentLanguageCultureFormat = "en-US",
        ContentLanguageDisplayName = "English (United States)",
        // ContentLanguageFallbackContentLanguageGuid = new Guid("FD0A0727-FC68-4936-B868-119DF0F0AD7A"),
        ContentLanguageGUID = CONTENT_LANGUAGE_ENUS_SAMPLE_GUID,
        ContentLanguageIsDefault = true,
        ContentLanguageName = "en-US"
    };

    [Sample("contentlanguage.sample.en-gb", "This sample describes how to create content language for English (United Kingdom)", "ContentLanguage Sample - English UK")]
    public static ContentLanguageModel SampleContentLanguageEnGb => new()
    {
        ContentLanguageCultureFormat = "en-GB",
        ContentLanguageDisplayName = "English (United Kingdom)",
        // ContentLanguageFallbackContentLanguageGuid = new Guid("FD0A0727-FC68-4936-B868-119DF0F0AD7A"),
        ContentLanguageGUID = CONTENT_LANGUAGE_ENGB_SAMPLE_GUID,
        ContentLanguageIsDefault = false,
        ContentLanguageName = "en-GB"
    };

    [Sample("contentlanguage.sample.es", "This sample describes how to create content language for Spanish", "ContentLanguage Sample - Spanish")]
    public static ContentLanguageModel SampleContentLanguageEs => new()
    {
        ContentLanguageCultureFormat = "es-CU",
        ContentLanguageDisplayName = "Cuban Spanish",
        ContentLanguageGUID = CONTENT_LANGUAGE_ES_SAMPLE_GUID,
        ContentLanguageIsDefault = false,
        ContentLanguageName = "es-CU"
    };
}
