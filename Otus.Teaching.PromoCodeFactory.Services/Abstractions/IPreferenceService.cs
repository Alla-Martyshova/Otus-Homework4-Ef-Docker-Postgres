using Otus.Teaching.PromoCodeFactory.Services.Models;

namespace Otus.Teaching.PromoCodeFactory.Services.Abstractions
{
    public interface IPreferenceService
    {
        Task<List<PreferenceResponse>> GetAsync();
    }
}
