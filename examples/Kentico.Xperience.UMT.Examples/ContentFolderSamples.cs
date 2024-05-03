using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class ContentFolderSamples
{
    [Sample("ContentFolderModel.Sample", "", "Content folder basic sample")]
    public static ContentFolderModel SampleContentFolder => new()
    {
        ContentFolderGUID = new Guid("7665A8FC-53A2-4AFF-86E8-99B009104FF2"),
        ContentFolderName = "articles",
        ContentFolderDisplayName = "Articles",
        ContentFolderTreePath = "/articles",
        ContentFolderParentFolderGUID = null
    };
    
    [Sample("ContentFolderModel.SubFolderSample", "", "Content folder basic sample")]
    public static ContentFolderModel SampleContentSubFolder => new()
    {
        ContentFolderGUID = new Guid("AE29C1D1-217A-45DA-8B30-585D1881387E"),
        ContentFolderName = "obsolete",
        ContentFolderDisplayName = "Obsolete",
        ContentFolderTreePath = "/articles/obsolete",
        ContentFolderParentFolderGUID = SampleContentFolder.ContentFolderGUID
    };
}
