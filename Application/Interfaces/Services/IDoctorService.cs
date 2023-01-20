using HealthPlus.Application.DTOs;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IDoctorService
    {
        BaseResponse CreateDoctor(CreateDoctorRequestModel request);
    }
}
