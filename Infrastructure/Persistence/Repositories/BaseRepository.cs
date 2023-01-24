using HealthPlus.Application.Interfaces.Repositories;
using HealthPlus.Domain.Entities;
using HealthPlus.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HealthPlus.Infrastructure.Perisstence.Repositories
{
    public class BaseRepository : IRepository
    {
        private readonly HealthPlusContext _context;

        public BaseRepository (HealthPlusContext context)
        {
            _context = context;
        }
        public T Add<T> (T entity) where T : class, new()
        {
            _context.Set<T>().Add(entity);
            return entity;
        }
       
        public T Delete<T> (T entity) where T : class, new()
        {
            _context.Set<T>().Remove(entity);
            return entity;
        }
        public T Get<T> (Expression<Func<T, bool>> expression) where T : class, new()
        {
            return _context.Set<T>().SingleOrDefault(expression);
        }

        public IList<T> GetAll<T> (Expression<Func<T, bool>>? expression = null) where T : class, new()
        {
            return _context.Set<T>().ToList();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public T Update<T> (T entity) where T : class, new()
        {
            _context.Set<T>().Update(entity);
            return entity;
        }

        public Patient GetPatient(Expression<Func<Patient, bool>> expression)
        {
            return _context.Patients.Include(x => x.User).SingleOrDefault(expression);
        }

        public IList<Patient> GetAllPatient(Expression<Func<Patient, bool>> expression = null)
        {
            return _context.Patients.Include(x => x.User).ToList();
        }

    }
}
