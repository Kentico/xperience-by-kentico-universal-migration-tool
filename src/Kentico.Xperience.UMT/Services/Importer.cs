using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
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

internal class Importer : IImporter
{
    private readonly ILogger<Importer> logger;
    private readonly AdapterFactory adapterFactory;

    public Importer(ILogger<Importer> logger, AdapterFactory adapterFactory)
    { 
        this.logger = logger;
        this.adapterFactory = adapterFactory;
    }

    public async Task<IImportResult> ImportAsync(IUmtModel umtModel)
    {
        var providerProxyContext = new ProviderProxyContext();
        
        try
        {
            var importResult = await ImportObject(umtModel, providerProxyContext);
            return importResult;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occured");

            return new ImportResult()
            {
                Success = false,
                Exception = ex
            };
        }
    }

    public void Dispose()
    {

    }

    private async Task<ImportResult> ImportObject(IUmtModel model, ProviderProxyContext providerProxyContext)
    {
        var adapter = adapterFactory.CreateAdapter(model, providerProxyContext);

        if (adapter == null)
        {
            logger.LogError("Unable to find import object adapter for type '{Type}'", model.GetType());

            return new ImportResult()
            {
                Success = false,
                Exception = new InvalidOperationException($"Unable to find import object adapter for type '{model.GetType()}'")
            };
        }

        var modelValidationResults = new List<ValidationResult>();
        if (!ValidationService.Instance.TryValidateModel(model, ref modelValidationResults))
        {
            return new ImportResult()
            {
                Success = false,
                ModelValidationResults = modelValidationResults
            };
        }

        BaseInfo? adapted = null;
        try
        {
            adapted = adapter.Adapt(model);
        }
        catch(Exception ex)
        {
            logger.LogError(ex, "Model adaptation to InfoObject failed");
            return new ImportResult()
            {
                Exception = ex,
                Success = false,
                Imported = adapted
            };
        }

        try
        {
            adapter.ProviderProxy.Save(adapted);
            return new ImportResult()
            {
                Success = true,
                Imported = adapted,
                PrimaryKey = adapted.GetIntegerValue(adapted.TypeInfo.IDColumn, 0)
            };
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Entity persistance failed");
            return new ImportResult()
            {
                Exception = ex,
                Success = false
            };
        }
    }
}
