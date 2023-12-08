using System.ComponentModel.DataAnnotations;
using CMS.DataEngine;
using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Services;

public interface IImportResult
{
    bool Success { get; }
    int PrimaryKey { get; }
    BaseInfo? Imported { get; }
    Exception? Exception { get; set; }
    List<ValidationResult>? ModelValidationResults { get; set; }
}

public interface IImporter
{
    Task<IImportResult> ImportAsync(IUmtModel model);
}
