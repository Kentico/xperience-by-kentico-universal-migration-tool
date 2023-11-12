using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples
{
    public static class AssetSamples
    {
        public static Guid MEDIA_LIBRARY_SAMPLE_GUID = new Guid("E3A9C50C-2B76-4BA8-AC19-2F0AA64C47D5");
        public static MediaFileModel SampleMediaFile => new()
        {
            DataSourcePath = "C:\\Users\\asus\\Desktop\\Model pre websitechannel, emailchan.txt",
            FileGUID = new Guid("214E29AA-32D5-40D7-9FEA-896591439E74"),
            FileCreatedByUserGuid = new Guid("863F796E-823A-4F5E-BBDB-E4A6F15B349B"),
            FileLibraryGuid = MEDIA_LIBRARY_SAMPLE_GUID,
            FileName = "NewTestFile",
            FileTitle = "Title",
            FilePath = "newPath"
        };

        public static MediaLibraryModel SampleMediaLibrary => new()
        {
            LibraryName = "LibrarySample",
            LibraryDisplayName = "LibraryDisplayedName",
            LibraryDescription = "TestLibrary",
            LibraryGUID = MEDIA_LIBRARY_SAMPLE_GUID,
            LibraryFolder = "TestFolder"
        };
    }
}
