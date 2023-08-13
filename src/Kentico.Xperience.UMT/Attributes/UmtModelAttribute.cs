namespace Kentico.Xperience.UMT.Attributes;

public class UmtModelAttribute: Attribute
{
    public string Discriminator { get; }

    public UmtModelAttribute(string discriminator) => Discriminator = discriminator;
}