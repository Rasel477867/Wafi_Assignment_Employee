using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EmployeesWeb.Models
{
    public class EmployeeView
    {
     
        [Required]
        public string FirstName { get; set; }
        [Required]
    
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [Required]
        public DateOnly DOB { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Photo")]
        public IFormFile? Image { get; set; }
    }
}
