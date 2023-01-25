using HealthPlus.Application.DTOs;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IServiceService
    {
        BaseResponse CreateService(CreateServiceRequestModel request);
        BaseResponse UpdateService(UpdateServiceRequestModel request);
    }
}
