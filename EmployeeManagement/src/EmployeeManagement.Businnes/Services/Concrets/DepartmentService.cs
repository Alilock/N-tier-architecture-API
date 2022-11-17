using AutoMapper;
using EmployeeManagement.Businnes.DTOs.DepartmentDTOs;
using EmployeeManagement.Businnes.DTOs.EmployeeDTOs;
using EmployeeManagement.Businnes.Exceptions;
using EmployeeManagement.Businnes.Services.Abstracts;
using EmployeeManagement.DAL.Abstracts.UnitOfWork;
using EmployeeManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Businnes.Services.Concrets
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(DepartmentCreateDto entity)
        {
            await _unitOfWork.EmployeeRepository.AddAsync(_mapper.Map<Employee>(entity));
        }

        public async Task DeleteAsync(string id)
        {
            Department? department = await _unitOfWork.DepartmentRepository.GetAsync(id);
            if (department is null) throw new EntityNotFoundException();
            _unitOfWork.DepartmentRepository.Delete(department);
        }
        public async Task UpdateAsync(string id, DepartmentCreateDto dto)
        {
            Department? department = await _unitOfWork.DepartmentRepository.GetAsync(id);
            if (department is null) throw new EntityNotFoundException();

            _unitOfWork.DepartmentRepository.Update(_mapper.Map<Department>(dto));
        }
        public async Task<IEnumerable<DepartmentGetDto>> GetAllAsync()
        {
            IEnumerable<Department> departments = await _unitOfWork.DepartmentRepository.GetAllAsync();
            if (departments is null) throw new EntityNotFoundException();
            foreach (var department in departments)
            {
                _mapper.Map<DepartmentGetDto>(department);
            }
            return (IEnumerable<DepartmentGetDto>)departments;
        }

        public async Task<DepartmentGetDto> GetAsync(string id)
        {
            Department? department = await _unitOfWork.DepartmentRepository.GetAsync(id);
            if (department is null) throw new EntityNotFoundException("Employee Not Found");
            return _mapper.Map<DepartmentGetDto>(department);
        }


    }
}
