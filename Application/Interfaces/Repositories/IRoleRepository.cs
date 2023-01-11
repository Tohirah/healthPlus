using HealthPlus.Domain.Entities;

namespace HealthPlus.Application.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Role Add(Role role);
        void Delete(Role role);
        Role Get(int id);
        Role Update (Role role);
        IList<Role> GetAll();
    }
}
