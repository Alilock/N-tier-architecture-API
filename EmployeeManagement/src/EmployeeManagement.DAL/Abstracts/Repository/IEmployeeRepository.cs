using EmployeeManagement.DAL.Abstracts.Repository.Base;
using EmployeeManagement.Data.Entities;

namespace EmployeeManagement.DAL.Abstracts.Repository
{
    public interface IEmployeeRepository : IGenericRepository<Employee, string>
    {
    }
}
