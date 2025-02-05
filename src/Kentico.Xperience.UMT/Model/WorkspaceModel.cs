using System.ComponentModel.DataAnnotations;

using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK WorkspaceInfo
/// </summary>
/// <sample>WorkspaceModel.Sample</sample>
/// <sample>ContentItemSimplifiedModel.Sample.EventInSampleWorkspace</sample>
[UmtModel(DISCRIMINATOR)]
public class WorkspaceModel : UmtModel
{
    public const string DISCRIMINATOR = "Workspace";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? WorkspaceGUID { get; set; }

    [Map]
    [Required]
    public string? WorkspaceDisplayName { get; set; }

    [Map]
    [Required]
    public string? WorkspaceName { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (WorkspaceGUID, NOT_AVAILABLE, NOT_AVAILABLE);
}
