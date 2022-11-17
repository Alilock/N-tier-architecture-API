using AutoMapper;
using EmployeeManagement.Businnes.Concrets.UnitOfWork;
using EmployeeManagement.Businnes.DTOs.EmployeeDTOs;
using EmployeeManagement.Businnes.Exceptions;
using EmployeeManagement.Businnes.Services.Abstracts;
using EmployeeManagement.DAL.Abstracts.Repository;
using EmployeeManagement.DAL.Abstracts.UnitOfWork;
using EmployeeManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Businnes.Services.Concrets
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(EmployeeCreateDto entity)
        {
            await _unitOfWork.EmployeeRepository.AddAsync(_mapper.Map<Employee>(entity));
        }

        public async Task DeleteAsync(string id)
        {
            Employee? employee =await _unitOfWork.EmployeeRepository.GetAsync(id);
            if (employee is null) throw new EntityNotFoundException();
            _unitOfWork.EmployeeRepository.Delete(employee);
        }
        public async Task UpdateAsync(string id, EmployeeCreateDto dto)
        {
            Employee? employee =await _unitOfWork.EmployeeRepository.GetAsync(id);
            if (employee is null) throw new EntityNotFoundException();
            
            _unitOfWork.EmployeeRepository.Update(_mapper.Map<Employee>(dto));
        }
        public async Task<IEnumerable<EmployeeGetDto>> GetAllAsync()
        {
            IEnumerable<Employee> employees =await _unitOfWork.EmployeeRepository.GetAllAsync();
            if (employees is null) throw new EntityNotFoundException();
            foreach (var employee in employees)
            {
                _mapper.Map<EmployeeGetDto>(employee);
            }
            return (IEnumerable<EmployeeGetDto>)employees;
        }

        public async Task<EmployeeGetDto> GetAsync(string id)
        {
            Employee? employee = await _unitOfWork.EmployeeRepository.GetAsync(id);
            if (employee is null) throw new EntityNotFoundException("Employee Not Found");
            return _mapper.Map<EmployeeGetDto>(employee);
        }

       
    }
}
