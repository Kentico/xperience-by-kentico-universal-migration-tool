namespace Kentico.Xperience.UMT.Attributes;


public interface IReferenceProperty
{
    Type InfoType { get; }
    string ReferencedPropertyName { get; } 
}