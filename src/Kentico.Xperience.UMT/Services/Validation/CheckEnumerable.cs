using System.Collections;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kentico.Xperience.UMT.Services.Validation;

public class CheckEnumerableAttribute: ValidationAttribute
{
    private readonly ConcurrentDictionary<int, List<ValidationResult>> validationResults = new();

    /// <inheritdoc />
    public override bool IsValid(object? value)
    {
        bool isValid = true;
        
        if (value is IEnumerable list)
        {
            int idx = 0;
            foreach (object? item in list)
            {
                var validationContext = new ValidationContext(item);
                bool isItemValid = Validator.TryValidateObject(item, validationContext, validationResults.GetOrAdd(idx, i => new List<ValidationResult>()), true);
                isValid &= isItemValid;
                idx += 1;
            }
        }
        
        return isValid;
    }

    /// <inheritdoc />
    public override string FormatErrorMessage(string name)
    {
        var sb = new StringBuilder();
        foreach ((int index, var value) in validationResults)
        {
            if (value is { Count: > 0 })
            {
                sb.AppendLine($"item[{index}]:{string.Join(", ", value.Select(x=> x.ErrorMessage))}");    
            }
        }

        return sb.ToString();
    }
}
