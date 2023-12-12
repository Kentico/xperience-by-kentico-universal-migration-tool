using Microsoft.CodeAnalysis;

namespace Kentico.Xperience.UMT.DocUtils.Templates;

public record FormComponent(INamedTypeSymbol ClassName, string? Identifier, ITypeSymbol? ValueType, ITypeSymbol? Properties);
public record FormComponentTemplateModel(IModuleSymbol Module, FormComponent[] Components);