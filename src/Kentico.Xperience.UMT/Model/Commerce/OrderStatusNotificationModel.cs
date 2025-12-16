using System.ComponentModel.DataAnnotations;

using CMS.Commerce;
using CMS.Commerce.Internal;
using CMS.Membership;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK OrderStatusNotificationInfo.
/// </summary>
/// <seealso cref="OrderStatusNotificationInfo"/>
[UmtModel(DISCRIMINATOR)]
public class OrderStatusNotificationModel : UmtModel
{
    public const string DISCRIMINATOR = "OrderStatusNotification";

    [Required]
    [ReferenceProperty(typeof(OrderStatusInfo), "OrderStatusNotificationOrderStatusID", IsRequired = true)]
    [UniqueKeyPart("OrderStatusNotificationOrderStatusID", typeof(OrderStatusInfo))]
    public Guid? OrderStatusNotificationOrderStatusGUID { get; set; }

    [Required]
    [ReferenceProperty(typeof(UserInfo), "OrderStatusNotificationUserID", IsRequired = true)]
    [UniqueKeyPart("OrderStatusNotificationUserID", typeof(UserInfo))]
    public Guid? OrderStatusNotificationUserGUID { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (OrderStatusNotificationOrderStatusGUID, NOT_AVAILABLE, NOT_AVAILABLE);
}
