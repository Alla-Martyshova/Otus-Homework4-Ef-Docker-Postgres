using Otus.Teaching.PromoCodeFactory.Services.Models;

namespace Otus.Teaching.PromoCodeFactory.Services.Abstractions
{
    public interface IPromoCodeService
    {
        Task<List<PromoCodeShortResponse>> GetAsync();

        Task<bool> CreateAsync(GivePromoCodeRequest request);
    }
}
