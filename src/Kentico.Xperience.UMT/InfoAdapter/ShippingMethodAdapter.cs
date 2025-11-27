using CMS.Commerce;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class ShippingMethodAdapter : GenericInfoAdapter<ShippingMethodInfo>
{
    internal ShippingMethodAdapter(ILogger<ShippingMethodAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
    }
}

