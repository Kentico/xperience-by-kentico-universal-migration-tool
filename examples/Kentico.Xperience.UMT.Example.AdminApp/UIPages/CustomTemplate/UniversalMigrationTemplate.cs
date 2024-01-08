using Kentico.Xperience.Admin.Base;
using Kentico.Xperience.UMT.Example.AdminApp;
using Kentico.Xperience.UMT.Example.AdminApp.UIPages.CustomTemplate;

// Defines a new application and registers its root page under <webappdomain>/admin/CustomTemplate
[assembly: UIApplication("UMT.index", typeof(UniversalMigrationTemplate), "universal-migration-toolkit", "Universal migration toolkit", UmtWebAdminModule.CustomCategory, Icons.Clock, "@umt/web-admin/CustomLayout")]

namespace Kentico.Xperience.UMT.Example.AdminApp.UIPages.CustomTemplate
{
    internal class UniversalMigrationTemplate : Page<CustomLayoutProperties>
    {
        public override Task<CustomLayoutProperties> ConfigureTemplateProperties(CustomLayoutProperties properties)
        {
            properties.Label = "Migrate data from anywhere";
            return Task.FromResult(properties);
        }
    }

    internal class CustomLayoutProperties : TemplateClientProperties
    {
        public string Label { get; set; } = null!;
    }
}
