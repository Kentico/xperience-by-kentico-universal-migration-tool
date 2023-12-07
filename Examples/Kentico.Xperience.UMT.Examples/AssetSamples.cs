using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples
{
    public static class AssetSamples
    {
        public static Guid MEDIA_LIBRARY_SAMPLE_GUID = new Guid("E3A9C50C-2B76-4BA8-AC19-2F0AA64C47D5");
        
        [Sample("mediafile.sample", "", "Sample of media file")]
        public static MediaFileModel SampleMediaFile => new()
        {
            // TODO tomas.krch: 2023-11-26 CHANGE SAMPLE => PATH SHALL BE RELATIVE TO SAMPLE PROJECT
            DataSourcePath = ".\\sample.png",
            DataSourceBase64 = "",
            FileGUID = new Guid("214E29AA-32D5-40D7-9FEA-896591439E74"),
            FileCreatedByUserGuid = new Guid("863F796E-823A-4F5E-BBDB-E4A6F15B349B"),
            FileLibraryGuid = MEDIA_LIBRARY_SAMPLE_GUID,
            FileName = "NewTestFile.png",
            FileExtension = ".png",
            FileTitle = "Title",
            FilePath = "newPath/somepath",
            CustomProperties =
            {
                {"", ""}
            }
        };

        [Sample("medialibrary.sample", "", "Sample of media library")]
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
