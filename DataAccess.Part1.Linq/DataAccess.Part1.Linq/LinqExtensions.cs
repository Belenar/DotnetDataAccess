using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Part1.Linq
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> inputList, Predicate<T> filter)
        {
            foreach (var inputItem in inputList)
            {
                if(filter(inputItem))
                    yield return inputItem;
            }
        }

        public static T MyFirstOrDefault<T>(this IEnumerable<T> inputList)
        {
            foreach (var inputItem in inputList)
            {
                return inputItem;
            }
            return default(T);
        }

        public static IEnumerable<IGrouping<TKey, TElement>> MyGroupBy<TKey, TElement>(
            this IEnumerable<TElement> source, Func<TElement, TKey> keySelector)
        {
            var keys = new List<TKey>();

            foreach (var sourceItem in source)
            {
                var key = keySelector(sourceItem);
                if (!keys.Contains(key))
                {
                    keys.Add(key);
                }
            }

            foreach (var key in keys)
            {
                yield return new Grouping<TKey, TElement>(key, source.MyWhere(x => key.Equals(keySelector(x))));
            }
        }
    }
}
