using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Otus.Teaching.PromoCodeFactory.Core.Domain;

namespace Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories
{
    public interface IRepository<T>
        where T: BaseEntity
    {
        IQueryable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        
        Task<T> GetByIdAsync(Guid id);

        Task<Guid> CreateAsync(T model);

        void Update(T model);

        void Delete(T model);
    }
}