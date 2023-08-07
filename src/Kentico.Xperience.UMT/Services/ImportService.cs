using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using CMS.DataEngine;
using Kentico.Xperience.UMT.InfoAdapter;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Serialization;
using Kentico.Xperience.UMT.Services.Model;
using Kentico.Xperience.UMT.Services.Validation;
using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.Services;

/// <summary>
/// Import state object, contains information about import progress and  
/// </summary>
public sealed class ImportStateObserver
{
    /// <summary>
    /// Task completes when whole import processing ends, if not awaited undefined behavior may occur
    /// Property is set internally by IImportService when CreateImport is called
    /// </summary>
    public Task ImportCompletedTask { get; internal set; } = null!;

    /// <summary>
    /// Delegate specifies callback method for event ImportedInfo
    /// </summary>
    public delegate void ImportedInfoDelegate(BaseInfo info);
    
    /// <summary>
    /// Invoked when Kentico API Info object is successfully created
    /// </summary>
    public event ImportedInfoDelegate? ImportedInfo;

    /// <summary>
    /// Delegate specifies callback method for event ValidationError
    /// </summary>
    public delegate void ModelValidationError(UmtModel model, Guid? uniqueId, ICollection<ValidationResult> errors);
    /// <summary>
    /// Invoked when format of model is incorrect
    /// </summary>
    public event ModelValidationError? ValidationError;
    
    
    /// <summary>
    /// Delegate specifies callback method for event Exception
    /// </summary>
    public delegate void RaisedException(UmtModel relatedModel, Guid? uniqueId, Exception exception);
    /// <summary>
    /// Invoked when exception related to one model instance
    /// </summary>
    public event RaisedException? Exception;
    

    internal void OnImportedInfo(BaseInfo info) => ImportedInfo?.Invoke(info);

    internal void OnValidationError(UmtModel model, Guid? uniqueId, ICollection<ValidationResult> errors) => ValidationError?.Invoke(model, uniqueId, errors);

    internal void OnException(UmtModel relatedModel, Guid? uniqueId, Exception exception) => Exception?.Invoke(relatedModel, uniqueId, exception);
}



/// <inheritdoc />
internal class ImportService : IImportService
{
    private readonly ILogger<ImportService> logger;
    private readonly AdapterFactory adapterFactory;
    private readonly UmtModelService umtModelService;

    /// <summary>
    /// DI constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="adapterFactory"></param>
    /// <param name="umtModelService"></param>
    public ImportService(ILogger<ImportService> logger, AdapterFactory adapterFactory, UmtModelService umtModelService)
    {
        this.logger = logger;
        this.adapterFactory = adapterFactory;
        this.umtModelService = umtModelService;
    }

    /// <inheritdoc />
    public string SerializeToJson(UmtModel model, JsonSerializerOptions? options = null)
    {
        var converter = new UmtModelStjConverter(umtModelService.GetAll());
        options ??= new JsonSerializerOptions();
        options.Converters.Add(converter);
        return JsonSerializer.Serialize(model, options);
    }
    
    /// <inheritdoc />
    public string SerializeToJson(UmtModel[] model, JsonSerializerOptions? options = null)
    {
        var converter = new UmtModelStjConverter(umtModelService.GetAll());
        options ??= new JsonSerializerOptions();
        options.Converters.Add(converter);
        return JsonSerializer.Serialize(model, options);
    }

    /// <inheritdoc />
    public IAsyncEnumerable<UmtModel?> FromJsonStream(Stream jsonStream)
    {
        var converter = new UmtModelStjConverter(umtModelService.GetAll());
        return JsonSerializer.DeserializeAsyncEnumerable<UmtModel?>(jsonStream, new JsonSerializerOptions
        {
            Converters = { converter }
        });
    }

    /// <inheritdoc />
    public ImportStateObserver StartImport(IEnumerable<UmtModel> importedObjects, ImporterContext context, ImportStateObserver? importObserver = null)
    {
        var observer = importObserver ?? new ImportStateObserver();
        observer.ImportCompletedTask = Task.Run(() =>
        {
            var providerProxyContext = new ProviderProxyContext(context.SiteName, context.CultureCode);

            foreach (var importedObject in importedObjects)
            {
                ImportObject(importedObject, observer, providerProxyContext);
            }
        });

        return observer;
    }

    /// <inheritdoc />
    public Task<ImportStateObserver> StartImportAsync(IAsyncEnumerable<UmtModel> importedObjects, ImporterContext context, ImportStateObserver? importObserver = null)
    {
        var observer = importObserver ?? new ImportStateObserver();
        observer.ImportCompletedTask = Task.Run(async () =>
        {
            try
            {
                var providerProxyContext = new ProviderProxyContext(context.SiteName, context.CultureCode);
                var enumerator = importedObjects.GetAsyncEnumerator();
                while (await enumerator.MoveNextAsync())
                {
                    var current = enumerator.Current;

                    ImportObject(current, observer, providerProxyContext);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occured");
            }
        });

        return Task.FromResult(observer);
    }

    private void ImportObject(UmtModel model, ImportStateObserver observer, ProviderProxyContext providerProxyContext)
    {
        var adapter = adapterFactory.CreateAdapter(model, providerProxyContext);
        if (adapter == null)
        {
            observer.OnException(model, null, new InvalidOperationException($"Unable to find import object adapter for type '{model.GetType()}'"));
            logger.LogError("Unable to find import object adapter for type '{Type}'", model.GetType());
            return;
        }
        
        var modelValidationResults = new List<ValidationResult>();
        var uniqueId = adapter.GetUniqueIdOrNull(model);
        if (!ValidationService.Instance.TryValidateModel(model, ref modelValidationResults))
        {
            observer.OnValidationError(model, uniqueId, modelValidationResults);
            return;
        }

        BaseInfo? adapted;
        try
        {
            adapted = adapter.Adapt(model);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Model adaptation to InfoObject failed");
            observer.OnException(model, uniqueId, ex);
            return;
        }

        try
        {
            adapter.ProviderProxy.Save(adapted);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Entity persistence failed");
            observer.OnException(model, uniqueId, ex);
            return;
        }
        
        observer.OnImportedInfo(adapted);
    }
}
