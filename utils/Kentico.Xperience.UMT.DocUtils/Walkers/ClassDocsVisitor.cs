using Microsoft.CodeAnalysis;

namespace Kentico.Xperience.UMT.DocUtils.Walkers;

public class ClassDocsVisitor : SymbolVisitor
{
    public override void Visit(ISymbol? symbol)
    {
        Class = symbol is INamedTypeSymbol type ? type : throw new InvalidOperationException("Visitor supports only NamedTypeSymbol");
        base.Visit(symbol);
    }

    public List<IPropertySymbol> Properties { get; } = [];
    public List<IMethodSymbol> Methods { get; } = [];
    public List<INamedTypeSymbol> Delegates { get; } = [];
    public List<IEventSymbol> Events { get; } = [];
    public INamedTypeSymbol Class { get; private set; } = null!;

    public override void VisitNamedType(INamedTypeSymbol symbol)
    {
        switch (symbol.TypeKind)
        {
            case TypeKind.Unknown:
                break;
            case TypeKind.Array:
                break;
            case TypeKind.Class:
                if (!Class.Equals(symbol, SymbolEqualityComparer.Default))
                {
                    return;
                }

                break;
            case TypeKind.Delegate:
                Console.WriteLine($"    Delegate: {symbol.Name}");
                Delegates.Add(symbol);
                return;
            case TypeKind.Dynamic:
                break;
            case TypeKind.Enum:
                break;
            case TypeKind.Error:
                break;
            case TypeKind.Interface:
                break;
            case TypeKind.Module:
                break;
            case TypeKind.Pointer:
                break;
            case TypeKind.Struct:
                break;
            case TypeKind.TypeParameter:
                break;
            case TypeKind.Submission:
                break;
            case TypeKind.FunctionPointer:
                break;
            default:
                throw new ArgumentOutOfRangeException($"Unknown symbol type kind '{symbol.TypeKind}'");
        }

        foreach (var member in symbol.GetMembers())
        {
            if (member.DeclaredAccessibility == Accessibility.Public)
            {
                Console.WriteLine($"    Public member: {member.Name}");
                member.Accept(this);
            }
        }
    }

    public override void VisitProperty(IPropertySymbol symbol)
    {
        Console.WriteLine($"      Property: {symbol.Name}");
        Properties.Add(symbol);
        base.VisitProperty(symbol);
    }

    public override void VisitMethod(IMethodSymbol symbol)
    {
        if (symbol.MethodKind == MethodKind.Ordinary)
        {
            Console.WriteLine($"      Method: {symbol.Name}");
            Methods.Add(symbol);
        }
        base.VisitMethod(symbol);
    }

    public override void VisitEvent(IEventSymbol symbol)
    {
        Console.WriteLine($"      Event: {symbol.Name}");
        Events.Add(symbol);
        base.VisitEvent(symbol);
    }
}
