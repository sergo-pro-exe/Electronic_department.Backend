using System;

namespace Electronic_department.Application.Interfaces
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
    }
}
