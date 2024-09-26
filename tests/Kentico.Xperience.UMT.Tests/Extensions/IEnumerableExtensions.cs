using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAfterMigration.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> SelectManyRecursive<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> selector)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            return !source.Any() ? source :
                source.Concat(
                    source
                    .SelectMany(i => selector(i))
                    .SelectManyRecursive(selector)
                );
        }
    }
}
