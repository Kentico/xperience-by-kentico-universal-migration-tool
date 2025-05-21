using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

using CMS.ContactManagement;
using CMS.DataProtection;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model
{
    [UmtModel(DISCRIMINATOR)]
    [Experimental("UMTExperimentalModelConsentAgreement")]
    public class ConsentAgreementModel : UmtModel
    {
        public const string DISCRIMINATOR = "ConsentAgreement";

        [UniqueIdProperty]
        [Required]
        public Guid? ConsentAgreementGUID { get; set; }

        [Map]
        public bool? ConsentAgreementRevoked { get; set; }

        [Map]
        public string? ConsentAgreementConsentHash { get; set; }

        [Map]
        public DateTime? ConsentAgreementTime { get; set; }

        [ReferenceProperty(typeof(ContactInfo), "ConsentAgreementContactID")]
        public Guid? ConsentAgreementContactGUID { get; set; }

        [ReferenceProperty(typeof(ConsentInfo), "ConsentAgreementConsentID")]
        public Guid? ConsentAgreementConsentGUID { get; set; }

        protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (ConsentAgreementGUID, NOT_AVAILABLE, NOT_AVAILABLE);
    }
}
