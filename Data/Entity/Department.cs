using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    [Table("Department")]
    public class Department
    {
        [Key]
        [Column("Id")]
        public Guid id { get; set; }

        [Column("name")]
        public string name { get; set; }

    }
}
