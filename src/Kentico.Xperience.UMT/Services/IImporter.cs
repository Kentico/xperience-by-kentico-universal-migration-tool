using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using CMS.DataEngine;
using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Services;

public interface IImportResult
{
    bool Success { get; }
    int PrimaryKey { get; }
    BaseInfo? Imported { get; }
    Exception? Exception { get; set; }
    List<ValidationResult>? ModelValidationResults { get; set; } // TODO tomas.krch: 2023-11-16 convert to interface
}

public interface IImporter : IDisposable
{
    Task<IImportResult> ImportAsync(IUmtModel model);
}
