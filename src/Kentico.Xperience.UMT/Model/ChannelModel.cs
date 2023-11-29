

using System.ComponentModel.DataAnnotations;
using CMS.ContentEngine;
using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK ChannelInfo
/// </summary>
/// <sample>emailchannelchannel.sample</sample>
[UmtModel(DISCRIMINATOR)]
public class ChannelModel : UmtModel
{
    public const string DISCRIMINATOR = "Channel";

    [Map]
    [Required]
    public string? ChannelDisplayName { get; set; }

    [Map]
    [Required]
    public string? ChannelName { get; set; }

    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid? ChannelGUID { get; set; }

    [Map]
    [Required]
    public ChannelType? ChannelType { get; set; }
    
    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (ChannelGUID, ChannelName, ChannelDisplayName);
}
