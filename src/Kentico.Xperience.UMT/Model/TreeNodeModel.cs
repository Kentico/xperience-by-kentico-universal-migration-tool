// ReSharper disable InconsistentNaming

using System.ComponentModel.DataAnnotations;
using CMS.DataEngine;
// using CMS.DocumentEngine; => obsolete
using Kentico.Xperience.UMT.Attributes;

namespace Kentico.Xperience.UMT.Model;

/// <summary>
/// 
/// </summary>
/// <sample>treenode.singleevent</sample>
/// <sample>treenode.yearlyevent</sample>
[UmtModel(DISCRIMINATOR)]
public class TreeNodeModel: UmtModel
{
    /// <summary>
    /// Discriminator used in serialized structures to identify model 
    /// </summary>
    public const string DISCRIMINATOR = "TreeNode";

    #region "References"

    /// <summary>
    /// Required reference to DataClass unique id 
    /// </summary>
    [Required]
    [ReferenceProperty(typeof(DataClassInfo), "NodeClassID", IsRequired = true)]
    public Guid? NodeClassGuid { get; set; }

    // TODO tomas.krch: 2023-09-05 migration v27: obsolete
    /// <summary>
    /// Required reference to user that owns node
    /// </summary>
    // [Required]
    // [ReferenceProperty(typeof(UserInfo), nameof(TreeNode.NodeOwner), IsRequired = true)]
    // public Guid? NodeOwnerGuid { get; set; }

    // TODO tomas.krch: 2023-09-05 migration v27: obsolete
    /// <summary>
    /// Required reference to node parent node
    /// </summary>
    // [Required]
    // [ReferenceProperty(typeof(TreeNode), nameof(TreeNode.NodeParentID), IsRequired = true, SearchedField = nameof(TreeNode.NodeGUID), ValueField = nameof(TreeNode.NodeID))]
    // public Guid? NodeParentGuid { get; set; }

    #endregion

    #region Node properties
    
    /// <summary>
    /// unique identification of Node in tree structure, culture independent
    /// </summary>
    [Map]
    [Required]
    public Guid? NodeGUID { get; set; }
    
    /// <summary>
    /// Node alias is used internally by XbyK API to organize node by path (NodeAliasPath)
    /// </summary>
    [Map]
    [Required]
    public string? NodeAlias { get; set; }
    
    [Map]
    [Required]
    public string? NodeName { get; set; }
    
    /// <summary>
    /// Order of node in tree structure, decides order of nodes in same level of tree structure, default to calculated value by XbyK API
    /// </summary>
    [Map]
    public int? NodeOrder { get; set; }

    #endregion

    #region Document properties

    /// <summary>
    /// document culture specified in .NET culture format - en-US, en-GB,...
    /// </summary>
    [Map]
    [Required]
    public string? DocumentCulture { get; set; }

    [Map]
    public string? DocumentName { get; set; }

    // TODO tomas.krch: 2023-03-29 DocumentContent, DocumentPageBuilderWidgets, DocumentPageTemplateConfiguration - widget/page template support

    /// <summary>
    /// property is set when workflow is applied to publication date
    /// </summary>
    [Map]
    public DateTime? DocumentLastPublished { get; set; }
    /// <summary>
    /// document last modification date - defaults to null
    /// </summary>
    [Map]
    public DateTime? DocumentModifiedWhen { get; set; }
    /// <summary>
    /// document creation date - defaults to current server time
    /// </summary>
    [Map]
    public DateTime? DocumentCreatedWhen { get; set; }

    /// <summary>
    /// planned publication date, document will/was accessible to public from this date
    /// </summary>
    [Map]
    public DateTime? DocumentPublishFrom { get; set; }
    
    /// <summary>
    /// planned publication date, document will/was accessible to public until this date
    /// nullish value is DateTime.MaxDate - XbyK API considers NULL and DataTime.MaxDate same for this field
    /// </summary>
    [Map]
    public DateTime? DocumentPublishTo { get; set; } // TODO tomas.krch: 2023-03-29 CAREFUL - DateTime.MaxDate is nullish value here 

    /// <summary>
    /// UniqueId of TreeNodeModel, unique for each combination of DocumentCulture, NodeGuid, NodeSiteID
    /// </summary>
    [Required]
    [UniqueIdProperty]
    public Guid? DocumentGUID { get; set; }

    // TODO tomas.krch: 2023-09-05 migration v27: obsolete
    // /// <summary>
    // /// UniqueId of user that created document
    // /// </summary>
    // [Required]
    // [ReferenceProperty(typeof(UserInfo), nameof(TreeNode.DocumentCreatedByUserID), IsRequired = true)]
    // public Guid? DocumentCreatedByUserGuid { get; set; } //DocumentCreatedByUserID
    //
    // /// <summary>
    // /// UniqueId of user that modified document, can be set to null
    // /// </summary>
    // [ReferenceProperty(typeof(UserInfo), nameof(TreeNode.DocumentModifiedByUserID), IsRequired = false)]
    // public Guid? DocumentModifiedByUserGuid { get; set; } //DocumentModifiedByUserID

    #endregion

    internal bool NodeIsPage => true;
}
