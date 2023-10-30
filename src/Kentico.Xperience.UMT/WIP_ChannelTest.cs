using CMS.ContentEngine;
using CMS.ContentEngine.Internal;
using CMS.EmailLibrary;
using CMS.Websites;

namespace Kentico.Xperience.UMT;

public class WIP_ChannelTest
{
    public WIP_ChannelTest()
    {
        var channelInfo = new ChannelInfo
        {
            ChannelID = 0,
            ChannelDisplayName = null,
            ChannelName = null,
            ChannelType = ChannelType.Website,
            ChannelGUID = default
        };

        var websiteChannelInfo = new WebsiteChannelInfo
        {
            WebsiteChannelID = 0,
            WebsiteChannelDefaultCookieLevel = 0,
            WebsiteChannelGUID = default,
            WebsiteChannelDomain = null,
            WebsiteChannelHomePage = null,
            WebsiteChannelPrimaryContentLanguageID = 0,
            WebsiteChannelChannelID = 0,
            WebsiteChannelStoreFormerUrls = false
        };

        var emailChannelInfo = new EmailChannelInfo
        {
            EmailChannelID = 0,
            EmailChannelGUID = default,
            EmailChannelSendingDomain = null,
            EmailChannelServiceDomain = null,
            EmailChannelChannelID = 0,
            EmailChannelPrimaryContentLanguageID = 0
        };

        var contentItemInfo = new ContentItemInfo
        {
            ContentItemChannelID = 0,
            ContentItemID = 0,
            ContentItemGUID = default,
            ContentItemName = null,
            ContentItemIsReusable = false,
            ContentItemIsSecured = false,
            ContentItemContentTypeID = 0
        };

        var contentItemCommonDataInfo = new ContentItemCommonDataInfo
        {
            ContentItemCommonDataID = 0,                    // nebude součástí modelu, orientujeme se dle GUID 
            ContentItemCommonDataGUID = default,            // důležité, s pomocí této vlastnosti se bude provádět hledání
            ContentItemCommonDataContentItemID = 0,         // nalezeno dle guid
            ContentItemCommonDataContentLanguageID = 0,     // ref na language, nejlepší bude language codename
            ContentItemCommonDataVersionStatus = VersionStatus.InitialDraft, // odvozená vlastnost
            ContentItemCommonDataIsLatest = false,          // odvozená vlastnost
            ContentItemCommonDataPageBuilderWidgets = null, // bude třeba konvertovat na model - vlastnost jako string nedává pro UMT smysl
            ContentItemCommonDataPageTemplateConfiguration = null // bude třeba konvertovat na model - vlastnost jako string nedává pro UMT smysl
        };

        var contentItemLanguageMetadataInfo = new ContentItemLanguageMetadataInfo
        {
            ContentItemLanguageMetadataID = 0,
            ContentItemLanguageMetadataContentItemID = 0,
            ContentItemLanguageMetadataContentLanguageID = 0,
            ContentItemLanguageMetadataDisplayName = null,
            ContentItemLanguageMetadataLatestVersionStatus = VersionStatus.InitialDraft,
            ContentItemLanguageMetadataGUID = default,
            ContentItemLanguageMetadataCreatedWhen = default,
            ContentItemLanguageMetadataCreatedByUserID = 0,
            ContentItemLanguageMetadataModifiedWhen = default,
            ContentItemLanguageMetadataModifiedByUserID = 0,
            ContentItemLanguageMetadataHasImageAsset = false
        };
    }
}
