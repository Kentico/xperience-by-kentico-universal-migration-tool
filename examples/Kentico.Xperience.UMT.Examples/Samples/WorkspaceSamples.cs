using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class WorkspaceSamples
{
    public static readonly Guid SampleWorkspaceGuid = new("018FE300-D522-4CC8-9888-B7248E922077");

    [Sample("WorkspaceModel.Sample", "", "Workspace sample")]
    public static WorkspaceModel SampleWorkspace => new()
    {
        WorkspaceGUID = SampleWorkspaceGuid,
        WorkspaceName = "SampleWorkspace",
        WorkspaceDisplayName = "Sample Workspace",
    };
}
