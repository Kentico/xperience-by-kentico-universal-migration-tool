using CMS.ContentEngine.Internal;
using CMS.Core;
using CMS.DataEngine;
using CMS.DataEngine.Internal;
using CMS.FormEngine;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Services.Model;
using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class ContentItemCommonDataAdapter : GenericInfoAdapter<ContentItemCommonDataInfo>
{
    internal ContentItemCommonDataAdapter(ILogger<ContentItemCommonDataAdapter> logger, UmtModelService modelService, IProviderProxy providerProxy, IProviderProxyFactory providerProxyFactory) : base(logger, modelService, providerProxy, providerProxyFactory)
    {
    }

    public override ContentItemCommonDataInfo Adapt(IUmtModel input)
    {
        if (input is not ContentItemCommonDataModel)
        {
            throw new InvalidOperationException($"Invalid adapter for model {input.GetType()}");
        }

        var model = (ContentItemCommonDataModel)input;

        if (model.ContentItemDataGuid is null)
        {
            throw new InvalidOperationException("Object guid is required for Custom ContentItemData model");
        }

        var contentItemInfoProvider = Provider<ContentItemInfo>.Instance;
        var dataClassProvider = DataClassInfoProvider.ProviderObject;
        var contentItemCommonDataInfoProvider = Provider<ContentItemCommonDataInfo>.Instance;

        var contentItemInfo = contentItemInfoProvider.Get().WithGuid(model.ContentItemCommonDataContentItemGuid!.Value).FirstOrDefault();
        var dataClassInfo = dataClassProvider.Get().WithID(contentItemInfo!.ContentItemContentTypeID).FirstOrDefault();
        var formInfo = new FormInfo(dataClassInfo!.ClassFormDefinition);

        var toAdapt = new ContentItemCommonDataModel()
        {
            ContentItemCommonDataContentItemGuid = model.ContentItemCommonDataContentItemGuid,
            ContentItemCommonDataContentLanguageGuid = model.ContentItemCommonDataContentLanguageGuid,
            ContentItemCommonDataGUID = model.ContentItemCommonDataGUID,
            ContentItemCommonDataIsLatest = model.ContentItemCommonDataIsLatest,
            ContentItemCommonDataPageBuilderWidgets = model.ContentItemCommonDataPageBuilderWidgets,
            ContentItemCommonDataPageTemplateConfiguration = model.ContentItemCommonDataPageTemplateConfiguration,
            ContentItemCommonDataVersionStatus = model.ContentItemCommonDataVersionStatus,
            ContentItemDataGuid = model.ContentItemDataGuid,
            CustomProperties = new Dictionary<string, object?>(model.CustomProperties)
        };

        var formDefinitionProperties = new Dictionary<string, object?>();

        foreach (var formDefinitionProperty in formInfo.GetFields(true, true))
        {
            bool isSetInProperties = input.CustomProperties.ContainsKey(formDefinitionProperty.Name);

            if (!formDefinitionProperty.AllowEmpty && !isSetInProperties && !formDefinitionProperty.PrimaryKey && !formDefinitionProperty.System)
            {
                throw new InvalidOperationException($"Property {formDefinitionProperty.Name} does not allow empty in {dataClassInfo.ClassName} and it has not been set in the CustomProperties");
            }
            if (isSetInProperties)
            {
                toAdapt.CustomProperties.Remove(formDefinitionProperty.Name);
                formDefinitionProperties.Add(formDefinitionProperty.Name, input.CustomProperties[formDefinitionProperty.Name]);
            }
        }

        var adapted = base.Adapt(toAdapt);

        contentItemCommonDataInfoProvider.Set(adapted);

        var savedCommonDataInfo = contentItemCommonDataInfoProvider.Get().WithGuid(model.ContentItemCommonDataGUID!.Value).FirstOrDefault();
        var itemDataProvider = Service.Resolve<IContentItemDataInfoProviderAccessor>().Get(dataClassInfo.ClassName);

        var contentItemDataInfo = itemDataProvider.Get().WithGuid(model.ContentItemDataGuid.Value).FirstOrDefault()
            ??
        new ContentItemDataInfo(dataClassInfo.ClassName ?? throw new InvalidOperationException("ClassName is required for Custom ContentItemData model"))
        {
            ContentItemDataCommonDataID = savedCommonDataInfo!.ContentItemCommonDataID,
            ContentItemDataGUID = model.ContentItemDataGuid.Value,
        };

        foreach (var prop in formDefinitionProperties)
        {
            contentItemDataInfo.SetValue(prop.Key, prop.Value);
        }

        itemDataProvider.Set(contentItemDataInfo);
        return adapted;
    }
}


//internal class ContentItemLanguageMetadataAdapter : GenericInfoAdapter<ContentItemLanguageMetadataInfo>
//{
//    internal ContentItemLanguageMetadataAdapter(ILogger<ContentItemLanguageMetadataAdapter> logger, UmtModelService modelService, IProviderProxy providerProxy, IProviderProxyFactory providerProxyFactory) : base(logger, modelService, providerProxy, providerProxyFactory)
//    { 
//    }

//    public override ContentItemLanguageMetadataInfo Adapt(IUmtModel input)
//    {
//        if (input is not ContentItemLanguageMetadataModel)
//        {
//            throw new InvalidOperationException($"Invalid adapter for model {input.GetType()}");
//        }

//        //TODO - zakomentovat - zmenit na generic adapter

//        var model = (ContentItemLanguageMetadataModel)input;
//        var infoProvider = Provider<ContentItemLanguageMetadataInfo>.Instance;

//        if (model.ContentItemLanguageMetadataLatestVersionStatus == null)
//        {
//            if (infoProvider.Get().WithGuid(model.ContentItemLanguageMetadataContentLanguageGuid!.Value).FirstOrDefault() == null)
//            {
//                model.ContentItemLanguageMetadataLatestVersionStatus = 0;
//            }
//        }

//        var adapted = base.Adapt(model);

//        return adapted;
//    }
//}
