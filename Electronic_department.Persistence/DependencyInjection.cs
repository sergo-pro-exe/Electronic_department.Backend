using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Electronic_department.Application.Interfaces;

namespace Electronic_department.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<Electronic_departmentDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IElectronic_departmentDbContext>(provider =>
                provider.GetService<Electronic_departmentDbContext>());
            return services;
        }
    }
}
