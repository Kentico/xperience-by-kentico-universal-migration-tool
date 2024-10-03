using System.Xml.Linq;

using Microsoft.CodeAnalysis;

namespace Kentico.Xperience.UMT.DocUtils.Walkers;

public static class Extensions
{
    public static XDocument? GetDocumentationXml(this ISymbol symbol)
    {
        if (symbol.GetDocumentationCommentXml() is { } documentationCommentXml && !string.IsNullOrWhiteSpace(documentationCommentXml))
        {
            return XDocument.Parse(documentationCommentXml);
        }

        return null;
    }

    public delegate bool BaseTypePredicate(INamedTypeSymbol symbol);

    public static INamedTypeSymbol? GetFirstBaseType(this INamedTypeSymbol symbol, BaseTypePredicate predicate)
    {
        var baseType = symbol.BaseType;
        while (baseType != null)
        {
            if (predicate(baseType))
            {
                return baseType;
            }
            baseType = baseType.BaseType;
        }
        return null;
    }

    public static INamedTypeSymbol? GetFirstBaseTypeOrSelf(this INamedTypeSymbol symbol, BaseTypePredicate predicate) =>
        predicate(symbol)
            ? symbol
            : GetFirstBaseType(symbol, predicate);


    public static bool IsAccessibleOutsideOfAssembly(this ISymbol symbol) =>
        symbol.DeclaredAccessibility switch
        {
            Accessibility.Private => false,
            Accessibility.Internal => false,
            Accessibility.ProtectedAndInternal => false,
            Accessibility.Protected => true,
            Accessibility.ProtectedOrInternal => true,
            Accessibility.Public => true,
            _ => true, //Here should be some reasonable default
        };
}
