using System;
using FluentValidation;

namespace Electronic_department.Application.Electronic_department.Queries.GetElectDetails
{
    public class GetElectDetailsQueryValidator : AbstractValidator<GetElectDetailsQuery>
    {
        public GetElectDetailsQueryValidator()
        {
            RuleFor(elect => elect.Id).NotEqual(Guid.Empty);
            RuleFor(elect => elect.UserId).NotEqual(Guid.Empty);
        }
    }
}
