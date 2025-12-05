using CMS.Commerce;

using Kentico.Xperience.UMT.Model;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class OrderAddressAdapter : GenericInfoAdapter<OrderAddressInfo>
{
    internal OrderAddressAdapter(ILogger<OrderAddressAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
    }

    protected override void SetValue(OrderAddressInfo current, string propertyName, object? value)
    {
        if (propertyName == nameof(OrderAddressModel.OrderAddressType) && value is string orderAddressType)
        {
            current.OrderAddressType = orderAddressType.ToLowerInvariant() switch
            {
                "billing" => OrderAddressType.Billing,
                "shipping" => OrderAddressType.Shipping,
                _ => new OrderAddressType(orderAddressType)
            };
            return;
        }

        base.SetValue(current, propertyName, value);
    }
}
