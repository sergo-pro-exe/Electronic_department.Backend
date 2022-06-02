using System;
using Electronic_department.Application.Electronic_department.Commands.UpdateNote;
using FluentValidation;

namespace Electronic_department.Application.Electronic_department.Commands.UpdateElect
{
    public class UpdateElectCommandValidator : AbstractValidator<UpdateElectCommand>
    {
        public UpdateElectCommandValidator()
        {
            RuleFor(updateElectCommand => updateElectCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateElectCommand => updateElectCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateElectCommand => updateElectCommand.Title)
                .NotEmpty().MaximumLength(25);
        }
    }
}
