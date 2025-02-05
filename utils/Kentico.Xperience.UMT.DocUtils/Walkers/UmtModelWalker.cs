using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Kentico.Xperience.UMT.DocUtils.Walkers;

public class UmtModelWalker : CSharpSyntaxWalker
{
    public List<SyntaxNode> UmtModelClasses { get; } = [];

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        if (node.AttributeLists.Any(attributeListSyntax => attributeListSyntax.Attributes.Any(attributeSyntax => attributeSyntax.Name.ToString() == "UmtModel")))
        {
            UmtModelClasses.Add(node);
            return;
        }

        base.VisitClassDeclaration(node);
    }
}
