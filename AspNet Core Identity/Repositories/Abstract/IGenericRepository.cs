using System.Linq.Expressions;

namespace AspNet_Core_Identity.Repositories.Abstract
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);

        T? FindById(int id);

        bool Create (T entity);

        bool Update (T entity);

        bool Delete (T entity);
    }
}
