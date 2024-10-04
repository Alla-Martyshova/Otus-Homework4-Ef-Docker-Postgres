using Microsoft.EntityFrameworkCore;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;
using System.Linq;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Utils
{
    public class DbInitializer(ApplicationDbContext context) : IDbInitializer
    {
        public void DbReCreate()
        {
            var isDbNotCreated = !context.Database.CanConnect();
            if (isDbNotCreated)
            {
                context.Database.EnsureCreated();
                FillFakeData();
            }                     
        }

        public void DbMigrate()
        {
            var isDbNotCreated = !context.Database.CanConnect();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (isDbNotCreated)
                FillFakeData();
        }

        public void FillFakeData()
        {
            context.AddRange(FakeDataFactory.Roles);

            context.AddRange(FakeDataFactory.Employees.Select(e =>
            {
                e.Role = context.Roles.Find(e.Role.Id);
                return e;
            }
            ));

            context.AddRange(FakeDataFactory.Preferences);

            context.AddRange(FakeDataFactory.Customers.Select(c =>
            {
                c.Preferences = c.Preferences.Select(p =>
                    context.Preferences.Find(p.Id)
                ).ToList();
                return c;
            }
            ));
            context.SaveChanges();
        }
    }
}
