using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Electronic_department.Application.Electronic_department.Queries.GetElectList;
using Electronic_department.Persistence;
using Electronic_department.Tests.Common;
using Shouldly;
using Xunit;
using NoteElectronic_department.Application.Electronic_department.Queries.GetElectList;

namespace Electronic_department.Tests.Electronic_department.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteListQueryHandlerTests
    {
        private readonly Electronic_departmentDbContext Context;
        private readonly IMapper Mapper;

        public GetNoteListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetElectListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetElectListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetElectListQuery
                {
                    UserId = Electronic_departmentContextFactory.UserBId
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ElectListVm>();
            result.Electronic_department.Count.ShouldBe(2);
        }
    }
}
