using EmployeeManagement.DAL.Abstracts.Repository.Base;
using EmployeeManagement.Data.Entities;


namespace EmployeeManagement.DAL.Abstracts.Repository
{
    public interface IDepartmentRepository : IGenericRepository<Department, string>
    {
    }
}
