using System.Collections.Generic;

namespace DataAccess.Part10.EfCore
{

    
    public class Consultant
    {
        public Consultant()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            ResumeItem = new HashSet<ResumeItem>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime Birthday { get; set; }
    
        public virtual ICollection<ResumeItem> ResumeItem { get; set; }
    }
}
