using AutoMapper;
using Otus.Teaching.PromoCodeFactory.Services.Abstractions;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Entities;
using Otus.Teaching.PromoCodeFactory.Services.Models;

namespace Otus.Teaching.PromoCodeFactory.Services.Implementations
{
    public class PreferenceService(IEntities entities, IMapper mapper) : IPreferenceService
    {
        public async Task<List<PreferenceResponse>> GetAsync()
        {
            var result = await entities.PreferenceRepository.GetAllAsync();
            return mapper.Map<List<PreferenceResponse>>(result);
        }
    }
}
