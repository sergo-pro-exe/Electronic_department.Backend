using System;
using MediatR;

namespace Electronic_department.Application.Electronic_department.Commands.DeleteCommand
{
    public class DeleteElectCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
