using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Entities;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Entities
{
    public class EntitiesDb (IRepository<Employee> employeeRepository,
                            IRepository<Role> roleRepository,
                            IRepository<Customer> customerRepository,
                            IRepository<Preference> preferenceRepository,
                            IRepository<PromoCode> promoCodeRepository,
                            ApplicationDbContext dbContext) : IEntities
    {
        public IRepository<Employee> EmployeeRepository { get; } = employeeRepository;
        public IRepository<Role> RoleRepository { get; } = roleRepository;
        public IRepository<Customer> CustomerRepository { get; } = customerRepository;
        public IRepository<Preference> PreferenceRepository { get; } = preferenceRepository;
        public IRepository<PromoCode> PromoCodeRepository { get; } = promoCodeRepository;

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
