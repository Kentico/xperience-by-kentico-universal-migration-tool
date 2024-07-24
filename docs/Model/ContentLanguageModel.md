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


### ContentLanguage Sample - English US
This sample describes how to create content language for English (United States)
```json
{
  "$type": "ContentLanguage",
  "ContentLanguageGUID": "f454e93b-5fe9-42a9-b1af-b572234ed9c4",
  "ContentLanguageDisplayName": "English (United States)",
  "ContentLanguageName": "en-US",
  "ContentLanguageIsDefault": false,
  "ContentLanguageCultureFormat": "en-US"
}
```

### ContentLanguage Sample - English UK
This sample describes how to create content language for English (United Kingdom)
```json
{
  "$type": "ContentLanguage",
  "ContentLanguageGUID": "a6c0a558-8b33-47b6-87a8-491b437c9923",
  "ContentLanguageDisplayName": "English (United Kingdom)",
  "ContentLanguageName": "en-GB",
  "ContentLanguageIsDefault": false,
  "ContentLanguageCultureFormat": "en-GB"
}
```

### ContentLanguage Sample - English US
This sample describes how to create content language for English (United States)
```json
{
  "$type": "ContentLanguage",
  "ContentLanguageGUID": "f454e93b-5fe9-42a9-b1af-b572234ed9c4",
  "ContentLanguageDisplayName": "English (United States)",
  "ContentLanguageName": "en-US",
  "ContentLanguageIsDefault": false,
  "ContentLanguageCultureFormat": "en-US"
}
```
