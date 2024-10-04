using Otus.Teaching.PromoCodeFactory.Services.Models;

namespace Otus.Teaching.PromoCodeFactory.Services.Abstractions
{
    public interface ICustomerService
    {
        Task<List<CustomerShortResponse>> GetAsync();

        Task<CustomerResponse?> GetByIdAsync(Guid id);

        Task<Guid> CreateAsync(CreateOrEditCustomerRequest request);

        Task<bool> UpdateByIdAsync(Guid id, CreateOrEditCustomerRequest request);

        Task<bool> DeleteByIdAsync(Guid id);
    }
}
