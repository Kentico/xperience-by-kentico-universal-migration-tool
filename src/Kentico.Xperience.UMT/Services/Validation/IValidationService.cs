using System.ComponentModel.DataAnnotations;
using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Services.Validation;

/// <summary>
/// UMT Model validation / correct format checking
/// </summary>
public interface IValidationService
{ 
    /// <summary>
    /// Validates UMT model
    /// </summary>
    /// <param name="model"></param>
    /// <param name="result">collection where results are appended</param>
    /// <returns>true if valid, false if invalid</returns>
    bool TryValidateModel(IUmtModel model, ref List<ValidationResult> result);
}
