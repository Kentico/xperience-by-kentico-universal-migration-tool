using CMS.Commerce;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class CustomerAdapter : GenericInfoAdapter<CustomerInfo>
{
    internal CustomerAdapter(ILogger<CustomerAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
    }
}

