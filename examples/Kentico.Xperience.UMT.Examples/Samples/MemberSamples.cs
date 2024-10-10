using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class MemberSamples
{
    [Sample("memberinfo.sample.nocustomfields", "Sample demonstrates how to create a member without custom fields", "Instance of dataclass MemberInfo - Sample member without custom fields")]
    public static MemberInfoModel SampleMemberNoCustomFields => new()
    {
        MemberGUID = new Guid("4834F3C4-F7A5-46B8-A83D-607FCFC555D7"),
        MemberEmail = "john.doe@sample.localhost",
        MemberName = "John Doe",
        MemberCreated = new DateTime(2003, 02, 01, 4, 5, 6, 7, DateTimeKind.Utc),
        MemberEnabled = true,
        MemberIsExternal = false,
        MemberPassword = "[sample hash]",
        MemberSecurityStamp = "[sample security stamp]"
    };

    [Sample("memberinfo.sample.withcustomfields", "Sample demonstrates how to create a member with custom fields. Prior to usage, add the Member custom fields (see XbyK docs)", "Instance of dataclass MemberInfo - Sample member with custom fields")]
    public static MemberInfoModel SampleMemberWithCustomFields => new()
    {
        MemberGUID = new Guid("3DBA2983-33A3-46F5-B77C-EAC89FDB9559"),
        MemberEmail = "martin.atkins@sample.local",
        MemberName = "Martin Atkins",
        MemberCreated = new DateTime(2004, 06, 07, 3, 0, 0, 0, DateTimeKind.Utc),
        MemberEnabled = true,
        MemberIsExternal = false,
        MemberPassword = "[sample hash]",
        MemberSecurityStamp = "[sample security stamp]",
        CustomProperties =
        {
            ["MemberCity"] = "New York",
            ["MemberScore"] = 5,
        }
    };
}
