using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT;

public static class UserSamples
{
    [Sample("userinfo.fredadmin", "Sample demonstrates how to create administrator user", "Instance of dataclass UserInfo - Fred admin")]
    public static UserInfoModel FreddyAdministrator => new()
    {
        UserGUID = new Guid("DBFCC244-2CB9-4934-857F-9D75404C1553"),
        
        Email = $"freddyadmin@sample.localhost",
        FirstName = "Frederick",
        LastName = "The admin",
        UserCreated = new DateTime(1990, 01, 01),
        UserEnabled = true,
        UserPassword = "[sample hash]",
        UserName = "fradmin",
        UserAdministrationAccess = true,
        UserIsPendingRegistration = false,
        UserIsExternal = false
    };
}
