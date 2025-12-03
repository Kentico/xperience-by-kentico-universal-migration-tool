using System.Runtime.Serialization;
using System.Text;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Interface for UMT model
/// </summary>
public interface IUmtModel
{
    string PrintMe();

    public Dictionary<string, object?> CustomProperties { get; }
}

[KnownType(typeof(ChannelModel))]
[KnownType(typeof(ContentItemCommonDataModel))]
[KnownType(typeof(ContentItemDataModel))]
[KnownType(typeof(ContentItemLanguageMetadataModel))]
[KnownType(typeof(ContentItemModel))]
[KnownType(typeof(ContentLanguageModel))]
[KnownType(typeof(ContentFolderModel))]
[KnownType(typeof(DataClassModel))]
[KnownType(typeof(ContentTypeChannelModel))]
[KnownType(typeof(EmailChannelModel))]
[KnownType(typeof(MediaFileModel))]
[KnownType(typeof(MediaLibraryModel))]
[KnownType(typeof(UserInfoModel))]
[KnownType(typeof(MemberInfoModel))]
[KnownType(typeof(WebPageItemModel))]
[KnownType(typeof(WebPageAclModel))]
[KnownType(typeof(WebPageUrlPathModel))]
[KnownType(typeof(WebsiteChannelModel))]
[KnownType(typeof(TaxonomyModel))]
[KnownType(typeof(TagModel))]
#pragma warning disable UMTExperimentalModelOrderStatus
#pragma warning disable UMTExperimentalModelOrderStatusNotification
#pragma warning disable UMTExperimentalModelOrder
#pragma warning disable UMTExperimentalModelOrderItem
#pragma warning disable UMTExperimentalModelOrderAddress
[KnownType(typeof(OrderStatusModel))]
[KnownType(typeof(OrderStatusNotificationModel))]
[KnownType(typeof(OrderModel))]
[KnownType(typeof(OrderItemModel))]
[KnownType(typeof(OrderAddressModel))]
#pragma warning restore UMTExperimentalModelOrderStatus
#pragma warning restore UMTExperimentalModelOrderStatusNotification
#pragma warning restore UMTExperimentalModelOrder
#pragma warning restore UMTExperimentalModelOrderItem
#pragma warning restore UMTExperimentalModelOrderAddress
public abstract class UmtModel : IUmtModel
{
    public virtual string PrintMe()
    {
        var (uniqueId, name, displayName) = GetPrintArgs();
        var sb = new StringBuilder();
        sb.Append($"{GetType().Name}");
        sb.Append($" UID={uniqueId.ToString() ?? "<not specified>"}");
        if (name != NOT_AVAILABLE)
        {
            sb.Append($" N='{name ?? "<not specified>"}'");
        }
        if (displayName != NOT_AVAILABLE)
        {
            sb.Append($" DN='{displayName}'");
        }
        return sb.ToString();
    }

    /// <summary>
    /// method shall return information needed for entity log print
    /// </summary>
    /// <returns></returns>
    protected abstract (Guid? uniqueId, string? name, string? displayName) GetPrintArgs();

    /// <summary>
    /// any value that is consumable by standard XbyK api and <see cref="AssetSource"/>
    /// </summary>
    [System.Text.Json.Serialization.JsonExtensionData]
    public Dictionary<string, object?> CustomProperties { get; set; } = [];
}
