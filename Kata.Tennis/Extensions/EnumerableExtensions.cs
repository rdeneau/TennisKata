// ReSharper disable once CheckNamespace
namespace System.Collections.Generic
{
    public static class EnumerableExtensions
    {
        public static string JoinToString<T>(this IEnumerable<T> @this, string separator) =>
            string.Join(separator, @this);
    }
}
