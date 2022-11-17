using EmployeeManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.DAL.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(64);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(128);
            //migrationda yoxla
            builder.Property(e => e.Age > 18).IsRequired();
            builder.HasOne(e => e.Department)
                .WithMany(e => e.Employees);

        }
    }
}
