using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Otus.Teaching.PromoCodeFactory.Services.Abstractions;
using Otus.Teaching.PromoCodeFactory.Services.Implementations;

namespace Otus.Teaching.PromoCodeFactory.Services.Utils
{
    public static class AppDbServiceHelper
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile<MapperProfile>(); });

            var mapper = mappingConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);

            serviceCollection.AddScoped<ICustomerService, CustomerService>();
            serviceCollection.AddScoped<IPreferenceService, PreferenceService>();
            serviceCollection.AddScoped<IPromoCodeService, PromoCodeService>();

            return serviceCollection;
        }
    }
}
