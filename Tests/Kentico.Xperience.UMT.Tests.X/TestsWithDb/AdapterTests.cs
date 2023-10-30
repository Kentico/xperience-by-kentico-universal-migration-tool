// using CMS.Base;
// // using CMS.DocumentEngine; => obsolete
// using CMS.Membership;
// using FluentAssertions;
// using Kentico.Xperience.UMT.InfoAdapter;
// using Kentico.Xperience.UMT.Model;
// using Kentico.Xperience.UMT.ProviderProxy;
// using Microsoft.Extensions.DependencyInjection;
//
// namespace Kentico.Xperience.UMT;
//
// [Collection("UMT.Tests")]
// public class AdapterTests
// {
//     [Fact]
//     public void GenericAdapterTest_TreeNode_WithRequiredDeps()
//     {
//         var sp = KenticoFixture.GetUmtServiceProvider();
//         var providerProxyFactory = sp.GetRequiredService<IProviderProxyFactory>();
//         
//         var providerProxy = providerProxyFactory
//             .CreateProviderProxy(typeof(TreeNode), new("Boilerplate", "en-US"));
//         var documentGuid = new Guid("389E2A56-F2EA-48CD-998C-D44D74691360");
//
//         var logger = KenticoFixture.CreateLogger<GenericInfoAdapter<TreeNode>>();
//         var adapter = new GenericInfoAdapter<TreeNode>(logger, KenticoFixture.ModelService, providerProxy, providerProxyFactory);
//
//         var actual = adapter.Adapt(new TreeNodeModel
//         {
//             NodeOwnerGuid = KenticoFixture.AdminUserGuid,
//             NodeClassGuid = new Guid("299C6ED4-4889-4173-AD19-158A3AD77AFE"), // custom page class Guid ("UMT.Page")
//             NodeParentGuid = KenticoFixture.RootNodeGuid,
//             CustomProperties =
//             {
//                 { "Perex", "Testing perex" }
//             },
//             NodeGUID = new Guid("9C7BC0FE-449A-4CB2-B8DF-BDE1CA377E6C"),
//             NodeAlias = "umt.test.nodealias",
//             NodeName = "umt.test.ndoename",
//             // NodeOrder = null,
//             DocumentCulture = "en-US",
//             DocumentName = "umt.test.documentname",
//             DocumentLastPublished = new DateTime(2023, 01, 01),
//             DocumentModifiedWhen = new DateTime(2023, 01, 01),
//             DocumentCreatedWhen = new DateTime(2023, 01, 01),
//             DocumentPublishFrom = new DateTime(2023, 01, 01),
//             DocumentPublishTo = new DateTime(2026, 01, 01), // root node
//             DocumentGUID = documentGuid,
//             DocumentCreatedByUserGuid = KenticoFixture.AdminUserGuid,
//             DocumentModifiedByUserGuid = KenticoFixture.AdminUserGuid,
//         });
//
//         var actualTreeNode = actual
//             .Should().BeOfType<TreeNode>().Which;
//
//         actualTreeNode.DocumentGUID.Should().Be(documentGuid);
//         actualTreeNode.NodeOwner.Should().Be(53);
//         actualTreeNode.NodeParentID.Should().Be(1);
//         actualTreeNode.NodeClassName.Should().Be("UMT.Page");
//         actualTreeNode.Owner.UserName.Should().Be("administrator");
//         actualTreeNode.GetValue("Perex").Should().Be("Testing perex");
//     }
//
//     [Fact]
//     public void GenericAdapterTest_TreeNode_WithRequiredDeps_Insert()
//     {
//         var sp = KenticoFixture.GetUmtServiceProvider();
//         var providerProxyFactory = sp.GetRequiredService<IProviderProxyFactory>();
//         
//         var providerProxy = providerProxyFactory
//             .CreateProviderProxy(typeof(TreeNode), new("Boilerplate", "en-US"));
//         
//         var documentGuid = new Guid("389E2A56-F2EA-48CD-998C-D44D74691360");
//
//         var logger = KenticoFixture.CreateLogger<GenericInfoAdapter<TreeNode>>();
//         var adapter = new GenericInfoAdapter<TreeNode>(logger, KenticoFixture.ModelService, providerProxy, providerProxyFactory);
//
//         var adapted = adapter.Adapt(new TreeNodeModel
//         {
//             NodeOwnerGuid = KenticoFixture.AdminUserGuid,
//             NodeClassGuid = new Guid("299C6ED4-4889-4173-AD19-158A3AD77AFE"), // custom page class Guid ("UMT.Page")
//             NodeParentGuid = KenticoFixture.RootNodeGuid,
//             CustomProperties =
//             {
//                 { "Perex", "Testing perex" }
//             },
//             NodeGUID = new Guid("9C7BC0FE-449A-4CB2-B8DF-BDE1CA377E6C"),
//             NodeAlias = "umt.test.nodealias",
//             NodeName = "umt.test.ndoename",
//             // NodeOrder = null,
//             DocumentCulture = "en-US",
//             DocumentName = "umt.test.documentname",
//             DocumentLastPublished = new DateTime(2023, 01, 01),
//             DocumentModifiedWhen = new DateTime(2023, 01, 01),
//             DocumentCreatedWhen = new DateTime(2023, 01, 01),
//             DocumentPublishFrom = new DateTime(2023, 01, 01),
//             DocumentPublishTo = new DateTime(2026, 01, 01), // root node
//             DocumentGUID = documentGuid,
//             DocumentCreatedByUserGuid = new Guid("3758B9B5-045C-4B7D-B020-80F9B068D990"),
//             DocumentModifiedByUserGuid = KenticoFixture.AdminUserGuid,
//         });
//         
//         var treeProvider = new TreeProvider(UserInfoProvider.ProviderObject.Get(adapted.NodeOwner))
//         {
//             UseAutomaticOrdering = false,
//             UpdateUser = false,
//             UpdateTimeStamps = false,
//             LogEvents = false,
//             UpdatePaths = false,
//         };
//
//         DocumentHelper.InsertDocument(adapted, adapted.Parent, treeProvider);
//         var actual = adapted;
//
//         KenticoFixture.ObjectsToDelete.Add(actual);
//         
//         var actualTreeNode = actual
//             .Should().BeOfType<TreeNode>().Which;
//
//         actualTreeNode.DocumentGUID.Should().Be(documentGuid);
//         actualTreeNode.NodeOwner.Should().Be(53);
//         actualTreeNode.NodeParentID.Should().Be(1);
//         actualTreeNode.NodeClassName.Should().Be("UMT.Page");
//         actualTreeNode.Owner.UserName.Should().Be("administrator");
//         actualTreeNode.GetValue("Perex").Should().Be("Testing perex");
//         actualTreeNode.DocumentCreatedByUserID.Should().Be(65);
//     }
//
//     [Fact]
//     public void GenericAdapterTest_UserInfo()
//     {
//         var sp = KenticoFixture.GetUmtServiceProvider();
//         var providerProxyFactory = sp.GetRequiredService<IProviderProxyFactory>();
//         
//         var providerProxy = providerProxyFactory
//             .CreateProviderProxy(typeof(UserInfo), new("Boilerplate", "en-US"));
//         var logger = KenticoFixture.CreateLogger<GenericInfoAdapter<UserInfo>>();
//         var adapter = new GenericInfoAdapter<UserInfo>(logger, KenticoFixture.ModelService, providerProxy, providerProxyFactory);
//
//         var adapted = adapter.Adapt(new UserInfoModel
//         {
//             UserName = "super_user",
//             FirstName = "Super",
//             LastName = "User",
//             Email = "super.user@host.localhost",
//             UserPassword = "somepwdhash",
//             UserEnabled = true,
//             UserCreated = new DateTime(2023, 01, 01),
//             LastLogon = null,
//             UserGUID = new Guid("2FC2EBB3-F8C5-4977-B3F6-30BDC8C26B33"),
//             UserLastModified = null,
//             UserSecurityStamp = null,
//             UserPasswordLastChanged = null,
//             UserIsPendingRegistration = false,
//             UserRegistrationLinkExpiration = null,
//             UserAdministrationAccess = true,
//             UserIsExternal = false
//         });
//
//         using (new CMSActionContext(UserInfoProvider.AdministratorUser)
//                {
//                    User = UserInfoProvider.AdministratorUser,
//                    UseGlobalAdminContext = true
//                })
//         {
//             MembershipContext.AuthenticatedUser = UserInfoProvider.AdministratorUser;
//             UserInfoProvider.ProviderObject.Set(adapted);
//         }
//
//         var actual = adapted;
//
//         KenticoFixture.ObjectsToDelete.Add(actual);
//         
//         var actualTreeNode = actual
//             .Should().BeOfType<UserInfo>().Which;
//
//         actualTreeNode.UserName.Should().Be("super_user");
//         actualTreeNode.FirstName.Should().Be("Super");
//         actualTreeNode.LastName.Should().Be("User");
//         actualTreeNode.UserGUID.Should().Be(new Guid("2FC2EBB3-F8C5-4977-B3F6-30BDC8C26B33"));
//     }
// }
