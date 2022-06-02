using AutoMapper;
using System;
using Electronic_department.Application.Interfaces;
using Electronic_department.Application.Common.Mappings;
using Electronic_department.Persistence;
using Xunit;

namespace Electronic_department.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public Electronic_departmentDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = Electronic_departmentContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IElectronic_departmentDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            Electronic_departmentContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
