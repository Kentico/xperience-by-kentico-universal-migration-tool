using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class OrderStatusSamples
{
    public static readonly Guid SAMPLE_ORDER_STATUS_NEW_GUID = new("D4E5F6A7-B8C9-4012-D345-6789ABCDEF01");
    public static readonly Guid SAMPLE_ORDER_STATUS_PROCESSING_GUID = new("E5F6A7B8-C9D0-4123-E456-789ABCDEF012");
    public static readonly Guid SAMPLE_ORDER_STATUS_COMPLETED_GUID = new("F6A7B8C9-D0E1-4234-F567-89ABCDEF0123");

    [Sample("orderstatus.sample.new", "Sample demonstrates how to create a new order status", "Instance of dataclass OrderStatusInfo - Sample new order status")]
    public static OrderStatusModel SampleOrderStatusNew => new()
    {
        OrderStatusGUID = SAMPLE_ORDER_STATUS_NEW_GUID,
        OrderStatusName = "New",
        OrderStatusDisplayName = "New Order",
        OrderStatusOrder = 1,
        OrderStatusInternalNotificationEnabled = true,
        OrderStatusCustomerNotificationEnabled = true
    };


    [Sample("orderstatus.sample.completed", "Sample demonstrates how to create a completed order status", "Instance of dataclass OrderStatusInfo - Sample completed order status")]
    public static OrderStatusModel SampleOrderStatusCompleted => new()
    {
        OrderStatusGUID = SAMPLE_ORDER_STATUS_COMPLETED_GUID,
        OrderStatusName = "Completed",
        OrderStatusDisplayName = "Completed Order",
        OrderStatusOrder = 3,
        OrderStatusInternalNotificationEnabled = true,
        OrderStatusCustomerNotificationEnabled = true
    };
}

