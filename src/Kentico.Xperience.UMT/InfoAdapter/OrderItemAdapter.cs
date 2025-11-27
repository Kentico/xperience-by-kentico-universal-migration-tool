using CMS.Commerce;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class OrderItemAdapter : GenericInfoAdapter<OrderItemInfo>
{
    internal OrderItemAdapter(ILogger<OrderItemAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
    }
}

