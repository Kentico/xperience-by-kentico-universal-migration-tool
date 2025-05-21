using System.Diagnostics.CodeAnalysis;

using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model
{
    [UmtModel(DISCRIMINATOR)]
    [Experimental("UMTExperimentalModelFormSubmission")]
    public class FormSubmissionModel : UmtModel
    {
        public const string DISCRIMINATOR = "FormSubmission";

        [UniqueIdProperty]
        public Guid? FormSubmissionGUID { get; set; }
        public int FormClassID { get; set; }

        public KeyValuePair<string, object?>[]? Data { get; set; }

        protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (FormSubmissionGUID, NOT_AVAILABLE, NOT_AVAILABLE);
    }
}
