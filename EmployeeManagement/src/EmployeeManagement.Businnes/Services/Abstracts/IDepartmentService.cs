using EmployeeManagement.Businnes.DTOs.DepartmentDTOs;
using EmployeeManagement.Businnes.DTOs.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Businnes.Services.Abstracts
{
    public interface IDepartmentService
    {
        Task<DepartmentGetDto> GetAsync(string id);
        Task<IEnumerable<DepartmentGetDto>> GetAllAsync();
        Task CreateAsync(DepartmentCreateDto entity);
        Task DeleteAsync(string id);
        Task UpdateAsync(string id, DepartmentCreateDto dto);
    }
}
