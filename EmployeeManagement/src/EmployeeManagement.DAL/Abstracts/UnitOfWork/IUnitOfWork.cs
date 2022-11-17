using EmployeeManagement.DAL.Abstracts.Repository;

namespace EmployeeManagement.DAL.Abstracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
