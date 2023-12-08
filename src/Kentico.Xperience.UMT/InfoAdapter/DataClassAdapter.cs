using CMS.ContentEngine;
using CMS.Core;
using CMS.DataEngine;
using CMS.FormEngine;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Services.Model;
using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class DataClassAdapter : GenericInfoAdapter<DataClassInfo>
{
    private const string CONTROL_NAME = "controlname";

    internal DataClassAdapter(ILogger<DataClassAdapter> logger, UmtModelService modelService, IProviderProxy providerProxy, IProviderProxyFactory providerProxyFactory) : base(logger, modelService, providerProxy, providerProxyFactory)
    {

    }

    protected override void SetValue(DataClassInfo current, string propertyName, object? value)
    {
        if (Reflect<DataClassInfo>.TrySetProperty(current, propertyName, value))
        {
            // OK
            Logger.LogTrace("Setting property '{PropertyName}' of type '{Type}' to value: {Value}", propertyName, Reflect<DataClassInfo>.Current.FullName, value);
        }
        else if (Reflect<DataClassInfoBase<DataClassInfo>>.TrySetProperty(current, propertyName, value))
        {
            // OK
            Logger.LogTrace("Setting property '{PropertyName}' of type '{Type}' to value: {Value}", propertyName, Reflect<DataClassInfoBase<DataClassInfo>>.Current.FullName, value);
        }
        else
        {
            Logger.LogError("Object of type '{Type}' doesn't contain property '{PropertyName}' => unable to set value", current.GetType().FullName, propertyName);
        }
    }

    public override DataClassInfo Adapt(IUmtModel input)
    {
        if (input is DataClassModel dcm)
        {
            var adapted = base.Adapt(input);

            var contentTypeManager = Service.Resolve<IContentTypeManager>();
            contentTypeManager.Initialize(adapted);
            if (dcm.ClassTableName != null)
            {
                adapted.ClassTableName = dcm.ClassTableName;
            }
            var formInfo = new FormInfo(adapted.ClassFormDefinition);

            if (dcm.Fields is { Count: > 0 })
            {
                foreach (var field in dcm.Fields)
                {
                    var nfi = new FormFieldInfo
                    {
                        Name = field.Column,
                        Guid = field.Guid ?? throw new ArgumentException($"Field GUID is required"),
                        Caption = field.Properties.FieldCaption,
                        AllowEmpty = field.AllowEmpty,
                        DataType = field.ColumnType,
                        Enabled = field.Enabled,
                        Visible = field.Visible,
                        Size = field.ColumnSize
                    };
                    nfi.Caption = field.Properties.FieldCaption;
                    nfi.Settings[CONTROL_NAME] = field.Settings.ControlName;
                    
                    foreach ((string? key, object? value) in field.Properties.CustomProperties)
                    {
                        nfi.Properties[key] = value;
                    }
                    foreach ((string? key, object? value) in field.Settings.CustomProperties)
                    {
                        nfi.Settings[key] = value;
                    }

                    formInfo.AddFormItem(nfi);
                }
            }

            adapted.ClassFormDefinition = formInfo.GetXmlDefinition();
            return adapted;
        }
        else
        {
            throw new InvalidOperationException($"Invalid adapter for model");
        }
    }
}
