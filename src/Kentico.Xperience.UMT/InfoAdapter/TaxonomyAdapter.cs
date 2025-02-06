using CMS.ContentEngine;

using Kentico.Xperience.UMT.Model;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class TaxonomyAdapter : GenericInfoAdapter<TaxonomyInfo>
{
    internal TaxonomyAdapter(ILogger<TaxonomyAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
    }

    public override TaxonomyInfo Adapt(IUmtModel input)
    {
        var adapted = base.Adapt(input);

        if (input is TaxonomyModel { TaxonomyTranslations: { } taxonomyTranslations })
        {
            var translations = taxonomyTranslations.ToDictionary(
                x => x.Key,
                x => new TaxonomyTranslation { Title = x.Value.Title }
            );

            var taxonomyMetadata = new TaxonomyMetadata { Translations = translations };
            adapted.TaxonomyMetadata = taxonomyMetadata.Serialize();
        }

        return adapted;
    }
}
