using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.Services.Abstractions;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Entities;
using Otus.Teaching.PromoCodeFactory.Services.Models;

namespace Otus.Teaching.PromoCodeFactory.Services.Implementations
{
    public class PromoCodeService(IEntities entities, IMapper mapper) : IPromoCodeService
    {
        public async Task<List<PromoCodeShortResponse>> GetAsync()
        {
            var result = await entities.PromoCodeRepository.GetAllAsync();
            return mapper.Map<List<PromoCodeShortResponse>>(result);
        }

        public async Task<bool> CreateAsync(GivePromoCodeRequest request)
        {
            var preference = await entities.PreferenceRepository.GetAll()
                .Where(p => p.Name == request.Preference)
                .FirstOrDefaultAsync();

            if (preference == null)
            {
                return false;
            }

            var customers = await entities.CustomerRepository.GetAll()
                .Where(c => c.Preferences.Any(p => p.Id == preference.Id))
                .ToListAsync();

            if (customers.Count == 0)
            {
                return false;
            }

            foreach (var customer in customers)
            {
                await entities.PromoCodeRepository.CreateAsync(new PromoCode
                {
                    Code = request.PromoCode,
                    ServiceInfo = request.ServiceInfo,
                    BeginDate = DateTime.Today,
                    EndDate = DateTime.Today.AddMonths(1),
                    PartnerName = request.PartnerName,
                    Customer = customer,
                    Preference = preference
                });
            }

            await entities.SaveChangesAsync();

            return true;
        }
    }
}
