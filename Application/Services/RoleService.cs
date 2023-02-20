using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Repositories;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Domain.Entities;

namespace HealthPlus.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository _repository;

        public RoleService(IRepository repository)
        {
            _repository = repository;
        }
        public BaseResponse CreateRole(CreateRoleRequestModel request)
        {

            var role = new Role
            {
                Name = request.Name,
                Description = request.Description
            };

            _repository.Add<Role>(role);
            _repository.SaveChanges();

            return new BaseResponse
            {
                Message = "Role created successfully",
                Status = true
            };
        }

        public RoleResponseModel GetRolebyId(int id)
        {
            var role = _repository.Get<Role>(x => x.Id == id);
            return new RoleResponseModel
            {
                Name = role.Name,
                Description = role.Description
            };

        }
    }
}
