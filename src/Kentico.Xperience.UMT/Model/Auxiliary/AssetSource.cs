using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Base model for values imported into Xperience content item asset fields. Contains the metadata
/// used to describe the asset, while derived types define where the binary data is sourced from.
/// </summary>
[KnownType(typeof(AssetFileSource))]
[KnownType(typeof(AssetUrlSource))]
[KnownType(typeof(AssetDataSource))]
[KnownType(typeof(AssetMetadataSource))]
[JsonPolymorphic(TypeDiscriminatorPropertyName = DISCRIMINATOR_PROPERTY, UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization)]
[JsonDerivedType(typeof(AssetFileSource), typeDiscriminator: "AssetFile")]
[JsonDerivedType(typeof(AssetUrlSource), typeDiscriminator: "AssetUrl")]
[JsonDerivedType(typeof(AssetDataSource), typeDiscriminator: "AssetData")]
[JsonDerivedType(typeof(AssetMetadataSource), typeDiscriminator: "AssetMetadata")]
public class AssetSource
{
    public const string DISCRIMINATOR_PROPERTY = "$assetType";
    [Required]
    public Guid? ContentItemGuid { get; set; }
    [Required]
    public Guid? Identifier { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Extension { get; set; }
    public long? Size { get; set; }
    public DateTime? LastModified { get; set; }
    public int? ImageWidth { get; set; }
    public int? ImageHeight { get; set; }

    public virtual string InferExtension() => Extension ?? throw new InvalidOperationException($"{nameof(AssetFileSource)} has unknown extension. Specify explicitly by {nameof(Extension)} property");
}


/// <summary>
/// Imports asset binary data from a file system path. The file is copied into Xperience asset storage
/// and the extension can be inferred from <see cref="FilePath"/> when not specified explicitly.
/// </summary>
public class AssetFileSource : AssetSource
{
    [Required]
    public string? FilePath { get; set; }

    public override string InferExtension() => Extension ?? CMS.IO.FileInfo.New(FilePath).Extension ?? throw new InvalidOperationException($"{nameof(AssetFileSource)} has unknown extension. Specify explicitly by {nameof(Extension)} property");
}

/// <summary>
/// Downloads asset binary data from a URL and imports it into Xperience asset storage as a stream.
/// </summary>
public class AssetUrlSource : AssetSource
{
    [Required]
    public string? Url { get; set; }
}

/// <summary>
/// Imports asset binary data provided directly as an in-memory byte array.
/// </summary>
public class AssetDataSource : AssetSource
{
    [Required]
    public byte[]? Data { get; set; }
}

/// <summary>
/// Sets only the asset field metadata without transferring, deleting, or optimizing binary content.
/// Existing asset values are preserved; use when the physical asset file or blob is already available
/// through another transfer path.
/// </summary>
public class AssetMetadataSource : AssetSource
{
    /// <summary>
    /// When <c>true</c>, overwrites an existing asset value on the target field. When <c>false</c> (default),
    /// an existing value is left untouched and this metadata is only applied when the field is still empty.
    /// </summary>
    public bool ForceUpdate { get; set; }
}
