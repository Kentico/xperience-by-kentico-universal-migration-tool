using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using CMS.DataEngine;

using Kentico.Xperience.UMT.Attributes;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Serialization;
using Kentico.Xperience.UMT.Services.Model;
using Microsoft.Extensions.Logging;

[assembly: InternalsVisibleTo("Kentico.Xperience.UMT.Tests.X")]

namespace Kentico.Xperience.UMT.InfoAdapter;

internal interface IInfoAdapter<in TModel> where TModel : IUmtModel
{
    BaseInfo Adapt(TModel input);
    
    IProviderProxy ProviderProxy { get; }
    Guid? GetUniqueIdOrNull(TModel input);
}

internal interface IInfoAdapter<out TInfo, in TModel> : IInfoAdapter<TModel> where TInfo : AbstractInfoBase<TInfo>, new() where TModel : IUmtModel
{
    new TInfo Adapt(TModel input);
    new Guid? GetUniqueIdOrNull(TModel input);
}

public class GenericInfoAdapter<TTargetInfo> : IInfoAdapter<TTargetInfo, IUmtModel> where TTargetInfo : AbstractInfoBase<TTargetInfo>, new()
{
    protected readonly ILogger<GenericInfoAdapter<TTargetInfo>> Logger;
    private readonly UmtModelService modelService;
    private readonly IProviderProxyFactory providerProxyFactory;

    public IProviderProxy ProviderProxy { get; }

    internal GenericInfoAdapter(ILogger<GenericInfoAdapter<TTargetInfo>> logger, UmtModelService modelService, IProviderProxy providerProxy, IProviderProxyFactory providerProxyFactory)
    {
        Logger = logger;
        this.modelService = modelService;
        this.providerProxyFactory = providerProxyFactory;
        ProviderProxy = providerProxy;
    }

    protected virtual TTargetInfo ObjectFactory(UmtModelInfo umtModelInfo, IUmtModel umtModel) => new();

    protected virtual TTargetInfo MapProperties(IUmtModel umtModel, TTargetInfo current)
    {
        var inputReflected = Reflect.Type(umtModel.GetType());
        foreach (var property in inputReflected.PublicProperties)
        {
            if (property.GetCustomAttribute<MapAttribute>() is { })
            {
                if (current.ColumnNames.Contains(property.Name))
                {
                    object? value = property.GetValue(umtModel);
                    SetValue(current, property.Name, value);
                    Logger.LogTrace("[{ColumnName}]={Value}", property.Name, value);
                }
                else
                {
                    Logger.LogError("Info doesn't contain column with name '{ColumnName}' - MapAttribute is on invalid property, property SHALL have same name as column in target Info object", property.Name);
                    throw new InvalidOperationException($"Info doesn't contain column with name '{property.Name}' - MapAttribute is on invalid property, property SHALL have same name as column in target Info object");
                }
            }

            if (property.GetCustomAttribute<MapToAttribute>() is { PropertyName: not null } mapTo)
            {
                if (current.ColumnNames.Contains(mapTo.PropertyName))
                {
                    object? value = property.GetValue(umtModel);
                    SetValue(current, mapTo.PropertyName, value);
                    Logger.LogTrace("[{ColumnName}]={Value}", mapTo.PropertyName, value);
                }
                else
                {
                    Logger.LogError("Info doesn't contain column with name '{ColumnName}' - MapToAttribute has invalid PropertyName argument, property SHALL have same name as column in target Info object", property.Name);
                    throw new InvalidOperationException($"Info doesn't contain column with name '{property.Name}' - MapToAttribute has invalid PropertyName argument, property SHALL have same name as column in target Info object");
                }
            }
        }

        return current;
    }

    protected virtual void SetValue(TTargetInfo current, string propertyName, object? value)
    {
        Debug.Assert(current.ColumnNames.Contains(propertyName), "current.ColumnNames.Contains(propertyName)");
        if (Reflect<TTargetInfo>.TrySetProperty(current, propertyName, value))
        {
            // OK
            Logger.LogTrace("Setting property '{PropertyName}' of type '{Type}' to value: {Value}", propertyName, Reflect<TTargetInfo>.Current.FullName, value);
        }
        else
        {
            Logger.LogError("Object of type '{Type}' doesn't contain property '{PropertyName}' => unable to set value", current.GetType().FullName, propertyName);
        }
    }

    protected virtual string GetGuidColumnName(BaseInfo info) => info.TypeInfo.GUIDColumn;

