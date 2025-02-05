using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class TaxonomySamples
{
    public static readonly Guid SampleTaxonomyCoffeeGuid = new("BD88FD9B-8D36-4D02-A4A6-9A2B26C48488");

    [Sample("taxonomyinfo.coffeesample", "Sample demonstrates how to create taxonomy", "Instance of dataclass TaxonomyInfo - Sample taxonomy")]
    public static TaxonomyModel SampleTaxonomyCoffee => new()
    {
        TaxonomyGUID = SampleTaxonomyCoffeeGuid,
        TaxonomyTitle = "Coffea genus",
        TaxonomyName = "CoffeaGenus",
        TaxonomyDescription = "Coffea is a genus of flowering plants in the family Rubiaceae",
        TaxonomyTranslations = new Dictionary<Guid, TaxonomyTranslationModel>
        {
            [ContentLanguageSamples.CONTENT_LANGUAGE_ENUS_SAMPLE_GUID] = new("Coffea enUS"),
            [ContentLanguageSamples.CONTENT_LANGUAGE_ENGB_SAMPLE_GUID] = new("Coffea enGB")
        }
    };

    public static readonly Guid SampleTagCoffeaCanephoraGuid = new("A6E3CC11-95A8-482C-BEB4-58BBEF6E7BDD");
    [Sample("taginfo.canephorasample", "Sample demonstrates how to create taxonomy tag", "Instance of dataclass TagInfo - Sample tag canephora")]
    public static TagModel SampleTagCoffeaCanephora => new()
    {
        TagName = "CoffeaCanephora",
        TagGUID = SampleTagCoffeaCanephoraGuid,
        TagTaxonomyGUID = SampleTaxonomyCoffeeGuid,
        TagParentGUID = null,
        TagOrder = null,
        TagTitle = "Coffea canephora (Coffea robusta)",
        TagDescription = "Coffea canephora (especially C. canephora var. robusta, so predominantly cultivated that it is often simply termed Coffea robusta, or commonly robusta coffee)",
        TagTranslations = new Dictionary<Guid, TagTranslationModel>
        {
            [ContentLanguageSamples.CONTENT_LANGUAGE_ENUS_SAMPLE_GUID] = new("Coffea canephora enUS", "ENUS Robusta is a species of flowering plant in the family Rubiaceae. Though widely known by the synonym Coffea robusta, the plant is currently scientifically identified as Coffea canephora, which has two main varieties, C. c. robusta and C. c. nganda.[2] The plant has a shallow root system and grows as a robust tree or shrub to about 10 metres (30 feet) tall. It flowers irregularly, taking about 10—11 months for the berries to ripen, producing oval-shaped beans."),
            [ContentLanguageSamples.CONTENT_LANGUAGE_ENGB_SAMPLE_GUID] = new("Coffea canephora enGB", "ENGB Robusta is a species of flowering plant in the family Rubiaceae. Though widely known by the synonym Coffea robusta, the plant is currently scientifically identified as Coffea canephora, which has two main varieties, C. c. robusta and C. c. nganda.[2] The plant has a shallow root system and grows as a robust tree or shrub to about 10 metres (30 feet) tall. It flowers irregularly, taking about 10—11 months for the berries to ripen, producing oval-shaped beans.")
        }
    };

    public static readonly Guid SampleTagCoffeaNgandaGuid = new("B351F88C-7E0C-4339-BCF8-ED86BB8A2804");
    [Sample("taginfo.ngandasample", "Sample demonstrates how to create taxonomy tag", "Instance of dataclass TagInfo - Sample tag nganda")]
    public static TagModel SampleTagCoffeaNganda => new()
    {
        TagName = "CoffeaNganda",
        TagGUID = SampleTagCoffeaNgandaGuid,
        TagTaxonomyGUID = SampleTaxonomyCoffeeGuid,
        TagParentGUID = SampleTagCoffeaCanephora.TagGUID,
        TagOrder = null,
        TagTitle = "Coffea nganda",
        TagDescription = "Coffea nganda variety of coffea canephora",
        TagTranslations = new Dictionary<Guid, TagTranslationModel>
        {
            [ContentLanguageSamples.CONTENT_LANGUAGE_ENUS_SAMPLE_GUID] = new("Coffea nganda enUS", "ENUS Coffea nganda variety of coffea canephora."),
            [ContentLanguageSamples.CONTENT_LANGUAGE_ENGB_SAMPLE_GUID] = new("Coffea nganda enGB", "ENGB Coffea nganda variety of coffea canephora.")
        }
    };

    public static readonly Guid SampleTagCoffeaRobustaGuid = new("BB181050-79B0-4F42-9280-EF486A139623");
    [Sample("taginfo.robustasample", "Sample demonstrates how to create taxonomy tag", "Instance of dataclass TagInfo - Sample tag robusta")]
    public static TagModel SampleTagCoffeaRobusta => new()
    {
        TagName = "CoffeaRobusta",
        TagGUID = SampleTagCoffeaRobustaGuid,
        TagTaxonomyGUID = SampleTaxonomyCoffeeGuid,
        TagParentGUID = SampleTagCoffeaCanephora.TagGUID,
        TagOrder = null,
        TagTitle = "Coffea robusta",
        TagDescription = "Coffea robusta variety of coffea canephora",
        TagTranslations = new Dictionary<Guid, TagTranslationModel>
        {
            [ContentLanguageSamples.CONTENT_LANGUAGE_ENUS_SAMPLE_GUID] = new("Coffea robusta enUS", "ENUS Coffea robusta variety of coffea canephora."),
            [ContentLanguageSamples.CONTENT_LANGUAGE_ENGB_SAMPLE_GUID] = new("Coffea robusta enGB", "ENGB Coffea robusta variety of coffea canephora.")
        }
    };

    public static readonly Guid SampleTagCoffeaArabicaGuid = new("FFE48372-2BAC-4A14-AD8C-C86F3F54C7C5");
    [Sample("taginfo.arabicasample", "Sample demonstrates how to create taxonomy tag", "Instance of dataclass TagInfo - Sample tag arabica")]
    public static TagModel SampleTagCoffeaArabica => new()
    {
        TagName = "CoffeaArabica",
        TagGUID = SampleTagCoffeaArabicaGuid,
        TagTaxonomyGUID = SampleTaxonomyCoffeeGuid,
        TagParentGUID = null,
        TagOrder = null,
        TagTitle = "Coffea arabica",
        TagDescription = "Coffea arabica (/əˈræbɪkə/), also known as the Arabica coffee, is a species of flowering plant in the coffee and madder family Rubiaceae.",
        TagTranslations = new Dictionary<Guid, TagTranslationModel>
        {
            [ContentLanguageSamples.CONTENT_LANGUAGE_ENUS_SAMPLE_GUID] = new("Coffea arabica enUS", "ENUS Wild plants grow between 9 and 12 m (30 and 39 ft) tall, and have an open branching system; the leaves are opposite, simple elliptic-ovate to oblong, 6–12 cm (2.5–4.5 in) long and 4–8 cm (1.5–3 in) broad, glossy dark green. The flowers are white, 10–15 mm in diameter, and grow in axillary clusters. The seeds are contained in a drupe (commonly called a \"cherry\") 10–15 mm in diameter, maturing bright red to purple and typically containing two seeds, often called coffee beans."),
            [ContentLanguageSamples.CONTENT_LANGUAGE_ENGB_SAMPLE_GUID] = new("Coffea arabica enGB", "ENGB Wild plants grow between 9 and 12 m (30 and 39 ft) tall, and have an open branching system; the leaves are opposite, simple elliptic-ovate to oblong, 6–12 cm (2.5–4.5 in) long and 4–8 cm (1.5–3 in) broad, glossy dark green. The flowers are white, 10–15 mm in diameter, and grow in axillary clusters. The seeds are contained in a drupe (commonly called a \"cherry\") 10–15 mm in diameter, maturing bright red to purple and typically containing two seeds, often called coffee beans.")
        }
    };
}
