<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## ContentLanguageModel
Model represents XbyK ContentLanguageInfo

Model [discriminator](../UmtModel.md#discriminator): `ContentLanguage`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|ContentLanguageGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|ContentLanguageDisplayName\*||string?||
|ContentLanguageName\*||string?||
|ContentLanguageIsDefault\*||bool?||
|ContentLanguageFallbackContentLanguageGuid||System.Guid?|Reference to [ContentLanguageInfo](../References.md#ContentLanguageInfo) on property ContentLanguageFallbackContentLanguageID|
|ContentLanguageCultureFormat\*||string?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### ContentLanguage Sample
This sample describes how to create class inside XbyK to hold Content language data
```json
{
  "$type": "ContentLanguage",
  "ContentLanguageGUID": "3c9db02f-4b97-4af6-b9b2-b5708061e13f",
  "ContentLanguageDisplayName": "Slovak",
  "ContentLanguageName": "sk",
  "ContentLanguageIsDefault": false,
  "ContentLanguageFallbackContentLanguageGuid": "fd0a0727-fc68-4936-b868-119df0f0ad7a",
  "ContentLanguageCultureFormat": "sk"
}
```
