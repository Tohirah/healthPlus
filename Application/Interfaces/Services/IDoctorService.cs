using HealthPlus.Application.DTOs;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IDoctorService
    {
        BaseResponse CreateDoctor(CreateDoctorRequestModel request);
        DoctorResponseModel GetDoctorById(int id);
        DoctorResponseModel GetDoctorByDoctorNumber(string doctorNumber);
        BaseResponse UpdateDoctor(UpdateDoctorRequestModel request);
        //public IList<DoctorResponseModel> GetDoctors()
    }
}
