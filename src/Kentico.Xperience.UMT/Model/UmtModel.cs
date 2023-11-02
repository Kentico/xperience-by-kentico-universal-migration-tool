using System.Runtime.Serialization;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Interface for UMT model
/// </summary>
public interface IUmtModel
{
    public Dictionary<string, object?> CustomProperties { get; }
}

[KnownType(typeof(TreeNodeModel))]
[KnownType(typeof(DataClassModel))]
[KnownType(typeof(UserInfoModel))]
[KnownType(typeof(ChannelModel))]
[KnownType(typeof(WebsiteChannelModel))]
[KnownType(typeof(EmailChannelModel))]
public abstract class UmtModel : IUmtModel
{
    [System.Text.Json.Serialization.JsonExtensionData]
    public Dictionary<string, object?> CustomProperties { get; set; } = new();
}
