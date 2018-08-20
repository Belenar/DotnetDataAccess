using System.Data.Entity;
using ExistingClasses;

namespace DataLayer
{
    public class ConsultingContext : DbContext
    {
        public ConsultingContext(string connStr)
            :base(connStr)
        {
        }

        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<ResumeItem> ResumeItems { get; set; }
        public DbSet<Certification> Certifications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResumeItem>().HasKey(i => i.ItemKey);
            modelBuilder.Entity<Consultant>().ToTable("UberPeople");
            modelBuilder.Entity<Consultant>().Property(c => c.FirstName).IsRequired();
            modelBuilder.Entity<Consultant>().Property(c => c.LastName).HasMaxLength(40);
            modelBuilder.Entity<Consultant>().Property(c => c.Birthday).HasColumnType("date");
            modelBuilder.Entity<Consultant>().Property(c => c.Version).IsRowVersion();

            base.OnModelCreating(modelBuilder);
        }
    }
}
