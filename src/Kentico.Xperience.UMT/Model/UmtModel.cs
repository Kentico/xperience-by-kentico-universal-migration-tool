using System.Runtime.Serialization;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Interface for UMT model
/// </summary>
public interface IUmtModel
{
    public Dictionary<string, object?> CustomProperties { get; }
}

[KnownType(typeof(ChannelModel))]
[KnownType(typeof(ContentItemCommonDataModel))]
[KnownType(typeof(ContentItemDataModel))]
[KnownType(typeof(ContentItemLanguageMetadataModel))]
[KnownType(typeof(ContentItemModel))]
[KnownType(typeof(ContentLanguageModel))]
[KnownType(typeof(DataClassModel))]
[KnownType(typeof(EmailChannelModel))]
[KnownType(typeof(MediaFileModel))]
[KnownType(typeof(MediaLibraryModel))]
[KnownType(typeof(UserInfoModel))]
[KnownType(typeof(WebPageItemModel))]
[KnownType(typeof(WebPageUrlPathModel))]
[KnownType(typeof(WebsiteChannelModel))]
public abstract class UmtModel : IUmtModel
{
    [System.Text.Json.Serialization.JsonExtensionData]
    public Dictionary<string, object?> CustomProperties { get; set; } = new();
}
