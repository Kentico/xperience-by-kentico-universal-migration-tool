using System.Diagnostics.CodeAnalysis;

using CMS.ContactManagement;
using CMS.ContentEngine;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model
{
    [UmtModel(DISCRIMINATOR)]
    [Experimental("UMTExperimentalModelActivity")]
    public class ActivityModel : UmtModel
    {
        public const string DISCRIMINATOR = "Activity";

        [Map]
        public string? ActivityUTMSource { get; set; }

        [Map]
        public string? ActivityUTMContent { get; set; }

        [ReferenceProperty(typeof(ContactInfo), "ActivityContactID")]
        [UniqueKeyPart("ActivityContactID", referencedInfoType: typeof(ContactInfo))]
        public Guid? ActivityContactGUID { get; set; }

        [Map]
        public Guid? ActivityWebPageItemGUID { get; set; }

        [Map]
        public string? ActivityTitle { get; set; }

        [Map]
        public string? ActivityType { get; set; }

        [Map]
        public string? ActivityValue { get; set; }

        [Map]
        public string? ActivityURL { get; set; }

        [Map]
        [UniqueKeyPart]
        public DateTime? ActivityCreated { get; set; }

        [Map]
        public int? ActivityItemID { get; set; }

        [Map]
        public int? ActivityItemDetailID { get; set; }

        [Map]
        public string? ActivityURLReferrer { get; set; }

        [Map]
        public string? ActivityComment { get; set; }

        [ReferenceProperty(typeof(ContentLanguageInfo), "ActivityLanguageID")]
        public Guid? ActivityLanguageGUID { get; set; }

        [ReferenceProperty(typeof(ChannelInfo), "ActivityChannelID")]
        public Guid? ActivityChannelGUID { get; set; }

        protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (null, $"{ActivityType} {ActivityTitle}", NOT_AVAILABLE);
    }







}
