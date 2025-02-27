using CMS.ContentEngine.Internal;
using CMS.DataEngine;

using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.Services;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class ContentItemCommonDataAdapter : GenericInfoAdapter<ContentItemCommonDataInfo>
{
    internal ContentItemCommonDataAdapter(ILogger<ContentItemCommonDataAdapter> logger, GenericInfoAdapterContext adapterContext, ContentItemReferencePopulator contentItemReferencePopulator) : base(logger, adapterContext) => this.contentItemReferencePopulator = contentItemReferencePopulator;

    private readonly ContentItemReferencePopulator contentItemReferencePopulator;

    public override ContentItemCommonDataInfo Adapt(IUmtModel input)
    {
        var model = (ContentItemCommonDataModel)input;

        ContentItemReferencePopulator.Preprocess(ContentItemCommonDataInfo.TYPEINFO.ObjectClassName, model.CustomProperties);

        return base.Adapt(input);
    }

    public override void Postprocess(IUmtModel model, BaseInfo baseInfo)
    {
        base.Postprocess(model, baseInfo);

        contentItemReferencePopulator.Postprocess(ContentItemCommonDataInfo.TYPEINFO.ObjectClassName, model.CustomProperties, ((ContentItemCommonDataInfo)baseInfo).ContentItemCommonDataID);
    }
}
