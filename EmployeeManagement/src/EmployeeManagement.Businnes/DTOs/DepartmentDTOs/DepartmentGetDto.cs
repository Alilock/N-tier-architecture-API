using EmployeeManagement.Businnes.DTOs.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Businnes.DTOs.DepartmentDTOs
{
    public class DepartmentGetDto
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public ICollection<EmployeeGetDto>? Employees;

    }
}
