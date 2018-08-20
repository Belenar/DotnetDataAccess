using System;
using System.Data.Entity;
using DataLayer;
using ExistingClasses;

namespace DataAccess.Part5.CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ConsultingContext>());
            CreateConsultant();
        }

        private static void CreateConsultant()
        {
            //Consultant
            var consultant = new Consultant
            {
                FirstName = "Hannes",
                LastName = "Lowette",
                Birthday = new DateTime(1982, 02, 11)
            };
            //Certification
            var certification = new Certification
            {
                CertificationCode = "70-433",
                Name = "SQL Server 2008 - Database Development"
            };
            //ResumeItem
            var resumeItem = new ResumeItem
            {
                Certification = certification,
                Consultant = consultant,
                DateAcquired = new DateTime(2010, 05, 06)
            };


            //EF via DbContext weg.
            var db = new ConsultingContext("Data Source=WIN10DEVMACHINE;Initial Catalog=DemoDatabase;Integrated Security=True");

            db.Consultants.Add(consultant);
            db.Certifications.Add(certification);
            db.ResumeItems.Add(resumeItem);

            db.SaveChanges();
        }
    }
}
