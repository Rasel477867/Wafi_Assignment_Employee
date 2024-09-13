using EmployeesCore.EntityModel.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesCore.EntityModel
{
    public class Employee: AuditableEntity
    {
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }
        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Display(Name ="Date of Birth")]
        [Required]
        public DateOnly? DOB { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Display(Name = "Photo")]
        public string? ImageUrl { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [NotMapped]
        public IFormFile? Image { get; set; }

       
    }
}
