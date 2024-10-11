// ReSharper disable InconsistentNaming

using System.ComponentModel.DataAnnotations;
using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK MemberInfo
/// </summary>
/// <sample>memberinfo.sample.nocustomfields</sample>
[UmtModel(DISCRIMINATOR)]
public class MemberInfoModel : UmtModel
{
    /// <summary>
    /// Discriminator used in serialized structures to identify model 
    /// </summary>
    public const string DISCRIMINATOR = "MemberInfo";

    /// <summary>
    /// member name / login name - must be unique
    /// </summary>
    [Map]
    [Required]
    public string? MemberName { get; set; }

    /// <summary>
    /// valid email address according to XbyK API domain requirements (ValidationHelper.IsEmail()) or custom regex set through configuration "CMSEmailValidationRegex"
    /// </summary>
    [Map]
    [Required]
    public string? MemberEmail { get; set; }

    /// <summary>
    /// hashed member password
    /// </summary>
    [Map]
    public string? MemberPassword { get; set; }

    /// <summary>
    /// disable/enable member
    /// </summary>
    [Map]
    [Required]
    public bool? MemberEnabled { get; set; }

    /// <summary>
    /// datetime of member creation, defaults to current server time 
    /// </summary>
    [Map]
    public DateTime? MemberCreated { get; set; }

    /// <summary>
    /// uniqueId of member used for reference in other models 
    /// </summary>
    [UniqueIdProperty]
    [Required]
    public Guid? MemberGUID { get; set; }

    [Map]
    [Required]
    public bool? MemberIsExternal { get; set; }

    [Map]
    public string? MemberSecurityStamp { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (MemberGUID, MemberName, NOT_AVAILABLE);
}
