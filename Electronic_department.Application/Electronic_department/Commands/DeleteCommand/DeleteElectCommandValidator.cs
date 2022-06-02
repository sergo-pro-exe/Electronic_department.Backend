using System;
using FluentValidation;

namespace Electronic_department.Application.Electronic_department.Commands.DeleteCommand
{
    public class DeleteElectCommandValidator : AbstractValidator<DeleteElectCommand>
    {
        public DeleteElectCommandValidator()
        {
            RuleFor(deleteElectCommand => deleteElectCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteElectCommand => deleteElectCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
