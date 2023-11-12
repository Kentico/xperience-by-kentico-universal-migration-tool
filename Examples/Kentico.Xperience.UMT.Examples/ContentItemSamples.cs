using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class ContentItemSamples
{
    public static readonly Guid CONTENT_ITEM_GUID = new Guid("C354427D-3D02-4876-8ED4-4DE817FAE929");
    public static readonly Guid CONTENT_ITEM_FAQ_SAMPLE_GUID = new Guid("B28A0F09-9102-4E48-B6FE-3C405FEEAFB5");

    [Sample("contentitem.sample", "This sample describes how to create class inside XbyK to hold Content Item data", "ContentItem basic Sample")]
    public static ContentItemModel SampleContentItem => new()
    {
        ContentItemGUID = CONTENT_ITEM_GUID,
        ContentItemChannelGuid = new Guid("B186B5A3-F408-4E21-A2F9-E51D68ECAC38"),
        ContentItemDataClassGuid = new Guid("978B2CD4-C248-4317-86A1-3BDD17444267"),
        ContentItemIsSecured = true,
        ContentItemIsReusable = true,
        ContentItemName = "NewsLetterExampleName"
    };

    public static ContentItemModel SampleFaqContentItem => new()
    {
        ContentItemGUID = CONTENT_ITEM_FAQ_SAMPLE_GUID,
        ContentItemChannelGuid = ChannelSamples.WEBSITE_CHANNEL_SAMPLE_GUID,
        ContentItemDataClassGuid = DataClassSamples.FAQ_SAMPLE_GUID,
        ContentItemIsSecured = true,
        ContentItemIsReusable = true,
        ContentItemName = "FaqSampleItem"
    };
}
