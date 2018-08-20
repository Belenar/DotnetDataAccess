using System;
using System.Collections.Generic;

namespace DataAccess.Part1.Linq
{
    class Program
    {
        private static List<DemoClass> _queryList = QueryListInitializer.GetDemoList1();
        private static List<DemoClass> _queryList2 = QueryListInitializer.GetDemoList2();

        static void Main(string[] args)
        {
            /* SELECTING SINGLE ITEMS */

            // First (exception when the colletion is empty)
            // var queryItem = _queryList.First();

            // FirstOrDefault (returns default (null, 0, ...) when list is empty)
            // var queryItem = _queryList.FirstOrDefault();

            // Single (exception when there is more than 1 item)
            // var queryItem = _queryList.Single();

            // Find (same as Where(...).First())
            // var queryItem = _queryList.Find(x => x.StringProp == "BBB");

            // Further options: SingleOrDefault, Last, LastOrDefault, FindLast, ElementAt, ElementAtOrDefault, ...

            /* FILTERING AND SORTING */

            // A Simple WHERE
            // var query = _queryList.Where(x => x.IntProp > 17);

            // Ordering
            // var query = _queryList.OrderByDescending(x => x.IntProp);

            // Combining statements
            // var query = _queryList.Where(x => x.IntProp > 17)
            //                       .OrderByDescending(x => x.IntProp);

            // Further options: Skip, Take, OrderBy, ...

            /* GROUPING, UNION, ETC */

            // Union
            // var query = _queryList.Union(_queryList2);

            // Grouping
            // var groupedQuery = _queryList.Union(_queryList2)
            //                              .GroupBy(x => x.StringProp);

            /* HOMEBREW LINQ */
            // var queryItem = _queryList.MyWhere(x => x.IntProp > 14).MyFirstOrDefault();

            /* PRINTING THE RESULTS */

            // Printing a Single Item:
            // Console.WriteLine(queryItem);

            // Printing a list:
            // foreach (var queryItem in query)
            // {
            //     Console.WriteLine(queryItem);
            // }

            // Printing a grouped List:
            // foreach (var group in groupedQuery)
            // {
            //     Console.WriteLine($"GROUP: {group.Key}");
            //     foreach (var item in group)
            //     {
            //         Console.WriteLine(item);
            //     }
            //     Console.WriteLine();
            // }

            Console.ReadKey();
        }
    }
}
