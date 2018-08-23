using System;

namespace DataAccess.Part10.EfCore
{
    public class ResumeItem
    {
        public int Id { get; set; }
        public DateTime DateAcquired { get; set; }
    
        public virtual Consultant Consultant { get; set; }
        public virtual Certification Certification { get; set; }
    }
}
