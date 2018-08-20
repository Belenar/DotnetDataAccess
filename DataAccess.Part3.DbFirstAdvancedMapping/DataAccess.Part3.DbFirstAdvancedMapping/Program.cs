using System;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Part3.DbFirstAdvancedMapping
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AW2012Entities())
            {
                // Complex types
                foreach (var customer in context.Customers.Where(c => c.Name.FirstName.StartsWith("D")))
                {
                    Console.WriteLine($"{customer.Name.FirstName} {customer.Name.LastName}");
                }
                Console.ReadLine();

                // TPH mapping on the SalesOrderHeader table and Enums
                // If you want to see a different Status, change the Status field in the DB
                // If you want to see some PendingOrder objects, set the ShipDate to NULL in the DB for some records
                foreach (var order in context.Orders)
                {
                    Console.WriteLine($"{order.SalesOrderID} - {order.Status} - {order.GetType().BaseType}");
                }
                Console.ReadLine();
            }

            using (var context = new SchoolEntities())
            {
                // TPH mapping for Courses, OnlineCourses and OnSiteCourse
                foreach (var course in context.Courses)
                {
                    Console.WriteLine($"{course.Title} - {course.GetType().BaseType}");
                }
                Console.ReadLine();
            }
        }
    }
}
