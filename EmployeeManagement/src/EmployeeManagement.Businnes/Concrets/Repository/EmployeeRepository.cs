using EmployeeManagement.Businnes.Concrets.Repository.Base;
using EmployeeManagement.DAL.Abstracts.Repository;
using EmployeeManagement.DAL.Context;
using EmployeeManagement.Data.Entities;

namespace EmployeeManagement.Businnes.Concrets.Repository
{
    public class EmployeeRepository : GenericRepository<Employee, string>, IEmployeeRepository
    {
        public EmployeeRepository(AppDb db) : base(db)
        {
        }
    }
}
