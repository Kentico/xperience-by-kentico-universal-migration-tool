﻿using System.ComponentModel.DataAnnotations;
using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

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
    public int? LibraryAccess { get; set; }

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? LibraryGUID { get; set; }

    [Map]
    public DateTime? LibraryLastModified { get; set; }
}