using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.Services.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kentico.Xperience.UMT.Serialization;

/// <summary>
/// UMT model convertor for Newtonsoft.Json
/// </summary>
public class UmtModelJsonConverter: JsonConverter
{
    private readonly IReadOnlyList<UmtModelInfo> models;

    public UmtModelJsonConverter(IReadOnlyList<UmtModelInfo> models) => this.models = models;

    private const string DiscriminatorProperty = "$type";
    
    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer) {
        var item = JObject.Load(reader);
        string? modelDiscriminator = item[DiscriminatorProperty]?.Value<string>();
        var modelInfo = models.FirstOrDefault(m => m?.ModelDiscriminator == modelDiscriminator);
        if (modelInfo == null)
        {
            throw new InvalidOperationException($"Invalid model");
        }
        
        return item.ToObject(modelInfo.ModelType);
    }

    public override void WriteJson (JsonWriter writer, object? value, JsonSerializer serializer) {
        if (value != null)
        {
            var o = JObject.FromObject(value);

            var modelInfo = models.FirstOrDefault(m => m.ModelType == value.GetType());
            if (modelInfo == null)
            {
                throw new InvalidOperationException($"Invalid model");
            }
        
            o.AddFirst(new JProperty(DiscriminatorProperty, new JValue(modelInfo.ModelDiscriminator)));
            o.WriteTo(writer);
        }
    }

    public override bool CanConvert (Type objectType) => objectType == typeof(UmtModel) || models.Any(m => m.ModelType == objectType);
}
