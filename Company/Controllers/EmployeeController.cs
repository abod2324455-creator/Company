using Company.Models;
using Company.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyDbContext companyDbContext = new CompanyDbContext();
        public IActionResult GoEmployeePage()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            employeeViewModel.employees = companyDbContext.Employees.ToList();
            employeeViewModel.departments = companyDbContext.Departments.ToList();
            employeeViewModel.projects = companyDbContext.Projects.ToList();
            return View("Employee",employeeViewModel);
        }

        public IActionResult AddEmployee()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.departments = companyDbContext.Departments.ToList();
            employeeViewModel.projects = companyDbContext.Projects.ToList();
            return View("AddForm", employeeViewModel);
        }

        public IActionResult SaveEmployee(Employee employee)
        {
            companyDbContext.Employees.Add(employee);
            companyDbContext.SaveChanges();
            return RedirectToAction("GoEmployeePage");
        }

        public IActionResult DeleteEmployee(int id)
        {
            var employee = companyDbContext.Employees.FirstOrDefault(s => s.Id == id);
            companyDbContext.Employees.Remove(employee);
            companyDbContext.SaveChanges();
            return RedirectToAction("GoEmployeePage");
        }

        public IActionResult EditEmployee(int id)
        {
            var employee = companyDbContext.Employees.FirstOrDefault(s => s.Id == id);
            ViewData["Departments"] = companyDbContext.Departments.ToList();
            ViewData["Projects"] = companyDbContext.Projects.ToList();
            return View("EditForm",employee);
        }

        public IActionResult SaveUpdatedEmployee(Employee updatedEmployee)
        {
            var employee = companyDbContext.Employees.FirstOrDefault(s => s.Id == updatedEmployee.Id);
            employee.Name = updatedEmployee.Name;
            employee.Age = updatedEmployee.Age;
            employee.Salary = updatedEmployee.Salary;
            employee.Pid = updatedEmployee.Pid;
            employee.Did = updatedEmployee.Did;
            companyDbContext.SaveChanges();
            return RedirectToAction("GoEmployeePage");
        }
    }
}
