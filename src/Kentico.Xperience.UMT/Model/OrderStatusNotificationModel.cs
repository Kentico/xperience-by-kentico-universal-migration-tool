using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

using CMS.Commerce;
using CMS.Membership;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

[UmtModel(DISCRIMINATOR)]
[Experimental("UMTExperimentalModelOrderStatusNotification")]
public class OrderStatusNotificationModel : UmtModel
{
    public const string DISCRIMINATOR = "OrderStatusNotification";

    [ReferenceProperty(typeof(OrderStatusInfo), "OrderStatusNotificationOrderStatusID", IsRequired = true)]
    [Required]
    public Guid? OrderStatusNotificationOrderStatusGUID { get; set; }

    [ReferenceProperty(typeof(UserInfo), "OrderStatusNotificationUserID", IsRequired = true)]
    [Required]
    public Guid? OrderStatusNotificationUserGUID { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (null, NOT_AVAILABLE, NOT_AVAILABLE);
}
