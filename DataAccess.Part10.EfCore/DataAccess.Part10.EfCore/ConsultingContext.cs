using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Part10.EfCore
{
    public class ConsultingContext : DbContext
    {
        public virtual DbSet<Consultant> Consultants { get; set; }
        public virtual DbSet<Certification> Certifications { get; set; }
        public virtual DbSet<ResumeItem> ResumeItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                ConfigurationManager.ConnectionStrings["ConsultingContext"].ConnectionString);
        }
    }
}
