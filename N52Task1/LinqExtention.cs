namespace N52Task1;

public static class LinqExtention
{
    public static IEnumerable<(TSource, TSource)> ZipIntersect<TSource, TKey>(
        this ICollection<TSource> sourceA,
        ICollection<TSource> sourceB,
        Func<TSource, TKey> keySelector
        ) where TKey : notnull
    {
        if ( sourceA == null)
            throw new ArgumentNullException(nameof(sourceA));
        
        if ( sourceB == null)
            throw new ArgumentNullException(nameof(sourceB));

        if ( keySelector == null )
            throw new ArgumentNullException(nameof(keySelector));

        return ZipIntersectByIterator<TSource, TKey>(sourceA, sourceB, keySelector);
    }

    private static IEnumerable<(TSource, TSource)> ZipIntersectByIterator<TSource, TKey>(
        this ICollection<TSource> sourceA,
        ICollection<TSource> sourceB,
        Func<TSource, TKey> keySelector
        )  where TKey: notnull
    {
        
        foreach(var itemA in sourceA)
        {
            var key = keySelector(itemA);
            var itemB = sourceB.FirstOrDefault(element => keySelector(element).Equals(key));

            if ( itemB != null)
            {
                yield return (itemA, itemB);
            }
        }
    }
}