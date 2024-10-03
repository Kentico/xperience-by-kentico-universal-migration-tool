using Kentico.Xperience.UMT.Examples;

using Microsoft.CodeAnalysis;

namespace Kentico.Xperience.UMT.DocUtils.Templates;

public record ValidationInfo(bool IsRequired);
public record ModelProperty(string Name, string Summary, string Type, ModelPropertyReference? Reference, bool IsUniqueId, ValidationInfo ValidationInfo);
public record ModelClass(ITypeSymbol Symbol, string Name, string Summary, List<ModelProperty> Properties, List<SerializedSampleInfo> Samples, string? Discriminator = null);

public record ModelPropertyReference(INamedTypeSymbol InfoType, string ReferencedPropertyName, bool IsRequired, string? SearchField, string? SearchValue);
