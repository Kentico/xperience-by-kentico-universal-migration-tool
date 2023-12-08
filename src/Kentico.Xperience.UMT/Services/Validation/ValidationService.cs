using System.ComponentModel.DataAnnotations;
using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Services.Validation;

/// <inheritdoc />
public class ValidationService : IValidationService
{
    /// <summary>
    /// Return instance of validation service
    /// </summary>
    public static IValidationService Instance => new ValidationService();
    
    /// <summary>
    /// Validates UMT model
    /// </summary>
    /// <param name="model"></param>
    /// <param name="result">collection where results are appended</param>
    /// <returns>true if valid, false if invalid</returns>
    public bool TryValidateModel(IUmtModel model, ref List<ValidationResult> result)
    {
        var validationContext = new ValidationContext(model);
        return Validator.TryValidateObject(model, validationContext, result, true);
    }
}
