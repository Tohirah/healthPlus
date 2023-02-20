using HealthPlus.Application.DTOs;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IJWTAuthentication
    {
        string GenerateToken(UserResponseModel model);
    }
}
