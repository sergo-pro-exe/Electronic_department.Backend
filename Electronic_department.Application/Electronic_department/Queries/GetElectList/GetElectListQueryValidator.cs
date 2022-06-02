using System;
using FluentValidation;

namespace Electronic_department.Application.Electronic_department.Queries.GetElectList
{
    public class GetElectListQueryValidator : AbstractValidator<GetElectListQuery>
    {
        public GetElectListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
