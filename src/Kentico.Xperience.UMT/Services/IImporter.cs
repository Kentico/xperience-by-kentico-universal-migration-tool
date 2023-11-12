using System.Xml.Serialization;
using CMS.DataEngine;
using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Services;

public interface IImportResult
{
    bool Success { get; }
    int PrimaryKey { get; }
    BaseInfo? Imported { get; }
}

public interface IImporter : IDisposable
{
    Task<IImportResult> ImportAsync(UmtModel model, ImporterContext context);
}
