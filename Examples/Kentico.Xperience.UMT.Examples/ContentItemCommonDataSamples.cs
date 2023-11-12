using CMS.Base;
using CMS.ContentEngine;
using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class ContentItemCommonDataSamples
{
    public static ContentItemCommonDataModel SampleFaqContentItemCommonData => new()
    {
        ContentItemCommonDataContentItemGuid = ContentItemSamples.CONTENT_ITEM_FAQ_SAMPLE_GUID,
        ContentItemCommonDataContentLanguageGuid = ContentLanguageSamples.CONTENT_LANGUAGE_SAMPLE_GUID,
        ContentItemCommonDataGUID = new Guid("3ABBB5BB-C81C-44E2-8426-1439C0671019"),
        ContentItemDataGuid = new Guid("44D7E3DF-A7CB-4D6B-BA85-1420BC952992"),
        ContentItemCommonDataIsLatest = true,
        ContentItemCommonDataVersionStatus = 0,
        CustomProperties = new Dictionary<string, object?>
        {
            ["FaqQuestion"] = "Is this content item sample ?",
            ["FaqAnswer"] = "Yes!"
        }
    };
}
