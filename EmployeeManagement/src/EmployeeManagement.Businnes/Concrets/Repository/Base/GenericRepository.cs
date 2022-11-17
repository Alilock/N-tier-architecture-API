using EmployeeManagement.DAL.Abstracts.Repository.Base;
using EmployeeManagement.DAL.Context;
using EmployeeManagement.Data.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManagement.Businnes.Concrets.Repository.Base
{

    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        private readonly AppDb _db;
        public GenericRepository(AppDb db)
        {
            _db = db;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _db.Set<TEntity>().ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, params string[] includes)
        {
            IQueryable<TEntity> query = GetQuery(includes);
            return expression is null ? await query.ToListAsync()
                : await query.Where(expression).ToListAsync();
        }

        public async Task<TEntity?> GetAsync(TKey id, params string[] includes)
        {
            IQueryable<TEntity> query = GetQuery(includes);
            return await query.FirstOrDefaultAsync(e => Equals(id, e.Id));
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, params string[] includes)
        {
            IQueryable<TEntity> query = GetQuery(includes);
            return await query.Where(expression).FirstOrDefaultAsync();
        }

        public void Update(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
        }

        // getincludes

        private IQueryable<TEntity> GetQuery(params string[] includes)
        {
            IQueryable<TEntity> query = _db.Set<TEntity>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }
    }
}
