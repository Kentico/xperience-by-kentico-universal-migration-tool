using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

[UmtModel(DISCRIMINATOR)]
[Experimental("UMTExperimentalModelOrderStatus")]
public class OrderStatusModel : UmtModel
{
    public const string DISCRIMINATOR = "OrderStatus";

    [UniqueIdProperty]
    [Required]
    public Guid? OrderStatusGUID { get; set; }

    [Map]
    [Required]
    public string? OrderStatusName { get; set; }

    [Map]
    [Required]
    public string? OrderStatusDisplayName { get; set; }

    [Map]
    public int? OrderStatusOrder { get; set; }

    [Map]
    public bool? OrderStatusInternalNotificationEnabled { get; set; }

    [Map]
    public bool? OrderStatusCustomerNotificationEnabled { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (OrderStatusGUID, OrderStatusName, OrderStatusDisplayName);
}
