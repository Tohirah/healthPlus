using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Repositories;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Domain.Entities;

namespace HealthPlus.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository _roleRepository;

        public RoleService(IRepository roleRepository) 
        {
            _roleRepository = roleRepository;
        }

        public BaseResponse CreateRole(CreateRoleRequestModel request)
        {
            var role = new Role
            {
                Name = request.Name,
                Description = request.Description
            };
            _roleRepository.Add<Role>(role);
            _roleRepository.SaveChanges();

            return new BaseResponse
            {
                Message = "New Role Created Successfully",
                Status = true
            };
        }
    }
}
