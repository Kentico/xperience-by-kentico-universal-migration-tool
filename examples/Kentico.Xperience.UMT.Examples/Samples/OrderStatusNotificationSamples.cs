using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class OrderStatusNotificationSamples
{
    public static readonly Guid SAMPLE_ORDER_STATUS_NOTIFICATION_NEW_GUID = new("A1B2C3D4-E5F6-4789-A012-3456789ABCDE");
    public static readonly Guid SAMPLE_ORDER_STATUS_NOTIFICATION_COMPLETED_GUID = new("B2C3D4E5-F6A7-4890-B123-456789ABCDEF");

    [Sample("orderstatusnotification.sample.new", "Sample demonstrates how to create an order status notification for new orders", "Instance of dataclass OrderStatusNotificationInfo - Sample notification for new order status")]
    public static OrderStatusNotificationModel SampleOrderStatusNotificationNew => new()
    {
        OrderStatusNotificationGUID = SAMPLE_ORDER_STATUS_NOTIFICATION_NEW_GUID,
        OrderStatusNotificationOrderStatusGUID = OrderStatusSamples.SAMPLE_ORDER_STATUS_NEW_GUID,
        OrderStatusNotificationUserGUID = UserSamples.SampleAdminGuid
    };


    [Sample("orderstatusnotification.sample.completed", "Sample demonstrates how to create an order status notification for completed orders", "Instance of dataclass OrderStatusNotificationInfo - Sample notification for completed order status")]
    public static OrderStatusNotificationModel SampleOrderStatusNotificationCompleted => new()
    {
        OrderStatusNotificationGUID = SAMPLE_ORDER_STATUS_NOTIFICATION_COMPLETED_GUID,
        OrderStatusNotificationOrderStatusGUID = OrderStatusSamples.SAMPLE_ORDER_STATUS_COMPLETED_GUID,
        OrderStatusNotificationUserGUID = UserSamples.SampleAdminGuid
    };
}

