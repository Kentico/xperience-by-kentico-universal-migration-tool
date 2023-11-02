

using System.ComponentModel.DataAnnotations;
using CMS.ContentEngine;
using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

public class ChannelModel : UmtModel
{
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
}
