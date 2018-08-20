using System;

namespace DataAccess.Part9.Dapper
{
    public static class Extensions
    {
        public static object ConvertNullValue(this object value)
        {
            return (value == DBNull.Value) ? null : value;
        }
    }
}
