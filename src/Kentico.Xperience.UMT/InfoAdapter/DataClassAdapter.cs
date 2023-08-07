using CMS.DataEngine;
using CMS.FormEngine;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Services.Model;
using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class DataClassAdapter: GenericInfoAdapter<DataClassInfo>
{
    private const string CONTROL_NAME = "controlname";

    internal DataClassAdapter(ILogger<DataClassAdapter> logger, UmtModelService modelService, IProviderProxy providerProxy, IProviderProxyFactory providerProxyFactory) : base(logger, modelService, providerProxy, providerProxyFactory)
    {
    }

    public override DataClassInfo Adapt(IUmtModel input)
    {
        if (input is DataClassModel dcm)
        {
            var adapted = base.Adapt(input);

            var classStructureInfo = new ClassStructureInfo(dcm.ClassName, "", dcm.ClassTableName);
            var formInfo = FormHelper.GetBasicFormDefinition(dcm.ClassPrimaryKeyName ?? $"{dcm.ClassName?.Split('.').LastOrDefault()}ID");

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
                        Visible = field.Visible
                    };
                    
                    nfi.Caption = field.Properties.FieldCaption;
                    nfi.Settings[CONTROL_NAME] = field.Settings.ControlName;

                    formInfo.AddFormItem(nfi);
                }
            }

            adapted.ClassXmlSchema = classStructureInfo.GetXmlSchema();
            adapted.ClassFormDefinition = formInfo.GetXmlDefinition();
        
            return adapted;   
        }
        else
        {
            throw new InvalidOperationException($"Invalid adapter for model");
        }
    }
}
