using System;

namespace DataAccess.Part1.Linq
{
    class DemoClass
    {
        public int IntProp { get; set; }
        public string StringProp { get; set; }
        public DateTime DateProp { get; set; }
        public DemoSubClass SubClass { get; set; }

        public override string ToString()
        {
            return $"Item - Int: {IntProp}, String: {StringProp}, Date: {DateProp}\r\n\t{SubClass}";
        }
    }
}
