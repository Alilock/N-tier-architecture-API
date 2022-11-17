using EmployeeManagement.Businnes.Concrets.UnitOfWork;
using EmployeeManagement.DAL.Abstracts.UnitOfWork;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EmployeeManagement.Businnes
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
