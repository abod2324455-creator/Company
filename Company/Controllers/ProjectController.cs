using Company.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    public class ProjectController : Controller
    {
        CompanyDbContext companyDbContext = new CompanyDbContext();
        public IActionResult GoProjectPage()
        {
            List<Project> projects = companyDbContext.Projects.ToList();
            return View("Project", projects);
        }

        public IActionResult AddProject()
        {
            return View("AddForm");
        }

        public IActionResult SaveProject(Project project)
        {
            companyDbContext.Projects.Add(project);
            companyDbContext.SaveChanges();
            return RedirectToAction("GoProjectPage");
        }

        public IActionResult DeleteProject(int id)
        {
            var project = companyDbContext.Projects.FirstOrDefault(s => s.Id == id);
            companyDbContext.Projects.Remove(project);
            companyDbContext.SaveChanges();
            return RedirectToAction("GoProjectPage");
        }

        public IActionResult EditProject(int id)
        {
            var project = companyDbContext.Projects.FirstOrDefault(s => s.Id == id);
            return View("EditForm", project);
        }

        public IActionResult SaveUpdatedProject(Project updatedProject)
        {
            var project = companyDbContext.Projects.FirstOrDefault(s => s.Id == updatedProject.Id);
            project.Name = updatedProject.Name;
            project.Type = updatedProject.Type;
            companyDbContext.SaveChanges();
            return RedirectToAction("GoProjectPage");
        }

        public IActionResult ShowEmployees(int id)
        {
            ViewData["Employees"] = companyDbContext.Employees.ToList();
            ViewData["Departments"] = companyDbContext.Departments.ToList();
            var project = companyDbContext.Projects.FirstOrDefault(s => s.Id == id);
            return View("EmployeesInProject", project);
        }
    }
}
