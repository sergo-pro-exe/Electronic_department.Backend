using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Electronic_department.Application.Interfaces;
using Electronic_department.Application.Common.Exceptions;
using Electronic_department.Domain;

namespace Electronic_department.Application.Electronic_department.Commands.DeleteCommand
{
    public class DeleteElectCommandHandler
        : IRequestHandler<DeleteElectCommand>
    {
        private readonly IElectronic_departmentDbContext _dbContext;

        public DeleteElectCommandHandler(IElectronic_departmentDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteElectCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Electronic_department
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Elect), request.Id);
            }

            _dbContext.Electronic_department.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
