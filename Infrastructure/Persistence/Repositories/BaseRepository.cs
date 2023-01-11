using HealthPlus.Application.Interfaces.Repositories;
using HealthPlus.Infrastructure.Persistence.Context;
using System.Linq.Expressions;

namespace HealthPlus.Infrastructure.Perisstence.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, new()
    {
        private readonly HealthPlusContext _context;

        public BaseRepository (HealthPlusContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }
        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return entity;
        }
        public T Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().SingleOrDefault(expression);
        }

        public IList<T> GetAll(Expression<Func<T, bool>>? expression = null)
        {
            return _context.Set<T>().ToList();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }
    }
}