    public virtual TTargetInfo Adapt(IUmtModel input)
    {
        if (!modelService.TryGetModelInfo(input.GetType(), out var model) || model == null)
        {
            Logger.LogError("Model info for type {Type} not found => unsupported model", input.GetType().FullName);
            throw new InvalidOperationException($"Model info for type {input.GetType().FullName} not found => unsupported model");
        }

        TTargetInfo? current;

        if (model.ObjectGuidProperty is { } objectGuidProperty && objectGuidProperty.GetValue(input) is Guid objectGuid)
        {
            var existing = ProviderProxy.GetBaseInfoByGuid(objectGuid, input);

            if (existing != null)
            {
                if (existing is TTargetInfo @base)
                {
                    Logger.LogTrace("Info {Guid} exists", objectGuid);
                    current = @base;
                }
                else
                {
                    Logger.LogError("Returned object of type '{ReturnedType}' is not assignable to wanted type '{WantedType}'", existing.GetType().FullName, typeof(TTargetInfo).FullName);
                    throw new InvalidOperationException($"Returned object of type '{existing.GetType().FullName}' is not assignable to wanted type '{typeof(TTargetInfo).FullName}'");
                }
            }
            else
            {
                current = ObjectFactory(model, input);
                current.SetValue(GetGuidColumnName(current), objectGuid);
                Logger.LogTrace("Info {Guid} created", objectGuid);
            }
        } 
        else if (model.UniqueKeyParts is { Count: > 0 } keyParts)
        {
            var filters = new List<(string columnName, object? value)>();
            foreach ((string keyName, var propertyInfo, var referencedInfoType) in keyParts)
            {
                object? value = propertyInfo.GetValue(input);
                if (referencedInfoType != null && value is Guid uniqueId)
                {
                    var refObject = providerProxyFactory
                        .CreateProviderProxy(referencedInfoType, ProviderProxy.Context)
                        .GetBaseInfoByGuid(uniqueId, null!);
                    value = refObject?.GetValue(refObject.TypeInfo.IDColumn);
                }

                if (value is null)
                {
                    Logger.LogError("Property {Property} of type {Type} is required", propertyInfo.Name, propertyInfo.DeclaringType?.FullName);
                    throw new InvalidOperationException($"Property {propertyInfo.Name} of type {propertyInfo.DeclaringType?.FullName} is required");
                }
                
                filters.Add((keyName, value));
            }

            switch (ProviderProxy.GetInfoByKeys(input, filters))
            {
                case { Count: 0 }:
                {
                    current = ObjectFactory(model, input);
                    break;
                }
                case [TTargetInfo targetInfo]:
                {
                    current = targetInfo;
                    break;
                }
                default:// case { Count: > 1 }:
                {
                    Logger.LogError("Multiple results found for '{Model}', cannot continue we don't know which one to update", input.PrintMe());
                    throw new InvalidOperationException($"Multiple results found for '{input.PrintMe()}', cannot continue we don't know which one to update");
                }
            }
        }
        else
        {
            // no strategy for getting existing object
            current = ObjectFactory(model, input);
            Logger.LogTrace("Info created, no strategy used for selecting existing object");
        }

        // field mapping phase

        // map all foreign references to ensure they exist
        foreach (var referenceProperty in model.ReferenceProperties)
        {
            Logger.LogDebug("Mapping reference property '{RefProp}' from '{RefType}' ObjectId", referenceProperty.ReferencedPropertyName, referenceProperty.ReferencedInfoType.Name);

            object? refObject = referenceProperty.Property.GetValue(input);
            if (refObject is Guid foreignObjectGuid)
            {
                var providerProxy = providerProxyFactory.CreateProviderProxy(referenceProperty.ReferencedInfoType, ProviderProxy.Context);
                var foreign = referenceProperty.SearchedField == null
                    ? providerProxy.GetBaseInfoByGuid(foreignObjectGuid, input)
                    : providerProxy.GetBaseInfoBy(foreignObjectGuid, referenceProperty.SearchedField, input);

                if (foreign is not null)
                {
                    object? id = foreign[referenceProperty.ValueField ?? foreign.TypeInfo.IDColumn];
                    current.SetValue(referenceProperty.ReferencedPropertyName, id);
                    Logger.LogTrace("Dependency '{DepName}' set as ObjectId '{Id}'", referenceProperty.ReferencedPropertyName, id);
                }
                else if (referenceProperty.IsRequired)
                {
                    Logger.LogError("Missing required dependency - Object of type '{ReferencedInfoType}' with ObjectGUID '{ObjectGuid}' cannot be found", referenceProperty.ReferencedInfoType, foreignObjectGuid);
                    throw new InvalidOperationException($"Missing required dependency - Object of type '{referenceProperty.ReferencedInfoType}' with ObjectGUID '{foreignObjectGuid}' cannot be found");
                }
            }
            else if (referenceProperty.IsRequired)
            {
                Logger.LogError("Missing required dependency - '{PropName}' is not valid ObjectGUID", referenceProperty.Property.Name);
                throw new InvalidOperationException($"Missing required dependency - '{referenceProperty.Property.Name}' is not valid ObjectGUID");
            }
        }

        current = MapProperties(input, current);

        if (input.CustomProperties.Keys is { } customProperties)
        {
            foreach (string customProperty in customProperties)
            {
                if (customProperty == UmtModelStjConverter.DiscriminatorProperty)
                {
                    continue;
                }
                if (current.ColumnNames.Contains(customProperty))
                {
                    object? value = input.CustomProperties[customProperty];
                    if (value is JsonElement jsonElement)
                    {
                        
                        value = jsonElement.ToString();
                    }

                    current.SetValue(customProperty, value);
                    Logger.LogTrace("[{ColumnName}]={Value}", customProperty, value);
                }
                else
                {
                    Logger.LogError("Info doesn't contain column with name '{ColumnName}' - _CustomProperties has invalid key, key SHALL have same name as column in target Info object", customProperty);
                    throw new InvalidOperationException($"Info doesn't contain column with name '{customProperty}' - _CustomProperties has invalid key, key SHALL have same name as column in target Info object");
                }
            }
        }

        return current;
    }

    public Guid? GetUniqueIdOrNull(IUmtModel? input)
    {
        if (input == null)
        {
            return null;
        }
        if (!modelService.TryGetModelInfo(input.GetType(), out var model))
        {
            Logger.LogError("Model info for type {Type} not found => unsupported model", input.GetType().FullName);
            return null;
        }

        if (model?.ObjectGuidProperty is { } objectGuidProperty && objectGuidProperty.GetValue(input) is Guid objectGuid)
        {
            return objectGuid;
        }

        return null;
    }

    BaseInfo IInfoAdapter<IUmtModel>.Adapt(IUmtModel input) => Adapt(input);
}
