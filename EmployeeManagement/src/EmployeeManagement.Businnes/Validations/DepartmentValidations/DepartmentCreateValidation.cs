using EmployeeManagement.Businnes.DTOs.DepartmentDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Businnes.Validations.DepartmentValidations
{
    public class DepartmentCreateValidation : AbstractValidator<DepartmentCreateDto>
    {
        public DepartmentCreateValidation()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Department name is required").MaximumLength(64).WithMessage("Department name is too long");
        }
    }
}
