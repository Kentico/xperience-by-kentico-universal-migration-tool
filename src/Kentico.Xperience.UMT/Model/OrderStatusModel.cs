using System.ComponentModel.DataAnnotations;

using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK OrderStatusInfo
/// </summary>
[UmtModel(DISCRIMINATOR)]
public class OrderStatusModel : UmtModel
{
    public const string DISCRIMINATOR = "OrderStatus";

    [Map]
    [Required]
    [UniqueIdProperty]
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

    [Map]
    public int? OrderStatusCustomerNotificationEmailConfigurationID { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (OrderStatusGUID, OrderStatusName, OrderStatusDisplayName);
}

