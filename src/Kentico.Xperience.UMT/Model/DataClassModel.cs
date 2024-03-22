using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using CMS.Modules;
using Kentico.Xperience.UMT.Attributes;
using Kentico.Xperience.UMT.Services.Validation;
// ReSharper disable InconsistentNaming

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// Model represents XbyK DataClassInfo
/// </summary>
/// <sample>dataclass.article</sample>
/// <sample>dataclass.event</sample>
/// <sample>dataclass.faq</sample>
[UmtModel(Discriminator)]
[SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "For sake of completeness and to avoid unresolved properties in Kentico Info object. All commented properties exist in target model.")]
public class DataClassModel : UmtModel
{
    /// <summary>
    /// Discriminator used in serialized structures to identify model 
    /// </summary>
    public const string Discriminator = "DataClass";

    // managed internally
    // public int?             ClassID                       { get; private set; }
    
    /// <summary>
    /// Friendly name for class
    /// </summary>
    [Map]
    [Required]
    public string?          ClassDisplayName              { get; set; }
    /// <summary>
    /// Class unique codename
    /// </summary>
    [Map]
    [Required]
    public string?          ClassName                     { get; set; } = null!;

    // set internally, replace by Fields property 
    // public string?          ClassXmlSchema                { get; private set; }
    // set internally, replace by Fields property
    // public string?          ClassFormDefinition           { get; private set; }
    
    /// <summary>
    /// Short name
    /// </summary>
    private string? _classShortName;
    public string? ClassShortName
    {
        get => string.IsNullOrWhiteSpace(_classShortName) ? ClassName : _classShortName;
        set => _classShortName = value;
    }
    
    /// <summary>
    /// SQL Table name
    /// </summary>
    [Map]
    public string?          ClassTableName                { get; set; }
    
    [Map]
    public bool?            ClassShowTemplateSelection    { get; set; }

    /// <summary>
    /// last modification performed through API / UI
    /// </summary>
    [Map]
    [Required]
    public DateTime?        ClassLastModified             { get; set; }
    /// <summary>
    /// UniqueId of DataClass
    /// </summary>
    [Map]
    [Required]
    [UniqueIdProperty]
    public Guid?             ClassGUID                     { get; set; }
    
    [Map]
    public string?          ClassContactMapping           { get; set; }
    [Map]
    public bool?            ClassContactOverwriteEnabled  { get; set; }
    [Map]
    public string?          ClassConnectionString         { get; set; }
    [Map]
    public string?          ClassDefaultObjectType        { get; set; }

    /// <summary>
    /// Relation to CMS Resource (Custom module), set if dataclass is part custom module  
    /// </summary>
    [ReferenceProperty(typeof(ResourceInfo), "ClassResourceID", IsRequired = false)]
    public Guid?            ClassResourceGuid             { get; set; }
    
    [Map]
    public string?          ClassCodeGenerationSettings   { get; set; } = null;

    /// <summary>
    /// only if consumer wishes to manage SQL table manually
    /// </summary>
    [Map]
    [Required]
    public bool?            ClassHasUnmanagedDbSchema     { get; set; }

    [Map]
    [Required]
    public string? ClassType { get; set; }

    [Map]
    public string? ClassContentTypeType { get; set; }

    [Map]
    public bool? ClassWebPageHasUrl { get; set; }
    
    /// <summary>
    /// custom data fields for DataClass
    /// </summary>
    [CheckEnumerable]
    public List<FormField> Fields { get; set; } = new();

    protected override (Guid? uniqueId, string? name, string? displayName) GetPrintArgs() => (ClassGUID, ClassName, ClassDisplayName);
}

/// <summary>
/// Represents information about custom data field
/// </summary>
public class FormField
{
    /// <summary>
    /// marks field as nullable
    /// </summary>
    public bool AllowEmpty { get; set; }
    /// <summary>
    /// Name of column, this will be used for column naming in SQL Table
    /// </summary>
    [Required]
    public string? Column { get; set; }
    public int ColumnSize { get; set; }
    /// <summary>
    /// Column type, defines used type from vector [.NET type, SQL type, xsd schema type]
    /// </summary>
    /// <docref uri="../Enums/ColumnType">enumeration</docref>
    [Required]
    // [RegularExpression("^(boolean)|(integer)|(longinteger)|(double)|(datetime)|(longtext)|(binary)|(guid)|(decimal)|(timespan)|(binary)|(text)|(date)|(xml)|(pages)|(contentitems)|(contentitemasset)|(assets)|(bizformfile)|(objectcodenames)|(objectguids)|(objectids)$")]
    public string? ColumnType { get; set; }
    
    public bool Enabled { get; set; }
    /// <summary>
    /// Unique identification of field
    /// </summary>
    [Required]
    public Guid? Guid { get; set; }
    /// <summary>
    /// Field visibility in administration form
    /// </summary>
    public bool Visible { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <docref header="FormFieldProperties">definition</docref>
    public FormFieldProperties Properties { get; set; } = new();
    /// <summary>
    /// 
    /// </summary>
    /// <docref header="FormFieldSettings">definition</docref>
    public FormFieldSettings Settings { get; set; } = new();
}

/// <summary>
/// additional form field properties, they may differ by property type
/// </summary>
public class FormFieldProperties
{
    /// <summary>
    /// Friendly name displayed in form
    /// </summary>
    public string? FieldCaption { get; set; }
    
    [System.Text.Json.Serialization.JsonExtensionData]
    public Dictionary<string, object?> CustomProperties { get; set; } = new();
}

/// <summary>
/// settings related to form field
/// </summary>
public class FormFieldSettings
{
    /// <summary>
    /// Admin UI Component used for field data editing
    /// </summary>
    /// <docref uri="../Enums/FormComponents.md#module-kenticoxperienceadminbasedll">(for pages use enumeration here)</docref>
    public string? ControlName { get; set; }
    
    [System.Text.Json.Serialization.JsonExtensionData]
    public Dictionary<string, object?> CustomProperties { get; set; } = new();
}
