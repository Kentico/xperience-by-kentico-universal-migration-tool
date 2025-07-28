<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## MemberInfoModel
Model represents XbyK MemberInfo

Model [discriminator](../UmtModel.md#discriminator): `MemberInfo`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|MemberName\*|member name / login name - must be unique|string?||
|MemberEmail\*|valid email address according to XbyK API domain requirements (ValidationHelper.IsEmail()) or custom regex set through configuration "CMSEmailValidationRegex"|string?||
|MemberPassword|hashed member password|string?||
|MemberEnabled\*|disable/enable member|bool?||
|MemberCreated|datetime of member creation, defaults to current server time|System.DateTime?||
|MemberGUID\*|uniqueId of member used for reference in other models|System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|MemberIsExternal\*||bool?||
|MemberSecurityStamp||string?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Instance of dataclass MemberInfo - Sample member without custom fields
Sample demonstrates how to create a member without custom fields
```json
{
  "$type": "MemberInfo",
  "memberName": "John Doe",
  "memberEmail": "john.doe@sample.localhost",
  "memberPassword": "[sample hash]",
  "memberEnabled": true,
  "memberCreated": "2003-02-01T04:05:06.007Z",
  "memberGUID": "4834f3c4-f7a5-46b8-a83d-607fcfc555d7",
  "memberIsExternal": false,
  "memberSecurityStamp": "[sample security stamp]"
}
```
