using System.ComponentModel.DataAnnotations;

namespace Company.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; } = string.Empty;
        [StringLength(20)]
        public string Type { get; set; } = string.Empty;
        public List<Employee>? Employees { get; set; }
    }
}
