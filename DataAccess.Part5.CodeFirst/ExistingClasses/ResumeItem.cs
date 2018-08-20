using System;

namespace ExistingClasses
{
    public class ResumeItem
    {
        public int Id { get; set; }
        public DateTime DateAcquired { get; set; }

        public Consultant Consultant { get; set; }
        public Certification Certification { get; set; }
    }
}