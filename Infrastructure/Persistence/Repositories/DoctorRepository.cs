using HealthPlus.Domain.Entities;
using HealthPlus.Infrastructure.Perisstence.Repositories;
using HealthPlus.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HealthPlus.Infrastructure.Persistence.Repositories
{
    public class DoctorRepository : BaseRepository
    {
        private readonly HealthPlusContext _context;
        public DoctorRepository(HealthPlusContext context) : base(context)
        {
        }

        public Doctor GetDoctorbyId(Expression<Func<Doctor, bool>> expression)
        {
            return  _context.Doctors.Include(x => x.User).SingleOrDefault(expression);
        }

        public IList<Doctor> GetAllDoctors(Expression<Func<Doctor, bool>> expression = null)
        {
            return _context.Doctors.Include(x => x.User).ToList();
        }
    }
}
