using System.ComponentModel.DataAnnotations;

using CMS.Commerce;
using CMS.Membership;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK CustomerInfo.
/// </summary>
/// <seealso cref="CustomerInfo"/>
[UmtModel(DISCRIMINATOR)]
public class CustomerModel : UmtModel
{
    public const string DISCRIMINATOR = "Customer";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? CustomerGUID { get; set; }

    [Map]
    public string? CustomerFirstName { get; set; }

    [Map]
    public string? CustomerLastName { get; set; }

    [Map]
    public string? CustomerEmail { get; set; }

    [Map]
    public string? CustomerPhone { get; set; }

    [ReferenceProperty(typeof(MemberInfo), "CustomerMemberID", IsRequired = false)]
    public Guid? CustomerMemberGUID { get; set; }

    [Map]
    public DateTime? CustomerCreatedWhen { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (CustomerGUID, $"{CustomerFirstName} {CustomerLastName}", NOT_AVAILABLE);
}
