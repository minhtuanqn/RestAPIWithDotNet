using System;
using System.ComponentModel.DataAnnotations;

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
