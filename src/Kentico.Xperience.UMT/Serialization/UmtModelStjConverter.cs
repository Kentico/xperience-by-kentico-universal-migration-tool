﻿using System.Text.Json;

using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.Services.Model;

namespace Kentico.Xperience.UMT.Serialization;

/// <summary>
/// UMT model convertor for System.Text.Json 
/// </summary>
public class UmtModelStjConverter(IReadOnlyList<UmtModelInfo?> models) : System.Text.Json.Serialization.JsonConverter<UmtModel>
{
    public const string DISCRIMINATOR_PROPERTY = "$type";

    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(UmtModel) || models.Any(m => m?.ModelType == typeToConvert);

    public override UmtModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var readerClone = reader;

        if (readerClone.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        readerClone.Read();
        if (readerClone.TokenType != JsonTokenType.PropertyName)
        {
            throw new JsonException();
        }

        string? propertyName = readerClone.GetString();
        if (propertyName != DISCRIMINATOR_PROPERTY)
        {
            throw new JsonException();
        }

        readerClone.Read();
        if (readerClone.TokenType != JsonTokenType.String)
        {
            throw new JsonException();
        }

        string? discriminator = readerClone.GetString();
        var modelInfo = models.FirstOrDefault(m => m?.ModelDiscriminator == discriminator) ?? throw new InvalidOperationException($"Invalid model");

        var clonedOptions = new JsonSerializerOptions(options);
        if (clonedOptions.Converters.FirstOrDefault(x => x is UmtModelStjConverter) is { } converter)
        {
            clonedOptions.Converters.Remove(converter);
        }

        return JsonSerializer.Deserialize(ref reader, modelInfo.ModelType, clonedOptions)! as UmtModel;
    }

    public override void Write(Utf8JsonWriter writer, UmtModel value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        var modelInfo = models.FirstOrDefault(m => m?.ModelType == value.GetType()) ?? throw new InvalidOperationException($"Invalid model");
        writer.WriteString(DISCRIMINATOR_PROPERTY, modelInfo.ModelDiscriminator);

        var clonedOptions = new JsonSerializerOptions(options);
        if (clonedOptions.Converters.FirstOrDefault(x => x is UmtModelStjConverter) is { } converter)
        {
            clonedOptions.Converters.Remove(converter);
        }

        var doc = JsonSerializer.SerializeToDocument(value, modelInfo.ModelType, clonedOptions);
        foreach (var jsonProperty in doc.RootElement.EnumerateObject())
        {
            jsonProperty.WriteTo(writer);
        }

        writer.WriteEndObject();
    }
}
