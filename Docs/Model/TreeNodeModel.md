<!-- generated file with tool "Kentico.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## TreeNodeModel
Model [discriminator](../UmtModel.md#discriminator): `TreeNode`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|NodeClassGuid\*|Required reference to DataClass unique id|System.Guid?|Reference to [DataClassInfo](../References.md#DataClassInfo) on property NodeClassID **required**|
|NodeOwnerGuid\*|Required reference to user that owns node|System.Guid?|Reference to [UserInfo](../References.md#UserInfo) on property NodeOwner **required**|
|NodeParentGuid\*|Required reference to node parent node|System.Guid?|Reference to [TreeNode](../References.md#TreeNode) on property NodeParentID **required**|
|NodeGUID\*|unique identification of Node in tree structure, culture independent|System.Guid?||
|NodeAlias\*|Node alias is used internally by XbyK API to organize node by path (NodeAliasPath)|string?||
|NodeName\*||string?||
|NodeOrder|Order of node in tree structure, decides order of nodes in same level of tree structure, default to calculated value by XbyK API|int?||
|DocumentCulture\*|document culture specified in .NET culture format - en-US, en-GB,...|string?||
|DocumentName||string?||
|DocumentLastPublished|property is set when workflow is applied to publication date|System.DateTime?||
|DocumentModifiedWhen|document last modification date - defaults to null|System.DateTime?||
|DocumentCreatedWhen|document creation date - defaults to current server time|System.DateTime?||
|DocumentPublishFrom|planned publication date, document will/was accessible to public from this date|System.DateTime?||
|DocumentPublishTo|planned publication date, document will/was accessible to public until this date
    nullish value is DateTime.MaxDate - XbyK API considers NULL and DataTime.MaxDate same for this field|System.DateTime?||
|DocumentGUID\*|UniqueId of TreeNodeModel, unique for each combination of DocumentCulture, NodeGuid, NodeSiteID|System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|DocumentCreatedByUserGuid\*|UniqueId of user that created document|System.Guid?|Reference to [UserInfo](../References.md#UserInfo) on property DocumentCreatedByUserID **required**|
|DocumentModifiedByUserGuid|UniqueId of user that modified document, can be set to null|System.Guid?|Reference to [UserInfo](../References.md#UserInfo) on property DocumentModifiedByUserID|
|NodeIsPage||bool||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Instance of dataclass UMT.Event

```json
{
  "$type": "TreeNode",
  "NodeClassGuid": "3d36917e-de3e-4db3-9d71-7961d250085d",
  "NodeOwnerGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
  "NodeParentGuid": "acdd2058-bde0-4c9d-8332-45f417220571",
  "NodeGUID": "50cf01d4-1c39-4910-82ca-298c9f7a4840",
  "NodeAlias": "announcement-of-economic-results",
  "NodeName": "Announcement of economic results",
  "DocumentCulture": "en-US",
  "DocumentName": "Announcement of economic results",
  "DocumentGUID": "15f0efd6-6961-4640-af6d-9c06b3a0a24d",
  "DocumentCreatedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
  "EventTitle": "Announcement of economic results",
  "EventText": "\u003Ch1\u003EAnnouncement of economic results\u003C/h1\u003E",
  "EventDate": "2023-07-01T11:00:00",
  "EventRecurrentYearly": false
}
```

### Instance of dataclass UMT.Event

```json
{
  "$type": "TreeNode",
  "NodeClassGuid": "3d36917e-de3e-4db3-9d71-7961d250085d",
  "NodeOwnerGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
  "NodeParentGuid": "acdd2058-bde0-4c9d-8332-45f417220571",
  "NodeGUID": "e2b53c6c-020d-45d3-acb7-c2651bf7171a",
  "NodeAlias": "yearly-barbecue-for-customers",
  "NodeName": "Yearly barbeque for customers",
  "DocumentCulture": "en-US",
  "DocumentGUID": "34b4df1b-6261-4546-9382-941809e1936f",
  "DocumentCreatedByUserGuid": "dbfcc244-2cb9-4934-857f-9d75404c1553",
  "EventTitle": "Yearly barbeque for customers",
  "EventText": "\u003Ch1\u003EBarbecue is here!\u003C/h1\u003E\u003Cp\u003Elet us invite You to our yearly friendly meeting with You - our customers\u003C/p\u003E",
  "EventDate": "2023-06-01T11:00:00",
  "EventRecurrentYearly": true
}
```
