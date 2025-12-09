using System.ComponentModel.DataAnnotations;

using CMS.Membership;

using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK ShoppingCartInfo
/// </summary>
[UmtModel(DISCRIMINATOR)]
public class ShoppingCartModel : UmtModel
{
    public const string DISCRIMINATOR = "ShoppingCart";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? ShoppingCartGUID { get; set; }

    [Map]
    [Required]
    public string? ShoppingCartUniqueIdentifier { get; set; }

    [Map]
    public DateTime? ShoppingCartModifiedWhen { get; set; }

    /// <summary>
    /// reference to member
    /// </summary>
    [ReferenceProperty(typeof(MemberInfo), "ShoppingCartMemberID", IsRequired = false)]
    public Guid? ShoppingCartMemberGUID { get; set; }

    [Map]
    public string? ShoppingCartData { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (ShoppingCartGUID, ShoppingCartUniqueIdentifier, NOT_AVAILABLE);
}

