using System;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Part10.EfCore
{
    class Program
    {
        static void Main()
        {
            using (var context = new ConsultingContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Database.Migrate();

                var consultant = new Consultant
                {
                    FirstName = "Hannes",
                    LastName = "Lowette",
                    Birthday = new DateTime(1982, 2, 11)
                };

                var cert = new Certification
                {
                    CertificationCode = "ACC",
                    Name = "Awesome certified coach"
                };

                var resumeItem = new ResumeItem
                {
                    Consultant = consultant,
                    Certification = cert,
                    DateAcquired = DateTime.Today
                };

                context.ResumeItems.Add(resumeItem);

                context.SaveChanges();
            }
        }
    }
}
