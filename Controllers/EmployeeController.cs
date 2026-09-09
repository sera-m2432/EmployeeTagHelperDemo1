using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeTagHelperDemo.Models;

namespace EmployeeTagHelperDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Department> _departments = new()
        {
            new Department { Id = 1, Name = "Software Engineering" },
            new Department { Id = 2, Name = "Human Resources" },
            new Department { Id = 3, Name = "Quality Assurance" }
        };

        private static List<Employee> _employees = new()
        {
            new Employee { Id = 1, Name = "Sara Mohamed", Salary = 15000, Address = "Sadat City", DepartmentId = 1 },
            new Employee { Id = 2, Name = "Ahmed Ali", Salary = 12000, Address = "Cairo", DepartmentId = 2 }
        };

        // Get All Employees
        public IActionResult Index()
        {
            return View(_employees);
        }

        // GET: Edit/Update Employee
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = _employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();

            var viewModel = new EmployeeViewModel
            {
                Id = emp.Id,
                Name = emp.Name,
                Salary = emp.Salary,
                Address = emp.Address,
                DepartmentId = emp.DepartmentId,
                Departments = new SelectList(_departments, "Id", "Name", emp.DepartmentId)
            };

            return View(viewModel);
        }

        // POST: Edit/Update Employee using Tag Helpers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var emp = _employees.FirstOrDefault(e => e.Id == model.Id);
                if (emp != null)
                {
                    emp.Name = model.Name;
                    emp.Salary = model.Salary;
                    emp.Address = model.Address;
                    emp.DepartmentId = model.DepartmentId;
                }
                return RedirectToAction(nameof(Index));
            }

            model.Departments = new SelectList(_departments, "Id", "Name", model.DepartmentId);
            return View(model);
        }

        // GET: Create Employee
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new EmployeeViewModel
            {
                Departments = new SelectList(_departments, "Id", "Name")
            };
            return View(viewModel);
        }

        // POST: Create Employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                int newId = _employees.Any() ? _employees.Max(e => e.Id) + 1 : 1;
                _employees.Add(new Employee
                {
                    Id = newId,
                    Name = model.Name,
                    Salary = model.Salary,
                    Address = model.Address,
                    DepartmentId = model.DepartmentId
                });
                return RedirectToAction(nameof(Index));
            }

            model.Departments = new SelectList(_departments, "Id", "Name", model.DepartmentId);
            return View(model);
        }
    }
}