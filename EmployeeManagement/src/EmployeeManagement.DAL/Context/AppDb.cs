using EmployeeManagement.Data.Base;
using EmployeeManagement.Data.Entities;
using EmployeeManagement.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace EmployeeManagement.DAL.Context
{
    public class AppDb : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDb(DbContextOptions<AppDb> opt) : base(opt) { }
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<EntityEntry<BaseEntity>> entities = ChangeTracker.Entries<BaseEntity>();
            foreach (EntityEntry<BaseEntity> entity in entities)
            {
                if (entity.State == EntityState.Deleted)
                {
                    entity.Entity.IsDeleted = true;

                }
            }
            IEnumerable<EntityEntry<BaseAuditable>> enityAuditables = ChangeTracker.Entries<BaseAuditable>();
            foreach (EntityEntry<BaseAuditable> entity2 in enityAuditables)
            {
                if (entity2.State == EntityState.Deleted)
                {
                    entity2.Entity.IsDeleted = true;
                }
                else if (entity2.State == EntityState.Modified)
                {
                    entity2.Entity.ModifiedAt = DateTime.Now;
                }
            }


            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
