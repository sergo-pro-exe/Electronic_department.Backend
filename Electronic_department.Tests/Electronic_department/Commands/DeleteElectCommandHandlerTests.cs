using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Electronic_department.Application.Common.Exceptions;
using Electronic_department.Application.Electronic_department.Commands.CreateNote;
using Electronic_department.Application.Electronic_department.Commands.DeleteCommand;
using Electronic_department.Tests.Common;
using Xunit;

namespace Electronic_department.Tests.Electronic_department.Commands
{
    public class DeleteElectCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteElectCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteElectCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteElectCommand
            {
                Id = Electronic_departmentContextFactory.ElectIdForDelete,
                UserId = Electronic_departmentContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Electronic_department.SingleOrDefault(elect =>
                elect.Id == Electronic_departmentContextFactory.ElectIdForDelete));
        }

        [Fact]
        public async Task DeleteElectCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteElectCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteElectCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = Electronic_departmentContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeleteElectCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var deleteHandler = new DeleteElectCommandHandler(Context);
            var createHandler = new CreateNoteCommandHandler(Context);
            var electId = await createHandler.Handle(
                new CreateNoteCommand
                {
                    Title = "ElectTitle",
                    UserId = Electronic_departmentContextFactory.UserAId
                }, CancellationToken.None);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteElectCommand
                    {
                        Id = electId,
                        UserId = Electronic_departmentContextFactory.UserBId
                    }, CancellationToken.None));
        }
    }
}
