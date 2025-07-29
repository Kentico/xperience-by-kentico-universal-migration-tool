using CMS.ContentEngine;
using CMS.ContentEngine.Internal;
using CMS.DataEngine;

using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.Services;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class ContentItemAdapter : GenericInfoAdapter<ContentItemInfo>
{
    private readonly int rootContentFolderID;
    private readonly WorkspaceService workspaceService;

    internal ContentItemAdapter(ILogger<ContentItemAdapter> logger, IInfoProvider<ContentFolderInfo> contentFolderInfoProvider, WorkspaceService workspaceService, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
        rootContentFolderID = contentFolderInfoProvider.Get().Where(x => x.WhereEquals(nameof(ContentFolderInfo.ContentFolderTreePath), "/")).FirstOrDefault()?.ContentFolderID
            ?? throw new InvalidOperationException("Target instance doesn't contain root content folder");
        this.workspaceService = workspaceService;
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
            adapted.ContentItemWorkspaceID = workspaceService.FallbackWorkspace.Value.WorkspaceID;
        }
        return adapted;
    }
}
