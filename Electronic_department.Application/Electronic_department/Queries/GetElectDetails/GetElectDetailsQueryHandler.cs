using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Electronic_department.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Electronic_department.Application.Common.Exceptions;
using Electronic_department.Domain;

namespace Electronic_department.Application.Electronic_department.Queries.GetElectDetails
{
    public class GetElectDetailsQueryHandler
        : IRequestHandler<GetElectDetailsQuery, ElectDetailsVm>
    {
        private readonly IElectronic_departmentDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetElectDetailsQueryHandler(IElectronic_departmentDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ElectDetailsVm> Handle(GetElectDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Electronic_department
                .FirstOrDefaultAsync(elect =>
                elect.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Elect), request.Id);
            }

            return _mapper.Map<ElectDetailsVm>(entity);
        }
    }
}
