using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace DataAccess.Part7.CodeFirstInheritance
{
    public class VehicleContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boat>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Boats");
            });

            modelBuilder.Entity<Car>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Cars");
            });

            modelBuilder.Entity<Boat>()
            .Property(p => p.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Car>()
            .Property(p => p.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
