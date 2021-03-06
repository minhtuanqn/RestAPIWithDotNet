using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("Department")]
    public class Department
    {
        [Key]
        [Column("Id")]
        public Guid id { get; set; }

        [Column("Name")]
        public string name { get; set; }

        [Column("Status")]
        public bool status { get; set; }

        public virtual ICollection<User> users { get; set; } 
    }
}
