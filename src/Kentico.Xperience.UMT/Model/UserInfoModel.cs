// ReSharper disable InconsistentNaming

using System.ComponentModel.DataAnnotations;
using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK UserInfo
/// </summary>
/// <sample>userinfo.sampleadmin.XYZ</sample>
[UmtModel(DISCRIMINATOR)]
public class UserInfoModel : UmtModel
{
    /// <summary>
    /// Discriminator used in serialized structures to identify model 
    /// </summary>
    public const string DISCRIMINATOR = "UserInfo";

#pragma warning disable S125 // this property is part of target model, there is need to declare that we ignore this property explicitly
    // managed internally
    // public int UserID {get; set;}
#pragma warning restore S125

    /// <summary>
    /// user nane / login name - must be unique
    /// </summary>
    [Map]
    [Required]
    public string? UserName { get; set; }
    /// <summary>
    /// First name of user
    /// </summary>
    [Map]
    public string? FirstName { get; set; }
    /// <summary>
    /// Last name of user
    /// </summary>
    [Map]
    public string? LastName { get; set; }
    /// <summary>
    /// valid email address according to XbyK API domain requirements (ValidationHelper.IsEmail()) or custom regex set through configuration "CMSEmailValidationRegex"
    /// </summary>
    [Map]
    [Required]
    public string? Email { get; set; }
    /// <summary>
    /// hashed user password
    /// </summary>
    [Map]
    [Required]
    public string? UserPassword { get; set; }
    /// <summary>
    /// disable/enable user
    /// </summary>
    [Map]
    [Required]
    public bool? UserEnabled { get; set; }
    /// <summary>
    /// datetime of user creation, defaults to current server time 
    /// </summary>
    [Map]
    public DateTime? UserCreated { get; set; }
    /// <summary>
    /// lost logon of user to administration
    /// </summary>
    [Map]
    public DateTime? LastLogon { get; set; }
    /// <summary>
    /// uniqueId of user used for reference in other models 
    /// </summary>
    [UniqueIdProperty]
    [Required]
    public Guid? UserGUID { get; set; }
    /// <summary>
    /// date of last modification of user
    /// </summary>
    [Map]
    public DateTime? UserLastModified { get; set; }

    [Map]
    public string? UserSecurityStamp { get; set; }
    [Map]
    public DateTime? UserPasswordLastChanged { get; set; }
    [Map]
    [Required]
    public bool? UserIsPendingRegistration { get; set; }
    [Map]
    public DateTime? UserRegistrationLinkExpiration { get; set; }
    /// <summary>
    /// if set user has access to administration XbyK instance
    /// </summary>
    [Map]
    [Required]
    public bool? UserAdministrationAccess { get; set; }

    [Map]
    [Required]
    public bool? UserIsExternal { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (UserGUID, UserName, NOT_AVAILABLE);
}
