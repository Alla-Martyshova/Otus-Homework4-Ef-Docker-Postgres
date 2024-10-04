using Microsoft.EntityFrameworkCore;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext Context;
        private readonly DbSet<T> _entitySet;

        public EfRepository(ApplicationDbContext context)
        {
            Context = context;
            _entitySet = Context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _entitySet;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entitySet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _entitySet.FindAsync(id);
        }

        public async Task<Guid> CreateAsync(T model)
        {
            return (await _entitySet.AddAsync(model)).Entity.Id;
        }

        public async void Update(T model)
        {
            _entitySet.Update(model);
        }

        public async void Delete(T model) 
        {
            _entitySet.Remove(model);
        }
    }
}
