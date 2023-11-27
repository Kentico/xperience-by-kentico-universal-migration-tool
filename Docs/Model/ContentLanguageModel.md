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

