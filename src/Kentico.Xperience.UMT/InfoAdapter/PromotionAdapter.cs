using System.Reflection;

using CMS.Commerce;

using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class PromotionAdapter : GenericInfoAdapter<PromotionInfo>
{
    internal PromotionAdapter(ILogger<PromotionAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
    }

    protected override void SetValue(PromotionInfo current, string propertyName, object? value)
    {
        if (propertyName == nameof(Model.PromotionModel.PromotionRuleConfiguration) && value is string ruleConfiguration)
        {
            // Use reflection to set the internal PromotionRuleConfiguration property
#pragma warning disable S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields
            var propertyInfo = typeof(PromotionInfo).GetProperty(
                nameof(Model.PromotionModel.PromotionRuleConfiguration),
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
#pragma warning restore S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields

            if (propertyInfo != null)
            {
                propertyInfo.SetValue(current, ruleConfiguration);
                return;
            }

            Logger.LogWarning("Failed to find property {PropertyName} via reflection on {TypeName}",
                propertyName, nameof(PromotionInfo));
        }

        base.SetValue(current, propertyName, value);
    }
}
