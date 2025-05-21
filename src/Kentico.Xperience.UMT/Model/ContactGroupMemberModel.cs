using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

using CMS.ContactManagement;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model
{
    [UmtModel(DISCRIMINATOR)]
    [Experimental("UMTExperimentalModelContactGroupMember")]
    public class ContactGroupMemberModel : UmtModel
    {
        public const string DISCRIMINATOR = "ContactGroupMember";

        [ReferenceProperty(typeof(ContactGroupInfo), "ContactGroupMemberContactGroupID")]
        [UniqueKeyPart("ContactGroupMemberContactGroupID", typeof(ContactGroupInfo))]
        public Guid? ContactGroupMemberContactGroupGUID { get; set; }

        [Map]
        [Required]
        [UniqueKeyPart]
        public int? ContactGroupMemberType { get; set; }

        /// <summary>
        /// Warning - implemented just for related ID as reference to ContactInfo, not AccountInfo.
        /// </summary>
        [ReferenceProperty(typeof(ContactInfo), "ContactGroupMemberRelatedID")]
        [UniqueKeyPart("ContactGroupMemberRelatedID", typeof(ContactInfo))]
        public Guid? ContactGroupMemberRelatedGUID { get; set; }

        [Map]
        public bool? ContactGroupMemberFromCondition { get; set; }

        [Map]
        public bool? ContactGroupMemberFromAccount { get; set; }

        [Map]
        public bool? ContactGroupMemberFromManual { get; set; }

        protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (null, NOT_AVAILABLE, NOT_AVAILABLE);
    }
}
