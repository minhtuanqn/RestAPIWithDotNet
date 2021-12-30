using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("Staff")]
    public class Staff
    {
        [Key]
        [Column("Id")]
        public Guid id { get; set; }

        [Column("FirstName")]
        public string firstName { get; set; }

        [Column("LastName")]
        public string lastName { get; set; }

        [Column("Age")]
        public int age { get; set; }

        [Column("DepartmentId")]
        public Guid departmentId { get; set; }

        [Column("Status")]
        public bool status { get; set; }

    }
}
