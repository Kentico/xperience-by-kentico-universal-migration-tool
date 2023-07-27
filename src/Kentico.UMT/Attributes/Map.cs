namespace Kentico.Xperience.UMT.Attributes;

public class MapAttribute: Attribute
{
    
}

public class MapToAttribute: Attribute
{
    public string PropertyName { get; }

    public MapToAttribute(string propertyName) => PropertyName = propertyName;
}