using System.Linq.Expressions;

namespace HealthPlus.Application.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Delete(T entity);
        T Update(T entity);
        T Get(Expression<Func<T, bool>> expression;
        IList<T> GetAll(Expression<Func<T, bool>> expression = null);
        int SaveChanges();
    }
}
