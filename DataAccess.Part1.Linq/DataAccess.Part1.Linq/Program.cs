using System;
using System.Collections.Generic;

namespace DataAccess.Part1.Linq
{
    class Program
    {
        private static IEnumerable<DemoClass> _queryList = QueryListInitializer.GetDemoList1();
        private static List<DemoClass> _queryList2 = QueryListInitializer.GetDemoList2();

        static void Main(string[] args)
        {
            /* PRINTING THE RESULTS */

            // Printing a Single Item:
            // Console.WriteLine(queryItem);

            // Printing a list:
            //foreach (var queryItem in query)
            //{
            //    Console.WriteLine(queryItem);
            //}

            // Printing a grouped List:
            //foreach (var group in groupedQuery)
            //{
            //    Console.WriteLine($"GROUP: {group.Key}");

            //    foreach (var item in group)
            //    {
            //        Console.WriteLine(item);
            //    }
            //    Console.WriteLine();
            //}

            Console.ReadKey();
        }
    }
}
