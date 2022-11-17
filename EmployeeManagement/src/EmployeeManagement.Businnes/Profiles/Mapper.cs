using AutoMapper;
using EmployeeManagement.Businnes.DTOs.DepartmentDTOs;
using EmployeeManagement.Businnes.DTOs.EmployeeDTOs;
using EmployeeManagement.Data.Entities;

namespace EmployeeManagement.Businnes.Profiles
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Employee, EmployeeGetDto>();
            CreateMap<EmployeeCreateDto, Employee>();

            CreateMap<Department, DepartmentGetDto>();
            CreateMap<DepartmentCreateDto,Department>();
        }
    }
}
