using System.ComponentModel.DataAnnotations;
using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <sample>medialibrary.sample</sample>
[UmtModel(DISCRIMINATOR)]
public class MediaLibraryModel : UmtModel
{
    public const string DISCRIMINATOR = "Media_Library";

    [Map]
    [Required]
    public string? LibraryName { get; set; }

    [Map]
    [Required]
    public string? LibraryDisplayName { get; set; }

    [Map]
    public string? LibraryDescription { get; set; }
    
    [Map]
    [Required]
    public string? LibraryFolder { get; set; }

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? LibraryGUID { get; set; }

    [Map]
    public DateTime? LibraryLastModified { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (LibraryGUID, LibraryName, LibraryDisplayName);
}
