using CMS.DataEngine;
using CMS.Websites.Internal;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Services.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class WebPageUrlPathAdapter: GenericInfoAdapter<WebPageUrlPathInfo>
{
    internal WebPageUrlPathAdapter(ILogger<WebPageUrlPathAdapter> logger, UmtModelService modelService, IProviderProxy providerProxy, IProviderProxyFactory providerProxyFactory) : base(logger, modelService, providerProxy, providerProxyFactory)
    {
    }

    public override WebPageUrlPathInfo Adapt(IUmtModel input)
    {
        var adapted = base.Adapt(input);

        if (string.IsNullOrWhiteSpace(adapted.WebPageUrlPathHash))
        {
            try
            {
                using var conn = new SqlConnection(ConnectionHelper.ConnectionString);
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', LOWER(@path)), 2)";
                cmd.Parameters.AddWithValue("path", adapted.WebPageUrlPath);
                if (cmd.ExecuteScalar() is string result)
                {
                    adapted.WebPageUrlPathHash = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Failed to create SHA256 hash for PageUrlPath: {PageUrlPath}", input.PrintMe());
            }
        }

        return adapted;
    }
}
