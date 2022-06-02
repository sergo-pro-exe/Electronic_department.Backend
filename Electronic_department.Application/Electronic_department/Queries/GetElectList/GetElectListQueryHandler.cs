using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Electronic_department.Application.Interfaces;
using NoteElectronic_department.Application.Electronic_department.Queries.GetElectList;

namespace Electronic_department.Application.Electronic_department.Queries.GetElectList
{
    public class GetElectListQueryHandler
        : IRequestHandler<GetElectListQuery, ElectListVm>
    {
        private readonly IElectronic_departmentDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetElectListQueryHandler(IElectronic_departmentDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ElectListVm> Handle(GetElectListQuery request,
            CancellationToken cancellationToken)
        {
            var electronic_departmentQuery = await _dbContext.Electronic_department
                .Where(elect => elect.UserId == request.UserId)
                .ProjectTo<ElectLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ElectListVm { Electronic_department = electronic_departmentQuery };
        }
    }
}
