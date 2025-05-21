using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model
{
    [UmtModel(DISCRIMINATOR)]
    [Experimental("UMTExperimentalModelContactGroup")]
    public class ContactGroupModel : UmtModel
    {
        public const string DISCRIMINATOR = "ContactGroup";

        [Map]
        [Required]
        public string? ContactGroupName { get; set; }

        [Map]
        [Required]
        public string? ContactGroupDisplayName { get; set; }

        [Map]
        public string? ContactGroupDescription { get; set; }

        [Map]
        public string? ContactGroupDynamicCondition { get; set; }

        [Map]
        public bool? ContactGroupEnabled { get; set; }

        [Map]
        public DateTime? ContactGroupLastModified { get; set; }

        [UniqueIdProperty]
        [Required]
        public Guid? ContactGroupGUID { get; set; }

        [Map]
        public int? ContactGroupStatus { get; set; }

        [Map]
        public bool? ContactGroupIsRecipientList { get; set; }

        protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (ContactGroupGUID, ContactGroupName, NOT_AVAILABLE);
    }
}
