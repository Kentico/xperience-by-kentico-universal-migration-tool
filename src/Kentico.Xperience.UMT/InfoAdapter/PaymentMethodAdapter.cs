using CMS.Commerce;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class PaymentMethodAdapter : GenericInfoAdapter<PaymentMethodInfo>
{
    internal PaymentMethodAdapter(ILogger<PaymentMethodAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
    }
}

