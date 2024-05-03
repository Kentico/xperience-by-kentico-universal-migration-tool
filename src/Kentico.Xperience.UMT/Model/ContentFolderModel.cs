using System.ComponentModel.DataAnnotations;

using CMS.ContentEngine;

using Kentico.Xperience.UMT.Attributes;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK ContentFolderInfo, enables user to create content item folders with umt
/// </summary>
/// <sample>ContentFolderModel.Sample</sample>
[UmtModel(DISCRIMINATOR)]
public sealed class ContentFolderModel: UmtModel
{
    public const string DISCRIMINATOR = "ContentFolder";
    
    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? ContentFolderGUID { get; set; }
    
    /// <summary>
    /// parent folder guid. If null is specified, folder is created directly under root
    /// </summary>
    [ReferenceProperty(typeof(ContentFolderInfo), "ContentFolderParentFolderID", IsRequired = false)]
    public Guid? ContentFolderParentFolderGUID { get; set; }
    
    [Map]
    [Required]
    public string? ContentFolderName { get; set; }
    
    [Map]
    [Required]
    public string? ContentFolderDisplayName { get; set; }
    
    [Map]
    [Required]
    public string? ContentFolderTreePath { get; set; }
    

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (ContentFolderGUID, ContentFolderName, ContentFolderDisplayName);
}
