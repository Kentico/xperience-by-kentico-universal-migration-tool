using CMS.ContentEngine;
using CMS.Core;
using CMS.Core.Internal;
using CMS.DataEngine;
using CMS.Helpers;
using CMS.Workspaces;

using Kentico.Xperience.UMT.Model;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class ContentFolderAdapter : GenericInfoAdapter<ContentFolderInfo>
{
    private readonly IInfoProvider<ContentFolderInfo> contentFolderInfoProvider;
    private readonly IInfoProvider<WorkspaceInfo> workspaceInfoProvider;

    internal ContentFolderAdapter(ILogger<ContentFolderAdapter> logger, IInfoProvider<ContentFolderInfo> contentFolderInfoProvider, IInfoProvider<WorkspaceInfo> workspaceInfoProvider, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
        this.contentFolderInfoProvider = contentFolderInfoProvider;
        this.workspaceInfoProvider = workspaceInfoProvider;
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
            var defaultWorkspace = workspaceInfoProvider.Get()
                .WhereEquals(nameof(WorkspaceInfo.WorkspaceName), DEFAULT_WORKSPACE_NAME)
                .FirstOrDefault();

            if (defaultWorkspace != null)
            {
                info.ContentFolderWorkspaceID = defaultWorkspace.WorkspaceID;
            }
            else
            {
                Logger.LogError("Failed to locate default workspace");
            }
        }

        return info;
    }
}
