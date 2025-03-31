using CMS.ContentEngine;
using CMS.MediaLibrary;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Kentico.Xperience.UMT.Example.Target.Widgets.CoffeeSampleWidget;

public class CoffeeSampleWidgetProperties : IWidgetProperties
{
    [TextInputComponent(Label = "Heading", Order = 0)]
    public string Heading { get; set; } = string.Empty;

    [ContentItemSelectorComponent("DancingGoatCore.ProductSection", Label = "Linked content", Order = 1)]
    public IEnumerable<ContentItemReference> LinkedContent { get; set; } = [];

    [ContentItemSelectorComponent("DancingGoatCore.Coffee", Label = "Linked children", Order = 2)]
    public IEnumerable<ContentItemReference> LinkedChildren { get; set; } = [];
}
