using System.ComponentModel.DataAnnotations;
using Kentico.Xperience.UMT.Attributes;

// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model for creating WebPageFolder items in Xperience by Kentico.
/// Folders are special items with no content type (ContentItemDataClassID = NULL)
/// that organize web pages in the content tree.
/// </summary>
[UmtModel(DISCRIMINATOR)]
public class WebPageFolderModel : UmtModel
{
    public const string DISCRIMINATOR = "WebPageFolder";

    /// <summary>
    /// Unique identifier for the folder. Used for both ContentItem and WebPageItem GUIDs.
    /// </summary>
    [Required]
    [UniqueIdProperty]
    public Guid? WebPageFolderGUID { get; set; }

    /// <summary>
    /// Code name of the folder.
    /// </summary>
    [Required]
    public string? WebPageFolderName { get; set; }

    /// <summary>
    /// Display name of the folder shown in the admin UI.
    /// </summary>
    [Required]
    public string? WebPageFolderDisplayName { get; set; }

    /// <summary>
    /// Tree path of the folder (e.g., "/articles/reviews").
    /// </summary>
    [Required]
    public string? WebPageFolderTreePath { get; set; }

    /// <summary>
    /// GUID of the parent folder or page. If null, folder is created at the root.
    /// </summary>
    public Guid? WebPageFolderParentGUID { get; set; }

    /// <summary>
    /// Code name of the website channel where the folder will be created.
    /// </summary>
    [Required]
    public string? WebsiteChannelName { get; set; }

    /// <summary>
    /// Language code for the folder's display name (e.g., "en").
    /// </summary>
    [Required]
    public string? LanguageName { get; set; }

    /// <summary>
    /// Order of the folder within its parent. If null, defaults to 0.
    /// </summary>
    public int? WebPageFolderOrder { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() =>
        (WebPageFolderGUID, WebPageFolderName, WebPageFolderDisplayName);
}
