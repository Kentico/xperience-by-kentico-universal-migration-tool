using CMS.Workspaces;

namespace Kentico.Xperience.UMT.Services
{
    internal class WorkspaceService
    {
        public Lazy<WorkspaceInfo> FallbackWorkspace { get; } = new(() =>
        {
            var workspaces = WorkspaceInfo.Provider.Get().ToArray();

            return workspaces.Length switch
            {
                0 => throw new InvalidOperationException("Cannot determine fallback workspace. No workspace found in target database. Create a workspace and retry."),
                1 => workspaces[0],
                _ => workspaces.FirstOrDefault(x => string.Equals(x.WorkspaceName, DEFAULT_WORKSPACE_NAME, StringComparison.InvariantCultureIgnoreCase)) ?? throw new InvalidOperationException("Cannot determine fallback workspace. Multiple workspaces found in target database. Specify workspace explicitly.")
            };
        });
    }
}
