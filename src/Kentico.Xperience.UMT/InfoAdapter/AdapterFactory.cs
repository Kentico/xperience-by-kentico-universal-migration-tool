using CMS.Activities;
using CMS.Commerce;
using CMS.ContactManagement;
using CMS.ContentEngine;
using CMS.ContentEngine.Internal;
using CMS.Core;
using CMS.Core.Internal;
using CMS.DataEngine;
using CMS.DataProtection;
using CMS.EmailLibrary;
using CMS.MediaLibrary;
using CMS.Websites.Internal;
using CMS.Workspaces;

using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Services;
using Kentico.Xperience.UMT.Services.Model;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class AdapterFactory(ILoggerFactory loggerFactory, UmtModelService modelService, IProviderProxyFactory providerProxyFactory,
    AssetManager assetManager, WorkspaceService workspaceService, ContentItemReferencePopulator contentItemReferencePopulator)
{
    internal IInfoAdapter<IUmtModel>? CreateAdapter(IUmtModel umtModel, IProviderProxyContext providerProxyContext)
    {
        var adapterContext = new GenericInfoAdapterContext(modelService, providerProxyFactory, assetManager, providerProxyContext);
        return umtModel switch
        {
            UserInfoModel => new UserAdapter(loggerFactory.CreateLogger<UserAdapter>(), adapterContext),
            MemberInfoModel => new MemberAdapter(loggerFactory.CreateLogger<MemberAdapter>(), adapterContext),
            MediaFileModel => new MediaFileAdapter(loggerFactory.CreateLogger<MediaFileAdapter>(), adapterContext),
#pragma warning disable CS0618 // Type or member is obsolete
            MediaLibraryModel => new GenericInfoAdapter<MediaLibraryInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<MediaLibraryInfo>>(), adapterContext),
#pragma warning restore CS0618 // Type or member is obsolete
            ContentItemLanguageMetadataModel => new GenericInfoAdapter<ContentItemLanguageMetadataInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContentItemLanguageMetadataInfo>>(), adapterContext),
            ContentItemCommonDataModel => new ContentItemCommonDataAdapter(loggerFactory.CreateLogger<ContentItemCommonDataAdapter>(), adapterContext, contentItemReferencePopulator),
            ContentItemDataModel => new ContentItemDataAdapter(loggerFactory.CreateLogger<ContentItemDataAdapter>(), adapterContext, contentItemReferencePopulator),
            WebsiteChannelModel => new WebsiteChannelAdapter(Service.Resolve<IInfoProvider<WebPageScopeInfo>>(), loggerFactory.CreateLogger<WebsiteChannelAdapter>(), adapterContext),
            EmailChannelModel => new GenericInfoAdapter<EmailChannelInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<EmailChannelInfo>>(), adapterContext),
            ChannelModel => new GenericInfoAdapter<ChannelInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ChannelInfo>>(), adapterContext),
            ContentLanguageModel => new GenericInfoAdapter<ContentLanguageInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContentLanguageInfo>>(), adapterContext),
            ContentItemModel => new ContentItemAdapter(loggerFactory.CreateLogger<ContentItemAdapter>(), Service.Resolve<IInfoProvider<ContentFolderInfo>>(), workspaceService, adapterContext),
            WebPageItemModel => new GenericInfoAdapter<WebPageItemInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<WebPageItemInfo>>(), adapterContext),
            WebPageAclModel => new GenericInfoAdapter<WebPageAclInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<WebPageAclInfo>>(), adapterContext),
            WebPageUrlPathModel => new WebPageUrlPathAdapter(loggerFactory.CreateLogger<WebPageUrlPathAdapter>(), adapterContext),
            WebPageFormerUrlPathModel => new WebPageFormerUrlPathAdapter(loggerFactory.CreateLogger<WebPageFormerUrlPathAdapter>(), adapterContext),
            DataClassModel => new DataClassAdapter(loggerFactory.CreateLogger<DataClassAdapter>(), adapterContext),
            ContentTypeChannelModel => new GenericInfoAdapter<ContentTypeChannelInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContentTypeChannelInfo>>(), adapterContext),
            ContentItemReferenceModel => new GenericInfoAdapter<ContentItemReferenceInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContentItemReferenceInfo>>(), adapterContext),
            ContentFolderModel => new ContentFolderAdapter(loggerFactory.CreateLogger<ContentFolderAdapter>(), Service.Resolve<IInfoProvider<ContentFolderInfo>>(), adapterContext, workspaceService),
            TaxonomyModel => new TaxonomyAdapter(loggerFactory.CreateLogger<TaxonomyAdapter>(), adapterContext),
            TagModel => new TagAdapter(loggerFactory.CreateLogger<TagAdapter>(), adapterContext),
            CustomerModel => new GenericInfoAdapter<CustomerInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<CustomerInfo>>(), adapterContext),
            CustomerAddressModel => new GenericInfoAdapter<CustomerAddressInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<CustomerAddressInfo>>(), adapterContext),
            WorkspaceModel => new GenericInfoAdapter<WorkspaceInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<WorkspaceInfo>>(), adapterContext),
            WebPageScopeModel => new GenericInfoAdapter<WebPageScopeInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<WebPageScopeInfo>>(), adapterContext),
            WebPageScopeContentTypeModel => new GenericInfoAdapter<WebPageScopeContentTypeInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<WebPageScopeContentTypeInfo>>(), adapterContext),
            AllowedChildContentTypeModel => new GenericInfoAdapter<AllowedChildContentTypeInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<AllowedChildContentTypeInfo>>(), adapterContext),

#pragma warning disable UMTExperimentalModelContact
            ContactModel => new GenericInfoAdapter<ContactInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContactInfo>>(), adapterContext),
#pragma warning restore UMTExperimentalModelContact

#pragma warning disable UMTExperimentalModelContactGroup
            ContactGroupModel => new GenericInfoAdapter<ContactGroupInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContactGroupInfo>>(), adapterContext),
#pragma warning restore UMTExperimentalModelContactGroup

#pragma warning disable UMTExperimentalModelContactGroupMember
            ContactGroupMemberModel => new GenericInfoAdapter<ContactGroupMemberInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ContactGroupMemberInfo>>(), adapterContext),
#pragma warning restore UMTExperimentalModelContactGroupMember

#pragma warning disable UMTExperimentalModelActivity
            ActivityModel => new GenericInfoAdapter<ActivityInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ActivityInfo>>(), adapterContext),
#pragma warning restore UMTExperimentalModelActivity

#pragma warning disable UMTExperimentalModelConsentAgreement
            ConsentAgreementModel => new GenericInfoAdapter<ConsentAgreementInfo>(loggerFactory.CreateLogger<GenericInfoAdapter<ConsentAgreementInfo>>(), adapterContext),
#pragma warning restore UMTExperimentalModelConsentAgreement

            // macro models
            ContentItemSimplifiedModel => new ContentItemSimplifiedAdapter(providerProxyFactory.CreateProviderProxy<ContentItemInfo>(providerProxyContext), providerProxyFactory, Service.Resolve<IDateTimeNowService>(), this,
                loggerFactory.CreateLogger<ContentItemSimplifiedAdapter>(), Service.Resolve<IInfoProvider<ContentFolderInfo>>(), workspaceService),
            _ => null,
        };
    }
}
