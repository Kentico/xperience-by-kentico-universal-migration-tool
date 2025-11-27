using CMS.Commerce;

using Kentico.Xperience.UMT.Model;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class OrderAdapter : GenericInfoAdapter<OrderInfo>
{
    internal OrderAdapter(ILogger<OrderAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
    }

    public override OrderInfo Adapt(IUmtModel input)
    {
        var adapted = base.Adapt(input);

        return adapted;
    }
}

