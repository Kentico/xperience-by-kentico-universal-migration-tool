using CMS.DataEngine;
using CMS.EmailLibrary;
using Kentico.Xperience.UMT.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents EmailChannel
/// </summary>
/// <sample>emailchannels.sample</sample>
[UmtModel(DISCRIMINATOR)]
public class EmailChannelModel : ChannelModel
{
    public const string DISCRIMINATOR = "EmailChannel";

    [Required]
    [UniqueIdProperty]
    //[ReferenceProperty(typeof(DataClassInfo), "NodeClassID", IsRequired = true)]
    public Guid? EmailChannelGuid { get; set; }

    [Map]
    [Required]
    public string EmailChannelSendingDomain { get; set; }
    
    [Map]
    [Required]
    public int EmailChannelPrimaryContentLanguageID { get; set; }

    [Map]
    [Required]
    public string EmailChannelServiceDomain { get; set; }
}
