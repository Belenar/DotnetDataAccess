using System;
using System.Collections.Generic;

namespace ExistingClasses
{
    public class Consultant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public List<ResumeItem> Resume { get; set; }
    }
}
