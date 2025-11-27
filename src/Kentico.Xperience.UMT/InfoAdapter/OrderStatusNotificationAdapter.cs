using CMS.Commerce.Internal;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class OrderStatusNotificationAdapter : GenericInfoAdapter<OrderStatusNotificationInfo>
{
    internal OrderStatusNotificationAdapter(ILogger<OrderStatusNotificationAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
    }
}

