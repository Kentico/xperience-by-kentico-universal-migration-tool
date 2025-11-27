using CMS.Commerce;

using Kentico.Xperience.UMT.Model;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class OrderStatusAdapter : GenericInfoAdapter<OrderStatusInfo>
{
    internal OrderStatusAdapter(ILogger<OrderStatusAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
    }

    public override OrderStatusInfo Adapt(IUmtModel input)
    {
        var adapted = base.Adapt(input);

        return adapted;
    }
}

