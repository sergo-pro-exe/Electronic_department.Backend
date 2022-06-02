using Electronic_department.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Electronic_department.Application.Interfaces
{
    public interface IElectronic_departmentDbContext
    {
        DbSet<Elect> Electronic_department { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
