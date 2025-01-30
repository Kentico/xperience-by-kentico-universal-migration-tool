using CMS.DataEngine;
using CMS.Websites;

using Kentico.Xperience.UMT.Model;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter
{
    internal class WebPageFormerUrlPathAdapter : GenericInfoAdapter<WebPageFormerUrlPathInfo>
    {
        internal WebPageFormerUrlPathAdapter(ILogger<WebPageFormerUrlPathAdapter> logger, GenericInfoAdapterContext adapterContext) : base(logger, adapterContext)
        {
        }

        public override WebPageFormerUrlPathInfo Adapt(IUmtModel input)
        {
            var adapted = base.Adapt(input);

            if (string.IsNullOrWhiteSpace(adapted.WebPageFormerUrlPathHash))
            {
                try
                {
                    using var conn = new SqlConnection(ConnectionHelper.ConnectionString);
                    conn.Open();
                    using var cmd = conn.CreateCommand();
                    cmd.CommandText = $"SELECT CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', LOWER(@path)), 2)";
                    cmd.Parameters.AddWithValue("path", adapted.WebPageFormerUrlPath);
                    if (cmd.ExecuteScalar() is string result)
                    {
                        adapted.WebPageFormerUrlPathHash = result;
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, "Failed to create SHA256 hash for PageFormerUrlPath: {PageFormerUrlPath}", input.PrintMe());
                }
            }

            return adapted;
        }
    }
}
