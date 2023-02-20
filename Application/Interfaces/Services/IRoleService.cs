using HealthPlus.Application.DTOs;
using System.Linq.Expressions;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IRoleService
    {
        BaseResponse CreateRole(CreateRoleRequestModel request);
        RoleResponseModel GetRolebyId (int id);
    }
}
