using System.Text;

namespace Kentico.Xperience.UMT.DocUtils.Templates;

public record DocRef(string? Uri, string? Header, string Text)
{
    public string ToMarkdownLink()
    {
        if (!string.IsNullOrWhiteSpace(Header) || !string.IsNullOrWhiteSpace(Uri))
        {
            var sb = new StringBuilder();

            sb.Append($"[{Text}]");

            string? uri = "";
            if (!string.IsNullOrWhiteSpace(Uri))
            {
                uri += $"{Uri}.md";
            }

            if (!string.IsNullOrWhiteSpace(Header))
            {
                uri += $"#{Header}";
            }

            sb.Append($"({uri})");
            return sb.ToString();
        }

        return Text;
    }
};
