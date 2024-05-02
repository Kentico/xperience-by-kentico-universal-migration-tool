using System.ComponentModel.DataAnnotations;
using CMS.ContentEngine;
using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// 
/// </summary>
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
    
    public VersionStatus VersionStatus { get; set; } = VersionStatus.InitialDraft;
    
    [Required]
    public required Guid? UserGuid { get; set; }
    
    public Dictionary<string, object?>? ContentItemData { get; set; }
}

public class PageDataModel
{
    public List<PageUrlModel>? PageUrls { get; set; }
    public Guid? ParentGuid { get; set; }
    public string? TreePath { get; set; }
    public int? ItemOrder { get; set; }
}


public class PageUrlModel
{
    public string? UrlPath { get; set; }
    public bool? PathIsDraft { get; set; }
    public string? LanguageName { get; set; }
}
