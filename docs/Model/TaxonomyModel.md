<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## TaxonomyModel
Model [discriminator](../UmtModel.md#discriminator): `Taxonomy`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|TaxonomyName\*||string?||
|TaxonomyGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|TaxonomyTitle\*||string?||
|TaxonomyDescription||string?||
|TaxonomyTranslations|Key of the dictionary is the .|System.Collections.Generic.Dictionary<System.Guid, Kentico.Xperience.UMT.Model.TaxonomyTranslationModel>?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Instance of dataclass TaxonomyInfo - Sample taxonomy
Sample demonstrates how to create taxonomy
```json
{
  "$type": "Taxonomy",
  "taxonomyName": "CoffeaGenus",
  "taxonomyGUID": "bd88fd9b-8d36-4d02-a4a6-9a2b26c48488",
  "taxonomyTitle": "Coffea genus",
  "taxonomyDescription": "Coffea is a genus of flowering plants in the family Rubiaceae",
  "taxonomyTranslations": {
    "f454e93b-5fe9-42a9-b1af-b572234ed9c4": {
      "title": "Coffea enUS"
    },
    "a6c0a558-8b33-47b6-87a8-491b437c9923": {
      "title": "Coffea enGB"
    }
  }
}
```
## TaxonomyTranslationModel

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|EqualityContract||System.Type||
|Title||string||

<p>*) value is required</p>

