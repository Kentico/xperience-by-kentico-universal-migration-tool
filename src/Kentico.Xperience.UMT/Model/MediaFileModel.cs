using System.ComponentModel.DataAnnotations;
using CMS.MediaLibrary;
using CMS.Membership;
using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// 
/// </summary>
/// <sample>mediafile.sample.fromdisk</sample>
/// <sample>mediafile.sample.fromurl</sample>
[UmtModel(DISCRIMINATOR)]
public class MediaFileModel : UmtModel
{
    public const string DISCRIMINATOR = "Media_File";

    public string? DataSourcePath { get; set; }
    public string? DataSourceUrl { get; set; }

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? FileGUID { get; set; }

    [Required]
    [ReferenceProperty(typeof(MediaLibraryInfo), "FileLibraryID", IsRequired = true)]
    public Guid? FileLibraryGuid { get; set; }

    [ReferenceProperty(typeof(UserInfo), "FileCreatedByUserID", IsRequired = false)]
    public Guid? FileCreatedByUserGuid { get; set; }

    [ReferenceProperty(typeof(UserInfo), "FileModifiedByUserID", IsRequired = false)]
    public Guid? FileModifiedByUserGuid { get; set; }

    [Map]
    [Required]
    public string? FileName { get; set; }

    [Map]
    public string? FileTitle { get; set; }

    [Map]
    public string? FileDescription { get; set; }

    [Map]
    public string? FileExtension { get; set; }

    [Map]
    public string? FileMimeType { get; set; }

    [Map]
    public string? FilePath { get; set; }

    [Map]
    public int? FileImageWidth { get; set; }

    [Map]
    public int? FileImageHeight { get; set; }

    [Map]
    public DateTime? FileCreatedWhen { get; set; }

    [Map]
    public DateTime? FileModifiedWhen { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (FileGUID, FileName, FileTitle);
}
