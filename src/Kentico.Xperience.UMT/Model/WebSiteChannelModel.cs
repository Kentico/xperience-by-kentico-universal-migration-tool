using System.ComponentModel.DataAnnotations;

using CMS.ContentEngine;
using CMS.Websites;

using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK WebSiteChannelInfo
/// </summary>
/// <sample>websitechannels.sample</sample>
/// <sample>websitechannels.lsd.sample</sample>
[UmtModel(DISCRIMINATOR)]
public class WebsiteChannelModel : UmtModel, IValidatableObject
{
    public const string DISCRIMINATOR = "WebSiteChannel";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? WebsiteChannelGUID { get; set; }

    // example of extended settings [ReferenceProperty(typeof(ChannelInfo), "WebsiteChannelChannelID", IsRequired = true, SearchedField = "WebsiteChannelChannelGUID", ValueField = "WebsiteChannelChannelID")]
    [Required]
    [ReferenceProperty(typeof(ChannelInfo), "WebsiteChannelChannelID", IsRequired = true)]
    public Guid? WebsiteChannelChannelGuid { get; set; }

    /// <summary>
    /// required for PathPrefix routing, must be null for LanguageDomains routing (domains live in WebsiteChannelDomainOptions configuration)
    /// </summary>
    [Map]
    public string? WebsiteChannelDomain { get; set; }

    [Map]
    public string? WebsiteChannelHomePage { get; set; }

    /// <summary>
    /// required for PathPrefix routing, must be null for LanguageDomains routing (a language-domains channel has no primary language)
    /// </summary>
    [ReferenceProperty(typeof(ContentLanguageInfo), "WebsiteChannelPrimaryContentLanguageID", IsRequired = false)]
    public Guid? WebsiteChannelPrimaryContentLanguageGuid { get; set; }

    [Map]
    [Required]
    public int? WebsiteChannelDefaultCookieLevel { get; set; }

    [Map]
    [Required]
    public bool? WebsiteChannelStoreFormerUrls { get; set; }

    [Map]
    public WebsiteChannelLanguageRoutingMode? WebsiteChannelLanguageRoutingMode { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        // mirrors CHECK_CMS_WebsiteChannel_LanguageRoutingMode_DomainAndPrimaryContentLanguage
        if (WebsiteChannelLanguageRoutingMode == CMS.Websites.WebsiteChannelLanguageRoutingMode.LanguageDomains)
        {
            if (!string.IsNullOrEmpty(WebsiteChannelDomain))
            {
                yield return new ValidationResult($"{nameof(WebsiteChannelDomain)} must not be set when {nameof(WebsiteChannelLanguageRoutingMode)} is LanguageDomains - per-language domains are configured in the application's WebsiteChannelDomainOptions", [nameof(WebsiteChannelDomain)]);
            }
            if (WebsiteChannelPrimaryContentLanguageGuid is not null)
            {
                yield return new ValidationResult($"{nameof(WebsiteChannelPrimaryContentLanguageGuid)} must not be set when {nameof(WebsiteChannelLanguageRoutingMode)} is LanguageDomains - a language-domains channel has no primary language", [nameof(WebsiteChannelPrimaryContentLanguageGuid)]);
            }
        }
        else
        {
            if (string.IsNullOrEmpty(WebsiteChannelDomain))
            {
                yield return new ValidationResult($"{nameof(WebsiteChannelDomain)} is required for path-prefix routed website channels", [nameof(WebsiteChannelDomain)]);
            }
            if (WebsiteChannelPrimaryContentLanguageGuid is null)
            {
                yield return new ValidationResult($"{nameof(WebsiteChannelPrimaryContentLanguageGuid)} is required for path-prefix routed website channels", [nameof(WebsiteChannelPrimaryContentLanguageGuid)]);
            }
        }
    }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (WebsiteChannelGUID, NOT_AVAILABLE, NOT_AVAILABLE);
}
