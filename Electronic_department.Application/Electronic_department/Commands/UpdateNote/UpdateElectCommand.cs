using System;
using MediatR;

namespace Electronic_department.Application.Electronic_department.Commands.UpdateNote
{
    public class UpdateElectCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}
