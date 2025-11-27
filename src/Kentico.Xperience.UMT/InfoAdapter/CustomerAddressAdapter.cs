using CMS.Commerce;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class CustomerAddressAdapter : GenericInfoAdapter<CustomerAddressInfo>
{
    internal CustomerAddressAdapter(ILogger<CustomerAddressAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
    }
}

