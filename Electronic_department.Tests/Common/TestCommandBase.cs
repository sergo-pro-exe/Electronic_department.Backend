using System;
using Electronic_department.Persistence;

namespace Electronic_department.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly Electronic_departmentDbContext Context;

        public TestCommandBase()
        {
            Context = Electronic_departmentContextFactory.Create();
        }

        public void Dispose()
        {
            Electronic_departmentContextFactory.Destroy(Context);
        }
    }
}
