using R52_M8_Class_04_Work_01.Models;
using R52_M8_Class_04_Work_01.Repositories.Interfaces;

namespace R52_M8_Class_04_Work_01.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        BrandDbContext db;
        public UnitOfWork(BrandDbContext db)
        {
            this.db = db;
        }
        public async Task CompleteAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.db.Dispose();
        }

        public IGenericRepo<T> GetRepo<T>() where T : class, new()
        {
            return new GenericRepo<T>(db);
        }
    }
}
