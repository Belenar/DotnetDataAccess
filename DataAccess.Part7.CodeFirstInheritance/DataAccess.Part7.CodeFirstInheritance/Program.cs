using System;
using System.Data.Entity;

namespace DataAccess.Part7.CodeFirstInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<VehicleContext>());

            using (var db = new VehicleContext())
            {
                db.Vehicles.Add(new Car { Description = "BMW M4", HorsePower = 431, Seats = 4});
                db.Vehicles.Add(new Boat { Description = "Sun Odyssey 29.2", HullLength = 8.8M, MastHeight = 13.2M });
                db.SaveChanges();

                foreach (var vehicle in db.Vehicles)
                {
                    Console.WriteLine(vehicle.Description);
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
