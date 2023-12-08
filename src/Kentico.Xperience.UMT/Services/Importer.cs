using System.ComponentModel.DataAnnotations;
using CMS.DataEngine;
using Kentico.Xperience.UMT.InfoAdapter;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Services.Validation;
using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.Services;

public class ImportResult : IImportResult
{ 
    public bool Success { get; set; }
    public int PrimaryKey { get; set; }
    public BaseInfo? Imported { get; set; }
    public Exception? Exception { get; set; }
    public List<ValidationResult>? ModelValidationResults { get; set; }
}

internal class Importer(ILogger<Importer> logger, AdapterFactory factory) : IImporter
{
    public async Task<IImportResult> ImportAsync(IUmtModel model)
    {
        var providerProxyContext = new ProviderProxyContext();
        
        try
        {
            var importResult = await ImportObject(model, providerProxyContext);
            return importResult;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occured");

            return new ImportResult
            {
                Success = false,
                Exception = ex
            };
        }
    }

    private Task<ImportResult> ImportObject(IUmtModel model, IProviderProxyContext providerProxyContext)
    {
        var adapter = factory.CreateAdapter(model, providerProxyContext);

        if (adapter == null)
        {
            logger.LogError("Unable to find import object adapter for type '{Type}'", model.GetType());

            return Task.FromResult(new ImportResult
            {
                Success = false,
                Exception = new InvalidOperationException($"Unable to find import object adapter for type '{model.GetType()}'")
            });
        }

        var modelValidationResults = new List<ValidationResult>();
        if (!ValidationService.Instance.TryValidateModel(model, ref modelValidationResults))
        {
            return Task.FromResult(new ImportResult
            {
                Success = false,
                ModelValidationResults = modelValidationResults
            });
        }

        BaseInfo? adapted = null;
        try
        {
            adapted = adapter.Adapt(model);
        }
        catch(Exception ex)
        {
            logger.LogError(ex, "Model adaptation to InfoObject failed");
            return Task.FromResult(new ImportResult
            {
                Exception = ex,
                Success = false,
                Imported = adapted
            });
        }

        try
        {
            adapter.ProviderProxy.Save(adapted, model);
            return Task.FromResult(new ImportResult
            {
                Success = true,
                Imported = adapted,
                PrimaryKey = adapted.GetIntegerValue(adapted.TypeInfo.IDColumn, 0)
            });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Entity persistence failed");
            return Task.FromResult(new ImportResult
            {
                Exception = ex,
                Success = false
            });
        }
    }
}
