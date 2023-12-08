using System.ComponentModel.DataAnnotations;
using CMS.ContentEngine;
using CMS.DataEngine;
using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK ContentTypeChannelInfo
/// </summary>
/// <sample>contenttypechannel.article</sample>
[UmtModel(DISCRIMINATOR)]
public class ContentTypeChannelModel: UmtModel
{
    public const string DISCRIMINATOR = "ContentTypeChannel";
    
    [Required]
    [UniqueKeyPart("ContentTypeChannelChannelID", referencedInfoType: typeof(ChannelInfo))]
    [ReferenceProperty(typeof(ChannelInfo), "ContentTypeChannelChannelID", IsRequired = true)]
    public Guid? ContentTypeChannelChannelGuid { get; set; }
    
    [Required]
    [UniqueKeyPart("ContentTypeChannelContentTypeID", referencedInfoType: typeof(DataClassInfo))]
    [ReferenceProperty(typeof(DataClassInfo), "ContentTypeChannelContentTypeID", IsRequired = true)]
    public Guid? ContentTypeChannelContentTypeGuid { get; set; }
    
    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (null, $"{ContentTypeChannelChannelGuid}_{ContentTypeChannelContentTypeGuid}", $"Channel {ContentTypeChannelChannelGuid} uses content type {ContentTypeChannelContentTypeGuid}" );
}
