using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.Core.Abstractions.Entities
{
    public interface IEntities
    {
        IRepository<Employee> EmployeeRepository { get; }
        IRepository<Role> RoleRepository { get; }
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Preference> PreferenceRepository { get; }
        IRepository<PromoCode> PromoCodeRepository { get; }

        Task SaveChangesAsync();
    }
}
