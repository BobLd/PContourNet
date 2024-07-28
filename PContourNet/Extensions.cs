using System.Runtime.CompilerServices;

namespace PContourNet
{
    internal static class Extensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="fromIndex">Low endpoint (inclusive) of the subList.</param>
        /// <param name="toIndex">high endpoint (exclusive) of the subList.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> SubList<T>(this IEnumerable<T> source, int fromIndex, int toIndex)
        {
            // https://docs.oracle.com/javase/6/docs/api/java/util/List.html#subList(int,%20int)
            return source.Skip(fromIndex).Take(toIndex - fromIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="fromIndex">Low endpoint (inclusive) of the subList.</param>
        /// <param name="toIndex">high endpoint (exclusive) of the subList.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> SubList<T>(this ReadOnlySpan<T> source, int fromIndex, int toIndex)
        {
            // https://docs.oracle.com/javase/6/docs/api/java/util/List.html#subList(int,%20int)
            return source.Slice(fromIndex, toIndex - fromIndex);
        }
    }
}
