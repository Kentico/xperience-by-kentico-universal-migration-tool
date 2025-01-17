using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples
{
    public static class AssetSamples
    {
        public static readonly Guid MEDIA_LIBRARY_SAMPLE_GUID = new("E3A9C50C-2B76-4BA8-AC19-2F0AA64C47D5");

        [Sample("mediafile.sample.fromdisk", "", "Sample of media file loaded from disk")]
        public static MediaFileModel SampleMediaFile => new()
        {
            DataSourcePath = "##ASSETDIR##\\sample.png",
            FileGUID = new Guid("214E29AA-32D5-40D7-9FEA-896591439E74"),
            FileCreatedByUserGuid = new Guid("863F796E-823A-4F5E-BBDB-E4A6F15B349B"),
            FileLibraryGuid = MEDIA_LIBRARY_SAMPLE_GUID,
            FileName = "NewTestFile",
            FileExtension = ".png",
            FileTitle = "Title",
            FilePath = "customdir/NewTestFile.png"
        };

        [Sample("mediafile.sample.fromurl", "", "Sample of media file downloaded from url")]
        public static MediaFileModel SampleMediaFileFromUri => new()
        {
            DataSourceUrl = "https://devnet.kentico.com/DevNet/media/devnet/cms_screen.jpg",
            FileGUID = new Guid("94DF1156-C85D-4356-8E28-16D71C6AC899"),
            FileCreatedByUserGuid = new Guid("863F796E-823A-4F5E-BBDB-E4A6F15B349B"),
            FileLibraryGuid = MEDIA_LIBRARY_SAMPLE_GUID,
            FileName = "NewTestFileFromUri",
            FileExtension = ".jpg",
            FileTitle = "Old devnet screen",
            FilePath = "customdir/NewTestFileFromUri.jpg"
        };

        // https://res-5.cloudinary.com/xperience-io/image/upload/c_lfill,dpr_1,w_768/f_auto,q_auto/v1/homepage/k-02-your-real-needs-at-its-core-1600x1200px_ihqknl

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
