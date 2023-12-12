namespace Kentico.Xperience.UMT.Examples;

public class SampleAttribute: Attribute
{
    public string SampleName { get; }
    public string Description { get; }
    public string Header { get; }

    public SampleAttribute(string sampleName, string description, string header)
    {
        SampleName = sampleName;
        Description = description;
        Header = header;
    }
}
