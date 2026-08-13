using Company.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    public class DepartmentController : Controller
    {
        CompanyDbContext companyDbContext = new CompanyDbContext();
        public IActionResult GoDepartmentPage()
        {
            List<Department> departments = companyDbContext.Departments.ToList();
            return View("Department",departments);
        }

        public IActionResult AddDepartment()
        {
            return View("AddForm");
        }

        public IActionResult SaveDepartment(Department department)
        {
            companyDbContext.Departments.Add(department);
            companyDbContext.SaveChanges();
            return RedirectToAction("GoDepartmentPage");
        }

        public IActionResult DeleteDepartment(int id)
        {
            var department = companyDbContext.Departments.FirstOrDefault(s => s.Id == id);
            companyDbContext.Departments.Remove(department);
            companyDbContext.SaveChanges();
            return RedirectToAction("GoDepartmentPage");
        }

        public IActionResult EditDepartment(int id)
        {
            var department = companyDbContext.Departments.FirstOrDefault(s => s.Id == id);
            return View("EditForm",department);
        }

        public IActionResult SaveUpdatedDepartment(Department updatedDepartment)
        {
            var department = companyDbContext.Departments.FirstOrDefault(s => s.Id == updatedDepartment.Id);
            department.Name = updatedDepartment.Name;
            companyDbContext.SaveChanges();
            return RedirectToAction("GoDepartmentPage");
        }

        public IActionResult ShowEmployees(int id)
        {
            ViewData["Employees"] = companyDbContext.Employees.ToList();
            ViewData["Projects"] = companyDbContext.Projects.ToList();
            var department = companyDbContext.Departments.FirstOrDefault(s => s.Id == id);
            return View("EmployeesInDepartment",department);
        }
    }
}
