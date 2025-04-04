﻿namespace Kentico.Xperience.UMT.Utils
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
