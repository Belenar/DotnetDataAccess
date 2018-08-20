using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExistingClasses
{
    [Table("UberPeople")]
    public class Consultant
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [MinLength(5)]
        [MaxLength(40)]
        public string LastName { get; set; }
        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        public List<ResumeItem> Resume { get; set; }
    }
}
