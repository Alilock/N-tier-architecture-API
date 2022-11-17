using EmployeeManagement.Businnes.DTOs.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Businnes.Services.Abstracts
{
    public interface IEmployeeService
    {
        Task<EmployeeGetDto> GetAsync(string id); 
        Task<IEnumerable<EmployeeGetDto>> GetAllAsync();
        Task CreateAsync(EmployeeCreateDto entity);
        Task DeleteAsync(string id);
        Task UpdateAsync(string id,EmployeeCreateDto dto);
    }
}
