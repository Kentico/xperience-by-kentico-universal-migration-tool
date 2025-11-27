using System.ComponentModel.DataAnnotations;

using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK PaymentMethodInfo
/// </summary>
[UmtModel(DISCRIMINATOR)]
public class PaymentMethodModel : UmtModel
{
    public const string DISCRIMINATOR = "PaymentMethod";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? PaymentMethodGUID { get; set; }

    [Map]
    [Required]
    public string? PaymentMethodName { get; set; }

    [Map]
    [Required]
    public string? PaymentMethodDisplayName { get; set; }

    [Map]
    public string? PaymentMethodDescription { get; set; }

    [Map]
    public bool? PaymentMethodEnabled { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (PaymentMethodGUID, PaymentMethodName, PaymentMethodDisplayName);
}

