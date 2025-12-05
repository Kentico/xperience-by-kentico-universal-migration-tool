using System.ComponentModel.DataAnnotations;

using CMS.Commerce;
using CMS.Membership;

using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK OrderStatusNotificationInfo
/// </summary>
[UmtModel(DISCRIMINATOR)]
public class OrderStatusNotificationModel : UmtModel
{
    public const string DISCRIMINATOR = "OrderStatusNotification";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? OrderStatusNotificationGUID { get; set; }

    /// <summary>
    /// reference to order status
    /// </summary>
    [ReferenceProperty(typeof(OrderStatusInfo), "OrderStatusNotificationOrderStatusID", IsRequired = true)]
    public Guid? OrderStatusNotificationOrderStatusGUID { get; set; }

    /// <summary>
    /// reference to user
    /// </summary>
    [ReferenceProperty(typeof(UserInfo), "OrderStatusNotificationUserID", IsRequired = true)]
    public Guid? OrderStatusNotificationUserGUID { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (OrderStatusNotificationGUID, NOT_AVAILABLE, NOT_AVAILABLE);
}

