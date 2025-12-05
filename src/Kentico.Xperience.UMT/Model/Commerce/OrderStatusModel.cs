using System.ComponentModel.DataAnnotations;

using CMS.Commerce;
using CMS.EmailLibrary;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK <see cref="OrderStatusInfo"/>.
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
    [Required]
    public int? OrderStatusOrder { get; set; }

    [Map]
    [Required]
    public bool? OrderStatusInternalNotificationEnabled { get; set; }

    [Map]
    [Required]
    public bool? OrderStatusCustomerNotificationEnabled { get; set; }

    [ReferenceProperty(typeof(EmailConfigurationInfo), "OrderStatusCustomerNotificationEmailConfigurationID")]
    public Guid? OrderStatusCustomerNotificationEmailConfigurationGUID { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (OrderStatusGUID, OrderStatusName, OrderStatusDisplayName);
}
