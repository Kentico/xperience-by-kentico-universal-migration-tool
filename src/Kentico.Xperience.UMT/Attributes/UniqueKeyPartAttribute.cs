namespace Kentico.Xperience.UMT.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class UniqueKeyPartAttribute(string? keyName = null, Type? referencedInfoType = null) : Attribute
{
    public string? KeyName { get; } = keyName;
    public Type? ReferencedInfoType { get; } = referencedInfoType;
}
