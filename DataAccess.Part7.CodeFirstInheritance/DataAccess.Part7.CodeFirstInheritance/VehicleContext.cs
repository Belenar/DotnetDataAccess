using System.Data.Entity;

namespace DataAccess.Part7.CodeFirstInheritance
{
    public class VehicleContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
