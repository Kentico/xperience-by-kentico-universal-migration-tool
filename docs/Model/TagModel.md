<!-- generated file with tool "Kentico.Xperience.UMT.DocUtils" - edited through template "UmtModel.cshtml" -->
## TagModel
Model [discriminator](../UmtModel.md#discriminator): `Tag`

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|TagName\*||string?||
|TagGUID\*||System.Guid?|[UniqueId](../UmtModel.md#UniqueId)|
|TagTaxonomyGUID|Guid of taxonomy where tag belongs|System.Guid?|Reference to [TaxonomyInfo](../References.md#TaxonomyInfo) on property TagTaxonomyID|
|TagParentGUID||System.Guid?|Reference to [TagInfo](../References.md#TagInfo) on property TagParentID|
|TagOrder||int?||
|TagTitle\*||string?||
|TagDescription||string?||
|TagTranslations|Key of the dictionary is the .|System.Collections.Generic.Dictionary<System.Guid, Kentico.Xperience.UMT.Model.TagTranslationModel>?||
|[customPropertyName]|custom property defined by created [DataClass](./DataClassModel.md)|.NET type defined by data class field||

<p>*) value is required</p>


### Instance of dataclass TagInfo - Sample tag canephora
Sample demonstrates how to create taxonomy tag
```json
{
  "$type": "Tag",
  "tagName": "CoffeaCanephora",
  "tagGUID": "a6e3cc11-95a8-482c-beb4-58bbef6e7bdd",
  "tagTaxonomyGUID": "bd88fd9b-8d36-4d02-a4a6-9a2b26c48488",
  "tagTitle": "Coffea canephora (Coffea robusta)",
  "tagDescription": "Coffea canephora (especially C. canephora var. robusta, so predominantly cultivated that it is often simply termed Coffea robusta, or commonly robusta coffee)",
  "tagTranslations": {
    "f454e93b-5fe9-42a9-b1af-b572234ed9c4": {
      "title": "Coffea canephora enUS",
      "description": "ENUS Robusta is a species of flowering plant in the family Rubiaceae. Though widely known by the synonym Coffea robusta, the plant is currently scientifically identified as Coffea canephora, which has two main varieties, C. c. robusta and C. c. nganda.[2] The plant has a shallow root system and grows as a robust tree or shrub to about 10 metres (30 feet) tall. It flowers irregularly, taking about 10\u201411 months for the berries to ripen, producing oval-shaped beans."
    },
    "a6c0a558-8b33-47b6-87a8-491b437c9923": {
      "title": "Coffea canephora enGB",
      "description": "ENGB Robusta is a species of flowering plant in the family Rubiaceae. Though widely known by the synonym Coffea robusta, the plant is currently scientifically identified as Coffea canephora, which has two main varieties, C. c. robusta and C. c. nganda.[2] The plant has a shallow root system and grows as a robust tree or shrub to about 10 metres (30 feet) tall. It flowers irregularly, taking about 10\u201411 months for the berries to ripen, producing oval-shaped beans."
    }
  }
}
```

### Instance of dataclass TagInfo - Sample tag nganda
Sample demonstrates how to create taxonomy tag
```json
{
  "$type": "Tag",
  "tagName": "CoffeaNganda",
  "tagGUID": "b351f88c-7e0c-4339-bcf8-ed86bb8a2804",
  "tagTaxonomyGUID": "bd88fd9b-8d36-4d02-a4a6-9a2b26c48488",
  "tagParentGUID": "a6e3cc11-95a8-482c-beb4-58bbef6e7bdd",
  "tagTitle": "Coffea nganda",
  "tagDescription": "Coffea nganda variety of coffea canephora",
  "tagTranslations": {
    "f454e93b-5fe9-42a9-b1af-b572234ed9c4": {
      "title": "Coffea nganda enUS",
      "description": "ENUS Coffea nganda variety of coffea canephora."
    },
    "a6c0a558-8b33-47b6-87a8-491b437c9923": {
      "title": "Coffea nganda enGB",
      "description": "ENGB Coffea nganda variety of coffea canephora."
    }
  }
}
```

### Instance of dataclass TagInfo - Sample tag robusta
Sample demonstrates how to create taxonomy tag
```json
{
  "$type": "Tag",
  "tagName": "CoffeaRobusta",
  "tagGUID": "bb181050-79b0-4f42-9280-ef486a139623",
  "tagTaxonomyGUID": "bd88fd9b-8d36-4d02-a4a6-9a2b26c48488",
  "tagParentGUID": "a6e3cc11-95a8-482c-beb4-58bbef6e7bdd",
  "tagTitle": "Coffea robusta",
  "tagDescription": "Coffea robusta variety of coffea canephora",
  "tagTranslations": {
    "f454e93b-5fe9-42a9-b1af-b572234ed9c4": {
      "title": "Coffea robusta enUS",
      "description": "ENUS Coffea robusta variety of coffea canephora."
    },
    "a6c0a558-8b33-47b6-87a8-491b437c9923": {
      "title": "Coffea robusta enGB",
      "description": "ENGB Coffea robusta variety of coffea canephora."
    }
  }
}
```

### Instance of dataclass TagInfo - Sample tag arabica
Sample demonstrates how to create taxonomy tag
```json
{
  "$type": "Tag",
  "tagName": "CoffeaArabica",
  "tagGUID": "ffe48372-2bac-4a14-ad8c-c86f3f54c7c5",
  "tagTaxonomyGUID": "bd88fd9b-8d36-4d02-a4a6-9a2b26c48488",
  "tagTitle": "Coffea arabica",
  "tagDescription": "Coffea arabica (/\u0259\u02C8r\u00E6b\u026Ak\u0259/), also known as the Arabica coffee, is a species of flowering plant in the coffee and madder family Rubiaceae.",
  "tagTranslations": {
    "f454e93b-5fe9-42a9-b1af-b572234ed9c4": {
      "title": "Coffea arabica enUS",
      "description": "ENUS Wild plants grow between 9 and 12 m (30 and 39 ft) tall, and have an open branching system; the leaves are opposite, simple elliptic-ovate to oblong, 6\u201312 cm (2.5\u20134.5 in) long and 4\u20138 cm (1.5\u20133 in) broad, glossy dark green. The flowers are white, 10\u201315 mm in diameter, and grow in axillary clusters. The seeds are contained in a drupe (commonly called a \u0022cherry\u0022) 10\u201315 mm in diameter, maturing bright red to purple and typically containing two seeds, often called coffee beans."
    },
    "a6c0a558-8b33-47b6-87a8-491b437c9923": {
      "title": "Coffea arabica enGB",
      "description": "ENGB Wild plants grow between 9 and 12 m (30 and 39 ft) tall, and have an open branching system; the leaves are opposite, simple elliptic-ovate to oblong, 6\u201312 cm (2.5\u20134.5 in) long and 4\u20138 cm (1.5\u20133 in) broad, glossy dark green. The flowers are white, 10\u201315 mm in diameter, and grow in axillary clusters. The seeds are contained in a drupe (commonly called a \u0022cherry\u0022) 10\u201315 mm in diameter, maturing bright red to purple and typically containing two seeds, often called coffee beans."
    }
  }
}
```
## TagTranslationModel

|PropertyName|Summary|.NET Type|Notes|
|---|---|---|---|
|EqualityContract||System.Type||
|Title||string||
|Description||string||

<p>*) value is required</p>

