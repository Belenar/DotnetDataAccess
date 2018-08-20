using System.Collections.Generic;

namespace ExistingClasses
{
    public class Certification
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string CertificationCode { get; set; }

        public List<ResumeItem> ResumeItems { get; set; }
    }
}