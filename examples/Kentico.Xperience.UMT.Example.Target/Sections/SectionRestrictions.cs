using Kentico.Xperience.UMT.Example.Target.Widgets.SampleWidget;

namespace Kentico.Xperience.UMT.Example.Target.Sections;

public static class SectionRestrictions
{
    public static List<string> SingleColumnSectionsAllowedWidgets =>
    [
        SampleWidgetComponent.IDENTIFIER
    ];
}
