using System.Diagnostics;

using CMS.ContentEngine.Internal;
using CMS.DataEngine;

using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.Services;
using Kentico.Xperience.UMT.Services.Model;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class ContentItemDataAdapter : GenericInfoAdapter<ContentItemDataInfo>
{
    private readonly ContentItemReferencePopulator contentItemReferencePopulator;

    internal ContentItemDataAdapter(ILogger<ContentItemDataAdapter> logger, GenericInfoAdapterContext adapterContext, ContentItemReferencePopulator contentItemReferencePopulator) : base(logger, adapterContext) => this.contentItemReferencePopulator = contentItemReferencePopulator;

    protected override string GetGuidColumnName(BaseInfo info) => nameof(ContentItemDataInfo.ContentItemDataGUID);

    public override ContentItemDataInfo Adapt(IUmtModel input)
    {
        var model = (ContentItemDataModel)input;

        ContentItemReferencePopulator.Preprocess(model.ContentItemContentTypeName!, model.CustomProperties);

        return base.Adapt(input);
    }

    public override void Postprocess(IUmtModel model, BaseInfo baseInfo)
    {
        base.Postprocess(model, baseInfo);

        contentItemReferencePopulator.Postprocess(((ContentItemDataInfo)baseInfo).ClassName, model.CustomProperties, ((ContentItemDataInfo)baseInfo).ContentItemDataCommonDataID);
    }

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
