// using CMS.Membership;
// using FluentAssertions;
// using Kentico.Xperience.UMT.ProviderProxy;
// using Microsoft.Extensions.DependencyInjection;
//
// namespace Kentico.Xperience.UMT;
//
// [Collection("UMT.Tests")]
// public class ProviderProxyTests
// {
//     private static readonly ProviderProxyContext providerProxyContext = new("Boilerplate", "en-US");
//
//     [Fact]
//     public void ProviderProxy_UserInfo_GetByGuidTest()
//     {
//         var sp = KenticoFixture.GetUmtServiceProvider();
//         var providerProxyFactory = sp.GetRequiredService<IProviderProxyFactory>();
//         
//         // test assumes, that admin user with particular guid exists in database
//         var proxy = providerProxyFactory.CreateProviderProxy(typeof(UserInfo), providerProxyContext);
//
//         var adminUserGuid = new Guid("6415B8CE-8072-4BCD-8E48-9D7178B826B7");
//         var actual = proxy.GetBaseInfoByGuid(adminUserGuid);
//
//         actual.Should().NotBeNull().And.BeAssignableTo(typeof(UserInfo));
//         actual?[actual.TypeInfo.GUIDColumn].Should().Be(adminUserGuid);
//     }
//
//     [Fact()]
//     public void ProviderProxy_TreeNode_GetByGuidTest()
//     {
//         var sp = KenticoFixture.GetUmtServiceProvider();
//         var providerProxyFactory = sp.GetRequiredService<IProviderProxyFactory>();
//         
//         // test assumes, that root TreeNode with particular guid exists in database
//         var proxy = providerProxyFactory.CreateProviderProxy(typeof(TreeNode), providerProxyContext);
//
//         var rootDocumentGuid = new Guid("AA0FC9AF-C321-41B2-872A-A92A9153E6C4");
//         var actual = proxy.GetBaseInfoByGuid(rootDocumentGuid);
//
//         actual.Should().NotBeNull().And.BeAssignableTo(typeof(TreeNode));
//         actual?[actual.TypeInfo.GUIDColumn].Should().Be(rootDocumentGuid);
//     }
// }
