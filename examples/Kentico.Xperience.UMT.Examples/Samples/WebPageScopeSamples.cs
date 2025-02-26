using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class WebPageScopeSamples
{
    public static readonly Guid EmptyWebPageScopeGuid = new("86F11122-D4F3-4886-A0E6-1C31CA1DC21B");
    public static readonly Guid PopulatedWebPageScopeGuid = new("B8944002-1792-46FB-B14B-D185CE904085");

    [Sample("webpagescope.sample.empty", "This sample describes how to create an empty webpage scope", "Empty WebPageScope Sample")]
    public static WebPageScopeModel SampleEmptyWebPageScope => new()
    {
        WebPageScopeGUID = EmptyWebPageScopeGuid,
        WebPageScopeIncludeChildren = true,
        WebPageScopeWebsiteChannelGuid = WebSiteChannelSamples.WebsiteChannelGuid,
        WebPageScopeWebPageItemGuid = ContentItemSimplifiedSamples.SampleArticleSubPage4WebPageItemGuid
    };

    [Sample("webpagescope.sample.populated", "This sample describes how to create a webpage scope, later populated by webpagescopecontenttype.sample", "Populated WebPageScope Sample")]
    public static WebPageScopeModel SamplePopulatedWebPageScope => new()
    {
        WebPageScopeGUID = PopulatedWebPageScopeGuid,
        WebPageScopeIncludeChildren = true,
        WebPageScopeWebsiteChannelGuid = WebSiteChannelSamples.WebsiteChannelGuid,
        WebPageScopeWebPageItemGuid = ContentItemSimplifiedSamples.SampleArticleSubPage5WebPageItemGuid
    };

    [Sample("webpagescopecontenttype.sample", "This sample describes how to populate a webpage scope with allowed content type", "WebPageScopeContentType Sample")]
    public static WebPageScopeContentTypeModel SampleWebPageScopeContentType => new()
    {
        WebPageScopeContentTypeWebPageScopeGuid = PopulatedWebPageScopeGuid,
        WebPageScopeContentTypeContentTypeGuid = DataClassSamples.ARTICLE_SAMPLE_GUID
    };
}
