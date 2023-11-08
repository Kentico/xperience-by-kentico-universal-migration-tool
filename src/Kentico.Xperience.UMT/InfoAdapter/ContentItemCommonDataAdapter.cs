using System.Data;
using System.Diagnostics;
using System.Text.Json;
using CMS.ContentEngine.Internal;
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

    private object? GetCustomProperty(IUmtModel input, string customProperty)
    {
        object? value = input.CustomProperties[customProperty];
        if (value is JsonElement jsonElement)
        {
            value = jsonElement.ToString();
        }

        return value;
    }

    public override ContentItemCommonDataInfo Adapt(IUmtModel input)
    {
        if (input is not ContentItemCommonDataModel)
        {
            throw new InvalidOperationException($"Invalid adapter for model");
        }

        var model = (ContentItemCommonDataModel)input;

        var adapted = base.Adapt(input);

        if (model.ContentItemDataGuid is null)
        {
            throw new InvalidOperationException("Object guid is required for Custom ContentItemData model");
        }

        var contentItemInfoProvider = Provider<ContentItemInfo>.Instance;
        var dataClassProvider = Provider<DataClassInfo>.Instance;

        var contentItemInfo = contentItemInfoProvider.Get().WithGuid(model.ContentItemCommonDataContentItemGuid!.Value).FirstOrDefault();
        var dataClassInfo = dataClassProvider.Get().WithID(contentItemInfo!.ContentItemContentTypeID).FirstOrDefault();
        var formInfo = new FormInfo(dataClassInfo!.ClassFormDefinition);

        if (input.CustomProperties.Count > 0)
        {
            //var contentItemDataInfo = new ContentItemDataInfo((string?)GetCustomProperty(input, "ClassName") ?? throw new InvalidOperationException("ClassName is required for Custom ContentItemData model"))
            //{
            //    ContentItemDataCommonDataID = savedInfo.ContentItemCommonDataID,
            //    ContentItemDataGUID = model.ContentItemDataGuid.Value,
            //};

            //foreach (var customProperty in input.CustomProperties)
            //{
            //    var columnName = customProperty.Key;
            //    var value = GetCustomProperty(input, customProperty.Key);

            //    contentItemDataInfo.SetValue(columnName, value);
            //}
        }

        return adapted;
    }
}
