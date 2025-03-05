using System.ComponentModel.DataAnnotations;

using CMS.DataEngine;
using CMS.Websites.Internal;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK WebPageScopeContentTypeInfo
/// </summary>
[UmtModel(DISCRIMINATOR)]
public class AllowedChildContentTypeModel : UmtModel
{
    public const string DISCRIMINATOR = "AllowedChildContentType";

    [Required]
    [UniqueKeyPart("AllowedChildContentTypeParentID", referencedInfoType: typeof(DataClassInfo))]
    [ReferenceProperty(typeof(DataClassInfo), "AllowedChildContentTypeParentID", IsRequired = true)]
    public Guid? AllowedChildContentTypeParentGuid { get; set; }

    [Required]
    [UniqueKeyPart("AllowedChildContentTypeChildID", referencedInfoType: typeof(DataClassInfo))]
    [ReferenceProperty(typeof(DataClassInfo), "AllowedChildContentTypeChildID", IsRequired = true)]
    public Guid? AllowedChildContentTypeChildGuid { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (null, $"{AllowedChildContentTypeParentGuid}_{AllowedChildContentTypeChildGuid}", $"Scope {AllowedChildContentTypeParentGuid} allows content type {AllowedChildContentTypeChildGuid}");
}
