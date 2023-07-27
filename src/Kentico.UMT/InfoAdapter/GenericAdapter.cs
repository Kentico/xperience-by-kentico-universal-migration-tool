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

internal class GenericInfoAdapter<TTargetInfo> : IInfoAdapter<TTargetInfo, IUmtModel> where TTargetInfo : AbstractInfoBase<TTargetInfo>, new()
{
    private readonly ILogger<GenericInfoAdapter<TTargetInfo>> logger;
    private readonly UmtModelService modelService;

    public IProviderProxy ProviderProxy { get; }

    internal GenericInfoAdapter(ILogger<GenericInfoAdapter<TTargetInfo>> logger, UmtModelService modelService, IProviderProxy providerProxy)
    {
        this.logger = logger;
        this.modelService = modelService;
        ProviderProxy = providerProxy;
    }

    public virtual TTargetInfo Adapt(IUmtModel input)
    {
        if (!modelService.TryGetModelInfo(input.GetType(), out var model) || model == null)
        {
            logger.LogError("Model info for type {Type} not found => unsupported model", input.GetType().FullName);
            throw new InvalidOperationException($"Model info for type {input?.GetType().FullName} not found => unsupported model");
        }

        TTargetInfo? current;

        if (model.ObjectGuidProperty is { } objectGuidProperty && objectGuidProperty.GetValue(input) is Guid objectGuid)
        {
            var existing = ProviderProxy.GetBaseInfoByGuid(objectGuid);

            if (existing != null)
            {
                if (existing is TTargetInfo @base)
                {
                    logger.LogTrace("Info {Guid} exists", objectGuid);
                    current = @base;
                }
                else
                {
                    logger.LogError("Returned object of type '{ReturnedType}' is not assignable to wanted type '{WantedType}'", existing.GetType().FullName, typeof(TTargetInfo).FullName);
                    throw new InvalidOperationException($"Returned object of type '{existing.GetType().FullName}' is not assignable to wanted type '{typeof(TTargetInfo).FullName}'");
                }
            }
            else
            {
                current = new();
                current.SetValue(current.TypeInfo.GUIDColumn, objectGuid);
                logger.LogTrace("Info {Guid} created", objectGuid);
            }
        }
        else
        {
            // no strategy for getting existing object
            current = new();
            logger.LogTrace("Info created, no strategy used for selecting existing object");
        }

        // field mapping phase

        // map all foreign references to ensure they exist
        foreach (var referenceProperty in model.ReferenceProperties)
        {
            logger.LogInformation("Mapping reference property '{RefProp}' from '{RefType}' ObjectId", referenceProperty.ReferencedPropertyName, referenceProperty.ReferencedInfoType?.Name);

            object? refObject = referenceProperty.Property?.GetValue(input);
            if (refObject is Guid foreignObjectGuid)
            {
                var providerProxy = ProviderProxyFactory.CreateProviderProxy(referenceProperty.ReferencedInfoType, ProviderProxy.Context);
                var foreign = referenceProperty.SearchedField == null
                    ? providerProxy.GetBaseInfoByGuid(foreignObjectGuid)
                    : providerProxy.GetBaseInfoBy(foreignObjectGuid, referenceProperty.SearchedField);

                if (foreign is not null)
                {
                    object? id = foreign[referenceProperty.ValueField ?? foreign.TypeInfo.IDColumn];
                    current.SetValue(referenceProperty.ReferencedPropertyName, id);
                    logger.LogTrace("Dependency '{DepName}' set as ObjectId '{Id}'", referenceProperty.ReferencedPropertyName, id);
                }
                else if (referenceProperty.IsRequired)
                {
                    logger.LogError("Missing required dependency - Object of type '{ReferencedInfoType}' with ObjectGUID '{ObjectGuid}' cannot be found", referenceProperty.ReferencedInfoType, foreignObjectGuid);
                    throw new InvalidOperationException($"Missing required dependency - Object of type '{referenceProperty.ReferencedInfoType}' with ObjectGUID '{foreignObjectGuid}' cannot be found");
                }
            }
            else if (referenceProperty.IsRequired)
            {
                logger.LogError("Missing required dependency - '{PropName}' is not valid ObjectGUID", referenceProperty.Property?.Name);
                throw new InvalidOperationException($"Missing required dependency - '{referenceProperty.Property?.Name}' is not valid ObjectGUID");
            }
        }


        var inputReflected = Reflect.Type(input.GetType());
        foreach (var property in inputReflected.PublicProperties)
        {
            if (property.GetCustomAttribute<MapAttribute>() is { })
            {
                if (current.ColumnNames.Contains(property.Name))
                {
                    object? value = property.GetValue(input);
                    current.SetValue(property.Name, value);
                    logger.LogTrace("[{ColumnName}]={Value}", property.Name, value);
                }
                else
                {
                    logger.LogError("Info doesn't contain column with name '{ColumnName}' - MapAttribute is on invalid property, property SHALL have same name as column in target Info object", property.Name);
                    throw new InvalidOperationException($"Info doesn't contain column with name '{property.Name}' - MapAttribute is on invalid property, property SHALL have same name as column in target Info object");
                }
            }

            if (property.GetCustomAttribute<MapToAttribute>() is { PropertyName: not null } mapTo)
            {
                if (current.ColumnNames.Contains(mapTo.PropertyName))
                {
                    object? value = property.GetValue(input);
                    current.SetValue(mapTo.PropertyName, value);
                    logger.LogTrace("[{ColumnName}]={Value}", mapTo.PropertyName, value);
                }
                else
                {
                    logger.LogError("Info doesn't contain column with name '{ColumnName}' - MapToAttribute has invalid PropertyName argument, property SHALL have same name as column in target Info object", property.Name);
                    throw new InvalidOperationException($"Info doesn't contain column with name '{property.Name}' - MapToAttribute has invalid PropertyName argument, property SHALL have same name as column in target Info object");
                }
            }
        }

        if (input.CustomProperties.Keys is { } customProperties)
        {
            foreach (string customProperty in customProperties)
            {
                if (customProperty == UmtModelStjConverter.DiscriminatorProperty)
                {
                    continue;
                }

                // TODO tomas.krch: 2023-06-27 guard custom vs base properties (deny setting base property with custom accessor)
                
                if (current.ColumnNames.Contains(customProperty))
                {
                    object? value = input.CustomProperties[customProperty];
                    if (value is JsonElement jsonElement)
                    {
                        // TODO tomas.krch: 2023-06-27 convert to correct column type (don't rely on internal handling) from perspective of UMT this is unpredictability
                        value = jsonElement.ToString();
                    }

                    current.SetValue(customProperty, value);
                    
                    logger.LogTrace("[{ColumnName}]={Value}", customProperty, value);
                }
                else
                {
                    logger.LogError("Info doesn't contain column with name '{ColumnName}' - _CustomProperties has invalid key, key SHALL have same name as column in target Info object", customProperty);
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
            logger.LogError("Model info for type {Type} not found => unsupported model", input?.GetType()?.FullName);
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
