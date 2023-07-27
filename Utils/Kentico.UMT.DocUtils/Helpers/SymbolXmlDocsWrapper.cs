using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;
using Kentico.Xperience.UMT.Walkers;
using Microsoft.CodeAnalysis;

namespace Kentico.Xperience.UMT.Helpers;

public interface ISymbolXmlDocsWrapper
{
    bool TryGetSummary(out string summary);
    string? GetSummaryOrEmpty();
    string? GetReturnsOrEmpty();
    string? GetParamSummaryOrEmpty(IParameterSymbol symbol);
}

public class SymbolXmlDocsWrapper : ISymbolXmlDocsWrapper
{
    private readonly ISymbol symbol;
    public XDocument? DocsXml { get; set; }

    public SymbolXmlDocsWrapper(ISymbol symbol)
    {
        this.symbol = symbol;
        DocsXml = symbol.GetDocumentationXml();
    }

    public bool TryGetSummary(out string summary)
    {
        summary = DocsXml?.XPathSelectElement("//summary")?.Value?.Trim() ?? "";
        return string.IsNullOrWhiteSpace(summary);
    }
    
    public string? GetSummaryOrEmpty() => DocsXml?.XPathSelectElement("//summary")?.Value?.Trim() ?? "";

    public string? GetReturnsOrEmpty() => DocsXml?.XPathSelectElement("//returns")?.Value?.Trim() ?? "";

    public string? GetParamSummaryOrEmpty(IParameterSymbol symbol) => DocsXml?.XPathSelectElement($"//param[@name=\"{symbol.Name}\"]")?.Value?.Trim() ?? "";
}


public class SymbolXmlDocsWrapperMarkdown:ISymbolXmlDocsWrapper
{
    private readonly ISymbolXmlDocsWrapper inner;

    public SymbolXmlDocsWrapperMarkdown(ISymbolXmlDocsWrapper inner) => this.inner = inner;

    public bool TryGetSummary(out string summary)
    {
        bool success = inner.TryGetSummary(out summary);
        summary = ApplyFormattingPipeline(summary)!;
        return success;
    }

    public string? GetSummaryOrEmpty() => ApplyFormattingPipeline(inner.GetSummaryOrEmpty());

    public string? GetReturnsOrEmpty() => ApplyFormattingPipeline(inner.GetReturnsOrEmpty());

    public string? GetParamSummaryOrEmpty(IParameterSymbol symbol) => ApplyFormattingPipeline(inner.GetParamSummaryOrEmpty(symbol));

    private string? ApplyFormattingPipeline(string? input) => HandleNewlines(input);

    private string? HandleNewlines(string? input) => input != null ? Regex.Replace(input, "([\r\n]{1,2})", "<br/>") : null;
}
