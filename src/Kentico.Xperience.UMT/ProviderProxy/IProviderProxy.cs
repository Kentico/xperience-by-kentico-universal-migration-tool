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
    BaseInfo? GetBaseInfoByGuid(Guid guid, IUmtModel model);
    BaseInfo? GetBaseInfoBy(Guid guid, string searchedField, IUmtModel model);
    BaseInfo Save(BaseInfo info, IUmtModel model);
    
    ProviderProxyContext Context { get; }
}

public record ProviderProxyContext();

internal class ContentItemDataProxy : IProviderProxy
{
    public ContentItemDataProxy(ProviderProxyContext context) => Context = context;

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

    public ProviderProxyContext Context { get; }
}

internal class ProviderProxy<TInfo> : IProviderProxy where TInfo : AbstractInfoBase<TInfo>, new()
{
    public ProviderProxyContext Context { get; }

    protected readonly IInfoProvider<TInfo> ProviderInstance;

    public ProviderProxy(ProviderProxyContext context)
    {
        Context = context;
        if (typeof(TInfo).IsAssignableTo(typeof(DataClassInfo)))
        {
            ProviderInstance = (IInfoProvider<TInfo>)DataClassInfoProvider.ProviderObject;
            return;
        }

        ProviderInstance = Provider<TInfo>.Instance;
    }

    public BaseInfo? GetInfoByGuid(Guid guid, IUmtModel model) => ProviderInstance.Get().WithGuid(guid).FirstOrDefault();

    public BaseInfo? GetBaseInfoByGuid(Guid guid, IUmtModel model) => GetInfoByGuid(guid, model);

    public BaseInfo? GetInfoBy(Guid guid, string searchedField, IUmtModel model) => ProviderInstance.Get().Where(searchedField, QueryOperator.Like, guid).FirstOrDefault();

    public BaseInfo? GetBaseInfoBy(Guid guid, string searchedField, IUmtModel model) => GetInfoBy(guid, searchedField, model);

    public virtual TInfo Save(TInfo info, IUmtModel model)
    {
        using (new CMSActionContext(UserInfoProvider.AdministratorUser) { User = UserInfoProvider.AdministratorUser, UseGlobalAdminContext = true })
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
