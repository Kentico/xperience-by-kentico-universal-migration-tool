using CMS.Base;

namespace Kentico.Xperience.UMT.Model;

public class UploadedFile : IUploadedFile
{
    public Stream InputStream { get; }

    public string? ContentType { get; }

    public long Length { get; }

    public string FileName { get; }

    private UploadedFile(Stream stream, string contentType, long length, string fileName)
    {
        InputStream = stream;
        FileName = fileName;
        Length = length;
        ContentType = contentType;
    }

    private UploadedFile(Stream stream, long length, string fileName)
    {
        InputStream = stream;
        FileName = fileName;
        Length = length;
    }

    public static IUploadedFile FromStream(Stream stream, string contentType, long length, string fileName) =>
        new UploadedFile(stream, contentType, length, fileName);

    public static IUploadedFile FromStream(Stream stream, long length, string fileName) =>
        new UploadedFile(stream, length, fileName);

    public static IUploadedFile FromByteArray(byte[] byteArray, string contentType, long length, string fileName) =>
        new UploadedFile(new MemoryStream(byteArray), contentType, length, fileName);

    public Stream OpenReadStream() => InputStream;

    public bool CanOpenReadStream => InputStream.CanRead;
}
