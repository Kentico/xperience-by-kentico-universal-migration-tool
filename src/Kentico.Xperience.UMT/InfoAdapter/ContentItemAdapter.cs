using CMS.ContentEngine;
using CMS.ContentEngine.Internal;
using CMS.DataEngine;
using CMS.Workspaces;

using Kentico.Xperience.UMT.Model;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class ContentItemAdapter : GenericInfoAdapter<ContentItemInfo>
{
    private readonly int defaultWorkspaceID;
    private readonly int rootContentFolderID;

    internal ContentItemAdapter(ILogger<ContentItemAdapter> logger, IInfoProvider<ContentFolderInfo> contentFolderInfoProvider, IInfoProvider<WorkspaceInfo> workspaceInfoProvider, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
        rootContentFolderID = contentFolderInfoProvider.Get().Where(x => x.WhereEquals(nameof(ContentFolderInfo.ContentFolderTreePath), "/")).FirstOrDefault()?.ContentFolderID
            ?? throw new InvalidOperationException("Target instance doesn't contain root content folder");

        defaultWorkspaceID = workspaceInfoProvider.Get().Where(x => x.WhereEquals(nameof(WorkspaceInfo.WorkspaceName), DEFAULT_WORKSPACE_NAME)).FirstOrDefault()?.WorkspaceID
            ?? throw new InvalidOperationException($"Target instance doesn't contain default workspace (WorkspaceName=\"{DEFAULT_WORKSPACE_NAME}\"");
    }

    public override ContentItemInfo Adapt(IUmtModel input)
    {
        var adapted = base.Adapt(input);
        if (0 == adapted.ContentItemContentFolderID)
        {
            adapted.ContentItemContentFolderID = rootContentFolderID;
        }
        if (0 == adapted.ContentItemWorkspaceID)
        {
            adapted.ContentItemWorkspaceID = defaultWorkspaceID;
        }
        return adapted;
    }
}
