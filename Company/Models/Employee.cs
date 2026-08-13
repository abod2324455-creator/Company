using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; } = string.Empty;
        public int Salary { get; set; }
        public int Age { get; set; }
        [ForeignKey("Department")]
        public int Did { get; set; }
        [ForeignKey("Project")]
        public int Pid { get; set; }
        public Department? Department { get; set; }
        public Project? Project { get; set; }
    }
}
