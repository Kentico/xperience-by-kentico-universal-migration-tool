namespace Kentico.Xperience.UMT.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class UniqueKeyPartAttribute: System.Attribute
{
    public string? KeyName { get; }
    public Type? ReferencedInfoType { get; }

    public UniqueKeyPartAttribute(string? keyName = null, Type? referencedInfoType = null)
    {
        KeyName = keyName;
        ReferencedInfoType = referencedInfoType;
    }
}
