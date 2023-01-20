using HealthPlus.Application.DTOs;
using System.Linq.Expressions;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IUserService
    {
        BaseResponse CreateRole(CreateRoleRequestModel request);
        RoleResponseModel GetRoleById(int id);
        IList<RoleResponseModel> GetRoles();
        RoleResponseModel GetRoleByName(string name);
        public UserResponseModel GetUserById(int id);
        public UserResponseModel GetUserByUsername(string name);
        public IList<UserResponseModel> GetUsers();
    }
}
