using Kentico.Xperience.Admin.Base;
using Kentico.Xperience.UMT.Example.AdminApp;

[assembly: CMS.AssemblyDiscoverable]
[assembly: CMS.RegisterModule(typeof(UmtWebAdminModule))]

// Adds a new application category 
[assembly: UICategory(UmtWebAdminModule.CUSTOM_CATEGORY, "Migration samples", Icons.CustomElement, 100)]

namespace Kentico.Xperience.UMT.Example.AdminApp
{
    internal class UmtWebAdminModule() : AdminModule("Umt.Web.Admin")
    {
        public const string CUSTOM_CATEGORY = "umt.web.admin.category";

        protected override void OnInit()
        {
            base.OnInit();

            // Makes the module accessible to the admin UI
            RegisterClientModule("umt", "web-admin");
        }
    }
}
