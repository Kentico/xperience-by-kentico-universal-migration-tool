namespace Kentico.Xperience.UMT.Examples;

[AttributeUsage(AttributeTargets.Property)]
public class SampleAttribute(string sampleName, string description, string header) : Attribute
{
    public string SampleName { get; } = sampleName;
    public string Description { get; } = description;
    public string Header { get; } = header;
}
