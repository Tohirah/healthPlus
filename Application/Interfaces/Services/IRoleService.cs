using HealthPlus.Application.DTOs;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IRoleService
    {
        BaseResponse CreateRole(CreateRoleRequestModel request);
    }
}
