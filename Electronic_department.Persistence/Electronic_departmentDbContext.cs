using Electronic_department.Application.Interfaces;
using Electronic_department.Domain;
using Electronic_department.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Electronic_department.Persistence
{
    public class Electronic_departmentDbContext : DbContext, IElectronic_departmentDbContext
    {
        public DbSet<Elect> Electronic_department { get; set; }

        public Electronic_departmentDbContext(DbContextOptions<Electronic_departmentDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ElectConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
