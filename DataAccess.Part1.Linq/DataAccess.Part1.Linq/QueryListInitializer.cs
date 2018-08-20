using System;
using System.Collections.Generic;

namespace DataAccess.Part1.Linq
{
    class QueryListInitializer
    {
        public static List<DemoClass> GetDemoList1()
        {
            var demoList = new List<DemoClass>();

            for (int i = 1; i <= 26; i++)
            {
                var demoItem = new DemoClass
                {
                    IntProp = i,
                    StringProp = "" + (char)(i + 64) + (char)(i + 64) + (char)(i + 64),
                    DateProp = new DateTime(1900 + i, 1, 1),
                    SubClass = i % 2 == 0 ? null :
                        new DemoSubClass
                        {
                            SubIntProp = i,
                            SubStringProp = "" + (char)(i + 64) + (char)(i + 64) + (char)(i + 64),
                            SubDateProp = new DateTime(1900 + i, 1, 1)
                        }
                };

                demoList.Add(demoItem);
            }
            return demoList;
        }


        public static List<DemoClass> GetDemoList2()
        {
            var demoList2 = new List<DemoClass>();

            for (int i = 1; i <= 26; i++)
            {
                var demoItem2 = new DemoClass
                {
                    IntProp = i + 26,
                    StringProp = "" + (char)(91 - i) + (char)(91 - i) + (char)(91 - i),
                    DateProp = new DateTime(1926 + i, 1, 1),
                    SubClass = i % 2 == 0 ? null :
                        new DemoSubClass
                        {
                            SubIntProp = i + 26,
                            SubStringProp = "" + (char)(91 - i) + (char)(91 - i) + (char)(91 - i),
                            SubDateProp = new DateTime(1926 + i, 1, 1)
                        }
                };

                demoList2.Add(demoItem2);
            }
            return demoList2;
        }
    }
}
