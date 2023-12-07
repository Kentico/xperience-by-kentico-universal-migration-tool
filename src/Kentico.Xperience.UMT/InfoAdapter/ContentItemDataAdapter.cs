using System.Diagnostics;
using CMS.ContentEngine.Internal;
using CMS.DataEngine;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Services.Model;
using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class ContentItemDataAdapter: GenericInfoAdapter<ContentItemDataInfo>
{
    internal ContentItemDataAdapter(ILogger<ContentItemDataAdapter> logger, UmtModelService modelService, IProviderProxy providerProxy, IProviderProxyFactory providerProxyFactory) : base(logger, modelService, providerProxy, providerProxyFactory)
    {
    }

    protected override string GetGuidColumnName(BaseInfo info) => nameof(ContentItemDataInfo.ContentItemDataGUID);

    
    
    protected override ContentItemDataInfo ObjectFactory(UmtModelInfo umtModelInfo, IUmtModel umtModel)
    {
        if (umtModel is ContentItemDataModel contentItemDataModel)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(contentItemDataModel.ContentItemContentTypeName), "!string.IsNullOrWhiteSpace(contentItemDataModel.ContentItemContentTypeName)");
            return new ContentItemDataInfo(contentItemDataModel.ContentItemContentTypeName);
        }

        throw new InvalidOperationException($"Unknown model");
    }
}
