using Company.Models;
namespace Company.ViewModel
{
    public class EmployeeViewModel
    {
        public List<Project> projects { get; set; } = new List<Project>();
        public List<Employee> employees { get; set; } = new List<Employee>();
        public List<Department> departments { get; set; } = new List<Department>();
    }
}
