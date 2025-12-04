using System.ComponentModel.DataAnnotations;

using CMS.Commerce;
using CMS.Globalization;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK <see cref="CustomerAddressInfo"/>.
/// </summary>
[UmtModel(DISCRIMINATOR)]
public class CustomerAddressModel : UmtModel
{
    public const string DISCRIMINATOR = "CustomerAddress";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? CustomerAddressGUID { get; set; }

    [ReferenceProperty(typeof(CustomerInfo), "CustomerAddressCustomerID", IsRequired = true)]
    public Guid? CustomerAddressCustomerGUID { get; set; }

    [Map]
    public string? CustomerAddressFirstName { get; set; }

    [Map]
    public string? CustomerAddressLastName { get; set; }

    [Map]
    public string? CustomerAddressCompany { get; set; }

    [Map]
    public string? CustomerAddressEmail { get; set; }

    [Map]
    public string? CustomerAddressPhone { get; set; }

    [Map]
    public string? CustomerAddressLine1 { get; set; }

    [Map]
    public string? CustomerAddressLine2 { get; set; }

    [Map]
    public string? CustomerAddressCity { get; set; }

    [Map]
    public string? CustomerAddressZip { get; set; }

    [ReferenceProperty(typeof(CountryInfo), "CustomerAddressCountryID", IsRequired = false)]
    public Guid? CustomerAddressCountryGUID { get; set; }

    [ReferenceProperty(typeof(StateInfo), "CustomerAddressStateID", IsRequired = false)]
    public Guid? CustomerAddressStateGUID { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (CustomerAddressGUID, $"{CustomerAddressFirstName} {CustomerAddressLastName}", NOT_AVAILABLE);
}
