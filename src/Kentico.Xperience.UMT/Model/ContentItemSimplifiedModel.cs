using System.ComponentModel.DataAnnotations;

using CMS.ContentEngine;

using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// 
/// </summary>
/// <sample>ContentItemSimplifiedModel.Sample.ArticleSubPage</sample>
/// <sample>ContentItemSimplifiedModel.Sample.Article</sample>
/// <sample>ContentItemSimplifiedModel.Sample.Event2024</sample>
[UmtModel(DISCRIMINATOR)]
public class ContentItemSimplifiedModel : UmtModel
{
    public const string DISCRIMINATOR = "ContentItemSimplified";

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? ContentItemGUID { get; set; }

    /// <summary>
    /// Reference to content folder
    /// </summary>
    public Guid? ContentItemContentFolderGUID { get; set; }

    /// <summary>
    /// Reference to workspace
    /// </summary>
    public Guid? ContentItemWorkspaceGUID { get; set; }

    public bool? IsSecured { get; set; } = false;


    #region "CreateContentItemParameters"

    /// <summary>Content item type name.</summary>
    [Required]
    public string? ContentTypeName { get; set; }

    /// <summary>Code name of the content item.</summary>
    [Required]
    public string? Name { get; set; }

    /// <summary>
    /// Indicates if content item is reusable. By default, item will be created as reusable.
    /// </summary>
    public bool IsReusable { get; set; } = false;

    /// <summary>
    /// ID of a channel the content item is owned by. By default, item won't be owned by a channel.
    /// </summary>
    public string? ChannelName { get; set; }

    public List<ContentItemLanguageData> LanguageData { get; set; } = [];

    public PageDataModel? PageData { get; set; }

    #endregion

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (ContentItemGUID, Name, null);
}

public class ContentItemLanguageData
{
    [Required]
    public required string LanguageName { get; set; }

    [Required]
    public required string DisplayName { get; set; }

    public VersionStatus VersionStatus { get; set; } = VersionStatus.Published;
    public bool IsLatest { get; set; } = true;

    [Required]
    public required Guid? UserGuid { get; set; }

    /// <summary>
    /// Date and time on which draft content item will be published, must be set in future
    /// </summary>
    public DateTime? ScheduledPublishWhen { get; set; }

    /// <summary>
    /// Date and time on which published content item will be unpublished, must be set in future
    /// </summary>
    public DateTime? ScheduledUnpublishWhen { get; set; }

    public Dictionary<string, object?>? ContentItemData { get; set; }

    public object? VisualBuilderTemplateConfiguration { get; set; }
    public object? VisualBuilderWidgets { get; set; }
}

public class PageDataModel
{
    /// <summary>
    /// PageUrlModel item is required for each content language that exist in XbyK instance without regards to created LanguageData (urls are pre-created for non-existing language versions)
    /// </summary>
    public List<PageUrlModel>? PageUrls { get; set; }

    /// <summary>
    /// PageFormerModel item is optional for each content language that exist in XbyK instance for correct redirection of former urls
    /// </summary>
    public List<PageFormerUrlModel>? PageFormerUrls { get; set; }

    /// <summary>
    /// Required only if page needs to be referenced as a parent by any child page
    /// </summary>
    public Guid? PageGuid { get; set; }
    public Guid? ParentGuid { get; set; }
    public string? TreePath { get; set; }
    public int? ItemOrder { get; set; }
}

/// <summary>
/// Defines url for web page item
/// </summary>
public class PageUrlModel
{
    public string? UrlPath { get; set; }
    /// <summary>
    /// currently unused, until simplified model supports Draft content items (and not only Published or InitialDraft) 
    /// </summary>
    public bool? PathIsDraft { get; set; } = false;
    public bool? PathIsLatest { get; set; } = true;
    public string? LanguageName { get; set; }
}

/// <summary>
/// Defines former url for web page item
/// </summary>
public class PageFormerUrlModel
{
    public string? FormerUrlPath { get; set; }
    public string? LanguageName { get; set; }
}
