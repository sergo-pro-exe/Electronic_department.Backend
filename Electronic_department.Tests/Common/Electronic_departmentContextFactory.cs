using System;
using Microsoft.EntityFrameworkCore;
using Electronic_department.Domain;
using Electronic_department.Persistence;

namespace Electronic_department.Tests.Common
{
    public class Electronic_departmentContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid ElectIdForDelete = Guid.NewGuid();
        public static Guid ElectIdForUpdate = Guid.NewGuid();

        public static Electronic_departmentDbContext Create()
        {
            var options = new DbContextOptionsBuilder<Electronic_departmentDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new Electronic_departmentDbContext(options);
            context.Database.EnsureCreated();
            context.Electronic_department.AddRange(
                new Elect
                {
                    CreationDate = DateTime.Today,
                    Details = "Details1",
                    EditDate = null,
                    Id = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"),
                    Title = "Title1",
                    UserId = UserAId
                },
                new Elect
                {
                    CreationDate = DateTime.Today,
                    Details = "Details2",
                    EditDate = null,
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                    Title = "Title2",
                    UserId = UserBId
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(Electronic_departmentDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
