using System;

namespace DataAccess.Part1.Linq
{
    class DemoSubClass
    {
        public int SubIntProp { get; set; }
        public string SubStringProp { get; set; }
        public DateTime SubDateProp { get; set; }

        public override string ToString()
        {
            return $"[SubItem - Int: {SubIntProp}, String: {SubStringProp}, Date: {SubDateProp}]";
        }
    }
}
