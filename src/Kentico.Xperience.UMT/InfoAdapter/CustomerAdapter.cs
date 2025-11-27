using CMS.Commerce;

using Kentico.Xperience.UMT.Model;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class CustomerAdapter : GenericInfoAdapter<CustomerInfo>
{
    internal CustomerAdapter(ILogger<CustomerAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
    }

    public override CustomerInfo Adapt(IUmtModel input)
    {
        var adapted = base.Adapt(input);

        return adapted;
    }
}

