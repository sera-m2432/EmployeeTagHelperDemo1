using System.ComponentModel.DataAnnotations;

namespace EmployeeTagHelperDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Employee Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Salary is required")]
        [Range(3000, 100000, ErrorMessage = "Salary must be between 3000 and 100000")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}