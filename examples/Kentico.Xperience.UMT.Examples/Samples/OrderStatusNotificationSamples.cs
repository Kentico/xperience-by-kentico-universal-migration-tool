using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class OrderStatusNotificationSamples
{
    public static readonly Guid SAMPLE_ORDER_STATUS_NOTIFICATION_NEW_GUID = new("AFCB1085-522C-4852-94D9-65B9022B67BD");
    public static readonly Guid SAMPLE_ORDER_STATUS_NOTIFICATION_COMPLETED_GUID = new("F285FAFB-3434-4A67-A199-62C32F532AF7");

    [Sample("orderstatusnotification.sample.new", "Sample demonstrates how to create an order status notification for new orders", "Instance of OrderStatusNotificationInfo - Sample notification for new order status")]
    public static OrderStatusNotificationModel SampleOrderStatusNotificationNew => new()
    {
        OrderStatusNotificationGUID = SAMPLE_ORDER_STATUS_NOTIFICATION_NEW_GUID,
        OrderStatusNotificationOrderStatusGUID = OrderStatusSamples.SAMPLE_ORDER_STATUS_NEW_GUID,
        OrderStatusNotificationUserGUID = UserSamples.SampleAdminGuid
    };


    [Sample("orderstatusnotification.sample.completed", "Sample demonstrates how to create an order status notification for completed orders", "Instance of OrderStatusNotificationInfo - Sample notification for completed order status")]
    public static OrderStatusNotificationModel SampleOrderStatusNotificationCompleted => new()
    {
        OrderStatusNotificationGUID = SAMPLE_ORDER_STATUS_NOTIFICATION_COMPLETED_GUID,
        OrderStatusNotificationOrderStatusGUID = OrderStatusSamples.SAMPLE_ORDER_STATUS_COMPLETED_GUID,
        OrderStatusNotificationUserGUID = UserSamples.SampleAdminGuid
    };
}
