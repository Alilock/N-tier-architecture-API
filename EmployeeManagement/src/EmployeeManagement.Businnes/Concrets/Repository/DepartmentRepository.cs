using EmployeeManagement.Businnes.Concrets.Repository.Base;
using EmployeeManagement.DAL.Abstracts.Repository;
using EmployeeManagement.DAL.Context;
using EmployeeManagement.Data.Entities;


namespace EmployeeManagement.Businnes.Concrets.Repository
{
    public class DepartmentRepository : GenericRepository<Department, string>, IDepartmentRepository
    {
        public DepartmentRepository(AppDb db) : base(db)
        {
        }
    }
}
