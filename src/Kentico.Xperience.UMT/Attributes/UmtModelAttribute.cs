namespace Kentico.Xperience.UMT.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class UmtModelAttribute(string discriminator) : Attribute
{
    public string Discriminator { get; } = discriminator;
}
