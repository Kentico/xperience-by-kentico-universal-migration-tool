﻿using CMS.ContentEngine;

using Kentico.Xperience.UMT.Model;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

public class TagAdapter : GenericInfoAdapter<TagInfo>
{
    internal TagAdapter(ILogger<TagAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
    }

    public override TagInfo Adapt(IUmtModel input)
    {
        var adapted = base.Adapt(input);

        if (input is TagModel { TagTranslations: { } tagTranslations })
        {
            var translations = tagTranslations.ToDictionary(
                x => x.Key,
                x => new TagTranslation { Title = x.Value.Title, Description = x.Value.Description }
            );

            var tagMetadata = new TagMetadata { Translations = translations };
            adapted.TagMetadata = tagMetadata.Serialize();
        }

        return adapted;
    }
}
