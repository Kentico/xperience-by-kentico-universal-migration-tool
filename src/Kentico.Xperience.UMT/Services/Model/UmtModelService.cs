using System.Collections.Immutable;
using System.Reflection;
using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Services.Model;

/// <summary>
/// Model info discovered at runtime
/// </summary>
public class UmtModelInfo
{
    public UmtModelInfo(List<UmtReferencePropertyInfo> referenceProperties, PropertyInfo? objectGuidProperty, Type modelType, List<UniqueKeyPartInfo> uniqueKeyParts)
    {
        ReferenceProperties = referenceProperties;
        ObjectGuidProperty = objectGuidProperty;
        ModelType = modelType;
        UniqueKeyParts = uniqueKeyParts;
    }

    public Type ModelType { get; set; }
    public List<UmtReferencePropertyInfo> ReferenceProperties { get; init; }
    public PropertyInfo? ObjectGuidProperty { get; set; }
    public List<UniqueKeyPartInfo> UniqueKeyParts { get; set; }
    public string? ModelDiscriminator { get; set; }
}

/// <summary>
/// Info about property in UMT model
/// </summary>
public class UmtReferencePropertyInfo
{
    public UmtReferencePropertyInfo(Type referencedInfoType, PropertyInfo property)
    {
        ReferencedInfoType = referencedInfoType;
        Property = property;
    }

    public PropertyInfo Property { get; set; }
    public string? ReferencedPropertyName { get; set; }
    public Type ReferencedInfoType { get; set; }
    public bool IsRequired { get; init; }
    public string? SearchedField { get; init; }
    public string? ValueField { get; set; }
}

public record UniqueKeyPartInfo(string KeyName, PropertyInfo PropertyInfo, Type? ReferencedInfoType = null);


/// <summary>
/// Service handling reflection of models
/// </summary>
public class UmtModelService
{
    private readonly Assembly[] discoveredAssemblies;
    private readonly ImmutableDictionary<Type, UmtModelInfo> modelInfos;

    public UmtModelService(Assembly[] discoveredAssemblies)
    {
        this.discoveredAssemblies = discoveredAssemblies;
        modelInfos = InitModelInfo().ToImmutableDictionary(x => x.ModelType, x => x);
    }
    
    public IEnumerable<UmtModelInfo> InitModelInfo()
    {
        foreach (var discoveredAssembly in discoveredAssemblies)
        {
            foreach (var umtModelType in discoveredAssembly.GetTypes().Where(x=> x.GetCustomAttribute<UmtModelAttribute>() != null))
            {
                var umtModelAttribute = umtModelType.GetCustomAttribute<UmtModelAttribute>();

                var referenceProperties = new List<UmtReferencePropertyInfo>();
                PropertyInfo? objectGuidProperty = null;
                var keyParts = new List<UniqueKeyPartInfo>();
                foreach (var propertyInfo in Reflect.Type(umtModelType).PublicProperties)
                {
                    var referenceProperty = propertyInfo.GetCustomAttribute<ReferencePropertyAttribute>();
                    if (referenceProperty != null)
                    {
                        referenceProperties.Add(new UmtReferencePropertyInfo(referenceProperty.InfoType, propertyInfo)
                        {
                            ReferencedPropertyName = referenceProperty.ReferencedPropertyName,
                            SearchedField = referenceProperty.SearchedField,
                            ValueField = referenceProperty.ValueField,
                            IsRequired = referenceProperty.IsRequired
                        });
                    }

                    var uniqueIdProperty = propertyInfo.GetCustomAttribute<UniqueIdPropertyAttribute>();
                    if (uniqueIdProperty != null)
                    {
                        if (objectGuidProperty != null)
                        {
                            throw new InvalidOperationException("Model cannot have multiple unique id columns");
                        }
                        objectGuidProperty = propertyInfo;
                    }

                    var uniqueKeyPartProperty = propertyInfo.GetCustomAttribute<UniqueKeyPartAttribute>();
                    if (uniqueKeyPartProperty != null)
                    {
                        keyParts.Add(new UniqueKeyPartInfo(uniqueKeyPartProperty.KeyName ?? propertyInfo.Name, propertyInfo, uniqueKeyPartProperty.ReferencedInfoType));
                    }   
                }

                if (keyParts is { Count: 0 } && objectGuidProperty == null)
                {
                    throw new InvalidOperationException("Object guid is required for object model");
                }
                
                var modelInfo = new UmtModelInfo(referenceProperties, objectGuidProperty, umtModelType, keyParts)
                {
                    ModelType = umtModelType,
                    ModelDiscriminator = umtModelAttribute?.Discriminator ?? throw new InvalidOperationException("Invalid model attribute - discriminator must be specified non empty, non null"),
                };

                yield return modelInfo;
            }
        }
    }

    public bool TryGetModelInfo(Type modelType, out UmtModelInfo? info) => modelInfos.TryGetValue(modelType, out info);

    public ImmutableList<UmtModelInfo> GetAll() => modelInfos.Values.ToImmutableList();
} 
