using System.ComponentModel.DataAnnotations;

using CMS.Commerce;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK <see cref="ShippingMethodInfo"/>. 
/// </summary>
[UmtModel(DISCRIMINATOR)]
public class ShippingMethodModel : UmtModel
{
    public const string DISCRIMINATOR = "ShippingMethod";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? ShippingMethodGUID { get; set; }

    [Map]
    [Required]
    public string? ShippingMethodName { get; set; }

    [Map]
    [Required]
    public string? ShippingMethodDisplayName { get; set; }

    [Map]
    public string? ShippingMethodDescription { get; set; }

    [Map]
    public bool? ShippingMethodEnabled { get; set; }

    [Map]
    public decimal? ShippingMethodPrice { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (ShippingMethodGUID, ShippingMethodName, ShippingMethodDisplayName);
}

