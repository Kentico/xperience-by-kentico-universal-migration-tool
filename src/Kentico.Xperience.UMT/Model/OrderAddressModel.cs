using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

using CMS.Commerce;
using CMS.Globalization;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

[UmtModel(DISCRIMINATOR)]
[Experimental("UMTExperimentalModelOrderAddress")]
public class OrderAddressModel : UmtModel
{
    public const string DISCRIMINATOR = "OrderAddress";

    [UniqueIdProperty]
    [Required]
    public Guid? OrderAddressGUID { get; set; }

    [ReferenceProperty(typeof(OrderInfo), "OrderAddressOrderID", IsRequired = true)]
    [Required]
    public Guid? OrderAddressOrderGUID { get; set; }

    [Map]
    public string? OrderAddressType { get; set; }

    [Map]
    public string? OrderAddressFirstName { get; set; }

    [Map]
    public string? OrderAddressLastName { get; set; }

    [Map]
    public string? OrderAddressCompany { get; set; }

    [Map]
    public string? OrderAddressEmail { get; set; }

    [Map]
    public string? OrderAddressPhone { get; set; }

    [Map]
    public string? OrderAddressLine1 { get; set; }

    [Map]
    public string? OrderAddressLine2 { get; set; }

    [Map]
    public string? OrderAddressCity { get; set; }

    [Map]
    public string? OrderAddressZip { get; set; }

    [ReferenceProperty(typeof(CountryInfo), "OrderAddressCountryID")]
    public Guid? OrderAddressCountryGUID { get; set; }

    [ReferenceProperty(typeof(StateInfo), "OrderAddressStateID")]
    public Guid? OrderAddressStateGUID { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (OrderAddressGUID, $"{OrderAddressFirstName} {OrderAddressLastName}", NOT_AVAILABLE);
}
