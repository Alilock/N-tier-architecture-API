using EmployeeManagement.Data.Base;
using System.Linq.Expressions;

namespace EmployeeManagement.DAL.Abstracts.Repository.Base
{
    public interface IGenericRepository<TEntity, TKEy> where TEntity : BaseEntity<TKEy>
    {
        Task<TEntity?> GetAsync(TKEy id, params string[] includes);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, params string[] includes);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, params string[] includes);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
