using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class WebPageContentItemSamples
{
    [Sample("webpageitem.sample", "This sample describes how to create class inside XbyK to hold WebPage Item data", "ContentItem Sample")]
    public static WebPageItemModel SampleWebPageItem => new()
    {
        WebPageItemGUID = new Guid("6E995319-77E7-475E-9EBB-607BDBF5AF9A"),
        WebPageItemContentItemGuid = ContentItemSamples.CONTENT_ITEM_GUID,
        WebPageItemName = "NewWebPageItem",
        WebPageItemOrder = 1,
        WebPageItemTreePath = "/home",
        WebPageItemWebsiteChannelGuid = WebSiteChannelSamples.WebsiteChannelGuid
    };
}
