using System;
using System.Threading;
using System.Threading.Tasks;
using Electronic_department.Application.Interfaces;
using Electronic_department.Domain;
using MediatR;

namespace Electronic_department.Application.Electronic_department.Commands.CreateNote
{
    public class CreateNoteCommandHandler
        :IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly IElectronic_departmentDbContext _dbContext;

        public CreateNoteCommandHandler(IElectronic_departmentDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateNoteCommand request,
            CancellationToken cancellationToken)
        {
            var elect = new Elect
            {
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };

            await _dbContext.Electronic_department.AddAsync(elect, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return elect.Id;
        }
    }
}
