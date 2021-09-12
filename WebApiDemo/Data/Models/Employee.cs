using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Data.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        [MaxLength(64)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(64)]
        public string Email { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        [MaxLength(32)]
        public string PhoneNumber { get; set; }
    }
}