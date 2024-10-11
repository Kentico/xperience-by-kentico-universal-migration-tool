using CMS.Membership;
using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class MemberAdapter : GenericInfoAdapter<MemberInfo>
{
    internal MemberAdapter(ILogger<MemberAdapter> logger, GenericInfoAdapterContext context) : base(logger, context)
    {
    }
}
