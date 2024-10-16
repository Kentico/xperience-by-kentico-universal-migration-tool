namespace Kentico.Xperience.UMT.Utils
{
    public static class LanguageExtensions
    {
        public static T Apply<T>(this T subject, Action<T> transformation)
        {
            transformation(subject);
            return subject;
        }
    }
}
