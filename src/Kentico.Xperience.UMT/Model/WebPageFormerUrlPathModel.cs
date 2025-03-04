using System.ComponentModel.DataAnnotations;

using CMS.ContentEngine;
using CMS.Websites;
using CMS.Websites.Internal;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model
{
    [UmtModel(DISCRIMINATOR)]
    public class WebPageFormerUrlPathModel : UmtModel
    {
        public const string DISCRIMINATOR = "WebPageFormerUrlPath";

        [Map]
        [Required]
        [UniqueIdProperty]
        public Guid? WebPageFormerUrlPathGUID { get; set; }

        [Map]
        public string? WebPageFormerUrlPath { get; set; }

        [Map]
        public string? WebPageFormerUrlPathHash { get; set; }

        [Required]
        [ReferenceProperty(typeof(WebPageItemInfo), "WebPageFormerUrlPathWebPageItemID", IsRequired = true)]
        public Guid? WebPageFormerUrlPathWebPageItemGuid { get; set; }

        [Required]
        [ReferenceProperty(typeof(WebsiteChannelInfo), "WebPageFormerUrlPathWebsiteChannelID", IsRequired = true)]
        public Guid? WebPageFormerUrlPathWebsiteChannelGuid { get; set; }

        [Required]
        [ReferenceProperty(typeof(ContentLanguageInfo), "WebPageFormerUrlPathContentLanguageID", IsRequired = true)]
        public Guid? WebPageFormerUrlPathContentLanguageGuid { get; set; }

        [ReferenceProperty(typeof(WebPageItemInfo), "WebPageFormerUrlPathSourceWebPageItemID", IsRequired = false)]
        public Guid? WebPageFormerUrlPathSourceWebPageItemGuid { get; set; }

        [Map]
        [Required]
        public bool? WebPageFormerUrlPathIsRedirect { get; set; }

        [Map]
        [Required]
        public bool? WebPageFormerUrlPathIsRedirectScheduled { get; set; }

        protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (WebPageFormerUrlPathGUID, WebPageFormerUrlPath, NOT_AVAILABLE);
    }
}
