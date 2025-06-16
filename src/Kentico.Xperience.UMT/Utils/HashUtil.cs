using System.Security.Cryptography;
using System.Text;

namespace Kentico.Xperience.UMT.Utils;

public static class HashUtil
{
    public static string Sha256SqlCompatible(string input)
    {
        string lowered = input.ToLowerInvariant();

        Encoding encoding1252 = Encoding.GetEncoding(1252);
        byte[] bytes = encoding1252.GetBytes(lowered);

        using var sha256 = SHA256.Create();
        byte[] hash = sha256.ComputeHash(bytes);

        StringBuilder sb = new(hash.Length * 2);
        foreach (byte b in hash)
        {
            sb.Append(b.ToString("X2"));
        }

        return sb.ToString();
    }
}
