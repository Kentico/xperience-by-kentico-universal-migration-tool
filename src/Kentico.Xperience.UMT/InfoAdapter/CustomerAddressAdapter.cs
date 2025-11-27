using CMS.Commerce;

using Kentico.Xperience.UMT.Model;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class CustomerAddressAdapter : GenericInfoAdapter<CustomerAddressInfo>
{
    internal CustomerAddressAdapter(ILogger<CustomerAddressAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
    }

    public override CustomerAddressInfo Adapt(IUmtModel input)
    {
        var adapted = base.Adapt(input);

        return adapted;
    }
}

