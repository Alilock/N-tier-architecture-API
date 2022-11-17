using EmployeeManagement.Businnes.Concrets.Repository;
using EmployeeManagement.DAL.Abstracts.Repository;
using EmployeeManagement.DAL.Abstracts.UnitOfWork;
using EmployeeManagement.DAL.Context;


namespace EmployeeManagement.Businnes.Concrets.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDb _dbContext;

        public UnitOfWork(AppDb dbContext)
        {
            _dbContext = dbContext;
        }
        private IEmployeeRepository? _employeeRepository;
        private IDepartmentRepository? _departmentRepository;
        public IEmployeeRepository EmployeeRepository => _employeeRepository ??= new EmployeeRepository(_dbContext);
        public IDepartmentRepository DepartmentRepository => _departmentRepository ??= new DepartmentRepository(_dbContext);


        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
