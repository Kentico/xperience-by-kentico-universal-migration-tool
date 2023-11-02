using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class ContentLanguageSample
{
    public static readonly Guid CONTENT_LANGUAGE_SAMPLE = Guid.NewGuid();

    [Sample("contentlanguage.sample", "This sample describes how to create class inside XbyK to hold Content language data", "ContentLanguage Sample")]
    public static ContentLanguageModel SampleContentLanugage => new()
    {
        ContentLanguageCultureFormat = "sk",
        ContentLanguageDisplayName = "Slovak",
        ContentLanguageFallbackContentLanguageGuid = new Guid("FD0A0727-FC68-4936-B868-119DF0F0AD7A"),
        ContentLanguageGUID = CONTENT_LANGUAGE_SAMPLE,
        ContentLanguageIsDefault = false,
        ContentLanguageName = "sk"

    };
}
