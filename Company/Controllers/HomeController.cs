using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
        public IActionResult GoDepartmentPage()
        {
            return View("Department");
        }
        public IActionResult GoProjectPage()
        {
            return View("Project");
        }
    }
}
