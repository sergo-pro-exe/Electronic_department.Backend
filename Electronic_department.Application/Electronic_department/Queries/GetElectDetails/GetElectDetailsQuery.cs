using System;
using MediatR;

namespace Electronic_department.Application.Electronic_department.Queries.GetElectDetails
{
    public class GetElectDetailsQuery : IRequest<ElectDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
