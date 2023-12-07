using System.Text.Json;
using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Services;

/// <summary>
/// Main universal migration toolkit entry point. Import service handles input of UMT model and performs persistence actions, behaves as proxy between Kentico API and UMT consumer
/// </summary>
public interface IImportService
{
    /// <summary>
    /// Serializes umt model to JSON
    /// </summary>
    /// <param name="model"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    string SerializeToJson(UmtModel model, JsonSerializerOptions? options = null);

    /// <summary>
    /// Serializes umt model to JSON
    /// </summary>
    /// <param name="model"></param>
    /// <param name="options"></param>
    string SerializeToJson(IEnumerable<UmtModel> model, JsonSerializerOptions? options = null);
    
    /// <summary>
    /// Reads json from stream and returns enumerable of UmtModel
    /// </summary>
    /// <param name="jsonStream">Stream of data, content must be valid JSON array of UMT model</param>
    /// <returns>UMT model enumerable</returns>
    IAsyncEnumerable<UmtModel?> FromJsonStream(Stream jsonStream);

    /// <summary>
    /// Reads model from json string and returns enumerable of UmtModel
    /// </summary>
    /// <param name="jsonString">String that contains valid JSON UMT model</param>
    /// <returns>UMT model enumerable</returns>
    IEnumerable<IUmtModel>? FromJsonString(string jsonString);

    /// <summary>
    /// Starts import
    /// </summary>
    /// <param name="importedObjects">UMT model, imported objects</param>
    /// <param name="importObserver">Import state observer, stores current information about import with events</param>
    /// <returns>Task, that will return object that represents import state</returns>
    ImportStateObserver StartImport(IEnumerable<IUmtModel> importedObjects, ImportStateObserver? importObserver = null);

    /// <summary>
    /// Starts import
    /// </summary>
    /// <param name="importedObjects">UMT model, imported objects</param>
    /// <param name="importObserver">Import state observer, stores current information about import with events</param>
    /// <returns>Task, that will return object that represents import state</returns>
    Task<ImportStateObserver> StartImportAsync(IAsyncEnumerable<IUmtModel> importedObjects, ImportStateObserver? importObserver = null);
}
