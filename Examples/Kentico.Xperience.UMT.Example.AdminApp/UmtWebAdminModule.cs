using Kentico.Xperience.Admin.Base;
using Kentico.Xperience.UMT;

[assembly: CMS.AssemblyDiscoverable]
[assembly: CMS.RegisterModule(typeof(UmtWebAdminModule))]

// Adds a new application category 
[assembly: UICategory(UmtWebAdminModule.CustomCategory, "Migration samples", Icons.CustomElement, 100)]

namespace Kentico.Xperience.UMT
{
    internal class UmtWebAdminModule : AdminModule
    {
        public const string CustomCategory = "umt.web.admin.category";

        public UmtWebAdminModule()
            : base("Umt.Web.Admin")
        {
        }

        protected override void OnInit()
        {
            base.OnInit();

            // Makes the module accessible to the admin UI
            RegisterClientModule("umt", "web-admin");
        }
    }
}
