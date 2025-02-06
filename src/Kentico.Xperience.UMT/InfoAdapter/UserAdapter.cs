using CMS.Membership;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class UserAdapter : GenericInfoAdapter<UserInfo>
{
    internal UserAdapter(ILogger<UserAdapter> logger, GenericInfoAdapterContext context) : base(logger, context)
    {
    }

    protected override void SetValue(UserInfo current, string propertyName, object? value)
    {
        if (propertyName == "UserPassword")
        {
            current.SetValue("UserPassword", value);
        }
        else
        {
            base.SetValue(current, propertyName, value);
        }
    }
}
