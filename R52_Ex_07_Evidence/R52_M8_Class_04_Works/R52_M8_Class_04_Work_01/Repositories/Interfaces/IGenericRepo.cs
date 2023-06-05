using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace R52_M8_Class_04_Work_01.Repositories.Interfaces
{
    public interface IGenericRepo<T> where T:class, new()
    {
        Task<IEnumerable<T>> GetAsync( );
        Task<T?> GetAsync(Expression<Func<T, bool>> prdicate);
        Task InsertAsync(T entity);
        Task InsertRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}
