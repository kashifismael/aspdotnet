using AspDotNetStarter.Domain;
using AspDotNetStarter.Exception;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetStarter.Services
{
    public abstract class AbstractCrudServiceImpl<T> : ICrudService<T> where T : DatabaseEntity
    {
        private readonly DbContext _dbContext;

        protected AbstractCrudServiceImpl(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T create(T t)
        {
            if (t.Id == null)
                t.Id = Guid.NewGuid().ToString();

            return createAsync(t).Result;
        }

        private async Task<T> createAsync(T t)
        {
            await _dbContext.AddAsync(t);
            await _dbContext.SaveChangesAsync();
            return t;
        }

        public bool delete(string id)
        {
            deleteAsync(id);
            return true;
        }

        private async void deleteAsync(string id)
        {
            T t = await getOneByIdAsync(id);
            _dbContext.Remove(t);
            await _dbContext.SaveChangesAsync();
        }

        public List<T> GetAll()
        {
            return getAllAsync().Result;
        }

        private async Task<List<T>> getAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public T getOneById(string id)
        {
            return getOneByIdAsync(id).Result;
        }

        private async Task<T> getOneByIdAsync(string id)
        {
            T t = await _dbContext.FindAsync<T>(id);

            if (t != null)
                return t;

            NotFoundException ex = new NotFoundException($"{t.GetType()} with id [{id}] not found");
            throw ex;
        }

        public T update(T t)
        {
            delete(t.Id);
            create(t);
            return t;
        }
    }
}
