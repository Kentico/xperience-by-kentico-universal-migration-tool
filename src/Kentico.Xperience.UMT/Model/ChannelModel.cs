

using System.ComponentModel.DataAnnotations;

namespace Kentico.Xperience.UMT.Model;

public class ChannelModel : UmtModel
{
    [Required]
    public string ChannelDisplayName { get; set; }

    [Required]
    public string ChannelName { get; set; }

    [Required]
    public Guid ChannelGUID { get; set; }
}
