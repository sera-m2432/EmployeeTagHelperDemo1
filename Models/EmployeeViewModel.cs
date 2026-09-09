using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeTagHelperDemo.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string Address { get; set; } = string.Empty;

        public int DepartmentId { get; set; }
        public SelectList? Departments { get; set; }
    }
}