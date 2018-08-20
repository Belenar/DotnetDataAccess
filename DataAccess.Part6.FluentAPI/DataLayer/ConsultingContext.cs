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
            // We can extend here

            base.OnModelCreating(modelBuilder);
        }
    }
}
