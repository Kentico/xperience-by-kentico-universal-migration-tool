namespace Kentico.Xperience.UMT.Attributes;

/// <summary>
/// /// Defines relation to other entity with specification of key
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ReferencePropertyAttribute : Attribute, IReferenceProperty
{
    // do not rename constructor arguments, they are referenced by name in docs generator

    /// <param name="infoType">Referenced abstract info type from XbyK API</param>
    /// <param name="referencedPropertyName">Referenced property name from abstract infoType</param>
    /// <param name="referenceKind">Defined if reference is ObjectGuid or ObjectCodeName</param>
    public ReferencePropertyAttribute(Type infoType, string referencedPropertyName, ReferenceKind referenceKind = ReferenceKind.UniqueId)
    {
        InfoType = infoType;
        ReferencedPropertyName = referencedPropertyName;
        ReferenceKind = referenceKind;
        IsRequired = false;
    }

    public Type InfoType { get; }
    public string ReferencedPropertyName { get; }
    public ReferenceKind ReferenceKind { get; }

    /// <summary>
    /// If reference is required, exception will be thrown at runtime when not specified in data 
    /// </summary>
    public bool IsRequired { get; set; }

    public string? SearchedField { get; set; }
    
    public string? ValueField { get; init; }
}
