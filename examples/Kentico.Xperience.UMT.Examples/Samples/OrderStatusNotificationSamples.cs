using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class OrderStatusNotificationSamples
{
    [Sample("orderstatusnotification.sample.new", "Sample demonstrates how to create an order status notification for new orders", "Instance of OrderStatusNotificationInfo - Sample notification for new order status")]
    public static OrderStatusNotificationModel SampleOrderStatusNotificationNew => new()
    {
        OrderStatusNotificationOrderStatusGUID = OrderStatusSamples.SAMPLE_ORDER_STATUS_NEW_GUID,
        OrderStatusNotificationUserGUID = UserSamples.SampleAdminGuid
    };


    [Sample("orderstatusnotification.sample.completed", "Sample demonstrates how to create an order status notification for completed orders", "Instance of OrderStatusNotificationInfo - Sample notification for completed order status")]
    public static OrderStatusNotificationModel SampleOrderStatusNotificationCompleted => new()
    {
        OrderStatusNotificationOrderStatusGUID = OrderStatusSamples.SAMPLE_ORDER_STATUS_COMPLETED_GUID,
        OrderStatusNotificationUserGUID = UserSamples.SampleAdminGuid
    };
}
