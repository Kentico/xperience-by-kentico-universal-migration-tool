using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Kentico.Xperience.UMT.DocUtils.Walkers;

public class UmtModelWalker : CSharpSyntaxWalker
{
    private readonly List<SyntaxNode> umtModelClasses = new();
    public List<SyntaxNode> UmtModelClasses => umtModelClasses;

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        if (node.AttributeLists.Any(attributeListSyntax => attributeListSyntax.Attributes.Any(attributeSyntax => attributeSyntax.Name.ToString() == "UmtModel")))
        {
            umtModelClasses.Add(node);
            return;
        }

        base.VisitClassDeclaration(node);
    }
}
