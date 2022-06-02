using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Electronic_department.Application.Common.Exceptions;
using Electronic_department.Application.Electronic_department.Commands.UpdateNote;
using Electronic_department.Tests.Common;
using Xunit;
using Electronic_department.Application.Electronic_department.Commands.UpdateElect;

namespace Electronic_department.Tests.Electronic_department.Commands
{
    public class UpdateElectCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateElectCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateElectCommandHandler(Context);
            var updatedTitle = "new title";

            // Act
            await handler.Handle(new UpdateElectCommand
            {
                Id = Electronic_departmentContextFactory.ElectIdForUpdate,
                UserId = Electronic_departmentContextFactory.UserBId,
                Title = updatedTitle
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Electronic_department.SingleOrDefaultAsync(elect =>
                elect.Id == Electronic_departmentContextFactory.ElectIdForUpdate &&
                elect.Title == updatedTitle));
        }

        [Fact]
        public async Task UpdateElectCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateElectCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateElectCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = Electronic_departmentContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateElectCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateElectCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateElectCommand
                    {
                        Id = Electronic_departmentContextFactory.ElectIdForUpdate,
                        UserId = Electronic_departmentContextFactory.UserAId
                    },
                    CancellationToken.None);
            });
        }
    }
}
