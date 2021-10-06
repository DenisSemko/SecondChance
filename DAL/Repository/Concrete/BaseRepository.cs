using DAL.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Concrete
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        public DatabaseContext databaseContext;

        public BaseRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Save()
        {
            databaseContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> Get()
        {
            return await databaseContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await databaseContext.Set<T>().FindAsync(id);
        }

        public async Task<T> Add(T entity)
        {
            await databaseContext.Set<T>().AddAsync(entity);
            await databaseContext.SaveChangesAsync();
            Save();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            databaseContext.Set<T>().Update(entity);
            await databaseContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteById(Guid id)
        {
            T entity = databaseContext.Set<T>().Find(id);
            databaseContext.Set<T>().Remove(entity);
            await databaseContext.SaveChangesAsync();
            return entity;
        }


    }
}
