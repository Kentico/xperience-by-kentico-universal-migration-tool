using Kentico.Xperience.Admin.Base;
using Kentico.Xperience.UMT;
using Kentico.Xperience.UMT.UIPages.CustomTemplate;

/*
 * This file demonstrates a UI page based on a custom template (CustomLayoutTemplate.tsx).
 * The page defines a single page command that returns the server's DateTime.Now value.
 */

// Defines a new application and registers its root page under <webappdomain>/admin/CustomTemplate
[assembly: UIApplication("UMT.Sitecore", typeof(SitecoreTemplate), "sitecore", "Sitecore", UmtWebAdminModule.CustomCategory, Icons.Clock, "@umt/web-admin/CustomLayout")]
[assembly: UIApplication("UMT.Sitefinity", typeof(SitefinityTemplate), "sitefinity", "Sitefinity", UmtWebAdminModule.CustomCategory, Icons.Clock, "@umt/web-admin/CustomLayout")]
[assembly: UIApplication("UMT.LegacyKentico9", typeof(LegacyKentico9Template), "legacy-kentico-9", "Legacy kentico 9", UmtWebAdminModule.CustomCategory, Icons.Clock, "@umt/web-admin/CustomLayout")]

namespace Kentico.Xperience.UMT.UIPages.CustomTemplate
{
    internal class SitecoreTemplate : Page<CustomLayoutProperties>
    {
        public override Task<CustomLayoutProperties> ConfigureTemplateProperties(CustomLayoutProperties properties)
        {
            properties.Label = "Insert JSON file with compatible UMT model";
            return Task.FromResult(properties);
        }
    }
    
    internal class SitefinityTemplate : Page<CustomLayoutProperties>
    {
        public override Task<CustomLayoutProperties> ConfigureTemplateProperties(CustomLayoutProperties properties)
        {
            properties.Label = "Insert JSON file with compatible UMT model";
            return Task.FromResult(properties);
        }
    }
    
    internal class LegacyKentico9Template : Page<CustomLayoutProperties>
    {
        public override Task<CustomLayoutProperties> ConfigureTemplateProperties(CustomLayoutProperties properties)
        {
            properties.Label = "Insert JSON file with compatible UMT model";
            return Task.FromResult(properties);
        }
    }

    internal class CustomLayoutProperties : TemplateClientProperties
    {
        public string Label { get; set; } = null!;
    }
}
