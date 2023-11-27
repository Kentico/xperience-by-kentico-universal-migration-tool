using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class UserSamples
{
    public static readonly Guid SampleAdminGuid = new Guid("DBFCC244-2CB9-4934-857F-9D75404C1553");
    
    [Sample("userinfo.sampleadmin", "Sample demonstrates how to create administrator user", "Instance of dataclass UserInfo - Sample admin")]
    public static UserInfoModel SampleAdministrator => new()
    {
        UserGUID = SampleAdminGuid,
        
        Email = $"admin@sample.localhost",
        FirstName = "Sample",
        LastName = "Admin",
        UserCreated = new DateTime(1990, 01, 01),
        UserEnabled = true,
        UserPassword = "[sample hash]",
        UserName = "sadmin",
        UserAdministrationAccess = true,
        UserIsPendingRegistration = false,
        UserIsExternal = false
    };
    
    [Sample("userinfo.sampleadmin.XYZ", "Sample demonstrates how to create administrator user", "Instance of dataclass UserInfo - Sample admin")]
    public static UserInfoModel SampleAdministratorXYZ => new()
    {
        UserGUID = new Guid("DBFCC244-2CB9-4934-857F-9D75404C1553"),
        
        Email = $"XYZ@sample.localhost",
        FirstName = "Sample",
        LastName = "Admin",
        UserCreated = new DateTime(1990, 01, 01),
        UserEnabled = true,
        UserPassword = "[sample hash]",
        UserName = "sadmin",
        UserAdministrationAccess = true,
        UserIsPendingRegistration = false,
        UserIsExternal = false
    };
}
