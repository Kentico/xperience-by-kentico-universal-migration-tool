using CMS.Commerce;

using Kentico.Xperience.UMT.Model;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class OrderAddressAdapter : GenericInfoAdapter<OrderAddressInfo>
{
    internal OrderAddressAdapter(ILogger<OrderAddressAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
    }

    public override OrderAddressInfo Adapt(IUmtModel input)
    {
        var adapted = base.Adapt(input);

        if (input is OrderAddressModel model)
        {
            adapted.OrderAddressType = model.OrderAddressType?.ToLowerInvariant() switch
            {
                "billing" => OrderAddressType.Billing,
                "shipping" => OrderAddressType.Shipping,
                _ => new OrderAddressType(model.OrderAddressType?.ToLowerInvariant())
            };
        }

        return adapted;
    }
}

