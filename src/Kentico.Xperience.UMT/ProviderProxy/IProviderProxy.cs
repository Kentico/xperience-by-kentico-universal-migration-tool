using CMS.Base;
using CMS.ContentEngine;
using CMS.ContentEngine.Internal;
using CMS.Core;
using CMS.DataEngine;
using CMS.DataEngine.Internal;
// using CMS.DocumentEngine; => obsolete
using CMS.Membership;

namespace Kentico.Xperience.UMT.ProviderProxy;

public interface IProviderProxy
{
    BaseInfo? GetBaseInfoByGuid(Guid guid);
    BaseInfo? GetBaseInfoBy(Guid guid, string searchedField);

    BaseInfo Save(BaseInfo info);

    ProviderProxyContext Context { get; }
}

public record ProviderProxyContext(string SiteName, string CultureCode);

// TODO tomas.krch: 2023-09-05 migration v27: TreeProvider obsolete - implement using ContentItemInfo 
internal class TreeProviderProxy : IProviderProxy
{
    public ProviderProxyContext Context { get; }

    public TreeProviderProxy(ProviderProxyContext context) => Context = context;

    /// <param name="guid">in this implementation use DocumentGuid</param>
    /// <returns></returns>
    public BaseInfo? GetBaseInfoByGuid(Guid guid)
    {
        // var query = DocumentHelper.GetDocuments<TreeNode>()
        //     .TopN(2)
        //     .WithGuid(guid)
        //     .Culture(Context.CultureCode);
        //
        // var node = query.SingleOrDefault();
        //
        // return node;
        int c = 1;
        return default;
    }

    public BaseInfo? GetBaseInfoBy(Guid guid, string searchedField)
    {
        // var query = DocumentHelper.GetDocuments<TreeNode>()
        //     .TopN(2)
        //     .Where(searchedField, QueryOperator.Equals, guid)
        //     .Culture(Context.CultureCode);
        //
        // var node = query.SingleOrDefault();
        //
        // return node;
        int c = 1;
        return default;
    }

    public TTreeNode Save<TTreeNode>(TTreeNode info) // where TTreeNode : TreeNode
    {
        // var treeProvider = new TreeProvider(UserInfoProvider.ProviderObject.Get(info.NodeOwner))
        // {
        //     UseAutomaticOrdering = false,
        //     UpdateUser = false,
        //     UpdateTimeStamps = false,
        //     LogEvents = false,
        //     UpdatePaths = false,
        // };
        //
        // // TODO tomas.krch: 2023-09-05 migration v27: site id ref - possibly ref channel?
        // // info.SetValue(nameof(TreeNode.NodeSiteID), site.SiteID);
        //
        // if (info.NodeID == 0)
        // {
        //     DocumentHelper.InsertDocument(info, info.Parent, treeProvider);
        // }
        // else
        // {
        //     DocumentHelper.UpdateDocument(info, treeProvider);
        // }
        //
        // return info;
        int c = 1;
        throw new NotImplementedException("");
        return default;
    }

    public BaseInfo Save(BaseInfo info)
    {
        // if (info.GetType().IsAssignableTo(typeof(TreeNode)))
        // {
        //     return Save((TreeNode)info);
        // }

        //throw new InvalidOperationException($"Invalid proxy type, this proxy supports any object with '{typeof(TreeNode).FullName}' as base type");
        int c = 1;
        throw new NotImplementedException("");
        return default;
    }
}

internal class ContentItemProxy : IProviderProxy
{
    public ContentItemProxy(ProviderProxyContext context) => Context = context;

    // TODO tomas.krch: 2023-09-05 migration v27: implement content item proxy
    public BaseInfo? GetBaseInfoByGuid(Guid guid) => throw new NotImplementedException();

    public BaseInfo? GetBaseInfoBy(Guid guid, string searchedField) => throw new NotImplementedException();

    public BaseInfo Save(BaseInfo info) => throw new NotImplementedException();

    public ProviderProxyContext Context { get; }

