using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using Electronic_department.Application.Electronic_department.Queries.GetElectDetails;
using Electronic_department.Persistence;
using Electronic_department.Tests.Common;
using Shouldly;
using Xunit;

namespace Electronic_department.Tests.Electronic_department.Queries
{
    [Collection("QueryCollection")]
    public class GetElectDetailsQueryHandlerTests
    {
        private readonly Electronic_departmentDbContext Context;
        private readonly IMapper Mapper;

        public GetElectDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetElectDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetElectDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetElectDetailsQuery
                {
                    UserId = Electronic_departmentContextFactory.UserBId,
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ElectDetailsVm>();
            result.Title.ShouldBe("Title2");
            result.CreationDate.ShouldBe(DateTime.Today);
        }
    }
}
