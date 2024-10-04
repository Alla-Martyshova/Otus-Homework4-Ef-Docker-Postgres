using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Entities;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Repositories;
using Otus.Teaching.PromoCodeFactory.DataAccess.Entities;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Utils
{
    public static class AppDbHelper
    {
        public static IServiceCollection AddApplicationDatabase(this IServiceCollection serviceCollection,
        IConfiguration configuration)
        {
            var connectionStringPG = configuration.GetValue<string>("ConnectionStrings:HW4PG");

            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(connectionStringPG));

            serviceCollection.AddScoped<IRepository<Employee>, EfRepository<Employee>>()
                .AddScoped<IRepository<Role>, EfRepository<Role>>()
                .AddScoped<IRepository<Customer>, EfRepository<Customer>>()
                .AddScoped<IRepository<Preference>, EfRepository<Preference>>()
                .AddScoped<IRepository<PromoCode>, EfRepository<PromoCode>>();

            serviceCollection.AddScoped<IEntities, EntitiesDb>();

            serviceCollection.AddScoped<IDbInitializer, DbInitializer>();

            return serviceCollection;
        }
    }
}
