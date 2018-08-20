using System;
using System.Linq;

namespace DataAccess.Part2.DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AWEntities())
            {
                var query = from c in context.Customers
                            where c.FirstName.StartsWith("D")
                            select c;

                var result = query.ToList();

                foreach (var cust in result)
                {
                    Console.WriteLine($"{cust.FirstName} {cust.LastName}");
                }
            }
            Console.ReadLine();
        }
    }
}