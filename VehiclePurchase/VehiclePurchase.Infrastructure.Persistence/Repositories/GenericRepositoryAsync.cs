using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VehiclePurchase.Application.Repositories.GenericRepository;
using VehiclePurchase.Infrastructure.Persistence.Contexts;

namespace VehiclePurchase.Infrastructure.Persistence.Repository
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _dbContext
                .Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }




        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext
                 .Set<T>()
                 .ToListAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext
                 .Set<T>();
        }
        public virtual Task<bool> ExistAsync(Expression<Func<T, bool>> predicate)
        {
            return GetAll().AnyAsync(predicate);
        }
        public virtual int Count()
        {
            return GetAll().Count();
        }

        public virtual Task<int> CountAsync()
        {
            return Task.FromResult(Count());
        }

        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate).Count();
        }

        public virtual Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return Task.FromResult(Count(predicate));
        }


        public virtual IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] propertySelectors)
        {
            return GetAll();
        }

        public virtual List<T> GetAllList(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }

        public virtual Task<List<T>> GetAllListAsync(Expression<Func<T, bool>> predicate)
        {
            return Task.FromResult(GetAllList(predicate));
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }
        public virtual T LastOrDefault(Expression<Func<T, bool>> predicate)
        {
            return GetAll().LastOrDefault(predicate);
        }

        public virtual Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return Task.FromResult(FirstOrDefault(predicate));
        }
        public virtual Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return Task.FromResult(LastOrDefault(predicate));
        }
    }
}
