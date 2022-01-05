using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto
{
    public class UserDTO
    {
        public Guid id { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public int age { get; set; }

        [Required]
        public string role { get; set; }

        [Required]
        public Guid departmentId { get; set; }

    }
}
