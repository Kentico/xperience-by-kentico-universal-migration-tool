using CMS.Commerce;

using Kentico.Xperience.UMT.Model;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class OrderItemAdapter : GenericInfoAdapter<OrderItemInfo>
{
    internal OrderItemAdapter(ILogger<OrderItemAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
    }

    public override OrderItemInfo Adapt(IUmtModel input)
    {
        var adapted = base.Adapt(input);

        return adapted;
    }
}

