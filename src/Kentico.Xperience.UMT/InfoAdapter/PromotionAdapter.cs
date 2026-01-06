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
            var propertyInfo = typeof(PromotionInfo).GetProperty(
                nameof(Model.PromotionModel.PromotionRuleConfiguration),
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            if (propertyInfo != null)
            {
                propertyInfo.SetValue(current, ruleConfiguration);
                return;
            }
        }

        base.SetValue(current, propertyName, value);
    }
}
