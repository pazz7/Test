using System.ComponentModel.DataAnnotations;

namespace Test.Application.Employees.Models
{
    public class EmployeeUpdateModel
    {
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}