using CMS.ContentEngine;
using CMS.Core;
using CMS.Core.Internal;
using CMS.DataEngine;
using CMS.Helpers;

using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.Services;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class ContentFolderAdapter : GenericInfoAdapter<ContentFolderInfo>
{
    private readonly IInfoProvider<ContentFolderInfo> contentFolderInfoProvider;
    private readonly WorkspaceService workspaceService;

    internal ContentFolderAdapter(ILogger<ContentFolderAdapter> logger, IInfoProvider<ContentFolderInfo> contentFolderInfoProvider,
        GenericInfoAdapterContext adapterContext, WorkspaceService workspaceService) : base(logger, adapterContext)
    {
        this.contentFolderInfoProvider = contentFolderInfoProvider;
        this.workspaceService = workspaceService;
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
            var root = contentFolderInfoProvider.Get()
                .WhereEquals(nameof(ContentFolderInfo.ContentFolderTreePath), "/")
                .FirstOrDefault();

            if (root != null)
            {
                info.ContentFolderParentFolderID = root.ContentFolderID;
            }
            else
            {
                Logger.LogError("Failed to locate root content item folder");
            }
        }

        if (input is ContentFolderModel { ContentFolderWorkspaceGUID: null })
        {
            info.ContentFolderWorkspaceID = workspaceService.FallbackWorkspace.Value.WorkspaceID;
        }

        return info;
    }
}
