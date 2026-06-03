using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class WebPageFolderSamples
{
    [Sample("WebPageFolderModel.Sample", "This sample describes how to create a web page folder in the content tree", "Web Page Folder Sample")]
    public static WebPageFolderModel SampleWebPageFolder => new()
    {
        WebPageFolderGUID = new Guid("F47AC10B-58CC-4372-A567-0E02B2C3D479"),
        WebPageFolderName = "TestFolder",
        WebPageFolderDisplayName = "Test Folder",
        WebPageFolderTreePath = "/test-folder",
        WebPageFolderParentGUID = null,
        WebsiteChannelName = "websitechannelExample",
        LanguageName = "en-US",
        WebPageFolderOrder = 0
    };

    [Sample("WebPageFolderModel.NestedSample", "This sample describes how to create a nested web page folder", "Nested Web Page Folder Sample")]
    public static WebPageFolderModel SampleNestedWebPageFolder => new()
    {
        WebPageFolderGUID = new Guid("A1B2C3D4-E5F6-7890-ABCD-EF1234567890"),
        WebPageFolderName = "NestedTestFolder",
        WebPageFolderDisplayName = "Nested Test Folder",
        WebPageFolderTreePath = "/test-folder/nested-folder",
        WebPageFolderParentGUID = SampleWebPageFolder.WebPageFolderGUID,
        WebsiteChannelName = "websitechannelExample",
        LanguageName = "en-US",
        WebPageFolderOrder = 0
    };
}
