using System.Collections.Generic;

namespace DataAccess.Part10.EfCore
{
    public class Certification
    {
        public Certification()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            ResumeItem = new HashSet<ResumeItem>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string CertificationCode { get; set; }
        public virtual ICollection<ResumeItem> ResumeItem { get; set; }
    }
}
