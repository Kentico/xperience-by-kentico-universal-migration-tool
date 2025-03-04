using CMS.ContentEngine;
using CMS.MediaLibrary;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Kentico.Xperience.UMT.Example.Target.Widgets.SampleWidget;

public class SampleWidgetProperties : IWidgetProperties
{
    [TextInputComponent(Label = "Heading", Order = 0)]
    public string Heading { get; set; } = string.Empty;

    [ContentItemSelectorComponent("UMT.Article", Label = "Linked articles", Order = 1)]
    public IEnumerable<ContentItemReference> LinkedArticles { get; set; } = [];
}
