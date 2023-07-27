using CMS.DocumentEngine;
using Kentico.Xperience.UMT.ProviderProxy;
using Kentico.Xperience.UMT.Services.Model;
using Microsoft.Extensions.Logging;

namespace Kentico.Xperience.UMT.InfoAdapter;

internal class TreeNodeAdapter: GenericInfoAdapter<TreeNode>
{
    internal TreeNodeAdapter(ILogger<TreeNodeAdapter> logger, UmtModelService modelService, TreeProviderProxy providerProxy) : base(logger, modelService, providerProxy)
    {
    }
}
