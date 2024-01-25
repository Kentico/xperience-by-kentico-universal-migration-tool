using CMS.Base;
using CMS.ContentEngine.Internal;
using CMS.Core;
using CMS.DataEngine;
using CMS.DataEngine.Internal;
using CMS.Membership;
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

public class ProviderProxyContext: IProviderProxyContext;

internal class ContentItemDataProxy(IProviderProxyContext context) : IProviderProxy
{
    private IInfoProvider<ContentItemDataInfo> GetProviderOrThrow(IUmtModel model)
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
            return Save((TInfo)info, model);
        }

        throw new InvalidOperationException($"Invalid proxy type, this proxy supports any object with '{typeof(TInfo).FullName}' as base type");
    }
}
