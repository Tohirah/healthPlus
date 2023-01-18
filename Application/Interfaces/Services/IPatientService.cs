using HealthPlus.Application.DTOs;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IPatientService
    {
        BaseResponse CreatePatient(CreatePatientRequestModel request);
        BaseResponse UpdatePatient();
    }
}
