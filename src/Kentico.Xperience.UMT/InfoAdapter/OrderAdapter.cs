using CMS.Commerce;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class OrderAdapter : GenericInfoAdapter<OrderInfo>
{
    internal OrderAdapter(ILogger<OrderAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
    }
}

