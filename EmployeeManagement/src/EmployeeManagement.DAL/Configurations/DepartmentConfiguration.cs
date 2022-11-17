using EmployeeManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.DAL.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Name).IsRequired().HasMaxLength(64);
            builder.HasMany(d => d.Employees)
                    .WithOne(e => e.Department)
                    .HasForeignKey(e => e.DepartmentId);
        }
    }
}
