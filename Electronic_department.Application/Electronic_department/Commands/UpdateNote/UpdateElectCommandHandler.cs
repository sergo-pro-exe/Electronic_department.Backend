using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Electronic_department.Application.Interfaces;
using Electronic_department.Application.Common.Exceptions;
using Electronic_department.Domain;
using Electronic_department.Application.Electronic_department.Commands.UpdateNote;

namespace Electronic_department.Application.Electronic_department.Commands.UpdateElect
{
    public class UpdateElectCommandHandler
        : IRequestHandler<UpdateElectCommand>
    {
        private readonly IElectronic_departmentDbContext _dbContext;

        public UpdateElectCommandHandler(IElectronic_departmentDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateElectCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Electronic_department.FirstOrDefaultAsync(elect =>
                    elect.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Elect), request.Id);
            }

            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
