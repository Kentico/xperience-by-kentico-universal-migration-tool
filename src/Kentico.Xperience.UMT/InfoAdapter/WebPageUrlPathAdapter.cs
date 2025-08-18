using CMS.DataEngine;
using CMS.Websites.Internal;

using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.Utils;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class WebPageUrlPathAdapter : GenericInfoAdapter<WebPageUrlPathInfo>
{
    internal WebPageUrlPathAdapter(ILogger<WebPageUrlPathAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
    {
    }

    public override WebPageUrlPathInfo Adapt(IUmtModel input)
    {
        ((WebPageUrlPathModel)input).WebPageUrlPathIsCanonical ??= true;

        var adapted = base.Adapt(input);
        using var conn = new SqlConnection(ConnectionHelper.ConnectionString);
        conn.Open();
        using var cmd = conn.CreateCommand();

        if (string.IsNullOrWhiteSpace(adapted.WebPageUrlPathHash))
        {
            adapted.WebPageUrlPathHash = HashUtil.Sha256SqlCompatible(adapted.WebPageUrlPath);
        }

        if (adapted.WebPageUrlPathIsDraft && adapted.WebPageUrlPathPublishedWebPageUrlPathID == 0)
        {
            try
            {
                adapted.WebPageUrlPathPublishedWebPageUrlPathID = WebPageUrlPathInfo.Provider.Get()
                    .WhereEquals(nameof(WebPageUrlPathInfo.WebPageUrlPathContentLanguageID), adapted.WebPageUrlPathContentLanguageID)
                    .WhereEquals(nameof(WebPageUrlPathInfo.WebPageUrlPathWebPageItemID), adapted.WebPageUrlPathWebPageItemID)
                    .WhereEquals(nameof(WebPageUrlPathInfo.WebPageUrlPathIsDraft), 0).Single()
                    .WebPageUrlPathID;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Failed to find published (IsDraft = 0) CMS_WebPageUrlPath row for draft row {WebPageUrlPath}", input.PrintMe());
            }
        }

        return adapted;
    }
}
