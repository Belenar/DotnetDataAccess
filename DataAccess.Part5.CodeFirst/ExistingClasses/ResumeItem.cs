using System;
using System.ComponentModel.DataAnnotations;

namespace ExistingClasses
{
    public class ResumeItem
    {
        [Key]
        public int ItemKey { get; set; }
        public DateTime DateAcquired { get; set; }

        public Consultant Consultant { get; set; }
        public Certification Certification { get; set; }
    }
}