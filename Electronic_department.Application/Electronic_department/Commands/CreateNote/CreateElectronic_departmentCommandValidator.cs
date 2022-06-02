using System;
using Electronic_department.Application.Electronic_department.Commands.CreateNote;
using FluentValidation;

namespace Electronic_department.Application.Electronic_department.Commands.CreateElectronic_department
{
    public class CreateElectCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateElectCommandValidator()
        {
            RuleFor(createElectCommand =>
                createElectCommand.Title).NotEmpty().MaximumLength(25);
            RuleFor(createElectCommand =>
                createElectCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
