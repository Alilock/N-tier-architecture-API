using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Businnes.DTOs.EmployeeDTOs
{
    public class EmployeeCreateDto
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int Age { get; set; }
        public string DepartmentId { get; set; } = null!;
    }
}
