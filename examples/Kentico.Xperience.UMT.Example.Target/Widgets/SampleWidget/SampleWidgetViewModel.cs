using CMS.ContentEngine;

using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Kentico.Xperience.UMT.Example.Target.Widgets.SampleWidget;

public class SampleWidgetViewModel
{
    public string Heading { get; set; } = string.Empty;
    public IEnumerable<string> LinkedArticleTitles { get; set; } = [];
}
