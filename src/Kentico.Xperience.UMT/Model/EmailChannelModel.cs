using CMS.ContentEngine;
using Kentico.Xperience.UMT.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK EmailChannelInfo
/// </summary>
/// <sample>emailchannels.sample</sample>
[UmtModel(DISCRIMINATOR)]
public class EmailChannelModel : UmtModel
{
    public const string DISCRIMINATOR = "EmailChannel";

    [Map]
    [Required]
    [UniqueIdProperty]
    //[ReferenceProperty(typeof(DataClassInfo), "NodeClassID", IsRequired = true)]
    public Guid? EmailChannelGUID { get; set; }

    [Map]
    [Required]
    public string? EmailChannelSendingDomain { get; set; }
    
    [Required]
    [ReferenceProperty(typeof(ContentLanguageInfo), "EmailChannelPrimaryContentLanguageID", IsRequired = true)]
    public Guid? EmailChannelPrimaryContentLanguageGUID { get; set; }

    [Required]
    [ReferenceProperty(typeof(ChannelInfo), "EmailChannelChannelID", IsRequired = true)]
    public Guid? EmailChannelChannelGuid { get; set; }

    [Map]
    [Required]
    public string? EmailChannelServiceDomain { get; set; }

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (EmailChannelGUID, NOT_AVAILABLE, NOT_AVAILABLE);
}
