using CMS.Base;
using CMS.DataEngine;
using CMS.DataEngine.Internal;
using CMS.DocumentEngine;
using CMS.Membership;
using CMS.SiteProvider;

namespace Kentico.Xperience.UMT.ProviderProxy;

public interface IProviderProxy
{
    BaseInfo? GetBaseInfoByGuid(Guid guid);
    BaseInfo? GetBaseInfoBy(Guid guid, string searchedField);

    BaseInfo Save(BaseInfo info);

    ProviderProxyContext Context { get; }
}

public  record ProviderProxyContext(string SiteName, string CultureCode);

internal class TreeProviderProxy : IProviderProxy
{
    public ProviderProxyContext Context { get; }

    public TreeProviderProxy(ProviderProxyContext context) => Context = context;

    /// <param name="guid">in this implementation use DocumentGuid</param>
    /// <returns></returns>
    public BaseInfo? GetBaseInfoByGuid(Guid guid)
    {
        var query = DocumentHelper.GetDocuments<TreeNode>()
            .TopN(2)
            .WithGuid(guid)
            .Culture(Context.CultureCode);

        var node = query.SingleOrDefault();

        return node;
    }

    public BaseInfo? GetBaseInfoBy(Guid guid, string searchedField)
    {
        var query = DocumentHelper.GetDocuments<TreeNode>()
            .TopN(2)
            .Where(searchedField, QueryOperator.Equals, guid)
            .Culture(Context.CultureCode);

        var node = query.SingleOrDefault();

        return node;
    }

    public TTreeNode Save<TTreeNode>(TTreeNode info) where TTreeNode : TreeNode
    {
        var treeProvider = new TreeProvider(UserInfoProvider.ProviderObject.Get(info.NodeOwner))
        {
            UseAutomaticOrdering = false,
            UpdateUser = false,
            UpdateTimeStamps = false,
            LogEvents = false,
            UpdatePaths = false,
        };

        var site = SiteInfoProvider.ProviderObject.Get(Context.SiteName);
        info.SetValue(nameof(TreeNode.NodeSiteID), site.SiteID);

        if (info.NodeID == 0)
        {
            DocumentHelper.InsertDocument(info, info.Parent, treeProvider);
        }
        else
        {
            DocumentHelper.UpdateDocument(info, treeProvider);
        }

        return info;
    }

    public BaseInfo Save(BaseInfo info)
    {
        if (info.GetType().IsAssignableTo(typeof(TreeNode)))
        {
            return Save((TreeNode)info);
        }

        throw new InvalidOperationException($"Invalid proxy type, this proxy supports any object with '{typeof(TreeNode).FullName}' as base type");
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
