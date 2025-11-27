using CMS.Commerce;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class ShoppingCartAdapter : GenericInfoAdapter<ShoppingCartInfo>
{
    internal ShoppingCartAdapter(ILogger<ShoppingCartAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
    }
}

