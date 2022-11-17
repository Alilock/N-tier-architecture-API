using EmployeeManagement.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DAL
{
    public static class ConfigureService
    {
        public static IServiceCollection AddDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDb>(opt => opt.UseNpgsql(configuration.GetConnectionString("PostgreSql")));
            return services;    
        }
    }
}