    private void Create_ContentHub_Item()
    {
        // Culture-invariant part of the item (CMS_Tree)
        var itemInfo = new ContentItemInfo
        {
            ContentItemName = "code_name", // NodeName
            ContentItemIsReusable = true, // Items for hub are re-usable
            ContentItemIsSecured = false, // IsSecuredNode
            ContentItemContentTypeID = 1, // NodeClassID
        };
        ContentItemInfo.Provider.Set(itemInfo);

        // TODO tomas.krch: 2023-09-05 migration v27: ensure somehow that language exists
        var lang = ContentLanguageInfoProvider.ProviderObject.Get().FirstOrDefault();
        int languageId = lang?.ContentLanguageID ?? 0;
        
        // Culture and version specific part (CMS_Document)
        var commonDataInfo = new ContentItemCommonDataInfo
        {
            ContentItemCommonDataContentItemID = itemInfo.ContentItemID,
            ContentItemCommonDataContentLanguageID = languageId, // DocumentCulture -> language entity needs to be created and its ID used here
            ContentItemCommonDataVersionStatus = VersionStatus.Published,
            ContentItemCommonDataIsLatest = true // Flag for latest record to know what to retrieve for the UI
        };
        ContentItemCommonDataInfo.Provider.Set(commonDataInfo);

        string contentTypeName = "cms.article"; // ClassName of the content type
        var itemDataInfo = new ContentItemDataInfo(contentTypeName);
        itemDataInfo.ContentItemDataCommonDataID = commonDataInfo.ContentItemCommonDataID;
        itemDataInfo.SetValue("Field", "");

        var itemDataProvider = Service.Resolve<IContentItemDataInfoProviderAccessor>().Get(contentTypeName);
        itemDataProvider.Set(itemDataInfo);

        int userId = 53;
        
        var languageMetadataInfo = new ContentItemLanguageMetadataInfo
        {
            ContentItemLanguageMetadataContentItemID = itemInfo.ContentItemID,
            ContentItemLanguageMetadataDisplayName = "display name", // For the admin UI only
            ContentItemLanguageMetadataLatestVersionStatus = VersionStatus.Published, // That's the latest status of th item for admin optimization
            ContentItemLanguageMetadataCreatedWhen = DateTime.Now, // DocumentCreatedWhen
            ContentItemLanguageMetadataModifiedWhen = DateTime.Now, // DocumentModifiedWhen
            ContentItemLanguageMetadataCreatedByUserID = userId, // DocumentCreatedByUserID
            ContentItemLanguageMetadataModifiedByUserID = userId, // DocumentModifiedByUserID
            ContentItemLanguageMetadataHasImageAsset = false, // This is for admin UI optimization - set to true if latest version contains a field with an image asset
            ContentItemLanguageMetadataContentLanguageID = languageId // DocumentCulture -> language entity needs to be created and its ID used here
        };
        ContentItemLanguageMetadataInfo.Provider.Set(languageMetadataInfo);
    }
}

internal class ProviderProxy<TInfo> : IProviderProxy where TInfo : AbstractInfoBase<TInfo>, new()
{
    public ProviderProxyContext Context { get; }

    private readonly IInfoProvider<TInfo> providerInstance;

    public ProviderProxy(ProviderProxyContext context)
    {
        Context = context;
        if (typeof(TInfo).IsAssignableTo(typeof(DataClassInfo)))
        {
            providerInstance = (IInfoProvider<TInfo>)DataClassInfoProvider.ProviderObject;
            return;
        }

        providerInstance = Provider<TInfo>.Instance;
    }

    public BaseInfo? GetInfoByGuid(Guid guid) => providerInstance.Get().WithGuid(guid).FirstOrDefault();

    public BaseInfo? GetBaseInfoByGuid(Guid guid) => GetInfoByGuid(guid);

    public BaseInfo? GetInfoBy(Guid guid, string searchedField) => providerInstance.Get().Where(searchedField, QueryOperator.Like, guid).FirstOrDefault();

    public BaseInfo? GetBaseInfoBy(Guid guid, string searchedField) => GetInfoBy(guid, searchedField);

    public TInfo Save(TInfo info)
    {
        using (new CMSActionContext(UserInfoProvider.AdministratorUser) { User = UserInfoProvider.AdministratorUser, UseGlobalAdminContext = true })
        {
            providerInstance.Set(info);
        }

        return info;
    }

    public BaseInfo Save(BaseInfo info)
    {
        if (info.GetType().IsAssignableTo(typeof(TInfo)))
        {
            return Save((TInfo)info);
        }

        throw new InvalidOperationException($"Invalid proxy type, this proxy supports any object with '{typeof(TInfo).FullName}' as base type");
    }
}
