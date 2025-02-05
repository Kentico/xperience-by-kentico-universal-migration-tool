using CMS.ContentEngine;
using CMS.ContentEngine.Internal;
using CMS.Core;
using CMS.Core.Internal;
using CMS.DataEngine;
using CMS.EmailLibrary;
using CMS.MediaLibrary;
using CMS.Websites;
using CMS.Websites.Internal;
using CMS.Workspaces;

using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Services;
using Kentico.Xperience.UMT.Services.Model;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class AdapterFactory(ILoggerFactory loggerFactory, UmtModelService modelService, IProviderProxyFactory providerProxyFactory, AssetManager assetManager)
{
    internal IInfoAdapter<IUmtModel>? CreateAdapter(IUmtModel umtModel, IProviderProxyContext providerProxyContext)
    {
        var adapterContext = new GenericInfoAdapterContext(modelService, providerProxyFactory, assetManager, providerProxyContext);
        return umtModel switch
        {
            UserInfoModel => new UserAdapter(loggerFactory.CreateLogger<UserAdapter>(), adapterContext),
            MemberInfoModel => new MemberAdapter(loggerFactory.CreateLogger<MemberAdapter>(), adapterContext),
            MediaFileModel => new MediaFileAdapter(loggerFactory.CreateLogger<MediaFileAdapter>(), adapterContext),
            MediaLibraryModel => new GenericInfoAdapter<MediaLibraryInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<MediaLibraryInfo>>(), adapterContext),
            ContentItemLanguageMetadataModel => new GenericInfoAdapter<ContentItemLanguageMetadataInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContentItemLanguageMetadataInfo>>(), adapterContext),
            ContentItemCommonDataModel => new GenericInfoAdapter<ContentItemCommonDataInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContentItemCommonDataInfo>>(), adapterContext),
            ContentItemDataModel => new ContentItemDataAdapter(loggerFactory.CreateLogger<ContentItemDataAdapter>(), adapterContext),
            WebsiteChannelModel => new GenericInfoAdapter<WebsiteChannelInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<WebsiteChannelInfo>>(), adapterContext),
            EmailChannelModel => new GenericInfoAdapter<EmailChannelInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<EmailChannelInfo>>(), adapterContext),
            ChannelModel => new GenericInfoAdapter<ChannelInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ChannelInfo>>(), adapterContext),
            ContentLanguageModel => new GenericInfoAdapter<ContentLanguageInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContentLanguageInfo>>(), adapterContext),
            ContentItemModel => new ContentItemAdapter(loggerFactory.CreateLogger<ContentItemAdapter>(), Service.Resolve<IInfoProvider<ContentFolderInfo>>(), Service.Resolve<IInfoProvider<WorkspaceInfo>>(), adapterContext),
            WebPageItemModel => new GenericInfoAdapter<WebPageItemInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<WebPageItemInfo>>(), adapterContext),
            WebPageAclModel => new GenericInfoAdapter<WebPageAclInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<WebPageAclInfo>>(), adapterContext),
            WebPageUrlPathModel => new WebPageUrlPathAdapter(loggerFactory.CreateLogger<WebPageUrlPathAdapter>(), adapterContext),
            DataClassModel => new DataClassAdapter(loggerFactory.CreateLogger<DataClassAdapter>(), adapterContext),
            ContentTypeChannelModel => new GenericInfoAdapter<ContentTypeChannelInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContentTypeChannelInfo>>(), adapterContext),
            ContentItemReferenceModel => new GenericInfoAdapter<ContentItemReferenceInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContentItemReferenceInfo>>(), adapterContext),
            ContentFolderModel => new ContentFolderAdapter(loggerFactory.CreateLogger<ContentFolderAdapter>(), Service.Resolve<IInfoProvider<ContentFolderInfo>>(), Service.Resolve<IInfoProvider<WorkspaceInfo>>(), adapterContext),
            TaxonomyModel => new TaxonomyAdapter(loggerFactory.CreateLogger<TaxonomyAdapter>(), adapterContext),
            TagModel => new TagAdapter(loggerFactory.CreateLogger<TagAdapter>(), adapterContext),
            WorkspaceModel => new GenericInfoAdapter<WorkspaceInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<WorkspaceInfo>>(), adapterContext),

            // macro models
            ContentItemSimplifiedModel => new ContentItemSimplifiedAdapter(providerProxyFactory.CreateProviderProxy<ContentItemInfo>(providerProxyContext), providerProxyFactory, Service.Resolve<IDateTimeNowService>(), this,
                loggerFactory.CreateLogger<ContentItemSimplifiedAdapter>(), Service.Resolve<IInfoProvider<ContentFolderInfo>>(), Service.Resolve<IInfoProvider<WorkspaceInfo>>()),
            _ => null,
        };
    }
}
