using System.ComponentModel.DataAnnotations;

using CMS.DataEngine;
using CMS.Websites.Internal;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK WebPageScopeContentTypeInfo
/// </summary>
[UmtModel(DISCRIMINATOR)]
public class WebPageScopeContentTypeModel : UmtModel
{
    public const string DISCRIMINATOR = "WebPageScopeContentType";

    [Required]
    [UniqueKeyPart("WebPageScopeContentTypeWebPageScopeID", referencedInfoType: typeof(WebPageScopeInfo))]
    [ReferenceProperty(typeof(WebPageScopeInfo), "WebPageScopeContentTypeWebPageScopeID", IsRequired = true)]
    public Guid? WebPageScopeContentTypeWebPageScopeGuid { get; set; }

    [Required]
    [UniqueKeyPart("WebPageScopeContentTypeContentTypeID", referencedInfoType: typeof(DataClassInfo))]
    [ReferenceProperty(typeof(DataClassInfo), "WebPageScopeContentTypeContentTypeID", IsRequired = true)]
    public Guid? WebPageScopeContentTypeContentTypeGuid { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (null, $"{WebPageScopeContentTypeWebPageScopeGuid}_{WebPageScopeContentTypeContentTypeGuid}", $"Scope {WebPageScopeContentTypeWebPageScopeGuid} allows content type {WebPageScopeContentTypeContentTypeGuid}");
}
