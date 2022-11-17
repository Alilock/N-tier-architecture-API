using EmployeeManagement.Businnes.DTOs.EmployeeDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Businnes.Validations.EmployeeValidations
{
    public class EmployeeCreateValidation : AbstractValidator<EmployeeCreateDto>
    {
        public EmployeeCreateValidation()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("Name is required").NotNull().MaximumLength(64).WithMessage("Name is too long");
            RuleFor(e => e.Surname).NotEmpty().WithMessage("Surname is required").MaximumLength(128).WithMessage("Surname is too long");
            RuleFor(e => e.Age).GreaterThanOrEqualTo(18);
        }
    }
}
