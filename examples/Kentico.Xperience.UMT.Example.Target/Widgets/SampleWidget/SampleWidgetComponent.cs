using CMS.ContentEngine;
using CMS.Websites;

using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.UMT.Example.Target.Widgets.SampleWidget;

using Microsoft.AspNetCore.Mvc;

[assembly:
    RegisterWidget(SampleWidgetComponent.IDENTIFIER, typeof(SampleWidgetComponent), "Sample Widget",
        typeof(SampleWidgetProperties), Description = "Sample Widget", IconClass = "icon-ribbon")]

namespace Kentico.Xperience.UMT.Example.Target.Widgets.SampleWidget;

public class SampleWidgetComponent(IContentQueryExecutor queryExecutor) : ViewComponent
{
    public const string IDENTIFIER = "UMT.SampleWidget";

    public async Task<IViewComponentResult> InvokeAsync(ComponentViewModel<SampleWidgetProperties> widgetProperties)
    {
        var viewmodel = new SampleWidgetViewModel();
        if (widgetProperties is not null)
        {
            viewmodel.Heading = widgetProperties.Properties.Heading;
            viewmodel.LinkedArticleTitles = await queryExecutor.GetWebPageResult(
                new ContentItemQueryBuilder().ForContentType("UMT.Article")
                    .Parameters(q => q.Where(w => w.WhereIn("ContentItemGUID", widgetProperties.Properties.LinkedArticles.Select(lc => lc.Identifier))))
                    .InLanguage("en-US", true),
                x => x.GetValue<string>("ArticleTitle"),
                new ContentQueryExecutionOptions { ForPreview = true });
        }
        return View("~/Widgets/SampleWidget/_SampleWidget.cshtml", viewmodel);
    }
}
