namespace Electronic_department.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(Electronic_departmentDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
