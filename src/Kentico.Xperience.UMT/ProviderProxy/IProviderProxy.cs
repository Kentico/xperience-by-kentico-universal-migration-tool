using CMS.Base;
using CMS.ContentEngine.Internal;
using CMS.Core;
using CMS.DataEngine;
using CMS.Membership;
using CMS.Websites;
using CMS.Websites.Internal;

using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.ProviderProxy;

public interface IProviderProxy
{
    List<BaseInfo> GetInfoByKeys(IUmtModel model, List<(string columnName, object? value)> filters);
    BaseInfo? GetBaseInfoByGuid(Guid guid, IUmtModel model);
    BaseInfo? GetBaseInfoBy(Guid guid, string searchedField, IUmtModel model);
    BaseInfo? GetBaseInfoByCodeName(string codeName, IUmtModel model);

    BaseInfo Save(BaseInfo info, IUmtModel model);

    IProviderProxyContext Context { get; }
}

public interface IProviderProxyContext;

public class ProviderProxyContext : IProviderProxyContext;

internal class ContentItemDataProxy(IProviderProxyContext context) : IProviderProxy
{
    private static IInfoProvider<ContentItemDataInfo> GetProviderOrThrow(IUmtModel model)
    {
        if (model is ContentItemDataModel contentItemDataModel)
        {
            return Service.Resolve<IContentItemDataInfoProviderAccessor>()
                .Get(contentItemDataModel.ContentItemContentTypeName);
        }
        else
        {
            throw new InvalidOperationException("Invalid model");
        }
    }

    public List<BaseInfo> GetInfoByKeys(IUmtModel model, List<(string columnName, object? value)> filters)
    {
        var query = GetProviderOrThrow(model).Get();
        foreach ((string keyName, object? value) in filters)
        {
            query.WhereEquals(keyName, value);
        }

        return query.Cast<BaseInfo>().ToList();
    }

    public BaseInfo? GetBaseInfoByGuid(Guid guid, IUmtModel model)
    {
        var provider = GetProviderOrThrow(model);
        return provider.Get().WhereEquals(nameof(ContentItemDataInfo.ContentItemDataGUID), guid).FirstOrDefault();
    }

    public BaseInfo? GetBaseInfoBy(Guid guid, string searchedField, IUmtModel model)
    {
        var provider = GetProviderOrThrow(model);
        return provider.Get().WhereEquals(searchedField, guid).FirstOrDefault();
    }

    public BaseInfo? GetBaseInfoByCodeName(string codeName, IUmtModel model) => throw new InvalidOperationException("Content item data has no CodeName column");

    public BaseInfo Save(BaseInfo info, IUmtModel model)
    {
        if (info is ContentItemDataInfo contentItemDataInfo)
        {
            var provider = GetProviderOrThrow(model);
            provider.Set(contentItemDataInfo);
            return contentItemDataInfo;
        }
        else
        {
            throw new InvalidOperationException($"Invalid info type '{info.GetType().FullName}', ContentItemDataInfo type is expected.");
        }
    }

    public IProviderProxyContext Context => context;
}

internal class ProviderProxy<TInfo> : IProviderProxy where TInfo : AbstractInfoBase<TInfo>, new()
{
    private static readonly Type InfoType = typeof(TInfo);

    public IProviderProxyContext Context { get; }

    protected readonly IInfoProvider<TInfo> ProviderInstance;

    public ProviderProxy(IProviderProxyContext context)
    {
        Context = context;
        if (typeof(TInfo).IsAssignableTo(typeof(DataClassInfo)))
        {
            ProviderInstance = (IInfoProvider<TInfo>)DataClassInfoProvider.ProviderObject;
            return;
        }

        ProviderInstance = Provider<TInfo>.Instance;
    }

    public List<BaseInfo> GetInfoByKeys(IUmtModel model, List<(string columnName, object? value)> filters)
    {
        var query = ProviderInstance.Get();
        foreach ((string keyName, object? value) in filters)
        {
            query.WhereEquals(keyName, value);
        }

        return query.Cast<BaseInfo>().ToList();
    }

    public BaseInfo? GetInfoByGuid(Guid guid, IUmtModel model) => ProviderInstance.Get().WithGuid(guid).FirstOrDefault();

    public BaseInfo? GetBaseInfoByGuid(Guid guid, IUmtModel model) => GetInfoByGuid(guid, model);

    public BaseInfo? GetInfoBy(Guid guid, string searchedField, IUmtModel model) => ProviderInstance.Get().Where(searchedField, QueryOperator.Like, guid).FirstOrDefault();

    public BaseInfo? GetBaseInfoBy(Guid guid, string searchedField, IUmtModel model) => GetInfoBy(guid, searchedField, model);
    public BaseInfo? GetBaseInfoByCodeName(string? codeName, IUmtModel model) => ProviderInstance.Get().WithCodeName(codeName).FirstOrDefault();

    public virtual TInfo Save(TInfo info, IUmtModel model)
    {
        var context = new CMSActionContext(UserInfoProvider.AdministratorUser) { User = UserInfoProvider.AdministratorUser, UseGlobalAdminContext = true };
        using (context)
        {
            ProviderInstance.Set(info);
        }

        return info;
    }

    public BaseInfo Save(BaseInfo info, IUmtModel model)
    {
        if (info.GetType().IsAssignableTo(typeof(TInfo)))
        {
            if (InfoType.IsAssignableTo(typeof(WebPageAclInfo)) && info is WebPageAclInfo webPageAclInfo)
            {
                // No actual saving. WebPageAclModel model is just supposed to break the inheritance
                var webPageAclMappingManagerFactory = Service.Resolve<IWebPageAclManagerFactory>();
                webPageAclMappingManagerFactory
                    .Create(webPageAclInfo.WebPageAclWebsiteChannelID)
                    .BreakInheritance(webPageAclInfo.WebPageAclWebPageItemID)
                    .GetAwaiter().GetResult();

                var savedInfo = ProviderInstance.Get()
                    .WhereEquals(nameof(WebPageAclInfo.WebPageAclWebsiteChannelID), webPageAclInfo.WebPageAclWebsiteChannelID)
                    .And().WhereEquals(nameof(WebPageAclInfo.WebPageAclWebPageItemID), webPageAclInfo.WebPageAclWebPageItemID)
                    .FirstOrDefault();
                if (savedInfo is not null)
                {
                    return savedInfo;
                }
            }
            else
            {
                try
                {
                    return Save((TInfo)info, model);
                }
                finally
                {
                    if (InfoType.IsAssignableTo(typeof(WebPageItemInfo)) && info is WebPageItemInfo webPageItemInfo)
                    {
                        var webPageAclMappingManager = Service.Resolve<IWebPageAclMappingManager>();
                        webPageAclMappingManager.CreateMapping(webPageItemInfo.WebPageItemID, webPageItemInfo.WebPageItemParentID, webPageItemInfo.WebPageItemWebsiteChannelID, CancellationToken.None).GetAwaiter().GetResult();

                        var webPageAclMappingManagerFactory = Service.Resolve<IWebPageAclManagerFactory>();
                        webPageAclMappingManagerFactory
                            .Create(webPageItemInfo.WebPageItemWebsiteChannelID)
                            .RestoreInheritance(webPageItemInfo.WebPageItemID)
                            .GetAwaiter().GetResult();
                    }
                }
            }
        }

        throw new InvalidOperationException($"Invalid proxy type, this proxy supports any object with '{typeof(TInfo).FullName}' as base type");
    }
}
