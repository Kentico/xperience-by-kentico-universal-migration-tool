<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## UserInfoModel
Model represents XbyK UserInfo

Model [discriminator](../UmtModel.md#discriminator): `UserInfo`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|UserName\*|user nane / login name - must be unique|string?||
|FirstName|First name of user|string?||
|LastName|Last name of user|string?||
|Email\*|valid email address according to XbyK API domain requirements (ValidationHelper.IsEmail()) or custom regex set through configuration "CMSEmailValidationRegex"|string?||
|UserPassword\*|hashed user password|string?||
|UserEnabled\*|disable/enable user|bool?||
|UserCreated|datetime of user creation, defaults to current server time|System.DateTime?||
|LastLogon|lost logon of user to administration|System.DateTime?||
|UserGUID\*|uniqueId of user used for reference in other models|System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|UserLastModified|date of last modification of user|System.DateTime?||
|UserSecurityStamp||string?||
|UserPasswordLastChanged||System.DateTime?||
|UserIsPendingRegistration\*||bool?||
|UserRegistrationLinkExpiration||System.DateTime?||
|UserAdministrationAccess\*|if set user has access to administration XbyK instance|bool?||
|UserIsExternal\*||bool?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Instance of dataclass UserInfo - Sample admin
Sample demonstrates how to create administrator user
```json
{
  "$type": "UserInfo",
  "UserName": "sadmin",
  "FirstName": "Sample",
  "LastName": "Admin",
  "Email": "XYZ@sample.localhost",
  "UserPassword": "[sample hash]",
  "UserEnabled": true,
  "UserCreated": "1990-01-01T00:00:00",
  "UserGUID": "dbfcc244-2cb9-4934-857f-9d75404c1553",
  "UserIsPendingRegistration": false,
  "UserAdministrationAccess": true,
  "UserIsExternal": false
}
```
