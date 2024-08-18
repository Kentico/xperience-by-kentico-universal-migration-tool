using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Kentico.Xperience.UMT.Model;

[KnownType(typeof(AssetFileSource))]
[KnownType(typeof(AssetUrlSource))]
[KnownType(typeof(AssetDataSource))]
[JsonPolymorphic(TypeDiscriminatorPropertyName = DISCRIMINATOR_PROPERTY, UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization)]
[JsonDerivedType(typeof(AssetFileSource), typeDiscriminator: "AssetFile")]
[JsonDerivedType(typeof(AssetUrlSource), typeDiscriminator: "AssetUrl")]
[JsonDerivedType(typeof(AssetDataSource), typeDiscriminator: "AssetData")]
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
}


public class AssetFileSource : AssetSource
{
    [Required]
    public string? FilePath { get; set; }
}

public class AssetUrlSource : AssetSource
{
    [Required]
    public string? Url { get; set; }
}

public class AssetDataSource : AssetSource
{
    [Required]
    public byte[]? Data { get; set; } 
}
