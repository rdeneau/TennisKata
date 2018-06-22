using System.Collections.Generic;
using System.Linq;

namespace Kata.Tennis
{
    public static class EnumerableExtensions
    {
        public static string JoinToString<T>(this IEnumerable<T> @this, string separator) =>
            string.Join(separator, @this);

        public static IEnumerable<T> DefaultsIfEmpty<T>(this IEnumerable<T> @this, IEnumerable<T> defaults) =>
            @this.Any() ? @this : defaults.DefaultIfEmpty();
    }
}
