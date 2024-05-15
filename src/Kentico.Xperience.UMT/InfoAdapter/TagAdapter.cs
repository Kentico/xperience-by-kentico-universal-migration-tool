using CMS.ContentEngine;

using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Services.Model;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class TagAdapter: GenericInfoAdapter<TagInfo>
{
    internal TagAdapter(ILogger<TagAdapter> logger, UmtModelService modelService, IProviderProxy providerProxy, IProviderProxyFactory providerProxyFactory) : base(logger, modelService, providerProxy, providerProxyFactory)
    {
    }

    public override TagInfo Adapt(IUmtModel input)
    {
        var adapted = base.Adapt(input);

        if (input is TagModel {TagTranslations: {} tagTranslations})
        {
            var translations = tagTranslations.ToDictionary(
                x => x.Key,
                x => new TagTranslation { Title = x.Value.Title, Description = x.Value.Description}
            );
            
            var tagMetadata = new TagMetadata { Translations = translations };
            adapted.TagMetadata = tagMetadata.Serialize();
        }
        
        return adapted;
    }
}
