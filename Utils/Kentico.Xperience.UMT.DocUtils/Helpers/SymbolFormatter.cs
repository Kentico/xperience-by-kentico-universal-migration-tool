using Microsoft.CodeAnalysis;

namespace Kentico.Xperience.UMT.Helpers;

public class SymbolFormatter
{
    private readonly ISymbol symbol;

    public SymbolFormatter(ISymbol symbol) => this.symbol = symbol;

    public string ToNiceDisplayName()
    {
        switch (symbol)
        {
            case INamedTypeSymbol namedTypeSymbol:
            {
                switch (namedTypeSymbol.ConstructedFrom?.MetadataName)
                {
                    case "Collection`1":
                    case "ICollection`1":
                    case "List`1":
                    case "IList`1":
                    case "IEnumerable`1":
                    {
                        return $"{new SymbolFormatter(namedTypeSymbol.TypeArguments[0]).ToNiceDisplayName()}[]";
                    }
                }

                return namedTypeSymbol.ToDisplayString();
            }
            default:
            {
                return symbol.ToDisplayString();
            }
        }
    }
}
