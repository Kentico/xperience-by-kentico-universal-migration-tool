using CMS.ContentEngine;
using CMS.Core;
using CMS.Core.Internal;
using CMS.Helpers;

using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Services.Model;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class ContentFolderAdapter: GenericInfoAdapter<ContentFolderInfo>
{
    internal ContentFolderAdapter(ILogger<ContentFolderAdapter> logger, UmtModelService modelService, IProviderProxy providerProxy, IProviderProxyFactory providerProxyFactory) : base(logger, modelService, providerProxy, providerProxyFactory)
    {
    }

    public override ContentFolderInfo Adapt(IUmtModel input)
    {
        var info = base.Adapt(input);
        
        var dateTimeNowService = Service.Resolve<IDateTimeNowService>();
        if (info.ContentFolderCreatedWhen == DateTimeHelper.ZERO_TIME)
        {
            info.ContentFolderCreatedWhen = dateTimeNowService.GetDateTimeNow();
        }
        info.ContentFolderModifiedWhen = dateTimeNowService.GetDateTimeNow();

        if (input is ContentFolderModel { ContentFolderParentFolderGUID: null })
        {
            var root = ContentFolderInfoProvider.ProviderObject.Get()
                .WhereEquals(nameof(ContentFolderInfo.ContentFolderTreePath), "/")
                .FirstOrDefault();
                
            if (root != null)
            {
                info.ContentFolderParentFolderID = root.ContentFolderID;    
            }
            else
            {
                Logger.LogError("Failed to located root content item folder");
            }
        }

        return info;
    }
}
