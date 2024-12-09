namespace Kentico.Xperience.UMT.Examples.Utils
{
    internal static class LanguageExtensions
    {
        internal static T Apply<T>(this T subject, Action<T> transformation)
        {
            transformation(subject);
            return subject;
        }
    }
}
