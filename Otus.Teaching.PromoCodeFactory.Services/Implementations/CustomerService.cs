using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Otus.Teaching.PromoCodeFactory.Services.Abstractions;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Entities;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.Services.Models;

namespace Otus.Teaching.PromoCodeFactory.Services.Implementations
{
    public class CustomerService(IEntities entities, IMapper mapper) : ICustomerService
    {
        public async Task<List<CustomerShortResponse>> GetAsync()
        {
            var result = await entities.CustomerRepository.GetAllAsync();
            return mapper.Map<List<CustomerShortResponse>>(result);
        }

        public async Task<CustomerResponse?> GetByIdAsync(Guid id)
        {
            var result = await entities.CustomerRepository
                .GetAll()
                .Include(c => c.PromoCodes)
                .Include(c => c.Preferences)
                .FirstOrDefaultAsync(c => c.Id == id);

            return mapper.Map<CustomerResponse>(result);
        }

        public async Task<Guid> CreateAsync(CreateOrEditCustomerRequest request)
        {
            var customer = mapper.Map<Customer>(request);
            customer.Preferences = await entities.PreferenceRepository.GetAll()
                .Where(p => request.PreferenceIds.Contains(p.Id))
                .ToListAsync();

            var id = await entities.CustomerRepository.CreateAsync(customer);
            await entities.SaveChangesAsync();

            return id;
        }

        public async Task<bool> UpdateByIdAsync(Guid id, CreateOrEditCustomerRequest request)
        {
            var customer = await entities.CustomerRepository
                .GetAll()
                .Include(c => c.PromoCodes)
                .Include(c => c.Preferences)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                return false;
            }

            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.Email = request.Email;
            customer.Preferences = await entities.PreferenceRepository.GetAll()
                .Where(p => request.PreferenceIds.Contains(p.Id))
                .ToListAsync();

            entities.CustomerRepository.Update(customer);
            await entities.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var customer = await entities.CustomerRepository
                .GetAll()
                .Include(c => c.PromoCodes)
                .Include(c => c.Preferences)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                return false;
            }

            entities.CustomerRepository.Delete(customer);
            await entities.SaveChangesAsync();

            return true;
        }
    }
}
