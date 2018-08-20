using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccess.Part4.ModelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var scope = new TransactionScope())
            {
                using (var context = new ConsultantModelContainer())
                {
                    var consultant = new Consultant
                    {
                        FirstName = "Hannes",
                        LastName = "Lowette",
                        Birthday = new DateTime(1982, 2, 11)
                    };

                    var cert = new Certification
                    {
                        Name = "Awesome certified"
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
                using (var context = new ConsultantModelContainer())
                {
                    var consultant = new Consultant
                    {
                        FirstName = "Hannes",
                        LastName = "Lowette",
                        Birthday = new DateTime(1982, 2, 11)
                    };

                    var cert = new Certification
                    {
                        Name = "Awesome certified"
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
                scope.Complete();
            }
        }
    }
}
