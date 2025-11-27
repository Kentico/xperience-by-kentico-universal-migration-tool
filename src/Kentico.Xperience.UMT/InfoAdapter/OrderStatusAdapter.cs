using CMS.Commerce;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class OrderStatusAdapter : GenericInfoAdapter<OrderStatusInfo>
{
    internal OrderStatusAdapter(ILogger<OrderStatusAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
    }
}

