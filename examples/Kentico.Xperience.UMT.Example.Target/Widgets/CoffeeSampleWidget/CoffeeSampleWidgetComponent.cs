using CMS.ContentEngine;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Kentico.Xperience.UMT.Example.Target.Widgets.CoffeeSampleWidget;
using CMS.Websites;

[assembly:
    RegisterWidget(CoffeeSampleWidgetComponent.IDENTIFIER, typeof(CoffeeSampleWidgetComponent), "Coffee Sample Widget",
        typeof(CoffeeSampleWidgetProperties), Description = "Coffee Sample Widget", IconClass = "icon-ribbon")]

namespace Kentico.Xperience.UMT.Example.Target.Widgets.CoffeeSampleWidget;

public class CoffeeSampleWidgetComponent(IContentQueryExecutor queryExecutor) : ViewComponent
{
    public const string IDENTIFIER = "UMT.CoffeeSampleWidget";

    public async Task<IViewComponentResult> InvokeAsync(ComponentViewModel<CoffeeSampleWidgetProperties> widgetProperties)
    {
        var viewmodel = new CoffeeSampleWidgetViewModel();
        if (widgetProperties is not null)
        {
            viewmodel.Coffees = await queryExecutor.GetWebPageResult(
                new ContentItemQueryBuilder().ForContentType("DancingGoatCore.Coffee")
                    .Parameters(q => q.Where(w => w.WhereIn("ContentItemGUID", widgetProperties.Properties.LinkedChildren.Select(lc => lc.Identifier))))
                    .InLanguage("en-US", true),
                x => $"{x.GetValue<string>("DocumentName")} from {x.GetValue<string>("CoffeeCountry")}",
                new ContentQueryExecutionOptions { ForPreview = true });
        }
        return View("~/Widgets/CoffeeSampleWidget/_CoffeeSampleWidget.cshtml", viewmodel);
    }
}
