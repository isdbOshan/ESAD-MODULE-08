using Microsoft.EntityFrameworkCore;
using R52_M8_Class_04_Work_01.Repositories.Interfaces;
using System.Linq.Expressions;

namespace R52_M8_Class_04_Work_01.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class, new()
    {
        private DbContext db = default!;
        private DbSet<T> dbSet = default!;
        public GenericRepo(DbContext db)
        {
            this.db = db;
            this.dbSet = this.db.Set<T>();
        }
        public async Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await this.dbSet.ToListAsync();
        }
        //Wait 

        public async Task<T?> GetAsync(Expression<Func<T, bool>> prdicate)
        {
            return await this.dbSet.FirstOrDefaultAsync(prdicate);
        }

        public async Task InsertAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task InsertRangeAsync(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public async Task UpdateAsync(T entity)
        {
            dbSet.Entry(entity).State= EntityState.Modified;
            await Task.CompletedTask;
        }
    }
}
