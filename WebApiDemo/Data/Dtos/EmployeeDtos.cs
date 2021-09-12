using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Data.Dtos
{
    public class CreateEmployeeDto
    {
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

    public class EmployeeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public DateTime StartDate { get; set; }

        public string PhoneNumber { get; set; }
    }

    public class UpdateEmployeeDto
    {
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

    public class FilterEmployeeDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public DateTime? MinStartDate { get; set; }

        public DateTime? MaxStartDate { get; set; }

        public string PhoneNumber { get; set; }
    }
}