using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using CMS.DataEngine;
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
[UmtModel(Discriminator)]
[SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "For sake of completeness and to avoid unresolved properties in Kentico Info object. All commented properties exist in target model.")]
public class DataClassModel: UmtModel
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
    public string          ClassName                     { get; set; } = null!;

    /// <summary>
    /// If data class represents Page/TreeNode set to true, otherwise false
    /// </summary>
    [Map]
    [Required]
    public bool?            ClassIsDocumentType           { get; private set; } = true;
    /// <summary>
    /// if DataClass contains custom data this will be true, if not set to false
    /// </summary>
    [Map]
    [Required]
    public bool?            ClassIsCoupledClass           { get; private set; } = true;
    // set internally, replace by Fields property 
    // public string?          ClassXmlSchema                { get; private set; }
    // set internally, replace by Fields property
    // public string?          ClassFormDefinition           { get; private set; }
    /// <summary>
    /// Source field name for node name, this has impact on generated URL of page 
    /// </summary>
    [Map]
    [Required]
    public string?          ClassNodeNameSource           { get; set; }
    /// <summary>
    /// SQL Table name
    /// </summary>
    [Map]
    [Required]
    public string?          ClassTableName                { get; set; }
    /// <summary>
    /// Marks DataClass as internal, for all custom classes managed by consumer value will be false 
    /// </summary>
    [Map]
    public bool?            ClassShowAsSystemTable        { get; private set; } = false;
    [Map]
    public bool?            ClassUsePublishFromTo         { get; set; }
    [Map]
    public bool?            ClassShowTemplateSelection    { get; set; }
    /// <summary>
    /// Defines property that will XbyK API use for Page Alias
    /// </summary>
    [Map]
    [Required]
    public string?          ClassNodeAliasSource          { get; set; }
    /// <summary>
    /// last modification performed through API / UI
    /// </summary>
    [Map]
    public DateTime?        ClassLastModified             { get; set; }
    /// <summary>
    /// UniqueId of DataClass
    /// </summary>
    [UniqueIdProperty]
    public Guid             ClassGuid                     { get; set; }
    // [Map]
    // public bool?            ClassIsCustomTable            { get; private set; } = false;
    [Map]
    public string?          ClassShowColumns              { get; set; }
    // public int?             ClassInheritsFromClassID      { get; set; }
    /// <summary>
    /// in case of inheritance set parent class GUID
    /// </summary>
    // TODO tomas.krch: 2023-09-05 migration v27: Class inheritance broken !!!! 
    // [ReferenceProperty(typeof(DataClassInfo), nameof(DataClassInfo.ClassInheritsFromClassID), IsRequired = false)]
    // public Guid?            ClassInheritsFromClassGuid    { get; set; }
    // [Map]
    // public bool?            ClassSearchEnabled            { get; set; }
    [Map]
    public string?          ClassContactMapping           { get; set; }
    [Map]
    public bool?            ClassContactOverwriteEnabled  { get; set; }
    [Map]
    public string?          ClassConnectionString         { get; set; }
    [Map]
    public string?          ClassDefaultObjectType        { get; set; }
    [Map]
    public bool?            ClassIsForm                   { get; set; } = false;

    /// <summary>
    /// Relation to CMS Resource (Custom module), set if dataclass is part custom module  
    /// </summary>
    [ReferenceProperty(typeof(ResourceInfo), nameof(DataClassInfo.ClassResourceID), IsRequired = false)]
    public Guid?            ClassResourceGuid             { get; set; }
    [Map]
    public string?          ClassCustomizedColumns        { get; set; } = null;
    [Map]
    public string?          ClassCodeGenerationSettings   { get; set; } = null;
    [Map]
    public string?          ClassIconClass                { get; set; } = null;
    [Map]
    public string?          ClassURLPattern               { get; set; }
    /// <summary>
    /// Page Builder feature, if enabled ClassHasURL is required too
    /// </summary>
    [Map]
    [Required]
    public bool?            ClassUsesPageBuilder          { get; set; }
    
    [Map]
    [Required]
    public bool?            ClassHasURL                   { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    [Map]
    [Required]
    public bool?            ClassHasMetadata              { get; set; }
    
    /// <summary>
    /// If true, DataClass represents Page/TreeNode   
    /// </summary>
    [Map]
    public bool?            ClassIsPage                   { get; set; } = true;
    
    /// <summary>
    /// only if consumer wishes to manage SQL table manually
    /// </summary>
    [Map]
    [Required]
    public bool?            ClassHasUnmanagedDbSchema     { get; set; }

    /// <summary>
    /// primary key name in database table
    /// </summary>
    [Required]
    public string? ClassPrimaryKeyName { get; set; }
    
    /// <summary>
    /// custom data fields for DataClass
    /// </summary>
    [CheckEnumerable]
    public List<FormField> Fields { get; set; } = new();
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
    [RegularExpression("^(boolean)|(integer)|(longinteger)|(double)|(datetime)|(longtext)|(binary)|(guid)|(decimal)|(timespan)|(binary)|(text)|(date)|(xml)|(pages)|(contentitems)|(contentitemasset)|(assets)|(bizformfile)|(objectcodenames)|(objectguids)|(objectids)$")]
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
    // TODO tomas.krch: 2023-07-23 validation needs to be done at runtime, target instance could contain custom form components
    public string? ControlName { get; set; }
}
