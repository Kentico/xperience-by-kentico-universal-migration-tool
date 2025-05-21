using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

using CMS.Globalization;
using CMS.Membership;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model
{
    [UmtModel(DISCRIMINATOR)]
    [Experimental("UMTExperimentalModelContact")]
    public class ContactModel : UmtModel
    {
        public const string DISCRIMINATOR = "Contact";

        [Map]
        public string? ContactEmail { get; set; }

        [Map]
        [Required]
        public DateTime? ContactLastModified { get; set; }

        [Map]
        public bool? ContactMonitored { get; set; }

        [Map]
        public DateTime? ContactBirthday { get; set; }

        [Map]
        public int? ContactGender { get; set; }

        [Map]
        public string? ContactFirstName { get; set; }

        [ReferenceProperty(typeof(CountryInfo), "ContactCountryID")]
        public Guid? ContactCountryGUID { get; set; }

        [Map]
        public string? ContactMobilePhone { get; set; }

        [Map]
        public string? ContactLastName { get; set; }

        [Map]
        public string? ContactCity { get; set; }

        [ReferenceProperty(typeof(UserInfo), "ContactUserID")]
        public Guid? ContactOwnerUserGUID { get; set; }

        [Map]
        [Required]
        public DateTime? ContactCreated { get; set; }

        [UniqueIdProperty]
        [Required]
        public Guid? ContactGUID { get; set; }

        [Map]
        public string? ContactJobTitle { get; set; }

        [ReferenceProperty(typeof(StateInfo), "ContactStateID")]
        public Guid? ContactStateGUID { get; set; }

        [Map]
        public string? ContactAddress1 { get; set; }

        [Map]
        public string? ContactNotes { get; set; }

        [Map]
        public string? ContactZIP { get; set; }

        [Map]
        public string? ContactMiddleName { get; set; }

        [Map]
        public string? ContactBusinessPhone { get; set; }

        [Map]
        public string? ContactCampaign { get; set; }

        [Map]
        public string? ContactCompanyName { get; set; }

        protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (ContactGUID, $"{ContactFirstName} {ContactLastName}", NOT_AVAILABLE);
    }
}
