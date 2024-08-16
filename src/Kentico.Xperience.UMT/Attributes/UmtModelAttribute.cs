namespace Kentico.Xperience.UMT.Attributes;

public class UmtModelAttribute(string discriminator) : Attribute
{
    public string Discriminator { get; } = discriminator;
}
