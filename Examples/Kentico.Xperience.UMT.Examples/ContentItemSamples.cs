using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class ContentItemSamples
{
    public static readonly Guid CONTENT_ITEM_GUID = new Guid("C354427D-3D02-4876-8ED4-4DE817FAE929");

    [Sample("contentitem.sample", "This sample describes how to create class inside XbyK to hold Content Item data", "ContentItem Sample")]
    public static ContentItemModel SampleContentItem => new()
    {
        ContentItemGUID = CONTENT_ITEM_GUID,
        ContentItemChannelGuid = new Guid("B186B5A3-F408-4E21-A2F9-E51D68ECAC38"),
        ContentItemDataClassGuid = new Guid("06540294-3B56-4CF7-8773-088BB766AC23"),
        ContentItemIsReusable = true,
        ContentItemIsSecured = true,
        ContentItemName = "ArticleContentItem"
    };
}
