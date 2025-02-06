namespace Kentico.Xperience.UMT.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class MapAttribute : Attribute
{

}

[AttributeUsage(AttributeTargets.Property)]
public class MapToAttribute(string propertyName) : Attribute
{
    public string PropertyName { get; } = propertyName;
}
