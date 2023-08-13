using Kentico.Xperience.UMT.Services;
using Microsoft.CodeAnalysis;

namespace Kentico.Xperience.UMT.Templates;

public record ClassViewModel(INamedTypeSymbol ClassSymbol, List<IPropertySymbol> Properties, List<IMethodSymbol> Methods, List<INamedTypeSymbol> Delegates, List<IEventSymbol> Events);
public record ClassDocsViewModel(IImportService ImportService, ClassViewModel ClassViewModel);